using Scan_Box.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scan_Box
{
    public partial class MappingExecutionForm : Form
    {
        private string sourceConnectionString;
        private string sourceTableName;
        private string targetConnectionString;
        private string targetTableName;
        private List<ColumnMapping> columnMappings;
        private List<FixedColumnMapping> fixedColumnMappings;
        private List<string> allTargetColumns;

        public MappingExecutionForm(string sourceConn, string sourceTable,
            string targetConn, string targetTable, List<ColumnMapping> mappings, List<string> targetColumns = null)
        {
            InitializeComponent();

            sourceConnectionString = sourceConn;
            sourceTableName = sourceTable;
            targetConnectionString = targetConn;
            targetTableName = targetTable;
            columnMappings = mappings;
            allTargetColumns = targetColumns ?? new List<string>();

            this.Text = $"Thực Thi Ánh Xạ: {sourceTable} → {targetTable}";

            InitializeFixedColumns();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewData();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            ExecuteMapping();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            PreviewData();
        }

        private void btnBulkReplace_Click(object sender, EventArgs e)
        {
            BulkReplaceValues();
        }

        private void PreviewData()
        {
            try
            {
                UpdateStatus("Đang tải dữ liệu xem trước...");
                progressBar1.Style = ProgressBarStyle.Marquee;

                string sourceColumns = string.Join(", ", columnMappings.Select(m => $"[{m.SourceColumn}]"));
                string query = $"SELECT {sourceColumns} FROM [{sourceTableName}]";

                if (!string.IsNullOrWhiteSpace(txtWhereClause.Text))
                {
                    query += $" WHERE {txtWhereClause.Text}";
                }

                using (SqlConnection connection = new SqlConnection(sourceConnectionString))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable previewData = new DataTable();
                        adapter.Fill(previewData);

                        // Rename columns to show mapping
                        foreach (DataColumn column in previewData.Columns)
                        {
                            var mapping = columnMappings.FirstOrDefault(m => m.SourceColumn == column.ColumnName);
                            if (mapping != null)
                            {
                                column.ColumnName = $"{mapping.SourceColumn} → {mapping.TargetColumn}";
                            }
                        }

                        // Add additional target columns that are not mapped
                        if (allTargetColumns != null && allTargetColumns.Count > 0)
                        {
                            var mappedTargetColumns = columnMappings.Select(m => m.TargetColumn).ToList();
                            var unmappedTargetColumns = allTargetColumns.Where(col => !mappedTargetColumns.Contains(col)).ToList();

                            foreach (string unmappedColumn in unmappedTargetColumns)
                            {
                                // Add column with default empty values
                                previewData.Columns.Add($"[Đích] {unmappedColumn}", typeof(string));

                                // Set default empty values for all rows
                                foreach (DataRow row in previewData.Rows)
                                {
                                    row[$"[Đích] {unmappedColumn}"] = "";
                                }
                            }
                        }

                        dgvPreview.DataSource = previewData;
                        UpdateStatus($"Đã tải xem trước: {previewData.Rows.Count} dòng");
                    }
                }

                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;
            }
            catch (Exception ex)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;
                MessageBox.Show($"Lỗi khi tải xem trước: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi: {ex.Message}");
            }
        }

        private void ExecuteMapping()
        {
            try
            {
                // Check if preview data exists
                if (dgvPreview.DataSource == null || ((DataTable)dgvPreview.DataSource).Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng tải dữ liệu xem trước trước khi thực thi ánh xạ.",
                        "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Hệ thống sẽ sử dụng dữ liệu hiện tại trong bảng xem trước (bao gồm các thay đổi đã chỉnh sửa)",
                    "Xác Nhận Thực Thi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                UpdateStatus("Đang thực thi ánh xạ...");
                progressBar1.Style = ProgressBarStyle.Marquee;

                // Get data from preview grid (including any edits)
                DataTable targetData = GetDataFromPreviewGrid();

                if (targetData.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để thực thi ánh xạ.",
                        "Thông Tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Execute mapping
                using (SqlConnection targetConnection = new SqlConnection(targetConnectionString))
                {
                    targetConnection.Open();
                    using (SqlTransaction transaction = targetConnection.BeginTransaction())
                    {
                        try
                        {
                            // Truncate target table if requested
                            if (checkBoxTruncateTarget.Checked)
                            {
                                UpdateStatus("Đang xóa dữ liệu bảng đích...");
                                using (SqlCommand truncateCmd = new SqlCommand($"TRUNCATE TABLE [{targetTableName}]", targetConnection, transaction))
                                {
                                    truncateCmd.ExecuteNonQuery();
                                }
                            }

                            // Get enabled fixed mappings
                            var enabledFixedMappings = GetEnabledFixedMappings();

                            // Build insert query with all target columns and fixed columns
                            var allTargetColumns = new List<string>();
                            var allParameterNames = new List<string>();

                            // Add all columns from target data (mapped + unmapped)
                            foreach (DataColumn column in targetData.Columns)
                            {
                                allTargetColumns.Add($"[{column.ColumnName}]");
                                allParameterNames.Add($"@col_{column.ColumnName}");
                            }

                            // Add enabled fixed columns (if not already included)
                            foreach (var fixedMapping in enabledFixedMappings)
                            {
                                if (!targetData.Columns.Contains(fixedMapping.ColumnName))
                                {
                                    allTargetColumns.Add($"[{fixedMapping.ColumnName}]");
                                    allParameterNames.Add($"@fixed_{fixedMapping.ColumnName}");
                                }
                            }

                            string targetColumns = string.Join(", ", allTargetColumns);
                            string parameterNames = string.Join(", ", allParameterNames);
                            string insertQuery = $"INSERT INTO [{targetTableName}] ({targetColumns}) VALUES ({parameterNames})";

                            UpdateStatus($"Đang chèn {targetData.Rows.Count} dòng...");
                            progressBar1.Style = ProgressBarStyle.Blocks;
                            progressBar1.Maximum = targetData.Rows.Count;
                            progressBar1.Value = 0;

                            int insertedRows = 0;
                            foreach (DataRow targetRow in targetData.Rows)
                            {
                                using (SqlCommand insertCmd = new SqlCommand(insertQuery, targetConnection, transaction))
                                {
                                    // Add parameters for all target columns
                                    foreach (DataColumn column in targetData.Columns)
                                    {
                                        object value = targetRow[column.ColumnName];
                                        insertCmd.Parameters.AddWithValue($"@col_{column.ColumnName}", value ?? DBNull.Value);
                                    }

                                    // Add parameters for fixed columns (if not already included)
                                    foreach (var fixedMapping in enabledFixedMappings)
                                    {
                                        if (!targetData.Columns.Contains(fixedMapping.ColumnName))
                                        {
                                            object value = GetFixedValue(fixedMapping.FixedValue);
                                            insertCmd.Parameters.AddWithValue($"@fixed_{fixedMapping.ColumnName}", value);
                                        }
                                    }

                                    insertCmd.ExecuteNonQuery();
                                    insertedRows++;

                                    if (insertedRows % 100 == 0)
                                    {
                                        progressBar1.Value = insertedRows;
                                        UpdateStatus($"Đã chèn {insertedRows} trong tổng số {targetData.Rows.Count} dòng...");
                                        Application.DoEvents();
                                    }
                                }
                            }

                            transaction.Commit();
                            progressBar1.Value = progressBar1.Maximum;

                            MessageBox.Show($"Thực thi ánh xạ thành công!\n\nSố dòng đã xử lý: {insertedRows}",
                                "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateStatus($"Hoàn thành ánh xạ thành công. Đã chèn {insertedRows} dòng.");
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;
                MessageBox.Show($"Lỗi khi thực thi ánh xạ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi: {ex.Message}");
            }
        }

        private void UpdateStatus(string message)
        {
            lblStatus.Text = message;
            lblStatus.Refresh();
        }

        private DataTable GetDataFromPreviewGrid()
        {
            DataTable previewData = (DataTable)dgvPreview.DataSource;
            if (previewData == null)
                return new DataTable();

            // Create a new DataTable with all target column names
            DataTable targetData = new DataTable();

            // Add columns for mapped source columns
            foreach (var mapping in columnMappings)
            {
                targetData.Columns.Add(mapping.TargetColumn, typeof(object));
            }

            // Add columns for unmapped target columns
            if (allTargetColumns != null && allTargetColumns.Count > 0)
            {
                var mappedTargetColumns = columnMappings.Select(m => m.TargetColumn).ToList();
                var unmappedTargetColumns = allTargetColumns.Where(col => !mappedTargetColumns.Contains(col)).ToList();

                foreach (string unmappedColumn in unmappedTargetColumns)
                {
                    targetData.Columns.Add(unmappedColumn, typeof(object));
                }
            }

            // Copy data from preview grid to target data table
            foreach (DataGridViewRow row in dgvPreview.Rows)
            {
                if (row.IsNewRow) continue;

                DataRow newRow = targetData.NewRow();

                // Copy mapped column data
                for (int i = 0; i < columnMappings.Count && i < row.Cells.Count; i++)
                {
                    var mapping = columnMappings[i];
                    newRow[mapping.TargetColumn] = row.Cells[i].Value ?? DBNull.Value;
                }

                // Copy unmapped column data
                if (allTargetColumns != null && allTargetColumns.Count > 0)
                {
                    var mappedTargetColumns = columnMappings.Select(m => m.TargetColumn).ToList();
                    var unmappedTargetColumns = allTargetColumns.Where(col => !mappedTargetColumns.Contains(col)).ToList();

                    int unmappedStartIndex = columnMappings.Count;
                    for (int i = 0; i < unmappedTargetColumns.Count; i++)
                    {
                        int cellIndex = unmappedStartIndex + i;
                        if (cellIndex < row.Cells.Count)
                        {
                            newRow[unmappedTargetColumns[i]] = row.Cells[cellIndex].Value ?? DBNull.Value;
                        }
                    }
                }

                targetData.Rows.Add(newRow);
            }

            return targetData;
        }

        private void BulkReplaceValues()
        {
            try
            {
                // Check if preview data exists
                if (dgvPreview.DataSource == null || ((DataTable)dgvPreview.DataSource).Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng tải dữ liệu xem trước trước khi thực hiện đổi nhanh giá trị.",
                        "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get available columns for replacement
                List<string> availableColumns = new List<string>();
                foreach (DataGridViewColumn column in dgvPreview.Columns)
                {
                    availableColumns.Add(column.HeaderText);
                }

                // Show bulk replace dialog
                using (var replaceForm = new BulkReplaceForm(availableColumns))
                {
                    if (replaceForm.ShowDialog() == DialogResult.OK)
                    {
                        PerformBulkReplace(replaceForm.SelectedColumn, replaceForm.OldValue,
                            replaceForm.NewValue, replaceForm.UseCondition, replaceForm.ReplaceAll);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực hiện đổi nhanh giá trị: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi: {ex.Message}");
            }
        }

        private void PerformBulkReplace(string columnName, string oldValue, string newValue,
            bool useCondition, bool replaceAll)
        {
            try
            {
                int columnIndex = -1;

                // Find column index
                for (int i = 0; i < dgvPreview.Columns.Count; i++)
                {
                    if (dgvPreview.Columns[i].HeaderText == columnName)
                    {
                        columnIndex = i;
                        break;
                    }
                }

                if (columnIndex == -1)
                {
                    MessageBox.Show($"Không tìm thấy cột '{columnName}'", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int replacedCount = 0;
                int totalRows = dgvPreview.Rows.Count;

                UpdateStatus("Đang thực hiện đổi nhanh giá trị...");
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.Maximum = totalRows;
                progressBar1.Value = 0;

                // Perform replacement
                foreach (DataGridViewRow row in dgvPreview.Rows)
                {
                    if (row.IsNewRow) continue;

                    object currentValue = row.Cells[columnIndex].Value;
                    string currentValueStr = currentValue?.ToString() ?? "";

                    bool shouldReplace = false;

                    if (replaceAll)
                    {
                        shouldReplace = true;
                    }
                    else if (useCondition)
                    {
                        shouldReplace = string.Equals(currentValueStr, oldValue, StringComparison.OrdinalIgnoreCase);
                    }

                    if (shouldReplace)
                    {
                        row.Cells[columnIndex].Value = newValue;
                        replacedCount++;
                    }

                    progressBar1.Value++;
                    if (progressBar1.Value % 100 == 0)
                    {
                        Application.DoEvents();
                    }
                }

                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;

                string message = $"Đã thay thế {replacedCount} giá trị trong cột '{columnName}'";
                if (useCondition && !replaceAll)
                {
                    message += $"\nĐiều kiện: '{oldValue}' → '{newValue}'";
                }
                else if (replaceAll)
                {
                    message += $"\nThay thế tất cả → '{newValue}'";
                }

                MessageBox.Show(message, "Hoàn Thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatus($"Đã thay thế {replacedCount} giá trị trong cột '{columnName}'");
            }
            catch (Exception ex)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = 0;
                MessageBox.Show($"Lỗi khi thực hiện thay thế: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi: {ex.Message}");
            }
        }

        private void labelExamples_Click(object sender, EventArgs e)
        {
            // Hiển thị dialog với các ví dụ chi tiết
            string examples = @"CÁC VÍ DỤ ĐIỀU KIỆN WHERE:

                                • created_time >= '2024-01-01'
                                • last_modified_times > '2024-06-01'
                                • CAST(created_time AS DATE) = CAST(GETDATE() AS DATE)
                                • created_time >= DATEADD(day, -7, GETDATE())
                                • id > 100
                                • ts_hocsinh_id = 12345
                                • dm_truong_id IN (1, 2, 3, 4)
                                • thu_tu BETWEEN 1 AND 50
                                • nam_hoc = '2024-2025'
                                • nam_hoc LIKE '2024%'
                                • dm_trangthaihocsinh_id = 1
                                • is_deleted = 0
                                • nam_hoc = '2024-2025' AND is_deleted = 0
                                • (dm_khoi_id = 10 OR dm_khoi_id = 11) AND dm_truong_id = 5
                                • created_user_id = 1 AND created_time >= '2024-01-01'
                                • is_deleted = 0 AND dm_trangthaihocsinh_id IN (1, 2)

                                ";

            MessageBox.Show(examples, "Ví Dụ Điều Kiện WHERE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InitializeFixedColumns()
        {
            // Initialize default fixed columns
            fixedColumnMappings = new List<FixedColumnMapping>
            {
                new FixedColumnMapping("is_deleted", "0", "bit"),
                new FixedColumnMapping("created_time", "GETDATE()", "datetime"),
                new FixedColumnMapping("created_user_id", "1", "int"),
                new FixedColumnMapping("last_modified_time", "GETDATE()", "datetime"),
                new FixedColumnMapping("last_modified_user_id", "1", "int")
            };

            SetupFixedColumnsDataGridView();
            LoadFixedColumnsToGrid();
        }

        private void SetupFixedColumnsDataGridView()
        {
            dgvFixedColumns.Columns.Clear();

            // Enabled column
            DataGridViewCheckBoxColumn enabledColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Enabled",
                HeaderText = "Kích Hoạt",
                Width = 80
            };
            dgvFixedColumns.Columns.Add(enabledColumn);

            // Column Name
            DataGridViewTextBoxColumn columnNameColumn = new DataGridViewTextBoxColumn
            {
                Name = "ColumnName",
                HeaderText = "Tên Cột"
            };
            dgvFixedColumns.Columns.Add(columnNameColumn);

            // Fixed Value
            DataGridViewTextBoxColumn fixedValueColumn = new DataGridViewTextBoxColumn
            {
                Name = "FixedValue",
                HeaderText = "Giá Trị Cố Định"
            };
            dgvFixedColumns.Columns.Add(fixedValueColumn);

            // Data Type
            DataGridViewTextBoxColumn dataTypeColumn = new DataGridViewTextBoxColumn
            {
                Name = "DataType",
                HeaderText = "Kiểu Dữ Liệu",
                Width = 80
            };
            dgvFixedColumns.Columns.Add(dataTypeColumn);

            dgvFixedColumns.AllowUserToAddRows = true;
            dgvFixedColumns.AllowUserToDeleteRows = true;
        }

        private void LoadFixedColumnsToGrid()
        {
            dgvFixedColumns.Rows.Clear();

            foreach (var fixedMapping in fixedColumnMappings)
            {
                int rowIndex = dgvFixedColumns.Rows.Add();
                DataGridViewRow row = dgvFixedColumns.Rows[rowIndex];

                row.Cells["Enabled"].Value = fixedMapping.IsEnabled;
                row.Cells["ColumnName"].Value = fixedMapping.ColumnName;
                row.Cells["FixedValue"].Value = fixedMapping.FixedValue;
                row.Cells["DataType"].Value = fixedMapping.DataType;
            }
        }

        private List<FixedColumnMapping> GetEnabledFixedMappings()
        {
            List<FixedColumnMapping> enabledMappings = new List<FixedColumnMapping>();

            foreach (DataGridViewRow row in dgvFixedColumns.Rows)
            {
                if (row.Cells["ColumnName"].Value != null &&
                    Convert.ToBoolean(row.Cells["Enabled"].Value ?? false))
                {
                    enabledMappings.Add(new FixedColumnMapping
                    {
                        ColumnName = row.Cells["ColumnName"].Value.ToString(),
                        FixedValue = row.Cells["FixedValue"].Value?.ToString() ?? "",
                        DataType = row.Cells["DataType"].Value?.ToString() ?? "",
                        IsEnabled = true
                    });
                }
            }

            return enabledMappings;
        }

        private object GetFixedValue(string fixedValue)
        {
            if (string.IsNullOrWhiteSpace(fixedValue))
                return DBNull.Value;

            // Handle special SQL functions
            switch (fixedValue.ToUpper())
            {
                case "GETDATE()":
                case "NOW()":
                    return DateTime.Now;
                case "NULL":
                    return DBNull.Value;
                default:
                    // Try to parse as different data types
                    if (int.TryParse(fixedValue, out int intValue))
                        return intValue;
                    if (bool.TryParse(fixedValue, out bool boolValue))
                        return boolValue;
                    if (DateTime.TryParse(fixedValue, out DateTime dateValue))
                        return dateValue;

                    // Return as string if no other type matches
                    return fixedValue;
            }
        }
    }
}
