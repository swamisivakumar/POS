namespace Inventory
{
    partial class Tax
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTbSearch = new System.Windows.Forms.Button();
            this.btnTbAdd = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.AddGroup = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtExpAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SearchGroup = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Cat_ItemGrid = new System.Windows.Forms.DataGridView();
            this.AddGroup.SuspendLayout();
            this.SearchGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cat_ItemGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTbSearch
            // 
            this.btnTbSearch.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnTbSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTbSearch.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnTbSearch.FlatAppearance.BorderSize = 0;
            this.btnTbSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnTbSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnTbSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnTbSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTbSearch.Location = new System.Drawing.Point(12, 48);
            this.btnTbSearch.Name = "btnTbSearch";
            this.btnTbSearch.Size = new System.Drawing.Size(107, 32);
            this.btnTbSearch.TabIndex = 97;
            this.btnTbSearch.Text = "Search";
            this.btnTbSearch.UseVisualStyleBackColor = false;
            this.btnTbSearch.Click += new System.EventHandler(this.btnTbSearch_Click);
            // 
            // btnTbAdd
            // 
            this.btnTbAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnTbAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTbAdd.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnTbAdd.FlatAppearance.BorderSize = 0;
            this.btnTbAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.btnTbAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnTbAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTbAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnTbAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTbAdd.Location = new System.Drawing.Point(120, 48);
            this.btnTbAdd.Name = "btnTbAdd";
            this.btnTbAdd.Size = new System.Drawing.Size(107, 32);
            this.btnTbAdd.TabIndex = 98;
            this.btnTbAdd.Text = "Add";
            this.btnTbAdd.UseVisualStyleBackColor = false;
            this.btnTbAdd.Click += new System.EventHandler(this.btnTbAdd_Click);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Firebrick;
            this.label22.Location = new System.Drawing.Point(405, 53);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 16);
            this.label22.TabIndex = 99;
            this.label22.Text = "VAT SETUP";
            // 
            // AddGroup
            // 
            this.AddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AddGroup.Controls.Add(this.label13);
            this.AddGroup.Controls.Add(this.btnClear);
            this.AddGroup.Controls.Add(this.btnSave);
            this.AddGroup.Controls.Add(this.txtExpAmount);
            this.AddGroup.Controls.Add(this.label5);
            this.AddGroup.Location = new System.Drawing.Point(11, 77);
            this.AddGroup.Name = "AddGroup";
            this.AddGroup.Size = new System.Drawing.Size(925, 457);
            this.AddGroup.TabIndex = 100;
            this.AddGroup.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(502, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "*";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(412, 124);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(131, 37);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(275, 124);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 37);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtExpAmount
            // 
            this.txtExpAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpAmount.ForeColor = System.Drawing.Color.Gray;
            this.txtExpAmount.Location = new System.Drawing.Point(338, 80);
            this.txtExpAmount.MaxLength = 8;
            this.txtExpAmount.Name = "txtExpAmount";
            this.txtExpAmount.Size = new System.Drawing.Size(158, 24);
            this.txtExpAmount.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(272, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "VAT % :";
            // 
            // SearchGroup
            // 
            this.SearchGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchGroup.Controls.Add(this.groupBox2);
            this.SearchGroup.Location = new System.Drawing.Point(11, 77);
            this.SearchGroup.Name = "SearchGroup";
            this.SearchGroup.Size = new System.Drawing.Size(961, 429);
            this.SearchGroup.TabIndex = 101;
            this.SearchGroup.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Cat_ItemGrid);
            this.groupBox2.Location = new System.Drawing.Point(12, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(937, 375);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            // 
            // Cat_ItemGrid
            // 
            this.Cat_ItemGrid.AllowUserToAddRows = false;
            this.Cat_ItemGrid.AllowUserToDeleteRows = false;
            this.Cat_ItemGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Cat_ItemGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Cat_ItemGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Cat_ItemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Cat_ItemGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.Cat_ItemGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Cat_ItemGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Cat_ItemGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Cat_ItemGrid.ColumnHeadersHeight = 25;
            this.Cat_ItemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Cat_ItemGrid.DefaultCellStyle = dataGridViewCellStyle7;
            this.Cat_ItemGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Cat_ItemGrid.EnableHeadersVisualStyles = false;
            this.Cat_ItemGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Cat_ItemGrid.Location = new System.Drawing.Point(6, 14);
            this.Cat_ItemGrid.MultiSelect = false;
            this.Cat_ItemGrid.Name = "Cat_ItemGrid";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Cat_ItemGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.Cat_ItemGrid.RowHeadersVisible = false;
            this.Cat_ItemGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Cat_ItemGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Cat_ItemGrid.Size = new System.Drawing.Size(926, 353);
            this.Cat_ItemGrid.TabIndex = 89;
            this.Cat_ItemGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Cat_ItemGrid_CellDoubleClick);
            // 
            // Tax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 485);
            this.Controls.Add(this.btnTbSearch);
            this.Controls.Add(this.btnTbAdd);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.AddGroup);
            this.Controls.Add(this.SearchGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tax";
            this.Text = "Tax";
            this.Load += new System.EventHandler(this.Tax_Load);
            this.AddGroup.ResumeLayout(false);
            this.AddGroup.PerformLayout();
            this.SearchGroup.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cat_ItemGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTbSearch;
        private System.Windows.Forms.Button btnTbAdd;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox AddGroup;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtExpAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox SearchGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView Cat_ItemGrid;
    }
}