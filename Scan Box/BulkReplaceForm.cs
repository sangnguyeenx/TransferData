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
    public partial class BulkReplaceForm : Form
    {
        public string SelectedColumn { get; private set; }
        public string OldValue { get; private set; }
        public string NewValue { get; private set; }
        public bool UseCondition { get; private set; }
        public bool ReplaceAll { get; private set; }

        private List<string> availableColumns;

        public BulkReplaceForm(List<string> columns)
        {
            InitializeComponent();
            availableColumns = columns;
            LoadColumns();
        }

        private void LoadColumns()
        {
            cmbColumn.Items.Clear();
            foreach (string column in availableColumns)
            {
                cmbColumn.Items.Add(column);
            }
            
            if (cmbColumn.Items.Count > 0)
            {
                cmbColumn.SelectedIndex = 0;
            }
        }

        private void radioReplaceAll_CheckedChanged(object sender, EventArgs e)
        {
            txtOldValue.Enabled = !radioReplaceAll.Checked;
            lblOldValue.Enabled = !radioReplaceAll.Checked;
            
            if (radioReplaceAll.Checked)
            {
                txtOldValue.Text = "";
            }
        }

        private void radioReplaceCondition_CheckedChanged(object sender, EventArgs e)
        {
            txtOldValue.Enabled = radioReplaceCondition.Checked;
            lblOldValue.Enabled = radioReplaceCondition.Checked;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Validate input
            if (cmbColumn.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn cột cần thay đổi.", "Cảnh Báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtNewValue.Text))
            {
                MessageBox.Show("Vui lòng nhập giá trị mới.", "Cảnh Báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (radioReplaceCondition.Checked && string.IsNullOrEmpty(txtOldValue.Text))
            {
                MessageBox.Show("Vui lòng nhập giá trị cần thay thế.", "Cảnh Báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Set results
            SelectedColumn = cmbColumn.SelectedItem.ToString();
            OldValue = txtOldValue.Text;
            NewValue = txtNewValue.Text;
            UseCondition = radioReplaceCondition.Checked;
            ReplaceAll = radioReplaceAll.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (cmbColumn.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn cột cần thay đổi.", "Cảnh Báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = $"Cột được chọn: {cmbColumn.SelectedItem}\n";
            
            if (radioReplaceAll.Checked)
            {
                message += $"Thao tác: Thay thế TẤT CẢ giá trị thành '{txtNewValue.Text}'";
            }
            else
            {
                message += $"Thao tác: Thay thế giá trị '{txtOldValue.Text}' thành '{txtNewValue.Text}'";
            }

            MessageBox.Show(message, "Xem Trước Thao Tác", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
