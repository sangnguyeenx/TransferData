namespace Scan_Box
{
    partial class ColumnMappingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxSource = new System.Windows.Forms.GroupBox();
            this.btnTestDB1 = new System.Windows.Forms.Button();
            this.cmbSourceTable = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDB1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxTarget = new System.Windows.Forms.GroupBox();
            this.btnTestDB2 = new System.Windows.Forms.Button();
            this.cmbTargetTable = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDB2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxMapping = new System.Windows.Forms.GroupBox();
            this.dgvMapping = new System.Windows.Forms.DataGridView();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.btnExecuteMapping = new System.Windows.Forms.Button();
            this.btnLoadMapping = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtConfigName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxSource.SuspendLayout();
            this.groupBoxTarget.SuspendLayout();
            this.groupBoxMapping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMapping)).BeginInit();
            this.groupBoxActions.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSource
            // 
            this.groupBoxSource.Controls.Add(this.btnTestDB1);
            this.groupBoxSource.Controls.Add(this.cmbSourceTable);
            this.groupBoxSource.Controls.Add(this.label2);
            this.groupBoxSource.Controls.Add(this.txtDB1);
            this.groupBoxSource.Controls.Add(this.label1);
            this.groupBoxSource.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSource.Name = "groupBoxSource";
            this.groupBoxSource.Size = new System.Drawing.Size(600, 120);
            this.groupBoxSource.TabIndex = 0;
            this.groupBoxSource.TabStop = false;
            this.groupBoxSource.Text = "Cơ Sở Dữ Liệu Nguồn (DB1)";
            // 
            // btnTestDB1
            // 
            this.btnTestDB1.Location = new System.Drawing.Point(500, 25);
            this.btnTestDB1.Name = "btnTestDB1";
            this.btnTestDB1.Size = new System.Drawing.Size(75, 23);
            this.btnTestDB1.TabIndex = 4;
            this.btnTestDB1.Text = "Kiểm Tra";
            this.btnTestDB1.UseVisualStyleBackColor = true;
            this.btnTestDB1.Click += new System.EventHandler(this.btnTestDB1_Click);
            // 
            // cmbSourceTable
            // 
            this.cmbSourceTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSourceTable.FormattingEnabled = true;
            this.cmbSourceTable.Location = new System.Drawing.Point(120, 80);
            this.cmbSourceTable.Name = "cmbSourceTable";
            this.cmbSourceTable.Size = new System.Drawing.Size(350, 21);
            this.cmbSourceTable.TabIndex = 3;
            this.cmbSourceTable.SelectedIndexChanged += new System.EventHandler(this.cmbSourceTable_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bảng:";
            // 
            // txtDB1
            // 
            this.txtDB1.Location = new System.Drawing.Point(120, 25);
            this.txtDB1.Multiline = true;
            this.txtDB1.Name = "txtDB1";
            this.txtDB1.Size = new System.Drawing.Size(350, 40);
            this.txtDB1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chuỗi Kết Nối:";
            // 
            // groupBoxTarget
            // 
            this.groupBoxTarget.Controls.Add(this.btnTestDB2);
            this.groupBoxTarget.Controls.Add(this.cmbTargetTable);
            this.groupBoxTarget.Controls.Add(this.label3);
            this.groupBoxTarget.Controls.Add(this.txtDB2);
            this.groupBoxTarget.Controls.Add(this.label4);
            this.groupBoxTarget.Location = new System.Drawing.Point(630, 12);
            this.groupBoxTarget.Name = "groupBoxTarget";
            this.groupBoxTarget.Size = new System.Drawing.Size(600, 120);
            this.groupBoxTarget.TabIndex = 1;
            this.groupBoxTarget.TabStop = false;
            this.groupBoxTarget.Text = "Cơ Sở Dữ Liệu Đích (DB2)";
            // 
            // btnTestDB2
            // 
            this.btnTestDB2.Location = new System.Drawing.Point(500, 25);
            this.btnTestDB2.Name = "btnTestDB2";
            this.btnTestDB2.Size = new System.Drawing.Size(75, 23);
            this.btnTestDB2.TabIndex = 4;
            this.btnTestDB2.Text = "Kiểm Tra";
            this.btnTestDB2.UseVisualStyleBackColor = true;
            this.btnTestDB2.Click += new System.EventHandler(this.btnTestDB2_Click);
            // 
            // cmbTargetTable
            // 
            this.cmbTargetTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetTable.FormattingEnabled = true;
            this.cmbTargetTable.Location = new System.Drawing.Point(120, 80);
            this.cmbTargetTable.Name = "cmbTargetTable";
            this.cmbTargetTable.Size = new System.Drawing.Size(350, 21);
            this.cmbTargetTable.TabIndex = 3;
            this.cmbTargetTable.SelectedIndexChanged += new System.EventHandler(this.cmbTargetTable_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bảng:";
            // 
            // txtDB2
            // 
            this.txtDB2.Location = new System.Drawing.Point(120, 25);
            this.txtDB2.Multiline = true;
            this.txtDB2.Name = "txtDB2";
            this.txtDB2.Size = new System.Drawing.Size(350, 40);
            this.txtDB2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Chuỗi Kết Nối:";
            // 
            // groupBoxMapping
            // 
            this.groupBoxMapping.Controls.Add(this.dgvMapping);
            this.groupBoxMapping.Location = new System.Drawing.Point(12, 150);
            this.groupBoxMapping.Name = "groupBoxMapping";
            this.groupBoxMapping.Size = new System.Drawing.Size(1218, 400);
            this.groupBoxMapping.TabIndex = 2;
            this.groupBoxMapping.TabStop = false;
            this.groupBoxMapping.Text = "Ánh Xạ Cột";
            // 
            // dgvMapping
            // 
            this.dgvMapping.AllowUserToAddRows = false;
            this.dgvMapping.AllowUserToDeleteRows = false;
            this.dgvMapping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMapping.Location = new System.Drawing.Point(3, 16);
            this.dgvMapping.Name = "dgvMapping";
            this.dgvMapping.Size = new System.Drawing.Size(1212, 381);
            this.dgvMapping.TabIndex = 0;
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.btnExecuteMapping);
            this.groupBoxActions.Controls.Add(this.btnLoadMapping);
            this.groupBoxActions.Controls.Add(this.btnDelete);
            this.groupBoxActions.Controls.Add(this.btnLoad);
            this.groupBoxActions.Controls.Add(this.btnSave);
            this.groupBoxActions.Controls.Add(this.txtConfigName);
            this.groupBoxActions.Controls.Add(this.label5);
            this.groupBoxActions.Location = new System.Drawing.Point(12, 570);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(1218, 80);
            this.groupBoxActions.TabIndex = 3;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Quản Lý Cấu Hình";
            // 
            // btnExecuteMapping
            // 
            this.btnExecuteMapping.BackColor = System.Drawing.Color.Orange;
            this.btnExecuteMapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteMapping.Location = new System.Drawing.Point(910, 45);
            this.btnExecuteMapping.Name = "btnExecuteMapping";
            this.btnExecuteMapping.Size = new System.Drawing.Size(283, 25);
            this.btnExecuteMapping.TabIndex = 7;
            this.btnExecuteMapping.Text = "Thực Thi ";
            this.btnExecuteMapping.UseVisualStyleBackColor = false;
            this.btnExecuteMapping.Click += new System.EventHandler(this.btnExecuteMapping_Click);
            // 
            // btnLoadMapping
            // 
            this.btnLoadMapping.BackColor = System.Drawing.Color.LightYellow;
            this.btnLoadMapping.Location = new System.Drawing.Point(770, 129);
            this.btnLoadMapping.Name = "btnLoadMapping";
            this.btnLoadMapping.Size = new System.Drawing.Size(120, 25);
            this.btnLoadMapping.TabIndex = 6;
            this.btnLoadMapping.Text = "Tải Ánh Xạ";
            this.btnLoadMapping.UseVisualStyleBackColor = false;
            this.btnLoadMapping.Click += new System.EventHandler(this.btnLoadMapping_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.Location = new System.Drawing.Point(650, 45);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 25);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa Cấu Hình";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.LightBlue;
            this.btnLoad.Location = new System.Drawing.Point(530, 45);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 25);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Tải Cấu Hình";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.Location = new System.Drawing.Point(410, 45);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu Cấu Hình";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtConfigName
            // 
            this.txtConfigName.Location = new System.Drawing.Point(120, 47);
            this.txtConfigName.Name = "txtConfigName";
            this.txtConfigName.Size = new System.Drawing.Size(250, 20);
            this.txtConfigName.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tên Cấu Hình:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 665);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1244, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel1.Text = "Sẵn Sàng";
            // 
            // ColumnMappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 687);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxMapping);
            this.Controls.Add(this.groupBoxTarget);
            this.Controls.Add(this.groupBoxSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ColumnMappingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DB MAPPING - SANG";
            this.Load += new System.EventHandler(this.ColumnMappingForm_Load);
            this.groupBoxSource.ResumeLayout(false);
            this.groupBoxSource.PerformLayout();
            this.groupBoxTarget.ResumeLayout(false);
            this.groupBoxTarget.PerformLayout();
            this.groupBoxMapping.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMapping)).EndInit();
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxActions.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSource;
        private System.Windows.Forms.ComboBox cmbSourceTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDB1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxTarget;
        private System.Windows.Forms.ComboBox cmbTargetTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDB2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxMapping;
        private System.Windows.Forms.DataGridView dgvMapping;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtConfigName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTestDB1;
        private System.Windows.Forms.Button btnTestDB2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnLoadMapping;
        private System.Windows.Forms.Button btnExecuteMapping;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
