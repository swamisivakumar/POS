namespace Inventory
{
    partial class Frm_POS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_POS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BillPrintPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument3 = new System.Drawing.Printing.PrintDocument();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.SVatAmt = new System.Windows.Forms.TextBox();
            this.SDue = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.txtSAmount = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtSDiscount = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtSTotal = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.label70 = new System.Windows.Forms.Label();
            this.textBox58 = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.textBox59 = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.textBox60 = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.textBox61 = new System.Windows.Forms.TextBox();
            this.panel24 = new System.Windows.Forms.Panel();
            this.label74 = new System.Windows.Forms.Label();
            this.textBox62 = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.textBox63 = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.textBox64 = new System.Windows.Forms.TextBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
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
            // printDocument3
            // 
            this.printDocument3.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument3_PrintPage);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel3.Controls.Add(this.button10);
            this.panel3.Controls.Add(this.SVatAmt);
            this.panel3.Controls.Add(this.SDue);
            this.panel3.Controls.Add(this.label40);
            this.panel3.Controls.Add(this.label41);
            this.panel3.Controls.Add(this.button8);
            this.panel3.Controls.Add(this.txtSAmount);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.txtSDiscount);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.txtSTotal);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Location = new System.Drawing.Point(6, 468);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(994, 78);
            this.panel3.TabIndex = 31;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.LimeGreen;
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button10.FlatAppearance.BorderSize = 2;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(701, 26);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(236, 39);
            this.button10.TabIndex = 27;
            this.button10.Text = "P A Y  N O W";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // SVatAmt
            // 
            this.SVatAmt.BackColor = System.Drawing.SystemColors.MenuText;
            this.SVatAmt.Enabled = false;
            this.SVatAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.SVatAmt.ForeColor = System.Drawing.Color.Lime;
            this.SVatAmt.Location = new System.Drawing.Point(422, 29);
            this.SVatAmt.Name = "SVatAmt";
            this.SVatAmt.Size = new System.Drawing.Size(131, 35);
            this.SVatAmt.TabIndex = 39;
            this.SVatAmt.Text = "0";
            // 
            // SDue
            // 
            this.SDue.BackColor = System.Drawing.SystemColors.MenuText;
            this.SDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.SDue.ForeColor = System.Drawing.Color.Lime;
            this.SDue.Location = new System.Drawing.Point(551, 29);
            this.SDue.Name = "SDue";
            this.SDue.Size = new System.Drawing.Size(135, 35);
            this.SDue.TabIndex = 37;
            this.SDue.Text = "0";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.label40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label40.Location = new System.Drawing.Point(561, 5);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(91, 20);
            this.label40.TabIndex = 38;
            this.label40.Text = "Total Due";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label41.Location = new System.Drawing.Point(425, 9);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(113, 20);
            this.label41.TabIndex = 36;
            this.label41.Text = "VAT Amount";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.LimeGreen;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button8.FlatAppearance.BorderSize = 2;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(738, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(236, 39);
            this.button8.TabIndex = 29;
            this.button8.Text = "P A Y  N O W";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // txtSAmount
            // 
            this.txtSAmount.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtSAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.txtSAmount.ForeColor = System.Drawing.Color.Lime;
            this.txtSAmount.Location = new System.Drawing.Point(304, 29);
            this.txtSAmount.Name = "txtSAmount";
            this.txtSAmount.Size = new System.Drawing.Size(120, 35);
            this.txtSAmount.TabIndex = 26;
            this.txtSAmount.Text = "0";
            this.txtSAmount.TextChanged += new System.EventHandler(this.txtSAmount_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label24.Location = new System.Drawing.Point(300, 6);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(51, 20);
            this.label24.TabIndex = 28;
            this.label24.Text = "Total";
            // 
            // txtSDiscount
            // 
            this.txtSDiscount.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtSDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.txtSDiscount.ForeColor = System.Drawing.Color.Lime;
            this.txtSDiscount.Location = new System.Drawing.Point(186, 29);
            this.txtSDiscount.MaxLength = 3;
            this.txtSDiscount.Name = "txtSDiscount";
            this.txtSDiscount.Size = new System.Drawing.Size(121, 35);
            this.txtSDiscount.TabIndex = 25;
            this.txtSDiscount.Text = "0";
            this.txtSDiscount.TextChanged += new System.EventHandler(this.txtSDiscount_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label25.Location = new System.Drawing.Point(182, 7);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(80, 20);
            this.label25.TabIndex = 24;
            this.label25.Text = "Discount";
            // 
            // txtSTotal
            // 
            this.txtSTotal.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtSTotal.Enabled = false;
            this.txtSTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.txtSTotal.ForeColor = System.Drawing.Color.Lime;
            this.txtSTotal.Location = new System.Drawing.Point(57, 29);
            this.txtSTotal.Name = "txtSTotal";
            this.txtSTotal.Size = new System.Drawing.Size(132, 35);
            this.txtSTotal.TabIndex = 23;
            this.txtSTotal.Text = "0";
            this.txtSTotal.TextChanged += new System.EventHandler(this.txtSTotal_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label26.Location = new System.Drawing.Point(53, 6);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(51, 20);
            this.label26.TabIndex = 22;
            this.label26.Text = "Total";
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox15.Controls.Add(this.panel2);
            this.groupBox15.Controls.Add(this.panel3);
            this.groupBox15.Controls.Add(this.tableLayoutPanel4);
            this.groupBox15.Controls.Add(this.textBox1);
            this.groupBox15.ForeColor = System.Drawing.Color.Black;
            this.groupBox15.Location = new System.Drawing.Point(4, 7);
            this.groupBox15.MaximumSize = new System.Drawing.Size(1280, 800);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(1009, 554);
            this.groupBox15.TabIndex = 41;
            this.groupBox15.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel2.Controls.Add(this.panel23);
            this.panel2.Controls.Add(this.panel24);
            this.panel2.Controls.Add(this.checkBox8);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.checkBox7);
            this.panel2.Location = new System.Drawing.Point(6, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(997, 17);
            this.panel2.TabIndex = 31;
            this.panel2.Visible = false;
            // 
            // panel23
            // 
            this.panel23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel23.Controls.Add(this.label70);
            this.panel23.Controls.Add(this.textBox58);
            this.panel23.Controls.Add(this.label71);
            this.panel23.Controls.Add(this.textBox59);
            this.panel23.Controls.Add(this.label72);
            this.panel23.Controls.Add(this.textBox60);
            this.panel23.Controls.Add(this.label73);
            this.panel23.Controls.Add(this.textBox61);
            this.panel23.Location = new System.Drawing.Point(138, 244);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(125, 137);
            this.panel23.TabIndex = 42;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.Location = new System.Drawing.Point(59, 88);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(37, 14);
            this.label70.TabIndex = 7;
            this.label70.Text = "Profit";
            // 
            // textBox58
            // 
            this.textBox58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox58.Enabled = false;
            this.textBox58.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox58.Location = new System.Drawing.Point(61, 104);
            this.textBox58.Name = "textBox58";
            this.textBox58.Size = new System.Drawing.Size(53, 23);
            this.textBox58.TabIndex = 6;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label71.Location = new System.Drawing.Point(1, 88);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(56, 14);
            this.label71.TabIndex = 5;
            this.label71.Text = "Comm %";
            // 
            // textBox59
            // 
            this.textBox59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox59.Enabled = false;
            this.textBox59.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox59.Location = new System.Drawing.Point(1, 104);
            this.textBox59.Name = "textBox59";
            this.textBox59.Size = new System.Drawing.Size(53, 23);
            this.textBox59.TabIndex = 4;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label72.Location = new System.Drawing.Point(1, 48);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(38, 14);
            this.label72.TabIndex = 3;
            this.label72.Text = "Name";
            // 
            // textBox60
            // 
            this.textBox60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox60.Enabled = false;
            this.textBox60.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox60.Location = new System.Drawing.Point(2, 62);
            this.textBox60.Name = "textBox60";
            this.textBox60.Size = new System.Drawing.Size(113, 23);
            this.textBox60.TabIndex = 2;
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label73.Location = new System.Drawing.Point(4, 10);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(86, 14);
            this.label73.TabIndex = 1;
            this.label73.Text = "Com Agent No";
            // 
            // textBox61
            // 
            this.textBox61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox61.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox61.Location = new System.Drawing.Point(2, 24);
            this.textBox61.Name = "textBox61";
            this.textBox61.Size = new System.Drawing.Size(114, 23);
            this.textBox61.TabIndex = 0;
            this.textBox61.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox61_KeyPress);
            // 
            // panel24
            // 
            this.panel24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel24.Controls.Add(this.label74);
            this.panel24.Controls.Add(this.textBox62);
            this.panel24.Controls.Add(this.label75);
            this.panel24.Controls.Add(this.textBox63);
            this.panel24.Controls.Add(this.label76);
            this.panel24.Controls.Add(this.textBox64);
            this.panel24.Location = new System.Drawing.Point(7, 245);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(127, 136);
            this.panel24.TabIndex = 41;
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label74.Location = new System.Drawing.Point(1, 88);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(101, 14);
            this.label74.TabIndex = 5;
            this.label74.Text = "Previous Balance";
            // 
            // textBox62
            // 
            this.textBox62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox62.Enabled = false;
            this.textBox62.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox62.Location = new System.Drawing.Point(1, 104);
            this.textBox62.Name = "textBox62";
            this.textBox62.Size = new System.Drawing.Size(100, 23);
            this.textBox62.TabIndex = 4;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label75.Location = new System.Drawing.Point(1, 48);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(38, 14);
            this.label75.TabIndex = 3;
            this.label75.Text = "Name";
            // 
            // textBox63
            // 
            this.textBox63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox63.Enabled = false;
            this.textBox63.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox63.Location = new System.Drawing.Point(2, 62);
            this.textBox63.Name = "textBox63";
            this.textBox63.Size = new System.Drawing.Size(117, 23);
            this.textBox63.TabIndex = 2;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(2, 10);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(71, 14);
            this.label76.TabIndex = 1;
            this.label76.Text = "Member No";
            // 
            // textBox64
            // 
            this.textBox64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox64.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox64.Location = new System.Drawing.Point(2, 24);
            this.textBox64.Name = "textBox64";
            this.textBox64.Size = new System.Drawing.Size(117, 23);
            this.textBox64.TabIndex = 0;
            this.textBox64.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox64_KeyPress);
            this.textBox64.Leave += new System.EventHandler(this.textBox64_Leave);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox8.Location = new System.Drawing.Point(23, 222);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(70, 24);
            this.checkBox8.TabIndex = 40;
            this.checkBox8.Text = "Credit";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.button6);
            this.panel10.Controls.Add(this.label32);
            this.panel10.Controls.Add(this.textBox18);
            this.panel10.Controls.Add(this.button5);
            this.panel10.Controls.Add(this.textBox12);
            this.panel10.Controls.Add(this.textBox16);
            this.panel10.Controls.Add(this.label28);
            this.panel10.Controls.Add(this.textBox15);
            this.panel10.Controls.Add(this.label31);
            this.panel10.Controls.Add(this.label29);
            this.panel10.Controls.Add(this.label30);
            this.panel10.Controls.Add(this.textBox14);
            this.panel10.Controls.Add(this.textBox13);
            this.panel10.Controls.Add(this.label33);
            this.panel10.Controls.Add(this.textBox19);
            this.panel10.Controls.Add(this.textBox17);
            this.panel10.Location = new System.Drawing.Point(6, 62);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(255, 160);
            this.panel10.TabIndex = 15;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkCyan;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button6.FlatAppearance.BorderSize = 2;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(110, 122);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(142, 39);
            this.button6.TabIndex = 34;
            this.button6.Text = "Cancel Redeem";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(5, 80);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(86, 15);
            this.label32.TabIndex = 30;
            this.label32.Text = "Eligible Points";
            // 
            // textBox18
            // 
            this.textBox18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox18.Location = new System.Drawing.Point(93, 76);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(155, 23);
            this.textBox18.TabIndex = 31;
            this.textBox18.Text = "0";
            this.textBox18.TextChanged += new System.EventHandler(this.textBox18_TextChanged);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkCyan;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button5.FlatAppearance.BorderSize = 2;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(12, 122);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 39);
            this.button5.TabIndex = 28;
            this.button5.Text = "Redeem";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox12
            // 
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(92, 3);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(155, 23);
            this.textBox12.TabIndex = 9;
            this.textBox12.TextChanged += new System.EventHandler(this.textBox12_TextChanged);
            // 
            // textBox16
            // 
            this.textBox16.Enabled = false;
            this.textBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(119, 140);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(100, 23);
            this.textBox16.TabIndex = 14;
            this.textBox16.Text = "0";
            this.textBox16.Visible = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(3, 4);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(85, 15);
            this.label28.TabIndex = 6;
            this.label28.Text = "Enter Card No";
            // 
            // textBox15
            // 
            this.textBox15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox15.Enabled = false;
            this.textBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.Location = new System.Drawing.Point(119, 99);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(100, 23);
            this.textBox15.TabIndex = 13;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(2, 102);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(113, 15);
            this.label31.TabIndex = 12;
            this.label31.Text = "Sale Points Earned";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(47, 29);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(41, 15);
            this.label29.TabIndex = 7;
            this.label29.Text = "Name";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(19, 53);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(71, 15);
            this.label30.TabIndex = 8;
            this.label30.Text = "Total Points";
            // 
            // textBox14
            // 
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox14.Enabled = false;
            this.textBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(93, 53);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(155, 23);
            this.textBox14.TabIndex = 11;
            this.textBox14.TextChanged += new System.EventHandler(this.textBox14_TextChanged);
            // 
            // textBox13
            // 
            this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox13.Enabled = false;
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(92, 28);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(155, 23);
            this.textBox13.TabIndex = 10;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(12, 149);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(88, 15);
            this.label33.TabIndex = 32;
            this.label33.Text = "redem amount";
            this.label33.Visible = false;
            // 
            // textBox19
            // 
            this.textBox19.Enabled = false;
            this.textBox19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox19.Location = new System.Drawing.Point(151, 70);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(100, 23);
            this.textBox19.TabIndex = 33;
            this.textBox19.Text = "PACNO";
            this.textBox19.Visible = false;
            // 
            // textBox17
            // 
            this.textBox17.Enabled = false;
            this.textBox17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.Location = new System.Drawing.Point(134, 117);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 23);
            this.textBox17.TabIndex = 29;
            this.textBox17.Visible = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Chocolate;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button9.FlatAppearance.BorderSize = 2;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(173, 7);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(80, 54);
            this.button9.TabIndex = 5;
            this.button9.Text = "Cancel F9";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Chocolate;
            this.button11.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button11.FlatAppearance.BorderSize = 2;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(89, 7);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(80, 54);
            this.button11.TabIndex = 4;
            this.button11.Text = "Calculate F8";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Chocolate;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button7.FlatAppearance.BorderSize = 2;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(5, 7);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(80, 54);
            this.button7.TabIndex = 2;
            this.button7.Text = "Stock F6";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox7.Location = new System.Drawing.Point(147, 221);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(71, 24);
            this.checkBox7.TabIndex = 43;
            this.checkBox7.Text = "Agent";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.dataGridView4, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(7, 44);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(995, 425);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView4.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView4.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView4.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView4.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(154)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView4.EnableHeadersVisualStyles = false;
            this.dataGridView4.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView4.Location = new System.Drawing.Point(3, 3);
            this.dataGridView4.MultiSelect = false;
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(989, 419);
            this.dataGridView4.TabIndex = 7;
            this.dataGridView4.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellEndEdit);
            this.dataGridView4.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView4_EditingControlShowing);
            this.dataGridView4.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView4_UserAddedRow);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(616, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 20);
            this.textBox1.TabIndex = 32;
            // 
            // Frm_POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1016, 570);
            this.Controls.Add(this.groupBox15);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_POS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Deactivate += new System.EventHandler(this.Frm_POS_Deactivate);
            this.Load += new System.EventHandler(this.Frm_POS_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewDialog BillPrintPreview;
        private System.Drawing.Printing.PrintDocument printDocument3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox SVatAmt;
        private System.Windows.Forms.TextBox SDue;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox txtSAmount;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtSDiscount;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtSTotal;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox textBox58;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.TextBox textBox59;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox textBox60;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.TextBox textBox61;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.TextBox textBox62;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.TextBox textBox63;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.TextBox textBox64;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.TextBox textBox1;

    }
}