using Scan_Box.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scan_Box
{
    public partial class ColumnMappingForm : Form
    {
        private MappingConfiguration currentConfig;
        private List<string> sourceColumns;
        private List<string> targetColumns;

        public ColumnMappingForm()
        {
            InitializeComponent();
            currentConfig = new MappingConfiguration();
            sourceColumns = new List<string>();
            targetColumns = new List<string>();
        }

        private void ColumnMappingForm_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            SetDefaultConnectionStrings();
            UpdateStatus("Sẵn Sàng");
        }

        private void SetDefaultConnectionStrings()
        {
            // Set some example connection strings
            txtDB1.Text = "data source=103.152.165.48,1414;initial catalog=TueDuc_Cu;user id=sa;password=E9EKS3AnBn2qbAJRtASQ;MultipleActiveResultSets=True;";
            txtDB2.Text = "data source=103.152.165.48,1414;initial catalog=XanhTueDuc;user id=sa;password=E9EKS3AnBn2qbAJRtASQ;MultipleActiveResultSets=True";
        }

        private void InitializeDataGridView()
        {
            dgvMapping.Columns.Clear();

            // Add columns to DataGridView
            DataGridViewCheckBoxColumn enabledColumn = new DataGridViewCheckBoxColumn
            {
                Name = "Enabled",
                HeaderText = "Kích Hoạt",
                Width = 80
            };
            dgvMapping.Columns.Add(enabledColumn);

            DataGridViewTextBoxColumn sourceColumn = new DataGridViewTextBoxColumn
            {
                Name = "SourceColumn",
                HeaderText = "Cột Nguồn",
                ReadOnly = true
            };
            dgvMapping.Columns.Add(sourceColumn);

            DataGridViewComboBoxColumn targetColumn = new DataGridViewComboBoxColumn
            {
                Name = "TargetColumn",
                HeaderText = "Cột Đích"
            };
            dgvMapping.Columns.Add(targetColumn);

            DataGridViewTextBoxColumn dataTypeColumn = new DataGridViewTextBoxColumn
            {
                Name = "DataType",
                HeaderText = "Kiểu Dữ Liệu",
                ReadOnly = true
            };
            dgvMapping.Columns.Add(dataTypeColumn);
        }

        private void btnTestDB1_Click(object sender, EventArgs e)
        {
            TestConnection(txtDB1.Text, "Cơ Sở Dữ Liệu Nguồn");
        }

        private void btnTestDB2_Click(object sender, EventArgs e)
        {
            TestConnection(txtDB2.Text, "Cơ Sở Dữ Liệu Đích");
        }

        private void TestConnection(string connectionString, string dbName)
        {
            try
            {
                UpdateStatus($"Đang kiểm tra kết nối {dbName}...");

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    MessageBox.Show($"Vui lòng nhập chuỗi kết nối cho {dbName}.", "Cảnh Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isConnected = DatabaseHelper.TestConnection(connectionString);
                
                if (isConnected)
                {
                    MessageBox.Show($"Kết nối {dbName} thành công!", "Thành Công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Load tables for the connected database
                    if (dbName.Contains("Nguồn"))
                    {
                        LoadTables(connectionString, cmbSourceTable);
                    }
                    else
                    {
                        LoadTables(connectionString, cmbTargetTable);
                    }

                    UpdateStatus($"Đã kết nối {dbName} thành công");
                }
                else
                {
                    MessageBox.Show($"Không thể kết nối đến {dbName}. Vui lòng kiểm tra chuỗi kết nối.",
                        "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateStatus($"Không thể kết nối đến {dbName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra kết nối {dbName}: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi: {ex.Message}");
            }
        }

        private void LoadTables(string connectionString, ComboBox comboBox)
        {
            try
            {
                List<string> tables = DatabaseHelper.GetTables(connectionString);
                comboBox.Items.Clear();
                comboBox.Items.AddRange(tables.ToArray());
                
                if (tables.Count > 0)
                {
                    UpdateStatus($"Đã tải {tables.Count} bảng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải bảng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi khi tải bảng: {ex.Message}");
            }
        }

        private void cmbSourceTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSourceTable.SelectedItem != null)
            {
                LoadSourceColumns();
            }
        }

        private void cmbTargetTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTargetTable.SelectedItem != null)
            {
                LoadTargetColumns();
            }
        }

        private void LoadSourceColumns()
        {
            try
            {
                string tableName = cmbSourceTable.SelectedItem.ToString();
                sourceColumns = DatabaseHelper.GetColumns(txtDB1.Text, tableName);
                
                UpdateMappingGrid();
                UpdateStatus($"Đã tải {sourceColumns.Count} cột nguồn từ {tableName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải cột nguồn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi khi tải cột nguồn: {ex.Message}");
            }
        }

        private void LoadTargetColumns()
        {
            try
            {
                string tableName = cmbTargetTable.SelectedItem.ToString();
                targetColumns = DatabaseHelper.GetColumns(txtDB2.Text, tableName);
                
                // Update target column dropdown in DataGridView
                DataGridViewComboBoxColumn targetColumn = (DataGridViewComboBoxColumn)dgvMapping.Columns["TargetColumn"];
                targetColumn.Items.Clear();
                targetColumn.Items.Add(""); // Add empty option
                targetColumn.Items.AddRange(targetColumns.ToArray());
                
                UpdateStatus($"Đã tải {targetColumns.Count} cột đích từ {tableName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải cột đích: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi khi tải cột đích: {ex.Message}");
            }
        }

        private void UpdateMappingGrid()
        {
            dgvMapping.Rows.Clear();
            
            foreach (string column in sourceColumns)
            {
                int rowIndex = dgvMapping.Rows.Add();
                DataGridViewRow row = dgvMapping.Rows[rowIndex];
                
                row.Cells["Enabled"].Value = true;
                row.Cells["SourceColumn"].Value = column;
                row.Cells["TargetColumn"].Value = "";
                row.Cells["DataType"].Value = GetColumnDataType(txtDB1.Text, cmbSourceTable.SelectedItem.ToString(), column);
            }
        }

        private string GetColumnDataType(string connectionString, string tableName, string columnName)
        {
            try
            {
                DataTable columnInfo = DatabaseHelper.GetColumnInfo(connectionString, tableName);
                DataRow[] rows = columnInfo.Select($"COLUMN_NAME = '{columnName}'");
                
                if (rows.Length > 0)
                {
                    return rows[0]["DATA_TYPE"].ToString();
                }
            }
            catch (Exception)
            {
                // Return empty string if error occurs
            }
            return "";
        }

        private void UpdateStatus(string message)
        {
            toolStripStatusLabel1.Text = message;
            statusStrip1.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadConfiguration();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteConfiguration();
        }

        private void btnLoadMapping_Click(object sender, EventArgs e)
        {
            LoadMappingFromFile();
        }

        private void btnExecuteMapping_Click(object sender, EventArgs e)
        {
            ExecuteMapping();
        }

        private void SaveConfiguration()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtConfigName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên cấu hình.", "Cảnh Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update current configuration
                currentConfig.ConfigurationName = txtConfigName.Text;
                currentConfig.SourceDatabase.ConnectionString = txtDB1.Text;
                currentConfig.SourceDatabase.DatabaseName = DatabaseHelper.GetDatabaseName(txtDB1.Text);
                currentConfig.SourceDatabase.TableName = cmbSourceTable.SelectedItem?.ToString() ?? "";

                currentConfig.TargetDatabase.ConnectionString = txtDB2.Text;
                currentConfig.TargetDatabase.DatabaseName = DatabaseHelper.GetDatabaseName(txtDB2.Text);
                currentConfig.TargetDatabase.TableName = cmbTargetTable.SelectedItem?.ToString() ?? "";

                // Get mappings from DataGridView
                currentConfig.ColumnMappings.Clear();
                foreach (DataGridViewRow row in dgvMapping.Rows)
                {
                    if (row.Cells["SourceColumn"].Value != null)
                    {
                        ColumnMapping mapping = new ColumnMapping
                        {
                            SourceColumn = row.Cells["SourceColumn"].Value.ToString(),
                            TargetColumn = row.Cells["TargetColumn"].Value?.ToString() ?? "",
                            DataType = row.Cells["DataType"].Value?.ToString() ?? "",
                            IsEnabled = Convert.ToBoolean(row.Cells["Enabled"].Value ?? true)
                        };
                        currentConfig.ColumnMappings.Add(mapping);
                    }
                }

                currentConfig.LastModified = DateTime.Now;

                // Save to file
                MappingFileManager.SaveMappingToFile(currentConfig, txtConfigName.Text);

                MessageBox.Show("Lưu cấu hình thành công!", "Thành Công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatus($"Đã lưu cấu hình '{txtConfigName.Text}' thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu cấu hình: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi khi lưu cấu hình: {ex.Message}");
            }
        }

        private void LoadConfiguration()
        {
            try
            {
                List<string> availableConfigs = MappingFileManager.GetAvailableMappingFiles();

                if (availableConfigs.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy cấu hình đã lưu.", "Thông Tin",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Show selection dialog
                using (var selectForm = new ConfigSelectionForm(availableConfigs))
                {
                    if (selectForm.ShowDialog() == DialogResult.OK)
                    {
                        string selectedConfig = selectForm.SelectedConfiguration;
                        LoadConfigurationByName(selectedConfig);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải cấu hình: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi khi tải cấu hình: {ex.Message}");
            }
        }

        private void LoadConfigurationByName(string configName)
        {
            try
            {
                currentConfig = MappingFileManager.LoadMappingFromFile(configName);

                // Update UI with loaded configuration
                txtConfigName.Text = currentConfig.ConfigurationName;
                txtDB1.Text = currentConfig.SourceDatabase.ConnectionString;
                txtDB2.Text = currentConfig.TargetDatabase.ConnectionString;

                // Load tables and select the configured ones
                if (!string.IsNullOrEmpty(currentConfig.SourceDatabase.ConnectionString))
                {
                    LoadTables(currentConfig.SourceDatabase.ConnectionString, cmbSourceTable);
                    cmbSourceTable.SelectedItem = currentConfig.SourceDatabase.TableName;
                }

                if (!string.IsNullOrEmpty(currentConfig.TargetDatabase.ConnectionString))
                {
                    LoadTables(currentConfig.TargetDatabase.ConnectionString, cmbTargetTable);
                    cmbTargetTable.SelectedItem = currentConfig.TargetDatabase.TableName;
                }

                // Load column mappings
                LoadColumnMappingsToGrid();

                MessageBox.Show($"Đã tải cấu hình '{configName}' thành công!", "Thành Công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatus($"Đã tải cấu hình '{configName}' thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải cấu hình '{configName}': {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi khi tải cấu hình: {ex.Message}");
            }
        }

        private void LoadColumnMappingsToGrid()
        {
            dgvMapping.Rows.Clear();

            foreach (var mapping in currentConfig.ColumnMappings)
            {
                int rowIndex = dgvMapping.Rows.Add();
                DataGridViewRow row = dgvMapping.Rows[rowIndex];

                row.Cells["Enabled"].Value = mapping.IsEnabled;
                row.Cells["SourceColumn"].Value = mapping.SourceColumn;
                row.Cells["TargetColumn"].Value = mapping.TargetColumn;
                row.Cells["DataType"].Value = mapping.DataType;
            }
        }

        private void DeleteConfiguration()
        {
            try
            {
                List<string> availableConfigs = MappingFileManager.GetAvailableMappingFiles();

                if (availableConfigs.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy cấu hình đã lưu.", "Thông Tin",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Show selection dialog
                using (var selectForm = new ConfigSelectionForm(availableConfigs))
                {
                    if (selectForm.ShowDialog() == DialogResult.OK)
                    {
                        string selectedConfig = selectForm.SelectedConfiguration;

                        DialogResult result = MessageBox.Show(
                            $"Bạn có chắc chắn muốn xóa cấu hình '{selectedConfig}'?",
                            "Xác Nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            MappingFileManager.DeleteMappingFile(selectedConfig);
                            MessageBox.Show($"Đã xóa cấu hình '{selectedConfig}' thành công!", "Thành Công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateStatus($"Đã xóa cấu hình '{selectedConfig}'");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa cấu hình: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi khi xóa cấu hình: {ex.Message}");
            }
        }

        private void LoadMappingFromFile()
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.Title = "Chọn File Cấu Hình Ánh Xạ";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Load directly from the selected file path
                        LoadConfigurationFromFullPath(openFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ánh xạ từ file: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi khi tải ánh xạ từ file: {ex.Message}");
            }
        }

        private void LoadConfigurationFromFullPath(string fullFilePath)
        {
            try
            {
                currentConfig = MappingFileManager.LoadMappingFromFullPath(fullFilePath);

                // Update UI with loaded configuration
                txtConfigName.Text = currentConfig.ConfigurationName;
                txtDB1.Text = currentConfig.SourceDatabase.ConnectionString;
                txtDB2.Text = currentConfig.TargetDatabase.ConnectionString;

                // Load tables and select the configured ones
                if (!string.IsNullOrEmpty(currentConfig.SourceDatabase.ConnectionString))
                {
                    LoadTables(currentConfig.SourceDatabase.ConnectionString, cmbSourceTable);
                    cmbSourceTable.SelectedItem = currentConfig.SourceDatabase.TableName;
                }

                if (!string.IsNullOrEmpty(currentConfig.TargetDatabase.ConnectionString))
                {
                    LoadTables(currentConfig.TargetDatabase.ConnectionString, cmbTargetTable);
                    cmbTargetTable.SelectedItem = currentConfig.TargetDatabase.TableName;
                }

                // Load column mappings
                LoadColumnMappingsToGrid();

                string fileName = System.IO.Path.GetFileNameWithoutExtension(fullFilePath);
                MessageBox.Show($"Đã tải cấu hình từ file '{fileName}' thành công!", "Thành Công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateStatus($"Đã tải cấu hình từ file '{fileName}' thành công");
            }
            catch (Exception ex)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(fullFilePath);
                MessageBox.Show($"Lỗi khi tải cấu hình từ file '{fileName}': {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi khi tải cấu hình từ file: {ex.Message}");
            }
        }

        private void ExecuteMapping()
        {
            try
            {
                // Validate configuration
                if (string.IsNullOrWhiteSpace(txtDB1.Text) || string.IsNullOrWhiteSpace(txtDB2.Text))
                {
                    MessageBox.Show("Vui lòng cấu hình cả hai cơ sở dữ liệu nguồn và đích.", "Cảnh Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbSourceTable.SelectedItem == null || cmbTargetTable.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn cả bảng nguồn và bảng đích.", "Cảnh Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get enabled mappings
                List<ColumnMapping> enabledMappings = new List<ColumnMapping>();
                foreach (DataGridViewRow row in dgvMapping.Rows)
                {
                    if (row.Cells["SourceColumn"].Value != null &&
                        Convert.ToBoolean(row.Cells["Enabled"].Value ?? false) &&
                        !string.IsNullOrEmpty(row.Cells["TargetColumn"].Value?.ToString()))
                    {
                        enabledMappings.Add(new ColumnMapping
                        {
                            SourceColumn = row.Cells["SourceColumn"].Value.ToString(),
                            TargetColumn = row.Cells["TargetColumn"].Value.ToString(),
                            DataType = row.Cells["DataType"].Value?.ToString() ?? "",
                            IsEnabled = true
                        });
                    }
                }

                if (enabledMappings.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy ánh xạ cột nào được kích hoạt. Vui lòng cấu hình ít nhất một ánh xạ.",
                        "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Show mapping execution form
                using (var executionForm = new MappingExecutionForm(
                    txtDB1.Text, cmbSourceTable.SelectedItem.ToString(),
                    txtDB2.Text, cmbTargetTable.SelectedItem.ToString(),
                    enabledMappings, targetColumns))
                {
                    executionForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thực thi ánh xạ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Lỗi khi thực thi ánh xạ: {ex.Message}");
            }
        }
    }
}
