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
    public partial class ConfigSelectionForm : Form
    {
        public string SelectedConfiguration { get; private set; }

        public ConfigSelectionForm(List<string> configurations)
        {
            InitializeComponent();
            
            listBoxConfigs.Items.Clear();
            listBoxConfigs.Items.AddRange(configurations.ToArray());
            
            if (configurations.Count > 0)
            {
                listBoxConfigs.SelectedIndex = 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (listBoxConfigs.SelectedItem != null)
            {
                SelectedConfiguration = listBoxConfigs.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một cấu hình.", "Cảnh Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBoxConfigs_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxConfigs.SelectedItem != null)
            {
                SelectedConfiguration = listBoxConfigs.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
