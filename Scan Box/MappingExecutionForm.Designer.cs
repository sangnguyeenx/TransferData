namespace Scan_Box
{
    partial class MappingExecutionForm
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
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.labelExamples = new System.Windows.Forms.Label();
            this.numericUpDownLimit = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxTruncateTarget = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWhereClause = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxFixedColumns = new System.Windows.Forms.GroupBox();
            this.dgvFixedColumns = new System.Windows.Forms.DataGridView();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnRefreshData = new System.Windows.Forms.Button();
            this.btnBulkReplace = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBoxPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLimit)).BeginInit();
            this.groupBoxFixedColumns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFixedColumns)).BeginInit();
            this.groupBoxActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Controls.Add(this.dgvPreview);
            this.groupBoxPreview.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(1248, 300);
            this.groupBoxPreview.TabIndex = 0;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "Xem Trước Dữ Liệu (Có thể chỉnh sửa)";
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreview.Location = new System.Drawing.Point(3, 16);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.Size = new System.Drawing.Size(1242, 281);
            this.dgvPreview.TabIndex = 0;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.labelExamples);
            this.groupBoxOptions.Controls.Add(this.numericUpDownLimit);
            this.groupBoxOptions.Controls.Add(this.label3);
            this.groupBoxOptions.Controls.Add(this.checkBoxTruncateTarget);
            this.groupBoxOptions.Controls.Add(this.label2);
            this.groupBoxOptions.Controls.Add(this.txtWhereClause);
            this.groupBoxOptions.Controls.Add(this.label1);
            this.groupBoxOptions.Location = new System.Drawing.Point(12, 330);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(839, 180);
            this.groupBoxOptions.TabIndex = 1;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Tùy Chọn Thực Thi";
            // 
            // labelExamples
            // 
            this.labelExamples.AutoSize = true;
            this.labelExamples.ForeColor = System.Drawing.Color.Blue;
            this.labelExamples.Location = new System.Drawing.Point(120, 55);
            this.labelExamples.Name = "labelExamples";
            this.labelExamples.Size = new System.Drawing.Size(152, 39);
            this.labelExamples.TabIndex = 6;
            this.labelExamples.Text = "Ví dụ: nam_hoc = \'2024-2025\'\r\n       id > 100, is_deleted = 0\r\n       Click để xe" +
    "m thêm ví dụ...";
            this.labelExamples.Click += new System.EventHandler(this.labelExamples_Click);
            // 
            // numericUpDownLimit
            // 
            this.numericUpDownLimit.Location = new System.Drawing.Point(120, 130);
            this.numericUpDownLimit.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLimit.Name = "numericUpDownLimit";
            this.numericUpDownLimit.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownLimit.TabIndex = 5;
            this.numericUpDownLimit.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giới Hạn Bản Ghi:";
            // 
            // checkBoxTruncateTarget
            // 
            this.checkBoxTruncateTarget.AutoSize = true;
            this.checkBoxTruncateTarget.Location = new System.Drawing.Point(15, 100);
            this.checkBoxTruncateTarget.Name = "checkBoxTruncateTarget";
            this.checkBoxTruncateTarget.Size = new System.Drawing.Size(203, 17);
            this.checkBoxTruncateTarget.TabIndex = 3;
            this.checkBoxTruncateTarget.Text = "Xóa dữ liệu bảng đích trước khi chèn";
            this.checkBoxTruncateTarget.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Tùy chọn SQL)";
            // 
            // txtWhereClause
            // 
            this.txtWhereClause.Location = new System.Drawing.Point(120, 25);
            this.txtWhereClause.Name = "txtWhereClause";
            this.txtWhereClause.Size = new System.Drawing.Size(702, 20);
            this.txtWhereClause.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Điều Kiện WHERE:";
            // 
            // groupBoxFixedColumns
            // 
            this.groupBoxFixedColumns.Controls.Add(this.dgvFixedColumns);
            this.groupBoxFixedColumns.Location = new System.Drawing.Point(857, 330);
            this.groupBoxFixedColumns.Name = "groupBoxFixedColumns";
            this.groupBoxFixedColumns.Size = new System.Drawing.Size(400, 180);
            this.groupBoxFixedColumns.TabIndex = 2;
            this.groupBoxFixedColumns.TabStop = false;
            this.groupBoxFixedColumns.Text = "Cột Dữ Liệu Cố Định";
            // 
            // dgvFixedColumns
            // 
            this.dgvFixedColumns.AllowUserToDeleteRows = false;
            this.dgvFixedColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFixedColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFixedColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFixedColumns.Location = new System.Drawing.Point(3, 16);
            this.dgvFixedColumns.Name = "dgvFixedColumns";
            this.dgvFixedColumns.Size = new System.Drawing.Size(394, 161);
            this.dgvFixedColumns.TabIndex = 0;
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.btnClose);
            this.groupBoxActions.Controls.Add(this.btnExecute);
            this.groupBoxActions.Controls.Add(this.btnPreview);
            this.groupBoxActions.Controls.Add(this.btnRefreshData);
            this.groupBoxActions.Controls.Add(this.btnBulkReplace);
            this.groupBoxActions.Location = new System.Drawing.Point(12, 530);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(800, 60);
            this.groupBoxActions.TabIndex = 3;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Hành Động";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.IndianRed;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Location = new System.Drawing.Point(700, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.Color.Orange;
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Location = new System.Drawing.Point(239, 25);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(161, 23);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "Thực Thi Ánh Xạ";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.LightBlue;
            this.btnPreview.Location = new System.Drawing.Point(20, 25);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(87, 23);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Xem Trước";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.Location = new System.Drawing.Point(594, 25);
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(100, 23);
            this.btnRefreshData.TabIndex = 3;
            this.btnRefreshData.Text = "Làm Mới Dữ Liệu";
            this.btnRefreshData.UseVisualStyleBackColor = true;
            this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
            // 
            // btnBulkReplace
            // 
            this.btnBulkReplace.BackColor = System.Drawing.Color.LightGreen;
            this.btnBulkReplace.Location = new System.Drawing.Point(113, 25);
            this.btnBulkReplace.Name = "btnBulkReplace";
            this.btnBulkReplace.Size = new System.Drawing.Size(120, 23);
            this.btnBulkReplace.TabIndex = 4;
            this.btnBulkReplace.Text = "Đổi Nhanh Giá Trị";
            this.btnBulkReplace.UseVisualStyleBackColor = false;
            this.btnBulkReplace.Click += new System.EventHandler(this.btnBulkReplace_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 610);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(800, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 645);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Sẵn Sàng";
            // 
            // MappingExecutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 669);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxFixedColumns);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.groupBoxPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MappingExecutionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thực Thi Ánh Xạ Cột";
            this.groupBoxPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLimit)).EndInit();
            this.groupBoxFixedColumns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFixedColumns)).EndInit();
            this.groupBoxActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox checkBoxTruncateTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWhereClause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnRefreshData;
        private System.Windows.Forms.Button btnBulkReplace;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.NumericUpDown numericUpDownLimit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelExamples;
        private System.Windows.Forms.GroupBox groupBoxFixedColumns;
        private System.Windows.Forms.DataGridView dgvFixedColumns;
    }
}
