namespace Scan_Box
{
    partial class BulkReplaceForm
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
            this.groupBoxColumn = new System.Windows.Forms.GroupBox();
            this.cmbColumn = new System.Windows.Forms.ComboBox();
            this.lblColumn = new System.Windows.Forms.Label();
            this.groupBoxOperation = new System.Windows.Forms.GroupBox();
            this.radioReplaceAll = new System.Windows.Forms.RadioButton();
            this.radioReplaceCondition = new System.Windows.Forms.RadioButton();
            this.groupBoxValues = new System.Windows.Forms.GroupBox();
            this.txtNewValue = new System.Windows.Forms.TextBox();
            this.lblNewValue = new System.Windows.Forms.Label();
            this.txtOldValue = new System.Windows.Forms.TextBox();
            this.lblOldValue = new System.Windows.Forms.Label();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBoxColumn.SuspendLayout();
            this.groupBoxOperation.SuspendLayout();
            this.groupBoxValues.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxColumn
            // 
            this.groupBoxColumn.Controls.Add(this.cmbColumn);
            this.groupBoxColumn.Controls.Add(this.lblColumn);
            this.groupBoxColumn.Location = new System.Drawing.Point(12, 12);
            this.groupBoxColumn.Name = "groupBoxColumn";
            this.groupBoxColumn.Size = new System.Drawing.Size(360, 60);
            this.groupBoxColumn.TabIndex = 0;
            this.groupBoxColumn.TabStop = false;
            this.groupBoxColumn.Text = "Chọn Cột";
            // 
            // cmbColumn
            // 
            this.cmbColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumn.FormattingEnabled = true;
            this.cmbColumn.Location = new System.Drawing.Point(80, 25);
            this.cmbColumn.Name = "cmbColumn";
            this.cmbColumn.Size = new System.Drawing.Size(270, 21);
            this.cmbColumn.TabIndex = 1;
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Location = new System.Drawing.Point(15, 28);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(29, 13);
            this.lblColumn.TabIndex = 0;
            this.lblColumn.Text = "Cột:";
            // 
            // groupBoxOperation
            // 
            this.groupBoxOperation.Controls.Add(this.radioReplaceAll);
            this.groupBoxOperation.Controls.Add(this.radioReplaceCondition);
            this.groupBoxOperation.Location = new System.Drawing.Point(12, 85);
            this.groupBoxOperation.Name = "groupBoxOperation";
            this.groupBoxOperation.Size = new System.Drawing.Size(360, 80);
            this.groupBoxOperation.TabIndex = 1;
            this.groupBoxOperation.TabStop = false;
            this.groupBoxOperation.Text = "Loại Thao Tác";
            // 
            // radioReplaceAll
            // 
            this.radioReplaceAll.AutoSize = true;
            this.radioReplaceAll.Location = new System.Drawing.Point(15, 50);
            this.radioReplaceAll.Name = "radioReplaceAll";
            this.radioReplaceAll.Size = new System.Drawing.Size(156, 17);
            this.radioReplaceAll.TabIndex = 1;
            this.radioReplaceAll.Text = "Thay thế TẤT CẢ giá trị";
            this.radioReplaceAll.UseVisualStyleBackColor = true;
            this.radioReplaceAll.CheckedChanged += new System.EventHandler(this.radioReplaceAll_CheckedChanged);
            // 
            // radioReplaceCondition
            // 
            this.radioReplaceCondition.AutoSize = true;
            this.radioReplaceCondition.Checked = true;
            this.radioReplaceCondition.Location = new System.Drawing.Point(15, 25);
            this.radioReplaceCondition.Name = "radioReplaceCondition";
            this.radioReplaceCondition.Size = new System.Drawing.Size(180, 17);
            this.radioReplaceCondition.TabIndex = 0;
            this.radioReplaceCondition.TabStop = true;
            this.radioReplaceCondition.Text = "Thay thế theo điều kiện";
            this.radioReplaceCondition.UseVisualStyleBackColor = true;
            this.radioReplaceCondition.CheckedChanged += new System.EventHandler(this.radioReplaceCondition_CheckedChanged);
            // 
            // groupBoxValues
            // 
            this.groupBoxValues.Controls.Add(this.txtNewValue);
            this.groupBoxValues.Controls.Add(this.lblNewValue);
            this.groupBoxValues.Controls.Add(this.txtOldValue);
            this.groupBoxValues.Controls.Add(this.lblOldValue);
            this.groupBoxValues.Location = new System.Drawing.Point(12, 175);
            this.groupBoxValues.Name = "groupBoxValues";
            this.groupBoxValues.Size = new System.Drawing.Size(360, 100);
            this.groupBoxValues.TabIndex = 2;
            this.groupBoxValues.TabStop = false;
            this.groupBoxValues.Text = "Giá Trị";
            // 
            // txtNewValue
            // 
            this.txtNewValue.Location = new System.Drawing.Point(120, 60);
            this.txtNewValue.Name = "txtNewValue";
            this.txtNewValue.Size = new System.Drawing.Size(230, 20);
            this.txtNewValue.TabIndex = 3;
            // 
            // lblNewValue
            // 
            this.lblNewValue.AutoSize = true;
            this.lblNewValue.Location = new System.Drawing.Point(15, 63);
            this.lblNewValue.Name = "lblNewValue";
            this.lblNewValue.Size = new System.Drawing.Size(69, 13);
            this.lblNewValue.TabIndex = 2;
            this.lblNewValue.Text = "Giá trị mới:";
            // 
            // txtOldValue
            // 
            this.txtOldValue.Location = new System.Drawing.Point(120, 25);
            this.txtOldValue.Name = "txtOldValue";
            this.txtOldValue.Size = new System.Drawing.Size(230, 20);
            this.txtOldValue.TabIndex = 1;
            // 
            // lblOldValue
            // 
            this.lblOldValue.AutoSize = true;
            this.lblOldValue.Location = new System.Drawing.Point(15, 28);
            this.lblOldValue.Name = "lblOldValue";
            this.lblOldValue.Size = new System.Drawing.Size(99, 13);
            this.lblOldValue.TabIndex = 0;
            this.lblOldValue.Text = "Giá trị cần thay:";
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.btnPreview);
            this.groupBoxActions.Controls.Add(this.btnCancel);
            this.groupBoxActions.Controls.Add(this.btnOK);
            this.groupBoxActions.Location = new System.Drawing.Point(12, 285);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(360, 60);
            this.groupBoxActions.TabIndex = 3;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Hành Động";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(15, 25);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 2;
            this.btnPreview.Text = "Xem Trước";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(275, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(190, 25);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Thực Hiện";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // BulkReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxValues);
            this.Controls.Add(this.groupBoxOperation);
            this.Controls.Add(this.groupBoxColumn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BulkReplaceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đổi Nhanh Giá Trị";
            this.groupBoxColumn.ResumeLayout(false);
            this.groupBoxColumn.PerformLayout();
            this.groupBoxOperation.ResumeLayout(false);
            this.groupBoxOperation.PerformLayout();
            this.groupBoxValues.ResumeLayout(false);
            this.groupBoxValues.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxColumn;
        private System.Windows.Forms.ComboBox cmbColumn;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.GroupBox groupBoxOperation;
        private System.Windows.Forms.RadioButton radioReplaceAll;
        private System.Windows.Forms.RadioButton radioReplaceCondition;
        private System.Windows.Forms.GroupBox groupBoxValues;
        private System.Windows.Forms.TextBox txtNewValue;
        private System.Windows.Forms.Label lblNewValue;
        private System.Windows.Forms.TextBox txtOldValue;
        private System.Windows.Forms.Label lblOldValue;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
