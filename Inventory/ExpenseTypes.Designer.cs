namespace Inventory
{
    partial class ExpenseTypes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseTypes));
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExpDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtExpName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSrchExpNames = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SearchGroup = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Expgrid = new System.Windows.Forms.DataGridView();
            this.AddGroup = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTbSearch = new System.Windows.Forms.Button();
            this.btnTbAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SearchGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Expgrid)).BeginInit();
            this.AddGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(737, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 18);
            this.label10.TabIndex = 24;
            this.label10.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(526, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "*";
            // 
            // txtExpDesc
            // 
            this.txtExpDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpDesc.ForeColor = System.Drawing.Color.Gray;
            this.txtExpDesc.Location = new System.Drawing.Point(237, 86);
            this.txtExpDesc.Multiline = true;
            this.txtExpDesc.Name = "txtExpDesc";
            this.txtExpDesc.Size = new System.Drawing.Size(494, 105);
            this.txtExpDesc.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(135, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Description :";
            // 
            // txtExpName
            // 
            this.txtExpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpName.ForeColor = System.Drawing.Color.Gray;
            this.txtExpName.Location = new System.Drawing.Point(237, 52);
            this.txtExpName.Name = "txtExpName";
            this.txtExpName.Size = new System.Drawing.Size(283, 24);
            this.txtExpName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(111, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Expense Name :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label17.Location = new System.Drawing.Point(179, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 15);
            this.label17.TabIndex = 7;
            this.label17.Text = "Expense Name :";
            // 
            // txtSrchExpNames
            // 
            this.txtSrchExpNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSrchExpNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSrchExpNames.ForeColor = System.Drawing.Color.Gray;
            this.txtSrchExpNames.Location = new System.Drawing.Point(305, 16);
            this.txtSrchExpNames.Name = "txtSrchExpNames";
            this.txtSrchExpNames.Size = new System.Drawing.Size(309, 24);
            this.txtSrchExpNames.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtSrchExpNames);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(16, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 50);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSearch.Image = global::Inventory.Properties.Resources.btn_login1;
            this.btnSearch.Location = new System.Drawing.Point(634, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(131, 30);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.SearchGroup.Size = new System.Drawing.Size(943, 449);
            this.SearchGroup.TabIndex = 20;
            this.SearchGroup.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Expgrid);
            this.groupBox2.Location = new System.Drawing.Point(16, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(915, 379);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // Expgrid
            // 
            this.Expgrid.AllowUserToAddRows = false;
            this.Expgrid.AllowUserToDeleteRows = false;
            this.Expgrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Expgrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.Expgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Expgrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Expgrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.Expgrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Expgrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Expgrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.Expgrid.ColumnHeadersHeight = 25;
            this.Expgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Expgrid.DefaultCellStyle = dataGridViewCellStyle12;
            this.Expgrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Expgrid.EnableHeadersVisualStyles = false;
            this.Expgrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Expgrid.Location = new System.Drawing.Point(7, 14);
            this.Expgrid.MultiSelect = false;
            this.Expgrid.Name = "Expgrid";
            this.Expgrid.ReadOnly = true;
            this.Expgrid.RowHeadersVisible = false;
            this.Expgrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Expgrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Expgrid.Size = new System.Drawing.Size(901, 357);
            this.Expgrid.TabIndex = 23;
            this.Expgrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Expgrid_CellDoubleClick);
            // 
            // AddGroup
            // 
            this.AddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AddGroup.Controls.Add(this.label10);
            this.AddGroup.Controls.Add(this.label2);
            this.AddGroup.Controls.Add(this.btnClear);
            this.AddGroup.Controls.Add(this.btnSave);
            this.AddGroup.Controls.Add(this.txtExpDesc);
            this.AddGroup.Controls.Add(this.label4);
            this.AddGroup.Controls.Add(this.txtExpName);
            this.AddGroup.Controls.Add(this.label3);
            this.AddGroup.Location = new System.Drawing.Point(8, 78);
            this.AddGroup.Name = "AddGroup";
            this.AddGroup.Size = new System.Drawing.Size(943, 377);
            this.AddGroup.TabIndex = 21;
            this.AddGroup.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClear.Image = global::Inventory.Properties.Resources.btn_login1;
            this.btnClear.Location = new System.Drawing.Point(475, 209);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(131, 32);
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
            this.btnSave.Location = new System.Drawing.Point(327, 209);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 32);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnTbSearch.Location = new System.Drawing.Point(7, 50);
            this.btnTbSearch.Name = "btnTbSearch";
            this.btnTbSearch.Size = new System.Drawing.Size(107, 32);
            this.btnTbSearch.TabIndex = 18;
            this.btnTbSearch.Text = "Search";
            this.btnTbSearch.UseVisualStyleBackColor = false;
            this.btnTbSearch.Click += new System.EventHandler(this.btnTbSearch_Click);
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
            this.btnTbAdd.Location = new System.Drawing.Point(114, 50);
            this.btnTbAdd.Name = "btnTbAdd";
            this.btnTbAdd.Size = new System.Drawing.Size(107, 32);
            this.btnTbAdd.TabIndex = 19;
            this.btnTbAdd.Text = "Add";
            this.btnTbAdd.UseVisualStyleBackColor = false;
            this.btnTbAdd.Click += new System.EventHandler(this.btnTbAdd_Click);
            // 
            // ExpenseTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(963, 571);
            this.Controls.Add(this.btnTbSearch);
            this.Controls.Add(this.btnTbAdd);
            this.Controls.Add(this.SearchGroup);
            this.Controls.Add(this.AddGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExpenseTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ExpenseTypes";
            this.Deactivate += new System.EventHandler(this.ExpenseTypes_Deactivate);
            this.Load += new System.EventHandler(this.ExpenseTypes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.SearchGroup.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Expgrid)).EndInit();
            this.AddGroup.ResumeLayout(false);
            this.AddGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtExpDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTbSearch;
        private System.Windows.Forms.TextBox txtExpName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtSrchExpNames;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox SearchGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Expgrid;
        private System.Windows.Forms.GroupBox AddGroup;
        private System.Windows.Forms.Button btnTbAdd;
    }
}