namespace Inventory
{
    partial class Expense
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AddGroup = new System.Windows.Forms.GroupBox();
            this.ddlExpDate = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ddlexpensetypes = new System.Windows.Forms.ComboBox();
            this.txtExpAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExpDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchGroup = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SrchddlExpTypes = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExpenseGrid = new System.Windows.Forms.DataGridView();
            this.btnTbAdd = new System.Windows.Forms.Button();
            this.btnTbSearch = new System.Windows.Forms.Button();
            this.AddGroup.SuspendLayout();
            this.SearchGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AddGroup
            // 
            this.AddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AddGroup.Controls.Add(this.ddlExpDate);
            this.AddGroup.Controls.Add(this.label13);
            this.AddGroup.Controls.Add(this.label12);
            this.AddGroup.Controls.Add(this.label2);
            this.AddGroup.Controls.Add(this.btnClear);
            this.AddGroup.Controls.Add(this.btnSave);
            this.AddGroup.Controls.Add(this.ddlexpensetypes);
            this.AddGroup.Controls.Add(this.txtExpAmount);
            this.AddGroup.Controls.Add(this.label5);
            this.AddGroup.Controls.Add(this.txtExpDesc);
            this.AddGroup.Controls.Add(this.label4);
            this.AddGroup.Controls.Add(this.label1);
            this.AddGroup.Controls.Add(this.label3);
            this.AddGroup.Location = new System.Drawing.Point(8, 78);
            this.AddGroup.Name = "AddGroup";
            this.AddGroup.Size = new System.Drawing.Size(925, 457);
            this.AddGroup.TabIndex = 18;
            this.AddGroup.TabStop = false;
            // 
            // ddlExpDate
            // 
            this.ddlExpDate.CustomFormat = "dd-MMM-yyyy";
            this.ddlExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F);
            this.ddlExpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ddlExpDate.Location = new System.Drawing.Point(294, 45);
            this.ddlExpDate.Name = "ddlExpDate";
            this.ddlExpDate.Size = new System.Drawing.Size(237, 25);
            this.ddlExpDate.TabIndex = 119;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(537, 118);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(537, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(537, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "*";
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClear.Image = global::Inventory.Properties.Resources.btn_login1;
            this.btnClear.Location = new System.Drawing.Point(441, 255);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(131, 37);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSave.Image = global::Inventory.Properties.Resources.btn_login1;
            this.btnSave.Location = new System.Drawing.Point(294, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 37);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ddlexpensetypes
            // 
            this.ddlexpensetypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlexpensetypes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ddlexpensetypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlexpensetypes.ForeColor = System.Drawing.Color.Gray;
            this.ddlexpensetypes.Location = new System.Drawing.Point(294, 81);
            this.ddlexpensetypes.Name = "ddlexpensetypes";
            this.ddlexpensetypes.Size = new System.Drawing.Size(237, 26);
            this.ddlexpensetypes.TabIndex = 14;
            // 
            // txtExpAmount
            // 
            this.txtExpAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpAmount.ForeColor = System.Drawing.Color.Gray;
            this.txtExpAmount.Location = new System.Drawing.Point(294, 116);
            this.txtExpAmount.MaxLength = 8;
            this.txtExpAmount.Name = "txtExpAmount";
            this.txtExpAmount.Size = new System.Drawing.Size(237, 24);
            this.txtExpAmount.TabIndex = 12;
            this.txtExpAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExpAmount_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(228, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Amount :";
            // 
            // txtExpDesc
            // 
            this.txtExpDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpDesc.ForeColor = System.Drawing.Color.Gray;
            this.txtExpDesc.Location = new System.Drawing.Point(294, 153);
            this.txtExpDesc.Multiline = true;
            this.txtExpDesc.Name = "txtExpDesc";
            this.txtExpDesc.Size = new System.Drawing.Size(422, 82);
            this.txtExpDesc.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(203, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Description :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(187, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Expence Type :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(187, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Expense Date :";
            // 
            // SearchGroup
            // 
            this.SearchGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchGroup.Controls.Add(this.groupBox1);
            this.SearchGroup.Controls.Add(this.groupBox2);
            this.SearchGroup.Location = new System.Drawing.Point(8, 78);
            this.SearchGroup.Name = "SearchGroup";
            this.SearchGroup.Size = new System.Drawing.Size(925, 457);
            this.SearchGroup.TabIndex = 19;
            this.SearchGroup.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.SrchddlExpTypes);
            this.groupBox1.Location = new System.Drawing.Point(7, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 50);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(262, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 15);
            this.label17.TabIndex = 7;
            this.label17.Text = "Expense Type";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSearch.Image = global::Inventory.Properties.Resources.btn_login1;
            this.btnSearch.Location = new System.Drawing.Point(568, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(131, 30);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // SrchddlExpTypes
            // 
            this.SrchddlExpTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SrchddlExpTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SrchddlExpTypes.ForeColor = System.Drawing.Color.Gray;
            this.SrchddlExpTypes.Location = new System.Drawing.Point(365, 14);
            this.SrchddlExpTypes.Name = "SrchddlExpTypes";
            this.SrchddlExpTypes.Size = new System.Drawing.Size(186, 26);
            this.SrchddlExpTypes.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.ExpenseGrid);
            this.groupBox2.Location = new System.Drawing.Point(7, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(910, 384);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // ExpenseGrid
            // 
            this.ExpenseGrid.AllowUserToAddRows = false;
            this.ExpenseGrid.AllowUserToDeleteRows = false;
            this.ExpenseGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ExpenseGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle31;
            this.ExpenseGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpenseGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ExpenseGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.ExpenseGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ExpenseGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExpenseGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.ExpenseGrid.ColumnHeadersHeight = 25;
            this.ExpenseGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ExpenseGrid.DefaultCellStyle = dataGridViewCellStyle33;
            this.ExpenseGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ExpenseGrid.EnableHeadersVisualStyles = false;
            this.ExpenseGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ExpenseGrid.Location = new System.Drawing.Point(6, 12);
            this.ExpenseGrid.MultiSelect = false;
            this.ExpenseGrid.Name = "ExpenseGrid";
            this.ExpenseGrid.ReadOnly = true;
            this.ExpenseGrid.RowHeadersVisible = false;
            this.ExpenseGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ExpenseGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ExpenseGrid.Size = new System.Drawing.Size(898, 366);
            this.ExpenseGrid.TabIndex = 23;
            this.ExpenseGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpenseGrid_CellDoubleClick);
            // 
            // btnTbAdd
            // 
            this.btnTbAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnTbAdd.BackgroundImage = global::Inventory.Properties.Resources.btn_tabs;
            this.btnTbAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTbAdd.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnTbAdd.FlatAppearance.BorderSize = 0;
            this.btnTbAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTbAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnTbAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTbAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnTbAdd.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnTbAdd.Location = new System.Drawing.Point(114, 50);
            this.btnTbAdd.Name = "btnTbAdd";
            this.btnTbAdd.Size = new System.Drawing.Size(107, 32);
            this.btnTbAdd.TabIndex = 16;
            this.btnTbAdd.Text = "Add";
            this.btnTbAdd.UseVisualStyleBackColor = false;
            this.btnTbAdd.Click += new System.EventHandler(this.btnTbAdd_Click);
            // 
            // btnTbSearch
            // 
            this.btnTbSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnTbSearch.BackgroundImage = global::Inventory.Properties.Resources.btn_tabs;
            this.btnTbSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTbSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnTbSearch.FlatAppearance.BorderSize = 0;
            this.btnTbSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTbSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnTbSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnTbSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnTbSearch.Location = new System.Drawing.Point(7, 50);
            this.btnTbSearch.Name = "btnTbSearch";
            this.btnTbSearch.Size = new System.Drawing.Size(107, 32);
            this.btnTbSearch.TabIndex = 15;
            this.btnTbSearch.Text = "Search";
            this.btnTbSearch.UseVisualStyleBackColor = false;
            this.btnTbSearch.Click += new System.EventHandler(this.btnTbSearch_Click);
            // 
            // Expense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(942, 547);
            this.Controls.Add(this.btnTbAdd);
            this.Controls.Add(this.btnTbSearch);
            this.Controls.Add(this.AddGroup);
            this.Controls.Add(this.SearchGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(10, 5);
            this.Name = "Expense";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Expense";
            this.Deactivate += new System.EventHandler(this.Expense_Deactivate);
            this.Load += new System.EventHandler(this.Expense_Load);
            this.AddGroup.ResumeLayout(false);
            this.AddGroup.PerformLayout();
            this.SearchGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExpenseGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTbAdd;
        private System.Windows.Forms.Button btnTbSearch;
        private System.Windows.Forms.GroupBox AddGroup;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox ddlexpensetypes;
        private System.Windows.Forms.TextBox txtExpAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExpDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox SearchGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox SrchddlExpTypes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView ExpenseGrid;
        private System.Windows.Forms.DateTimePicker ddlExpDate;

    }
}