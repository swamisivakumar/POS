namespace Inventory
{
    partial class SupplierReport
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
            this.ddlToDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlFromDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.lblCatName = new System.Windows.Forms.Label();
            this.ddlcatname = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlToDate
            // 
            this.ddlToDate.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ddlToDate.CalendarTitleForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ddlToDate.CustomFormat = "dd-MMM-yyyy";
            this.ddlToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ddlToDate.Location = new System.Drawing.Point(584, 14);
            this.ddlToDate.Name = "ddlToDate";
            this.ddlToDate.Size = new System.Drawing.Size(143, 26);
            this.ddlToDate.TabIndex = 122;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.ddlToDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ddlFromDate);
            this.groupBox1.Controls.Add(this.lblCatName);
            this.groupBox1.Controls.Add(this.ddlcatname);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(922, 53);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSearch.Image = global::Inventory.Properties.Resources.btn_login1;
            this.btnSearch.Location = new System.Drawing.Point(742, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(153, 30);
            this.btnSearch.TabIndex = 123;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(517, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 121;
            this.label1.Text = "To Date :";
            // 
            // ddlFromDate
            // 
            this.ddlFromDate.CalendarForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ddlFromDate.CalendarTitleForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ddlFromDate.CustomFormat = "dd-MMM-yyyy";
            this.ddlFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ddlFromDate.Location = new System.Drawing.Point(358, 14);
            this.ddlFromDate.Name = "ddlFromDate";
            this.ddlFromDate.Size = new System.Drawing.Size(144, 26);
            this.ddlFromDate.TabIndex = 120;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(274, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 15);
            this.label13.TabIndex = 119;
            this.label13.Text = "From Date :";
            // 
            // lblCatName
            // 
            this.lblCatName.AutoSize = true;
            this.lblCatName.BackColor = System.Drawing.Color.Transparent;
            this.lblCatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblCatName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCatName.Location = new System.Drawing.Point(8, 20);
            this.lblCatName.Name = "lblCatName";
            this.lblCatName.Size = new System.Drawing.Size(69, 15);
            this.lblCatName.TabIndex = 125;
            this.lblCatName.Text = "Supplier :";
            // 
            // ddlcatname
            // 
            this.ddlcatname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlcatname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlcatname.ForeColor = System.Drawing.Color.Gray;
            this.ddlcatname.FormattingEnabled = true;
            this.ddlcatname.Location = new System.Drawing.Point(81, 14);
            this.ddlcatname.Name = "ddlcatname";
            this.ddlcatname.Size = new System.Drawing.Size(174, 26);
            this.ddlcatname.TabIndex = 124;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.Location = new System.Drawing.Point(12, 105);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(922, 427);
            this.reportViewer1.TabIndex = 4;
            // 
            // SupplierReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 543);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SupplierReport";
            this.Text = "SupplierReport";
            this.Load += new System.EventHandler(this.SupplierReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DateTimePicker ddlToDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker ddlFromDate;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label lblCatName;
        public System.Windows.Forms.ComboBox ddlcatname;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}