namespace Inventory
{
    partial class FRM_Services
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Services));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BillPrintPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.label12 = new System.Windows.Forms.Label();
            this.PriviewPic = new System.Windows.Forms.PictureBox();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.BtnImageupld = new System.Windows.Forms.Button();
            this.txtServiceName = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BillPrint = new System.Drawing.Printing.PrintDocument();
            this.AddGroup = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSrChrg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ServicesGrid = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label44 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtsrchSrName = new System.Windows.Forms.TextBox();
            this.SearchGroup = new System.Windows.Forms.GroupBox();
            this.btnTbAdd = new System.Windows.Forms.Button();
            this.btnTbSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PriviewPic)).BeginInit();
            this.AddGroup.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServicesGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SearchGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // BillPrintPreview
            // 
            this.BillPrintPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.BillPrintPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.BillPrintPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.BillPrintPreview.Enabled = true;
            this.BillPrintPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("BillPrintPreview.Icon")));
            this.BillPrintPreview.Name = "BillPrintPreview";
            this.BillPrintPreview.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(142, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 128;
            this.label12.Text = "Image :";
            // 
            // PriviewPic
            // 
            this.PriviewPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PriviewPic.InitialImage = global::Inventory.Properties.Resources.Noimage;
            this.PriviewPic.Location = new System.Drawing.Point(777, 55);
            this.PriviewPic.Name = "PriviewPic";
            this.PriviewPic.Size = new System.Drawing.Size(120, 120);
            this.PriviewPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PriviewPic.TabIndex = 129;
            this.PriviewPic.TabStop = false;
            // 
            // txtImage
            // 
            this.txtImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtImage.ForeColor = System.Drawing.Color.Gray;
            this.txtImage.Location = new System.Drawing.Point(200, 115);
            this.txtImage.Name = "txtImage";
            this.txtImage.ReadOnly = true;
            this.txtImage.Size = new System.Drawing.Size(442, 24);
            this.txtImage.TabIndex = 126;
            // 
            // BtnImageupld
            // 
            this.BtnImageupld.BackColor = System.Drawing.Color.Transparent;
            this.BtnImageupld.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnImageupld.FlatAppearance.BorderSize = 0;
            this.BtnImageupld.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.BtnImageupld.ForeColor = System.Drawing.Color.Black;
            this.BtnImageupld.Location = new System.Drawing.Point(643, 114);
            this.BtnImageupld.Name = "BtnImageupld";
            this.BtnImageupld.Size = new System.Drawing.Size(109, 26);
            this.BtnImageupld.TabIndex = 3;
            this.BtnImageupld.Text = "Browse";
            this.BtnImageupld.UseVisualStyleBackColor = false;
            this.BtnImageupld.Click += new System.EventHandler(this.BtnImageupld_Click);
            // 
            // txtServiceName
            // 
            this.txtServiceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServiceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtServiceName.ForeColor = System.Drawing.Color.Gray;
            this.txtServiceName.Location = new System.Drawing.Point(200, 55);
            this.txtServiceName.Name = "txtServiceName";
            this.txtServiceName.Size = new System.Drawing.Size(552, 24);
            this.txtServiceName.TabIndex = 2;
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtDesc.ForeColor = System.Drawing.Color.Gray;
            this.txtDesc.Location = new System.Drawing.Point(200, 146);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(552, 58);
            this.txtDesc.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(58, 150);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 15);
            this.label6.TabIndex = 61;
            this.label6.Text = "Service Description :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(441, 89);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(16, 20);
            this.label26.TabIndex = 113;
            this.label26.Text = "*";
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClear.Image = global::Inventory.Properties.Resources.btn_login1;
            this.btnClear.Location = new System.Drawing.Point(483, 225);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(131, 30);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(755, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 20);
            this.label17.TabIndex = 95;
            this.label17.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(85, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 15);
            this.label13.TabIndex = 108;
            this.label13.Text = "Service Charge :";
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnAdd.Image = global::Inventory.Properties.Resources.btn_login1;
            this.BtnAdd.Location = new System.Drawing.Point(346, 225);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(131, 30);
            this.BtnAdd.TabIndex = 15;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // AddGroup
            // 
            this.AddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AddGroup.Controls.Add(this.panel1);
            this.AddGroup.Location = new System.Drawing.Point(10, 75);
            this.AddGroup.Name = "AddGroup";
            this.AddGroup.Size = new System.Drawing.Size(992, 475);
            this.AddGroup.TabIndex = 93;
            this.AddGroup.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.PriviewPic);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtImage);
            this.panel1.Controls.Add(this.BtnImageupld);
            this.panel1.Controls.Add(this.txtServiceName);
            this.panel1.Controls.Add(this.txtDesc);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.BtnAdd);
            this.panel1.Controls.Add(this.txtSrChrg);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(7, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 451);
            this.panel1.TabIndex = 0;
            // 
            // txtSrChrg
            // 
            this.txtSrChrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSrChrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtSrChrg.ForeColor = System.Drawing.Color.Gray;
            this.txtSrChrg.Location = new System.Drawing.Point(200, 85);
            this.txtSrChrg.MaxLength = 8;
            this.txtSrChrg.Name = "txtSrChrg";
            this.txtSrChrg.Size = new System.Drawing.Size(235, 24);
            this.txtSrChrg.TabIndex = 11;
            this.txtSrChrg.TextChanged += new System.EventHandler(this.txtSrChrg_TextChanged);
            this.txtSrChrg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSrChrg_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(93, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 15);
            this.label4.TabIndex = 94;
            this.label4.Text = "Service Name :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ServicesGrid);
            this.groupBox2.Location = new System.Drawing.Point(10, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(973, 396);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            // 
            // ServicesGrid
            // 
            this.ServicesGrid.AllowUserToAddRows = false;
            this.ServicesGrid.AllowUserToDeleteRows = false;
            this.ServicesGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ServicesGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.ServicesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ServicesGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ServicesGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.ServicesGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ServicesGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ServicesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.ServicesGrid.ColumnHeadersHeight = 25;
            this.ServicesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ServicesGrid.DefaultCellStyle = dataGridViewCellStyle9;
            this.ServicesGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ServicesGrid.EnableHeadersVisualStyles = false;
            this.ServicesGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ServicesGrid.Location = new System.Drawing.Point(7, 13);
            this.ServicesGrid.MultiSelect = false;
            this.ServicesGrid.Name = "ServicesGrid";
            this.ServicesGrid.ReadOnly = true;
            this.ServicesGrid.RowHeadersVisible = false;
            this.ServicesGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.ServicesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServicesGrid.Size = new System.Drawing.Size(959, 376);
            this.ServicesGrid.TabIndex = 69;
            this.ServicesGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ServicesGrid_CellDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtsrchSrName);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.Controls.Add(this.label44);
            this.groupBox3.Location = new System.Drawing.Point(10, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(973, 58);
            this.groupBox3.TabIndex = 73;
            this.groupBox3.TabStop = false;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label44.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label44.Location = new System.Drawing.Point(176, 25);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(104, 15);
            this.label44.TabIndex = 63;
            this.label44.Text = "Service Name :";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSearch.Image = global::Inventory.Properties.Resources.btn_login1;
            this.btnSearch.Location = new System.Drawing.Point(534, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 30);
            this.btnSearch.TabIndex = 68;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtsrchSrName
            // 
            this.txtsrchSrName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsrchSrName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtsrchSrName.ForeColor = System.Drawing.Color.Gray;
            this.txtsrchSrName.Location = new System.Drawing.Point(286, 21);
            this.txtsrchSrName.Name = "txtsrchSrName";
            this.txtsrchSrName.Size = new System.Drawing.Size(242, 24);
            this.txtsrchSrName.TabIndex = 62;
            // 
            // SearchGroup
            // 
            this.SearchGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchGroup.Controls.Add(this.groupBox3);
            this.SearchGroup.Controls.Add(this.groupBox2);
            this.SearchGroup.Location = new System.Drawing.Point(10, 75);
            this.SearchGroup.Name = "SearchGroup";
            this.SearchGroup.Size = new System.Drawing.Size(992, 475);
            this.SearchGroup.TabIndex = 96;
            this.SearchGroup.TabStop = false;
            // 
            // btnTbAdd
            // 
            this.btnTbAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnTbAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTbAdd.BackgroundImage")));
            this.btnTbAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTbAdd.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnTbAdd.FlatAppearance.BorderSize = 0;
            this.btnTbAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTbAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnTbAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTbAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnTbAdd.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnTbAdd.Location = new System.Drawing.Point(117, 47);
            this.btnTbAdd.Name = "btnTbAdd";
            this.btnTbAdd.Size = new System.Drawing.Size(107, 32);
            this.btnTbAdd.TabIndex = 98;
            this.btnTbAdd.Text = "Add";
            this.btnTbAdd.UseVisualStyleBackColor = false;
            this.btnTbAdd.Click += new System.EventHandler(this.btnTbAdd_Click);
            // 
            // btnTbSearch
            // 
            this.btnTbSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnTbSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTbSearch.BackgroundImage")));
            this.btnTbSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTbSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnTbSearch.FlatAppearance.BorderSize = 0;
            this.btnTbSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTbSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnTbSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnTbSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnTbSearch.Location = new System.Drawing.Point(9, 47);
            this.btnTbSearch.Name = "btnTbSearch";
            this.btnTbSearch.Size = new System.Drawing.Size(107, 32);
            this.btnTbSearch.TabIndex = 97;
            this.btnTbSearch.Text = "Search";
            this.btnTbSearch.UseVisualStyleBackColor = false;
            this.btnTbSearch.Click += new System.EventHandler(this.btnTbSearch_Click);
            // 
            // FRM_Services
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1010, 560);
            this.Controls.Add(this.btnTbSearch);
            this.Controls.Add(this.btnTbAdd);
            this.Controls.Add(this.AddGroup);
            this.Controls.Add(this.SearchGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_Services";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FRM_Services";
            this.Deactivate += new System.EventHandler(this.FRM_Services_Deactivate);
            this.Load += new System.EventHandler(this.FRM_Services_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PriviewPic)).EndInit();
            this.AddGroup.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServicesGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.SearchGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog BillPrintPreview;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox PriviewPic;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Button BtnImageupld;
        private System.Windows.Forms.TextBox txtServiceName;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button BtnAdd;
        private System.Drawing.Printing.PrintDocument BillPrint;
        private System.Windows.Forms.GroupBox AddGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSrChrg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView ServicesGrid;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtsrchSrName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.GroupBox SearchGroup;
        private System.Windows.Forms.Button btnTbAdd;
        private System.Windows.Forms.Button btnTbSearch;
    }
}