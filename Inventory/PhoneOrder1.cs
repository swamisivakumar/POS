using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMDal;
using System.Collections;
using System.IO;
using GenCode128;

namespace Inventory
{
    public partial class PhoneOrder1 : Form
    {
        #region global Declaration for custom messagebox
        FrmMessage.enumMessageIcon InformationIcon = FrmMessage.enumMessageIcon.Information;
        FrmMessage.enumMessageIcon QuestionIcon = FrmMessage.enumMessageIcon.Question;
        FrmMessage.enumMessageIcon ErrorIcon = FrmMessage.enumMessageIcon.Error;

        FrmMessage.enumMessageButton OkButton = FrmMessage.enumMessageButton.OK;
        FrmMessage.enumMessageButton YesNoButton = FrmMessage.enumMessageButton.YesNo;
        FrmMessage.enumMessageButton OkCancelButton = FrmMessage.enumMessageButton.OKCancel;
        string caption = "Inventory Management";
        #endregion


        SQLHelper sqlhelper = new SQLHelper();
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds9 = new DataSet();
        Int32 PCUSID;
        int RNO;

        decimal pric = 0;
        Bitmap bm;
        int i = 0;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        DataTable Faabee = new DataTable();

        int PostCodeID = 0;
        int AreaID = 0;
        int CustID = 0;
        Button btnfirst = new Button();
       
        public PhoneOrder1()
        {
            InitializeComponent();
        }




        private void generateCategoryButtons3()
        {
            //DynamicCategorybtn2_Click(btnfirst, e);

            sqlhelper = new SQLHelper();
            ds2 = new DataSet();
            ds2 = sqlhelper.ExecuteQueries("select CategoryID,CategoryName from GetStockCategories");
            if (ds2.Tables[0].Rows.Count > 0)
            {
                int y = 3;
                int x = 3;
                for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                {
                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    Button DynamicCategorybtn2 = new Button();
                    DynamicCategorybtn2.Name = "btn" + ds2.Tables[0].Rows[i]["CategoryID"].ToString();
                    btnfirst.Name = "btn" + ds2.Tables[0].Rows[0]["CategoryID"].ToString();
                    DynamicCategorybtn2.Text = ds2.Tables[0].Rows[i]["CategoryName"].ToString();
                    DynamicCategorybtn2.Size = new Size(145, 40);

                    ToolTip1.SetToolTip(DynamicCategorybtn2, DynamicCategorybtn2.Text);

                    DynamicCategorybtn2.Height = 40;
                    DynamicCategorybtn2.AutoSize = true;
                    DynamicCategorybtn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    DynamicCategorybtn2.BackgroundImage = global::Inventory.Properties.Resources.btn_login1;
                    DynamicCategorybtn2.Cursor = System.Windows.Forms.Cursors.Hand;
                    //DynamicCategorybtn.BackColor = System.Drawing.Color.Orange;
                    //DynamicCategorybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(94)))));
                    //DynamicCategorybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(133)))), ((int)(((byte)(51)))));
                    DynamicCategorybtn2.FlatAppearance.BorderSize = 0;
                    DynamicCategorybtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    DynamicCategorybtn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                    DynamicCategorybtn2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                    DynamicCategorybtn2.UseVisualStyleBackColor = true;

                    //DynamicCategorybtn.Image = ;
                    DynamicCategorybtn2.Location = new Point(x, y);
                    DynamicCategorybtn2.Visible = true;
                    panel14.Controls.Add(DynamicCategorybtn2);
                    x = x + DynamicCategorybtn2.Size.Width + 5;
                    DynamicCategorybtn2.Click += new System.EventHandler(DynamicCategorybtn2_Click);
                }
            }

        }

        private void generateCategoryButtons1()
        {
            //DynamicCategorybtn1_Click(btnfirst, e);

            sqlhelper = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelper.ExecuteQueries("select CategoryID,CategoryName from GetStockCategories");
            if (ds.Tables[0].Rows.Count > 0)
            {
                int y = 3;
                int x = 3;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    Button DynamicCategorybtn1 = new Button();
                    DynamicCategorybtn1.Name = "btn" + ds.Tables[0].Rows[i]["CategoryID"].ToString();
                    btnfirst.Name = "btn" + ds.Tables[0].Rows[0]["CategoryID"].ToString();
                    DynamicCategorybtn1.Text = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                    DynamicCategorybtn1.Size = new Size(145, 40);

                    ToolTip1.SetToolTip(DynamicCategorybtn1, DynamicCategorybtn1.Text);

                    DynamicCategorybtn1.Height = 40;
                    DynamicCategorybtn1.AutoSize = true;
                    DynamicCategorybtn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    DynamicCategorybtn1.BackgroundImage = global::Inventory.Properties.Resources.btn_login1;
                    DynamicCategorybtn1.Cursor = System.Windows.Forms.Cursors.Hand;
                    //DynamicCategorybtn.BackColor = System.Drawing.Color.Orange;
                    //DynamicCategorybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(94)))));
                    //DynamicCategorybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(133)))), ((int)(((byte)(51)))));
                    DynamicCategorybtn1.FlatAppearance.BorderSize = 0;
                    DynamicCategorybtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    DynamicCategorybtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                    DynamicCategorybtn1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                    DynamicCategorybtn1.UseVisualStyleBackColor = true;

                    //DynamicCategorybtn.Image = ;
                    DynamicCategorybtn1.Location = new Point(x, y);
                    DynamicCategorybtn1.Visible = true;
                    panel8.Controls.Add(DynamicCategorybtn1);
                    x = x + DynamicCategorybtn1.Size.Width + 5;
                    DynamicCategorybtn1.Click += new System.EventHandler(DynamicCategorybtn1_Click);
                }
            }

        }

        private void generateCategoryButtons()
        {
            sqlhelper = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelper.ExecuteQueries("select CategoryID,CategoryName from GetStockCategories");
            if (ds.Tables[0].Rows.Count > 0)
            {
                int y = 3;
                int x = 3;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    Button DynamicCategorybtn = new Button();
                    DynamicCategorybtn.Name = "btn" + ds.Tables[0].Rows[i]["CategoryID"].ToString();
                    btnfirst.Name = "btn" + ds.Tables[0].Rows[0]["CategoryID"].ToString();
                    DynamicCategorybtn.Text = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                    DynamicCategorybtn.Size = new Size(145, 40);

                    ToolTip1.SetToolTip(DynamicCategorybtn, DynamicCategorybtn.Text);

                    DynamicCategorybtn.Height = 40;
                    DynamicCategorybtn.AutoSize = true;
                    DynamicCategorybtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    DynamicCategorybtn.BackgroundImage = global::Inventory.Properties.Resources.btn_login1;
                    DynamicCategorybtn.Cursor = System.Windows.Forms.Cursors.Hand;
                    //DynamicCategorybtn.BackColor = System.Drawing.Color.Orange;
                    //DynamicCategorybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(94)))));
                    //DynamicCategorybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(133)))), ((int)(((byte)(51)))));
                    DynamicCategorybtn.FlatAppearance.BorderSize = 0;
                    DynamicCategorybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    DynamicCategorybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                    DynamicCategorybtn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                    DynamicCategorybtn.UseVisualStyleBackColor = true;

                    //DynamicCategorybtn.Image = ;
                    DynamicCategorybtn.Location = new Point(x, y);
                    DynamicCategorybtn.Visible = true;
                    pnlCategory.Controls.Add(DynamicCategorybtn);
                    x = x + DynamicCategorybtn.Size.Width + 5;
                    DynamicCategorybtn.Click += new System.EventHandler(DynamicCategorybtn_Click);



                    //----------------------------------------------------------------------

                    // Button DynamicCategorybtn1 = new Button();
                    // DynamicCategorybtn1.Name = "btn" + ds.Tables[0].Rows[i]["CategoryID"].ToString();
                    // btnfirst.Name = "btn" + ds.Tables[0].Rows[0]["CategoryID"].ToString();
                    // DynamicCategorybtn1.Text = ds.Tables[0].Rows[i]["CategoryName"].ToString();
                    // DynamicCategorybtn1.Size = new Size(145, 40);

                    // ToolTip1.SetToolTip(DynamicCategorybtn, DynamicCategorybtn.Text);

                    // DynamicCategorybtn1.Height = 40;
                    // DynamicCategorybtn1.AutoSize = true;
                    // DynamicCategorybtn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    // DynamicCategorybtn1.BackgroundImage = global::Inventory.Properties.Resources.btn_login1;
                    // DynamicCategorybtn1.Cursor = System.Windows.Forms.Cursors.Hand;
                    // //DynamicCategorybtn.BackColor = System.Drawing.Color.Orange;
                    // //DynamicCategorybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(94)))));
                    // //DynamicCategorybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(133)))), ((int)(((byte)(51)))));
                    // DynamicCategorybtn1.FlatAppearance.BorderSize = 0;
                    // DynamicCategorybtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    // DynamicCategorybtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                    // DynamicCategorybtn1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                    // DynamicCategorybtn1.UseVisualStyleBackColor = true;

                    // //DynamicCategorybtn.Image = ;
                    // DynamicCategorybtn1.Location = new Point(x, y);
                    // DynamicCategorybtn1.Visible = true;
                    //panel8.Controls.Add(DynamicCategorybtn1);
                    // x = x + DynamicCategorybtn1.Size.Width + 5;
                    // DynamicCategorybtn1.Click += new System.EventHandler(DynamicCategorybtn_Click);


                }

            }
        }


        private void DynamicCategorybtn_Click(object sender, EventArgs e)
        {
            GroupPanel.Controls.Clear();
            int y = 5;
            int x = 5;
            int count = 1;
            Button DynamicBtn = (sender as Button);
            if (!string.IsNullOrEmpty(DynamicBtn.Name.ToString()))
            {
                string DynamicCategoryID = DynamicBtn.Name.Substring(3, DynamicBtn.Name.Length - 3);
                DataSet dds = new DataSet();
                SQLHelper sqlhelper = new SQLHelper();
                dds = sqlhelper.ExecuteQueries("Select * from GetItemsForCashier where CategoryID=" + DynamicCategoryID + "");
                string dir = Application.StartupPath;//Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                dir = System.IO.Path.Combine(dir, "InventoryImages");
                for (int a = 0; a < dds.Tables[0].Rows.Count; a++)
                {

                    if ((count) % 7 > 0)
                    {
                        Panel panel = new Panel();
                        panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(142)))), ((int)(((byte)(224)))));
                        panel.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        panel.Size = new System.Drawing.Size(62, 55);
                        panel.Location = new Point(x, y);
                        panel.Cursor = System.Windows.Forms.Cursors.Hand;

                        System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();

                        //PictureBox pb = new PictureBox();
                        //pb.Size = new Size(55, 50);
                        //pb.Cursor = System.Windows.Forms.Cursors.Hand;
                        //pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        //pb.Location = new Point(5, 22);
                        //pb.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        //if (!string.IsNullOrEmpty(dds.Tables[0].Rows[a]["ImageName"].ToString()))
                        //{
                        //    pb.Image = System.Drawing.Image.FromFile(dir + "\\" + dds.Tables[0].Rows[a]["ImageName"].ToString());
                        //}


                        // label for displaying Item Name on Image.
                        Label DynamicLabel = new Label();
                        DynamicLabel.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        DynamicLabel.BackColor = Color.Transparent;
                        DynamicLabel.Text = dds.Tables[0].Rows[a]["ItemName"].ToString();
                        DynamicLabel.Location = new Point(1, 8);
                        DynamicLabel.Size = new Size(100, 12);
                        DynamicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        DynamicLabel.Cursor = System.Windows.Forms.Cursors.Hand;

                        // ToolTip1.SetToolTip(pb, DynamicLabel.Text);
                        ToolTip1.SetToolTip(DynamicLabel, DynamicLabel.Text);
                        ///////////////////////////////////////////////////////////////////////////////////////////////

                        // label for displaying Amount
                        Label DynamicLabl = new Label();
                        DynamicLabl.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        DynamicLabl.BackColor = System.Drawing.Color.Transparent;
                        DynamicLabl.Location = new Point(1, 35);
                        DynamicLabl.Text = "Rs:" + dds.Tables[0].Rows[a]["saleprice"].ToString();
                        DynamicLabl.Size = new Size(80, 12);
                        DynamicLabl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        DynamicLabl.Cursor = System.Windows.Forms.Cursors.Hand;
                        ToolTip1.SetToolTip(DynamicLabl, DynamicLabl.Text);
                        /////////////////////////////////////////////////////////////////////////////////////////////

                        //    pb.Controls.Add(DynamicLabel);                    
                        panel.Controls.Add(DynamicLabel);
                        //  panel.Controls.Add(pb);
                        panel.Controls.Add(DynamicLabl);
                        GroupPanel.Controls.Add(panel);
                        // groupBox2.Controls.Add(pb);
                        x = x + 64;
                        // pb.Click += new System.EventHandler(PbItems_Click);
                        DynamicLabl.Click += new System.EventHandler(PbItems_Click);
                        DynamicLabel.Click += new System.EventHandler(PbItems_Click);
                        panel.Click += new System.EventHandler(PbItems_Click);
                        panel.Paint += GroupPanel_Paint;
                    }
                    else
                    {
                        Panel panel = new Panel();
                        panel.BackColor = System.Drawing.Color.WhiteSmoke;
                        panel.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        panel.Size = new System.Drawing.Size(62, 55);
                        panel.Location = new Point(x, y);
                        panel.Cursor = System.Windows.Forms.Cursors.Hand;

                        System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();

                        //PictureBox pb = new PictureBox();
                        //pb.Size = new Size(55, 50);
                        //pb.Cursor = System.Windows.Forms.Cursors.Hand;
                        //pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        //pb.Location = new Point(5, 22);
                        //pb.Name = dds.Tables[0].Rows[a]["barcode"].ToString();

                        //if (!string.IsNullOrEmpty(dds.Tables[0].Rows[a]["ImageName"].ToString()))
                        //{
                        //    pb.Image = System.Drawing.Image.FromFile(dir + "\\" + dds.Tables[0].Rows[a]["ImageName"].ToString());
                        //}


                        // label for displaying Item Name on Image.
                        Label DynamicLabel = new Label();
                        DynamicLabel.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        DynamicLabel.BackColor = Color.Transparent;
                        DynamicLabel.Text = dds.Tables[0].Rows[a]["ItemName"].ToString();
                        DynamicLabel.Location = new Point(1, 8);
                        DynamicLabel.Size = new Size(56, 12);
                        DynamicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        DynamicLabel.Cursor = System.Windows.Forms.Cursors.Hand;

                        // ToolTip1.SetToolTip(pb, DynamicLabel.Text);
                        ToolTip1.SetToolTip(DynamicLabel, DynamicLabel.Text);
                        ////////////////////////////////////////////////////

                        // label for displaying Amount
                        Label DynamicLabl = new Label();
                        DynamicLabl.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        DynamicLabl.BackColor = System.Drawing.Color.Transparent;
                        DynamicLabl.Location = new Point(1, 35);
                        DynamicLabl.Text = "Rs:" + dds.Tables[0].Rows[a]["saleprice"].ToString();
                        DynamicLabl.Size = new Size(80, 12);
                        DynamicLabl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        DynamicLabl.Cursor = System.Windows.Forms.Cursors.Hand;

                        ToolTip1.SetToolTip(DynamicLabl, DynamicLabl.Text);
                        ////////////////////////////////////////////////////////////

                        //    pb.Controls.Add(DynamicLabel);                    
                        panel.Controls.Add(DynamicLabel);
                        // panel.Controls.Add(pb);
                        panel.Controls.Add(DynamicLabl);
                        GroupPanel.Controls.Add(panel);
                        x = 5;
                        y = y + 57;
                        //pb.Click += new System.EventHandler(PbItems_Click);
                        DynamicLabl.Click += new System.EventHandler(PbItems_Click);
                        DynamicLabel.Click += new System.EventHandler(PbItems_Click);
                        panel.Click += new System.EventHandler(PbItems_Click);
                        panel.Paint += GroupPanel_Paint;
                    }
                    count++;
                }
            }
            else
            {
                FrmMessage.Show("Stock is not Available. Please Enter the Stock Details First");
            }
        }

        private void GroupPanel_Paint(object Sender, PaintEventArgs e)
        {
            Panel GBDynamic = (Panel)Sender;
            e.Graphics.Clear(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51))))));
            e.Graphics.DrawString(GBDynamic.Text, GBDynamic.Font, Brushes.Black, 0, 0);
            Rectangle Rect = GBDynamic.ClientRectangle;
            ControlPaint.DrawBorder3D(e.Graphics, Rect, Border3DStyle.RaisedInner);

        }
        private void PbItems_Click(object sender, EventArgs e)
        {
            PictureBox DynamicItemsBarcode = (sender as PictureBox);
            Label labelbarcode = (sender as Label);
            Panel GroupbxBarcode = (sender as Panel);
            DataSet dsstk = new DataSet();
            SQLHelper sqlh = new SQLHelper();
            if (DynamicItemsBarcode == null && GroupbxBarcode == null)
            {
                dsstk = sqlh.ExecuteQueries("select * from GetItemsForCashier where  Barcode='" + labelbarcode.Name.ToString() + "'");
            }
            else if (labelbarcode == null && GroupbxBarcode == null)
            {
                dsstk = sqlh.ExecuteQueries("select * from GetItemsForCashier where  Barcode='" + DynamicItemsBarcode.Name.ToString() + "'");
            }

            else if (labelbarcode == null && DynamicItemsBarcode == null)
            {
                dsstk = sqlh.ExecuteQueries("select * from GetItemsForCashier where Barcode='" + GroupbxBarcode.Name.ToString() + "'");
            }
            if (dsstk.Tables[0].Rows.Count > 0)
            {
                lblMaxQty.Text = string.Empty;
                lblMaxQty.Text = "Avail Quantity " + Convert.ToDecimal(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString());

                if (Convert.ToDecimal(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString()) <= 0)
                {
                    FrmMessage.Show("Stock is not available for this Item. Please Re-Order the Stock");
                }
                else
                {
                    if (Convert.ToDecimal(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString()) <= Convert.ToDecimal(dsstk.Tables[0].Rows[0]["ReOrderQuantity"].ToString()))
                    {
                        FrmMessage.Show("Stock has reached to the minimum quantity level !!! Please Re-Order the Stock.");
                    }

                    if (dt.Columns.Count < 1)
                    {
                        dt.Columns.Add("Item");
                        dt.Columns.Add("Price");
                        dt.Columns.Add("Qty");
                        dt.Columns.Add("Type");
                        dt.Columns.Add("Barcode");
                        dt.Columns.Add("ItemID");
                        dt.Columns.Add("CategoryID");
                        dt.Columns.Add("Vat(%)");
                        dt.Columns.Add("MRP");
                    }

                    //Serial Number Code
                    if (!dt.Columns.Contains("SNo"))
                    {
                        dt.Columns.Add("SNo");


                    }
                    //Serial No Code Ends


                    dt.AcceptChanges();
                    DataRow row = dt.NewRow();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Barcode"].ToString() == dsstk.Tables[0].Rows[0]["barcode"].ToString())
                            {
                                row["Qty"] = dt.Rows[i]["Qty"].ToString();
                                break;
                            }
                            else
                            {
                                row["Qty"] = "1";
                            }
                        }
                    }
                    else
                    {
                        row["Qty"] = "1";
                    }
                    row["ItemID"] = dsstk.Tables[0].Rows[0]["ItemID"].ToString();
                    row["CategoryID"] = dsstk.Tables[0].Rows[0]["CategoryID"].ToString();
                    row["Item"] = dsstk.Tables[0].Rows[0]["ItemName"].ToString();
                    row["Type"] = dsstk.Tables[0].Rows[0]["QtyType"].ToString();
                    row["Price"] = dsstk.Tables[0].Rows[0]["saleprice"].ToString();
                    row["Barcode"] = dsstk.Tables[0].Rows[0]["barcode"].ToString();
                    row["Vat(%)"] = dsstk.Tables[0].Rows[0]["VatPercent"].ToString();
                    row["MRP"] = dsstk.Tables[0].Rows[0]["MRP"].ToString();
                    dt.Rows.Add(row);
                    DataView dView = new DataView(dt);
                    string[] arrColumns = { "SNo", "Item", "Price", "Qty", "Type", "Barcode", "ItemID", "CategoryID", "Vat(%)", "MRP" };
                    dt = dView.ToTable(true, arrColumns);
                    dt.AcceptChanges();

                    //Serial Number Code
                    int p = 1;

                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["SNo"] = p.ToString();
                        p++;
                    }
                    //Serial No Code Ends


                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                    //dataGridView1.CurrentCell = dataGridView1.Rows.OfType<DataGridViewRow>().Last().Cells.OfType<DataGridViewCell>().First();
                    //dataGridView1.ClearSelection();

                    pric = 0;
                    decimal VatAmount = 0;
                    for (int k = 0; k < (dataGridView1.Rows.Count); k++)
                    {
                        //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                        pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()))), 2);
                        VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView1.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView1.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                    }
                    //txtTotalAmount.Text = pric.ToString();
                    txtGrandTotal.Text = pric.ToString();
                    txtVatAmount.Text = VatAmount.ToString();
                    txtBillpaid.Text = (Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2)).ToString();
                }
            }
        }

        private void PhoneOrders_Load(object sender, EventArgs e)
        {
            generateCategoryButtons();
            DynamicCategorybtn_Click(btnfirst, e);
            AutoSuggestItemns();


        }

        private void AutoSuggestItemns()
        {
            sqlhelper = new SQLHelper();
            ds = sqlhelper.ExecuteQueries("select ItemName from GetItemsForCashier");

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["ItemName"].ToString());
            }
            txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtItemName.AutoCompleteCustomSource = col;
            txtItemName.AutoCompleteMode = AutoCompleteMode.Suggest;

            textBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox5.AutoCompleteCustomSource = col;
            textBox5.AutoCompleteMode = AutoCompleteMode.Suggest;


            textBox10.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox10.AutoCompleteCustomSource = col;
            textBox10.AutoCompleteMode = AutoCompleteMode.Suggest;

            txtItemBarcode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtItemBarcode.AutoCompleteCustomSource = col;
            txtItemBarcode.AutoCompleteMode = AutoCompleteMode.Suggest;

        }

        static string trnNo;

        private void btnPay_Click(object sender, EventArgs e)
        {
            // dt.AcceptChanges();
            try
            {
                if (string.IsNullOrEmpty(txtBillpaid.Text) || dataGridView1.Rows.Count <= 0)
                {
                    FrmMessage.Show("You cannot Generate Bill without Items", caption, OkButton, ErrorIcon);
                }
                //else if (string.IsNullOrEmpty(txtCustName.Text) || string.IsNullOrEmpty(txtCustPhnNo.Text))
                //{
                //    FrmMessage.Show("Customer Details should not be Empty", caption, OkButton, ErrorIcon);
                //}
                else
                {
                    sqlhelper = new SQLHelper();
                    bool result;

                    //result = sqlhelper.ExecuteNonQuery("insert into Customers(CustName,Phone) values ('" + txtCustName.Text + "'," + txtCustPhnNo.Text + ")");
                    //if (result == true)
                    //{

                    ds = new DataSet();
                    int count;
                    ds = sqlhelper.ExecuteQueries("select TranNo from TransactionNo");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["TranNo"].ToString()))
                        {
                            count = 1;
                        }
                        else
                        {
                            count = int.Parse(ds.Tables[0].Rows[0]["TranNo"].ToString()) + 1;
                        }
                    }
                    else
                    {
                        count = 1;
                    }

                    string todaysDate = sqlhelper.ExecuteScalar("select format(date(),'ddmmyyyy')");
                    trnNo = todaysDate + count;
                    result = sqlhelper.ExecuteNonQuery("insert into Payment(TransactionNo,TotalAmount,DiscountAmount,BillPaid,CreatedBy)" +
                                                       "values ('" + trnNo + "','" + txtGrandTotal.Text + "','" + txtDiscount.Text + "', '" + txtBillpaid.Text + "'," +
                                                       "" + GlobalData.UserID + ")");

                    result = sqlhelper.ExecuteNonQuery("insert into TaxHistory(TransactionNo,TotalAmount,DiscountAmount,BillPaid,VATAmount,Paid,CreatedBy)" +
                                                     "values ('" + trnNo + "','" + txtGrandTotal.Text + "','" + txtDiscount.Text + "', '" + txtBillpaid.Text + "', '" + txtVatAmount.Text + "', '" + txtDueAmt.Text + "'," +
                                                     "" + GlobalData.UserID + ")");


                    if (result == true)
                    {
                        

                        string PaymentId = sqlhelper.ExecuteScalar("select max(PaymentID) from Payment");

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {


                            result = sqlhelper.ExecuteNonQuery("insert into Transactions(PaymentID,Barcode,CategoryID,ItemID,SaleQty,VatPercent,ItemPrice,CreatedBy)" +
                                                               "values (" + PaymentId + ",'" + dataGridView1.Rows[i].Cells["Barcode"].Value.ToString() + "'," + dataGridView1.Rows[i].Cells["CategoryID"].Value.ToString() + "," +
                                                               "" + dataGridView1.Rows[i].Cells["ItemID"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Qty"].Value.ToString() + "," +
                                                               "" + dataGridView1.Rows[i].Cells["Vat(%)"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Price"].Value.ToString() + "," + GlobalData.UserID + ")");

                            result = sqlhelper.ExecuteNonQuery("Update Stock Set StockQuantity = (StockQuantity - " + dataGridView1.Rows[i].Cells["Qty"].Value.ToString() + ")" +
                                                               " where CategoryID= " + dataGridView1.Rows[i].Cells["CategoryID"].Value.ToString() + " and  " +
                                                               "ItemID=" + dataGridView1.Rows[i].Cells["ItemID"].Value.ToString() + " and Barcode='" + dataGridView1.Rows[i].Cells["Barcode"].Value.ToString() + "'");

                        }

                        if (result == true)
                        {
                            if (checkBox2.Checked == true)
                            {
                                if (string.IsNullOrEmpty(textBox37.Text))
                                {
                                }
                                else
                                {
                                    result = sqlhelper.ExecuteNonQuery("insert into DEALERCREDIT(DealerID,TransactionNo,TotalAmount,DiscountAmount,AfterDiscount,VATAmount,TOTALDUE,CreatedBy,STATUS)" +
                                                             "values ('" + DEALERID + "','" + trnNo + "','" + txtGrandTotal.Text + "', '" + txtDiscount.Text + "', '" + txtBillpaid.Text + "', " + txtVatAmount.Text + ", " + txtDueAmt.Text + ", " + GlobalData.UserID + ", 'CREDIT')");
                                    checkBox2.Checked = false;
                                    panel15.Visible = false;
                                    txtBal1.Text = string.Empty;
                                    textBox36.Text = string.Empty;
                                    textBox37.Text = string.Empty;

                                }
                            }

                            if (checkBox5.Checked == true)
                            {
                                if (string.IsNullOrEmpty(textBox53.Text))
                                {
                                }
                                else
                                {
                                    result = sqlhelper.ExecuteNonQuery("insert into AGENTEARNEDCOMISSION(ANO,TransactionNo,COMISSIONEARNED,COMISSION)" +
                                                             "values ('" + ANO + "','" + trnNo + "','" + txtAProfit1.Text + "', '" + txtACommission1.Text + "')");
                                    checkBox5.Checked = false;
                                    panel21.Visible = false;
                                    txtAProfit1.Text = string.Empty;
                                    txtACommission1.Text = string.Empty;
                                    textBox52.Text = string.Empty;
                                    textBox53.Text = string.Empty;

                                }
                            }

                         
                          


                           
                            

                        }
                    }

                    BillPrintPreview.Document = BillPrint;
                    BillPrintPreview.PrintPreviewControl.Zoom = 1;
                    BillPrintPreview.ShowDialog();


                    //BillPrintPreview2.Document = BillPrint2;
                    //BillPrintPreview2.PrintPreviewControl.Zoom = 1;
                    //BillPrintPreview2.ShowDialog();

                    //BillPrint2.Print();
                    FrmMessage.Show("Transaction Successful", caption, OkButton, InformationIcon);

                    button51_Click(sender, e);
                    txtVatAmount.Text = "0";
                    txtDueAmt.Text = "0";
                    txtGrandTotal.Text = "0";
                    txtBillpaid.Text = "0";
                    txtDiscount.Text = "0";
                   

                    //PhoneOrders f2 = new PhoneOrders();
                    //f2.MdiParent = this.ParentForm;
                    //f2.Show();

                    //PhoneOrders form = new PhoneOrders
                    //{
                    //    MdiParent = this.MdiParent,
                    //    Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    //        | System.Windows.Forms.AnchorStyles.Left)
                    //        | System.Windows.Forms.AnchorStyles.Right))),
                    //    Dock = DockStyle.Fill
                    //};

                    //form.Show();

                    //}


                }
            }
            catch (Exception ex)
            {
                FrmMessage.Show(ex.ToString());
            }
        }
        int xpos;
        private void btnRight_Click(object sender, EventArgs e)
        {

            if (xpos > pnlCategory.HorizontalScroll.Maximum + 905)
            {
                xpos = pnlCategory.HorizontalScroll.Maximum + 905;

            }
            else
            {
                xpos += 905;
                pnlCategory.AutoScrollPosition = new Point(xpos, 0);
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (xpos < 1)
            {
                xpos = 0;

            }
            else
            {
                xpos -= 905;
                pnlCategory.AutoScrollPosition = new Point(xpos, 0);
            }
        }

        private void PhoneOrders_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn dc in dataGridView1.Columns)
            {
                if (dc.Index.Equals(2))
                {
                    dc.ReadOnly = false;
                }
                else
                {
                    dc.ReadOnly = true;
                }

            }

        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                DataSet dsstk = new DataSet();
                SQLHelper sqlh = new SQLHelper();
                dsstk = sqlh.ExecuteQueries("select * from GetItemsForCashier where barcode='" + dataGridView1.Rows[e.RowIndex].Cells["barcode"].Value.ToString() + "'");
                if (dsstk.Tables[0].Rows.Count > 0)
                {
                    lblMaxQty.Text = "Avail Quantity " + Convert.ToDecimal(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString());

                    if (!string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value.ToString()))
                    {
                        if ((Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value.ToString())) > (Convert.ToDecimal(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString())))
                        {
                            FrmMessage.Show("You Cannot take more than " + lblMaxQty.Text + " for this Item", caption, OkButton, ErrorIcon);
                            dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value = Convert.ToDecimal(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString());
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["Qty"].Value = "1";
                    }
                }

                pric = 0;
                decimal VatAmount = 0;
                for (int k = 0; k < (dataGridView1.Rows.Count); k++)
                {
                    //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                    pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString()))), 2);
                    VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView1.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView1.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                }
                //txtTotalAmount.Text = pric.ToString();
                txtGrandTotal.Text = pric.ToString();
                txtVatAmount.Text = VatAmount.ToString();

                if (txtDiscount.Text != "0")
                {
                    txtBillpaid.Text = (Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2)).ToString();
                }
                else
                {
                    txtBillpaid.Text = txtGrandTotal.Text;
                }

            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //if (dataGridView1.Rows.Count != 0)
            //{
            //    pric = 0;
            //    decimal VatAmount = 0;
            //    for (int k = 0; k < (dataGridView1.Rows.Count); k++)
            //    {
            //        //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
            //        pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString()))), 2);
            //        VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView1.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView1.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
            //    }
            //    //txtTotalAmount.Text = pric.ToString();
            //    txtGrandTotal.Text = pric.ToString();
            //    txtVatAmount.Text = VatAmount.ToString();
            //    if (txtDiscount.Text != "0")
            //    {
            //        txtBillpaid.Text = (Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2)).ToString();
            //    }
            //    else
            //    {
            //        txtBillpaid.Text = txtGrandTotal.Text;
            //    }

            //}
            //else if (txtGrandTotal.Text != "0" || txtDueAmt.Text != "0")
            //{
            //    pric = 0;
            //    decimal VatAmount = 0;
            //    for (int k = 0; k < (dataGridView1.Rows.Count); k++)
            //    {
            //        //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
            //        pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString()))), 2);
            //        VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView1.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView1.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
            //    }
            //    //txtTotalAmount.Text = pric.ToString();
            //    txtGrandTotal.Text = pric.ToString();
            //    txtVatAmount.Text = VatAmount.ToString();
            //    if (txtDiscount.Text != "0")
            //    {
            //        txtBillpaid.Text = (Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2)).ToString();
            //    }
            //    else
            //    {
            //        txtBillpaid.Text = txtGrandTotal.Text;
            //    }

            //}
            //else
            //{
            //    txtGrandTotal.Text = "0";
            //    txtBillpaid.Text = "0";
            //    txtDiscount.Text = "0";
            //    lblMaxQty.Text = string.Empty;
            //    txtVatAmount.Text = "0";
            //  txtVatAmt3.Text = "0";
            //}
            ////dt.AcceptChanges();
        }



        DataTable dtshop = new DataTable();
        private void generateBill(DataTable dtshop, DataTable dtbill)
        {

        }


        private void BillPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {           

            try
            {
                if (!dt.Columns.Contains("sno"))
                {
                    dt.Columns.Add("sno");

                    int k = 1;
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["sno"] = k.ToString();
                        k++;
                    }
                }                

                Font font = new Font("Courier New", 9, System.Drawing.FontStyle.Bold);

                Font Header = new Font("Calibri", 11, System.Drawing.FontStyle.Bold);
                e.Graphics.DrawString("SALE INVOICE", Header, Brushes.Black, float.Parse("150"), float.Parse("0"));
                e.Graphics.DrawString(dtshop.Rows[0]["ShopName"].ToString(), Header, Brushes.Black, float.Parse("150"), float.Parse("15"));

                e.Graphics.DrawString("Address : " + dtshop.Rows[0]["Address"].ToString(), Header, Brushes.Black, float.Parse("150"), float.Parse("30"));
                 //e.Graphics.DrawString("Ph: " + dtshop.Rows[0]["ContactNo"].ToString(), Header, Brushes.Black, float.Parse("50"), float.Parse("45"));
                e.Graphics.DrawString("TIN No : " + dtshop.Rows[0]["TIN"].ToString(), Header, Brushes.Black, float.Parse("150"), float.Parse("45"));





                //Header               

                //  e.Graphics.DrawString("Sales Bill", Header, Brushes.Black, float.Parse("15"), float.Parse("0"));

                e.Graphics.DrawString("Bill Date: " + DateTime.Now.ToString("dd-MM-yyyy"), font, Brushes.Black, float.Parse("5"), float.Parse("60"));

                e.Graphics.DrawString("Bill No: " + trnNo, font, Brushes.Black, float.Parse("5"), float.Parse("75"));

                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), float.Parse("95"));

                e.Graphics.DrawString("S.No", font, Brushes.Black, float.Parse("5"), float.Parse("105"));

                e.Graphics.DrawString("Item(Qty)", font, Brushes.Black, float.Parse("50"), float.Parse("105"));

                e.Graphics.DrawString("MRP", font, Brushes.Black, float.Parse("150"), float.Parse("105"));

                e.Graphics.DrawString("Rate", font, Brushes.Black, float.Parse("235"), float.Parse("105"));
                e.Graphics.DrawString("Total", font, Brushes.Black, float.Parse("320"), float.Parse("105"));

                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), float.Parse("120"));

                //Header

                //Body
                float xx = 135;
                float yy = 5;
                decimal countqty = 0;
                decimal GrandTotal = 0;


               


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    

                    decimal TotalAmount;
                    //dt.AcceptChanges();
                    if (dt.Rows[i]["Item"].ToString().Length > 10)
                    {

                        
                        string splitItemName1 = (dt.Rows[i]["Item"].ToString().Substring(0, 10));
                        string splitItemName2 = (dt.Rows[i]["Item"].ToString().Substring(10));

                        e.Graphics.DrawString("" + dt.Rows[i]["sno"].ToString(), font, Brushes.Black, yy, xx);
                        yy = 50;

                        e.Graphics.DrawString(splitItemName1 + "-", font, Brushes.Black, yy, xx);
                        yy = 50;
                        xx = xx + 15;

                        e.Graphics.DrawString(splitItemName2 + " (" + dt.Rows[i]["Qty"].ToString() + ")", font, Brushes.Black, yy, xx);
                                             

                        yy = 150;
                        xx = xx - 15;
                        e.Graphics.DrawString("" + dt.Rows[i]["MRP"].ToString() + "/" + dt.Rows[i]["Type"].ToString() + "", font, Brushes.Black, yy, xx);

                       
                       

                        yy = 235;
                        e.Graphics.DrawString("" + dt.Rows[i]["Price"].ToString(), font, Brushes.Black, yy, xx);

                        yy = 320;
                        TotalAmount = Math.Round((decimal.Parse(dt.Rows[i]["Qty"].ToString()) * decimal.Parse(dt.Rows[i]["Price"].ToString())), 2);
                        e.Graphics.DrawString("" + TotalAmount.ToString(), font, Brushes.Black, yy, xx);

                        
                        //e.Graphics.DrawString("" + dt.Rows[i]["Vat(%)"].ToString(), font, Brushes.Black, yy, xx);

                        xx = xx + 55;
                        yy = 5;
                    }
                    else
                    {
                        e.Graphics.DrawString("" + dt.Rows[i]["sno"].ToString(), font, Brushes.Black, yy, xx);
                        yy = 50;
                        e.Graphics.DrawString(dt.Rows[i]["Item"].ToString() + " (" + dt.Rows[i]["Qty"].ToString() + ")", font, Brushes.Black, yy, xx);
                        //yy = 60;
                        //xx = xx + 15;
                        //e.Graphics.DrawString("" + dt.Rows[i]["MRP"].ToString() + ")/" + dt.Rows[i]["Type"].ToString() + "", font, Brushes.Black, yy, xx);

                        yy = 150;
                        //xx = xx - 15;
                        e.Graphics.DrawString("" + dt.Rows[i]["MRP"].ToString() + "/" + dt.Rows[i]["Type"].ToString() + "", font, Brushes.Black, yy, xx);

                       
                        yy = 235;
                        e.Graphics.DrawString("" + dt.Rows[i]["Price"].ToString(), font, Brushes.Black, yy, xx);

                        
                        yy = 320;
                        TotalAmount = Math.Round((decimal.Parse(dt.Rows[i]["Qty"].ToString()) * decimal.Parse(dt.Rows[i]["Price"].ToString())), 2);
                        e.Graphics.DrawString("" + TotalAmount.ToString(), font, Brushes.Black, yy, xx);
                        //e.Graphics.DrawString("" + dt.Rows[i]["Vat(%)"].ToString(), font, Brushes.Black, yy, xx);
                        xx = xx + 40;
                        yy = 5;
                    }
                    // countqty = countqty + decimal.Parse(dt.Rows[i]["Qty"].ToString());
                    GrandTotal = GrandTotal + TotalAmount;
                }
                //Footer
                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);

                xx = xx + 20;
                //e.Graphics.DrawString("Tot Qty:", font, Brushes.Black, float.Parse("5"), xx);

                //e.Graphics.DrawString(countqty.ToString(), font, Brushes.Black, float.Parse("75"), xx);

                e.Graphics.DrawString("Total :", font, Brushes.Black, float.Parse("172"), xx);

                e.Graphics.DrawString("" + GrandTotal.ToString(), font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Discount : ", font, Brushes.Black, float.Parse("150"), xx);

                e.Graphics.DrawString(txtDiscount.Text + "", font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("After Discount :", font, Brushes.Black, float.Parse("102"), xx);

                e.Graphics.DrawString(txtBillpaid.Text, font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Vat Amt :", font, Brushes.Black, float.Parse("155"), xx);

                e.Graphics.DrawString(txtVatAmount.Text, font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Grand Total :", font, Brushes.Black, float.Parse("125"), xx);

                e.Graphics.DrawString(txtDueAmt.Text, font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;
                decimal Savings=0;
                foreach (DataRow dr in dt.Rows)
                {
                    Savings = Savings + (decimal.Parse(dr["MRP"].ToString()) * decimal.Parse(dr["Qty"].ToString()));

                }               


                e.Graphics.DrawString("Your Savings : ", font, Brushes.Black, float.Parse("117"), xx);

                e.Graphics.DrawString((decimal.Parse(Savings.ToString()) - decimal.Parse(txtBillpaid.Text)).ToString(), font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                Image myimg = Code128Rendering.MakeBarcodeImage(trnNo, 2, true);
                e.Graphics.DrawImage(myimg, 1, xx);


                xx = xx + 60;


                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);
                xx = xx + 20;

                e.Graphics.DrawString("NO EXCHANGE !!!", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;

                e.Graphics.DrawString("GOODS ONCE SOLD CAN NOT BE TAKEN BACK !!!", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;
                e.Graphics.DrawString("*** CONDITION APPLY ***", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;

                e.Graphics.DrawString("Thank You. Visit Again !!!", font, Brushes.Black, float.Parse("8"), xx);


                //xx = xx + 20;

                //e.Graphics.DrawString("Powered By VihaanSys", font, Brushes.Black, float.Parse("8"), xx);
                //Footer
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Cells["Barcode"].Value.ToString();
                DataSet dsstk = new DataSet();
                SQLHelper sqlh = new SQLHelper();
                dsstk = sqlh.ExecuteQueries("select * from GetItemsForCashier where barcode='" + dataGridView1.SelectedRows[0].Cells["Barcode"].Value.ToString() + "'");
                if (dsstk.Tables[0].Rows.Count > 0)
                {
                    lblMaxQty.Text = "Avail Quantity " + Convert.ToDecimal(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString());
                }
            }
        }



        private void txtBarcodetext_TextChanged(object sender, EventArgs e)
        {

            if (ChkActivatePopup1.Checked == true && !string.IsNullOrEmpty(txtItemName.Text.Trim()))
            {
                DataTable dtpopup = sqlhelper.ExecuteTables("select ItemID,CategoryID,barcode,ItemName,MRP,saleprice,StockQuantity as [Qty Available],QtyType,VatPercent from GetItemsForCashier where (ItemName like '" + txtItemName.Text + "%' or MBarcode like'" + txtItemName.Text + "%' or Barcode like'" + txtItemName.Text + "%')");
                if (dtpopup.Rows.Count > 0)
                {
                    GlobalData.Dtpopup = dtpopup;
                    FRM_ITEMSPOPUP frm = new FRM_ITEMSPOPUP();
                    frm.ShowDialog();
                    dtpopup = new DataTable();
                    DataView dv = new DataView(GlobalData.Dtpopup);
                    if (!string.IsNullOrEmpty(GlobalData.ItemIDs))
                    {
                        dv.RowFilter = "ItemID in (" + GlobalData.ItemIDs + ")";
                        dtpopup = dv.ToTable();
                    }

                    if (dtpopup.Rows.Count > 0)
                    {

                        for (int j = 0; j < dtpopup.Rows.Count; j++)
                        {
                            if (Convert.ToDecimal(dtpopup.Rows[j]["Qty Available"].ToString()) <= 0)
                            {
                                MessageBox.Show("Stock is not available for one or more seleted items");
                            }
                            else
                            {
                                if (dt.Columns.Count < 1)
                                {
                                    dt.Columns.Add("Item");
                                    dt.Columns.Add("Price");
                                    dt.Columns.Add("Qty");
                                    dt.Columns.Add("Type");
                                    dt.Columns.Add("Barcode");
                                    dt.Columns.Add("ItemID");
                                    dt.Columns.Add("CategoryID");
                                    dt.Columns.Add("Vat(%)");
                                    dt.Columns.Add("MRP");
                                }

                                //Serial Number Code
                                if (!dt.Columns.Contains("SNo"))
                                {
                                    dt.Columns.Add("SNo");


                                }
                                //Serial No Code Ends


                                dt.AcceptChanges();
                                DataRow row = dt.NewRow();

                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        if (dt.Rows[i]["Barcode"].ToString() == dtpopup.Rows[j]["barcode"].ToString())
                                        {
                                            row["Qty"] = dt.Rows[i]["Qty"].ToString();
                                        }
                                        else
                                        {
                                            row["Qty"] = "1";
                                        }
                                    }
                                }
                                else
                                {
                                    row["Qty"] = "1";
                                }
                                row["ItemID"] = dtpopup.Rows[j]["ItemID"].ToString();
                                row["CategoryID"] = dtpopup.Rows[j]["CategoryID"].ToString();
                                row["Item"] = dtpopup.Rows[j]["ItemName"].ToString();
                                row["Type"] = dtpopup.Rows[j]["QtyType"].ToString();
                                row["Price"] = dtpopup.Rows[j]["saleprice"].ToString();
                                row["Vat(%)"] = dtpopup.Rows[j]["VatPercent"].ToString();
                                row["Barcode"] = dtpopup.Rows[j]["barcode"].ToString();
                                row["MRP"] = dtpopup.Rows[j]["MRP"].ToString();
                                dt.Rows.Add(row);
                                DataView dView = new DataView(dt);
                                string[] arrColumns = {"SNo", "Item", "Price", "Qty", "Type", "Barcode", "ItemID", "CategoryID", "Vat(%)", "MRP" };
                                dt = dView.ToTable(true, arrColumns);
                                dt.AcceptChanges();
                            }
                        }

                        //Serial Number Code
                        int p = 1;

                        foreach (DataRow dr in dt.Rows)
                        {
                            dr["SNo"] = p.ToString();
                            p++;
                        }
                        //Serial No Code Ends


                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.Columns[6].Visible = false;
                        dataGridView1.Columns[7].Visible = false;
                        dataGridView1.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                        pric = 0;
                        decimal VatAmount = 0;
                        for (int k = 0; k < (dataGridView1.Rows.Count); k++)
                        {
                            //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                            pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()))), 2);
                            VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView1.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView1.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                        }
                        //txtTotalAmount.Text = pric.ToString();
                        txtGrandTotal.Text = pric.ToString();
                        txtVatAmount.Text = VatAmount.ToString();
                        txtBillpaid.Text = (Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2)).ToString();
                        txtItemName.Text = string.Empty;
                    }

                    GlobalData.Dtpopup = new DataTable();
                    GlobalData.ItemIDs = string.Empty;

                }

            }

            else
            {

                if (!string.IsNullOrEmpty(GlobalData.phCustId))
                {
                    txtItemName.Text = GlobalData.phCustId;
                }
                ds = new DataSet();
                sqlhelper = new SQLHelper();
                if (!string.IsNullOrEmpty(txtItemName.Text))
                {
                    ds = sqlhelper.ExecuteQueries("select * from GetItemsForCashier where ItemName like'" + txtItemName.Text + "' or MBarcode='" + txtItemName.Text + "'");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblMaxQty.Text = string.Empty;
                        lblMaxQty.Text = "Avail Quantity " + Convert.ToDecimal(ds.Tables[0].Rows[0]["StockQuantity"].ToString());

                        if (Convert.ToDecimal(ds.Tables[0].Rows[0]["StockQuantity"].ToString()) <= 0)
                        {
                            MessageBox.Show("Stock is not available for this Item");
                        }
                        else
                        {
                            if (dt.Columns.Count < 1)
                            {
                                dt.Columns.Add("Item");
                                dt.Columns.Add("Price");
                                dt.Columns.Add("Qty");
                                dt.Columns.Add("Type");
                                dt.Columns.Add("Barcode");
                                dt.Columns.Add("ItemID");
                                dt.Columns.Add("CategoryID");
                                dt.Columns.Add("Vat(%)");
                                dt.Columns.Add("MRP");
                            }
                            //Serial Number Code
                                if (!dt.Columns.Contains("SNo"))
                                {
                                    dt.Columns.Add("SNo");


                                }
                                //Serial No Code Ends

                            dt.AcceptChanges();
                            DataRow row = dt.NewRow();

                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["Barcode"].ToString() == ds.Tables[0].Rows[0]["barcode"].ToString())
                                    {
                                        row["Qty"] = dt.Rows[i]["Qty"].ToString();
                                    }
                                    else
                                    {
                                        row["Qty"] = "1";
                                    }
                                }
                            }
                            else
                            {
                                row["Qty"] = "1";
                            }
                            row["ItemID"] = ds.Tables[0].Rows[0]["ItemID"].ToString();
                            row["CategoryID"] = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                            row["Item"] = ds.Tables[0].Rows[0]["ItemName"].ToString();
                            row["Type"] = ds.Tables[0].Rows[0]["QtyType"].ToString();
                            row["Price"] = ds.Tables[0].Rows[0]["saleprice"].ToString();
                            row["Vat(%)"] = ds.Tables[0].Rows[0]["VatPercent"].ToString();
                            row["MRP"] = ds.Tables[0].Rows[0]["MRP"].ToString();

                            row["Barcode"] = ds.Tables[0].Rows[0]["barcode"].ToString();
                            dt.Rows.Add(row);
                            DataView dView = new DataView(dt);
                            string[] arrColumns = { "SNo","Item", "Price", "Qty", "Type", "Barcode", "ItemID", "CategoryID", "Vat(%)", "MRP" };
                            dt = dView.ToTable(true, arrColumns);
                            dt.AcceptChanges();

                            //Serial Number Code
                        int p = 1;

                        foreach (DataRow dr in dt.Rows)
                        {
                            dr["SNo"] = p.ToString();
                            p++;
                        }
                        //Serial No Code Ends

                            dataGridView1.DataSource = dt;
                            dataGridView1.Columns[5].Visible = false;
                            dataGridView1.Columns[6].Visible = false;
                            dataGridView1.Columns[7].Visible = false;
                            dataGridView1.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                            pric = 0;
                            decimal VatAmount = 0;
                            for (int k = 0; k < (dataGridView1.Rows.Count); k++)
                            {
                                //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                                pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()))), 2);
                                VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView1.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView1.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                            }
                            //txtTotalAmount.Text = pric.ToString();
                            txtGrandTotal.Text = pric.ToString();
                            txtVatAmount.Text = VatAmount.ToString();
                            txtBillpaid.Text = (Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2)).ToString();
                            txtItemName.Text = string.Empty;
                        }
                    }
                }
            }
        }




        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDiscount.Text))
                {
                    //   txtBillpaid.Text = Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtGrandTotal.Text) * (decimal.Parse(txtDiscount.Text) / 100))),2).ToString();
                    txtBillpaid.Text = Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2).ToString();
                }
                else
                {
                    txtDiscount.Text = "0";

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtBillpaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void txtBillpaid_Leave(object sender, EventArgs e)
        {
            if (decimal.Parse(txtBillpaid.Text) < Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2))
            {
                FrmMessage.Show("You Cannot Generate a Bill until you pay the Total Amount");
            }
            else if (decimal.Parse(txtBillpaid.Text) > Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2))
            {
                FrmMessage.Show("Return Amount is " + Math.Round((decimal.Parse(txtBillpaid.Text) - (decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text)))), 2));
            }
            txtBillpaid.Text = Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2).ToString();
        }


        //private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //   DataGridViewTextBoxCell cell = dataGridView1[2, e.RowIndex] as DataGridViewTextBoxCell;

        //    if (cell != null)
        //    {
        //        if (e.ColumnIndex == 2)
        //        {
        //            char[] chars = e.FormattedValue.ToString().ToCharArray();
        //            foreach (char c in chars)
        //            {
        //                if (char.IsDigit(c) == false)
        //                {
        //                    dataGridView1.CurrentRow.Cells[2].Value = "1";
        //                    MessageBox.Show("You have to enter digits only");
        //                    e.Cancel = true;                            
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //}

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);


        }

        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            pric = 0;
            for (int k = 0; k < (dataGridView1.Rows.Count); k++)
            {
                pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()))), 2);
            }
            txtGrandTotal.Text = pric.ToString();
            txtBillpaid.Text = (Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2)).ToString();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F2))
            {

                return true;
            }
            //else if (keyData == (Keys.F5))
            //{
            //    savesmartPos();
            //    return true;
            //}
            else if (keyData == (Keys.F9))
            {
                cancelSmarttrans();
                return true;
            }
            else if (keyData == (Keys.F8))
            {
                openCalcy();
                return true;
            }
            else if (keyData == (Keys.F6))
            {
                ShowStock();
                return true;
            }



            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PhoneOrder1_Load(object sender, EventArgs e)
        {
            button8.Visible = false;
            dtshop = sqlhelper.ExecuteTables("select * from ShopDetails");

            try
            {
                generateCategoryButtons();
                DynamicCategorybtn_Click(btnfirst, e);

                generateCategoryButtons1();
                DynamicCategorybtn1_Click(btnfirst, e);

                generateCategoryButtons3();
                DynamicCategorybtn2_Click(btnfirst, e);
                AutoSuggestItemns();

                panel9.Visible = true;
                panel20.Visible = false;
                panel21.Visible = false;
                panel22.Visible = false;
                panel23.Visible = false;
                panel24.Visible = false;


                groupBox1.Visible = true;
                groupBox5.Visible = false;
                groupBox10.Visible = false;
                groupBox15.Visible = false;
                groupBox17.Visible = false;


                textBox12.Text = string.Empty;
                textBox13.Text = string.Empty;
                textBox14.Text = string.Empty;
                textBox15.Text = string.Empty;

                panel11.Visible = false;
                panel15.Visible = false;
                panel16.Visible = false;
                textBox16.Text = "0";

                //textBox16.Text = "0";

                SQLHelper sqlhelp = new SQLHelper();
                sqlhelp = new SQLHelper();
                DataSet ds = new DataSet();
                ds = sqlhelp.ExecuteQueries("select PERPOINTAMOUNT,Points from PCARDPOINTSETTING");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    textBox16.Text = ds.Tables[0].Rows[0]["PERPOINTAMOUNT"].ToString();

                }


            }
            catch
            {
            }

        }



        private void button27_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox5.Visible = false;
            groupBox10.Visible = false;
            groupBox15.Visible = false;
            panel15.Visible = false;
            checkBox2.Checked = false;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox5.Visible = true;
            groupBox10.Visible = false;
            groupBox15.Visible = false;
            panel16.Visible = false;
            checkBox3.Checked = false;



            //DynamicCategorybtn1_Click(btnfirst, e);

            //sqlhelper = new SQLHelper();
            //ds = new DataSet();
            //ds = sqlhelper.ExecuteQueries("select CategoryID,CategoryName from GetStockCategories");
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    int y = 3;
            //    int x = 3;
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            //        Button DynamicCategorybtn1 = new Button();
            //        DynamicCategorybtn1.Name = "btn" + ds.Tables[0].Rows[i]["CategoryID"].ToString();
            //        btnfirst.Name = "btn" + ds.Tables[0].Rows[0]["CategoryID"].ToString();
            //        DynamicCategorybtn1.Text = ds.Tables[0].Rows[i]["CategoryName"].ToString();
            //        DynamicCategorybtn1.Size = new Size(145, 40);

            //        ToolTip1.SetToolTip(DynamicCategorybtn1, DynamicCategorybtn1.Text);

            //        DynamicCategorybtn1.Height = 40;
            //        DynamicCategorybtn1.AutoSize = true;
            //        DynamicCategorybtn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //        DynamicCategorybtn1.BackgroundImage = global::Inventory.Properties.Resources.btn_login1;
            //        DynamicCategorybtn1.Cursor = System.Windows.Forms.Cursors.Hand;
            //        //DynamicCategorybtn.BackColor = System.Drawing.Color.Orange;
            //        //DynamicCategorybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(94)))));
            //        //DynamicCategorybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(133)))), ((int)(((byte)(51)))));
            //        DynamicCategorybtn1.FlatAppearance.BorderSize = 0;
            //        DynamicCategorybtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //        DynamicCategorybtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            //        DynamicCategorybtn1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            //        DynamicCategorybtn1.UseVisualStyleBackColor = true;

            //        //DynamicCategorybtn.Image = ;
            //        DynamicCategorybtn1.Location = new Point(x, y);
            //        DynamicCategorybtn1.Visible = true;
            //        panel8.Controls.Add(DynamicCategorybtn1);
            //        x = x + DynamicCategorybtn1.Size.Width + 5;
            //        DynamicCategorybtn1.Click += new System.EventHandler(DynamicCategorybtn1_Click);
            //    }
            //    }
        }

        private void PbItems1_Click(object sender, EventArgs e)
        {
            PictureBox DynamicItemsBarcode = (sender as PictureBox);
            Label labelbarcode = (sender as Label);
            Panel GroupbxBarcode = (sender as Panel);
            DataSet dsstk1 = new DataSet();
            SQLHelper sqlh = new SQLHelper();
            if (DynamicItemsBarcode == null && GroupbxBarcode == null)
            {
                dsstk1 = sqlh.ExecuteQueries("select * from GetItemsForCashier where  Barcode='" + labelbarcode.Name.ToString() + "'");
            }
            else if (labelbarcode == null && GroupbxBarcode == null)
            {
                dsstk1 = sqlh.ExecuteQueries("select * from GetItemsForCashier where  Barcode='" + DynamicItemsBarcode.Name.ToString() + "'");
            }

            else if (labelbarcode == null && DynamicItemsBarcode == null)
            {
                dsstk1 = sqlh.ExecuteQueries("select * from GetItemsForCashier where Barcode='" + GroupbxBarcode.Name.ToString() + "'");
            }
            if (dsstk1.Tables[0].Rows.Count > 0)
            {
                label10.Text = string.Empty;
                label10.Text = "Avail Quantity " + Convert.ToDecimal(dsstk1.Tables[0].Rows[0]["StockQuantity"].ToString());

                if (Convert.ToDecimal(dsstk1.Tables[0].Rows[0]["StockQuantity"].ToString()) <= 0)
                {
                    FrmMessage.Show("Stock is not available for this Item. Please Re-Order the Stock");
                }
                else
                {
                    if (Convert.ToDecimal(dsstk1.Tables[0].Rows[0]["StockQuantity"].ToString()) <= Convert.ToDecimal(dsstk1.Tables[0].Rows[0]["ReOrderQuantity"].ToString()))
                    {
                        FrmMessage.Show("Stock has reached to the minimum quantity level !!! Please Re-Order the Stock.");
                    }

                    if (dt1.Columns.Count < 1)
                    {
                        dt1.Columns.Add("Item");
                        dt1.Columns.Add("Price");
                        dt1.Columns.Add("Qty");
                        dt1.Columns.Add("Type");
                        dt1.Columns.Add("Barcode");
                        dt1.Columns.Add("ItemID");
                        dt1.Columns.Add("CategoryID");
                        dt1.Columns.Add("Vat(%)");
                        dt1.Columns.Add("MRP");

                    }

                    //Serial Number Code
                    if (!dt1.Columns.Contains("SNo"))
                    {
                        dt1.Columns.Add("SNo");


                    }
                    //Serial No Code Ends

                    dt1.AcceptChanges();
                    DataRow row = dt1.NewRow();
                    if (dt1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            if (dt1.Rows[i]["Barcode"].ToString() == dsstk1.Tables[0].Rows[0]["barcode"].ToString())
                            {
                                row["Qty"] = dt1.Rows[i]["Qty"].ToString();
                                break;
                            }
                            else
                            {
                                row["Qty"] = "1";
                            }
                        }
                    }
                    else
                    {
                        row["Qty"] = "1";
                    }
                    row["ItemID"] = dsstk1.Tables[0].Rows[0]["ItemID"].ToString();
                    row["CategoryID"] = dsstk1.Tables[0].Rows[0]["CategoryID"].ToString();
                    row["Item"] = dsstk1.Tables[0].Rows[0]["ItemName"].ToString();
                    row["Type"] = dsstk1.Tables[0].Rows[0]["QtyType"].ToString();
                    row["Price"] = dsstk1.Tables[0].Rows[0]["saleprice"].ToString();
                    row["Barcode"] = dsstk1.Tables[0].Rows[0]["barcode"].ToString();
                    row["Vat(%)"] = dsstk1.Tables[0].Rows[0]["VatPercent"].ToString();
                    row["MRP"] = dsstk1.Tables[0].Rows[0]["MRP"].ToString();
                    dt1.Rows.Add(row);
                    DataView dView = new DataView(dt1);
                    string[] arrColumns = { "SNo","Item", "Price", "Qty", "Type", "Barcode", "ItemID", "CategoryID", "Vat(%)", "MRP" };
                    dt1 = dView.ToTable(true, arrColumns);
                    dt1.AcceptChanges();

                    //Serial Number Code
                    int p = 1;

                    foreach (DataRow dr in dt1.Rows)
                    {
                        dr["SNo"] = p.ToString();
                        p++;
                    }
                    //Serial No Code Ends

                    dataGridView2.DataSource = dt1;
                    dataGridView2.Columns[5].Visible = false;
                    dataGridView2.Columns[6].Visible = false;
                    dataGridView2.Columns[7].Visible = false;
                    dataGridView2.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                    //dataGridView1.CurrentCell = dataGridView1.Rows.OfType<DataGridViewRow>().Last().Cells.OfType<DataGridViewCell>().First();
                    //dataGridView1.ClearSelection();

                    pric = 0;
                    decimal VatAmount = 0;
                    for (int k = 0; k < (dataGridView2.Rows.Count); k++)
                    {
                        //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                        pric = Math.Round((pric + (decimal.Parse(dataGridView2.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView2.Rows[k].Cells[3].Value.ToString()))), 2);
                        VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView2.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView2.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView2.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                    }
                    //txtTotalAmount.Text = pric.ToString();
                    txtTotal2.Text = pric.ToString();
                    txtVatAmt2.Text = VatAmount.ToString();
                    txtAmount2.Text = (Math.Round((decimal.Parse(txtTotal2.Text) - (decimal.Parse(txtDisc2.Text))), 2)).ToString();
                }
            }
        }
        private void DynamicCategorybtn1_Click(object sender, EventArgs e)
        {
            panel7.Controls.Clear();
            int y = 5;
            int x = 5;
            int count = 1;
            Button DynamicBtn1 = (sender as Button);
            if (!string.IsNullOrEmpty(DynamicBtn1.Name.ToString()))
            {
                string DynamicCategoryID = DynamicBtn1.Name.Substring(3, DynamicBtn1.Name.Length - 3);
                DataSet dds = new DataSet();
                SQLHelper sqlhelper = new SQLHelper();
                dds = sqlhelper.ExecuteQueries("Select * from GetItemsForCashier where CategoryID=" + DynamicCategoryID + "");
                string dir = Application.StartupPath;//Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                dir = System.IO.Path.Combine(dir, "InventoryImages");
                for (int a = 0; a < dds.Tables[0].Rows.Count; a++)
                {

                    if ((count) % 7 > 0)
                    {
                        Panel panel = new Panel();
                        panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(142)))), ((int)(((byte)(224)))));
                        panel.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        panel.Size = new System.Drawing.Size(62, 55);
                        panel.Location = new Point(x, y);
                        panel.Cursor = System.Windows.Forms.Cursors.Hand;

                        System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();

                        //PictureBox pb = new PictureBox();
                        //pb.Size = new Size(55, 50);
                        //pb.Cursor = System.Windows.Forms.Cursors.Hand;
                        //pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        //pb.Location = new Point(5, 22);
                        //pb.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        //if (!string.IsNullOrEmpty(dds.Tables[0].Rows[a]["ImageName"].ToString()))
                        //{
                        //    pb.Image = System.Drawing.Image.FromFile(dir + "\\" + dds.Tables[0].Rows[a]["ImageName"].ToString());
                        //}


                        // label for displaying Item Name on Image.
                        Label DynamicLabel = new Label();
                        DynamicLabel.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        DynamicLabel.BackColor = Color.Transparent;
                        DynamicLabel.Text = dds.Tables[0].Rows[a]["ItemName"].ToString();
                        DynamicLabel.Location = new Point(1, 8);
                        DynamicLabel.Size = new Size(100, 12);
                        DynamicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        DynamicLabel.Cursor = System.Windows.Forms.Cursors.Hand;

                        // ToolTip1.SetToolTip(pb, DynamicLabel.Text);
                        ToolTip1.SetToolTip(DynamicLabel, DynamicLabel.Text);
                        ///////////////////////////////////////////////////////////////////////////////////////////////

                        // label for displaying Amount
                        Label DynamicLabl = new Label();
                        DynamicLabl.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        DynamicLabl.BackColor = System.Drawing.Color.Transparent;
                        DynamicLabl.Location = new Point(1, 35);
                        DynamicLabl.Text = "Rs:" + dds.Tables[0].Rows[a]["saleprice"].ToString();
                        DynamicLabl.Size = new Size(80, 12);
                        DynamicLabl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        DynamicLabl.Cursor = System.Windows.Forms.Cursors.Hand;
                        ToolTip1.SetToolTip(DynamicLabl, DynamicLabl.Text);
                        /////////////////////////////////////////////////////////////////////////////////////////////

                        //    pb.Controls.Add(DynamicLabel);                    
                        panel.Controls.Add(DynamicLabel);
                        //  panel.Controls.Add(pb);
                        panel.Controls.Add(DynamicLabl);
                        panel7.Controls.Add(panel);
                        // groupBox2.Controls.Add(pb);
                        x = x + 64;
                        // pb.Click += new System.EventHandler(PbItems_Click);
                        DynamicLabl.Click += new System.EventHandler(PbItems1_Click);
                        DynamicLabel.Click += new System.EventHandler(PbItems1_Click);
                        panel.Click += new System.EventHandler(PbItems1_Click);
                        panel.Paint += GroupPanel_Paint;
                    }
                    else
                    {
                        Panel panel = new Panel();
                        panel.BackColor = System.Drawing.Color.WhiteSmoke;
                        panel.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        panel.Size = new System.Drawing.Size(62, 55);
                        panel.Location = new Point(x, y);
                        panel.Cursor = System.Windows.Forms.Cursors.Hand;

                        System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();

                        //PictureBox pb = new PictureBox();
                        //pb.Size = new Size(55, 50);
                        //pb.Cursor = System.Windows.Forms.Cursors.Hand;
                        //pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        //pb.Location = new Point(5, 22);
                        //pb.Name = dds.Tables[0].Rows[a]["barcode"].ToString();

                        //if (!string.IsNullOrEmpty(dds.Tables[0].Rows[a]["ImageName"].ToString()))
                        //{
                        //    pb.Image = System.Drawing.Image.FromFile(dir + "\\" + dds.Tables[0].Rows[a]["ImageName"].ToString());
                        //}


                        // label for displaying Item Name on Image.
                        Label DynamicLabel = new Label();
                        DynamicLabel.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        DynamicLabel.BackColor = Color.Transparent;
                        DynamicLabel.Text = dds.Tables[0].Rows[a]["ItemName"].ToString();
                        DynamicLabel.Location = new Point(1, 8);
                        DynamicLabel.Size = new Size(56, 12);
                        DynamicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        DynamicLabel.Cursor = System.Windows.Forms.Cursors.Hand;

                        // ToolTip1.SetToolTip(pb, DynamicLabel.Text);
                        ToolTip1.SetToolTip(DynamicLabel, DynamicLabel.Text);
                        ////////////////////////////////////////////////////

                        // label for displaying Amount
                        Label DynamicLabl = new Label();
                        DynamicLabl.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        DynamicLabl.BackColor = System.Drawing.Color.Transparent;
                        DynamicLabl.Location = new Point(1, 35);
                        DynamicLabl.Text = "Rs:" + dds.Tables[0].Rows[a]["saleprice"].ToString();
                        DynamicLabl.Size = new Size(80, 12);
                        DynamicLabl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        DynamicLabl.Cursor = System.Windows.Forms.Cursors.Hand;

                        ToolTip1.SetToolTip(DynamicLabl, DynamicLabl.Text);
                        ////////////////////////////////////////////////////////////

                        //    pb.Controls.Add(DynamicLabel);                    
                        panel.Controls.Add(DynamicLabel);
                        // panel.Controls.Add(pb);
                        panel.Controls.Add(DynamicLabl);
                        panel7.Controls.Add(panel);
                        x = 5;
                        y = y + 57;
                        //pb.Click += new System.EventHandler(PbItems_Click);
                        DynamicLabl.Click += new System.EventHandler(PbItems1_Click);
                        DynamicLabel.Click += new System.EventHandler(PbItems1_Click);
                        panel.Click += new System.EventHandler(PbItems1_Click);
                        panel.Paint += GroupPanel_Paint;
                    }
                    count++;
                }
            }
            else
            {
                FrmMessage.Show("Stock is not Available. Please Enter the Stock Details First");
            }
        }



        private void button21_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox5.Visible = false;
            groupBox10.Visible = true;
            groupBox15.Visible = false;
            //button26.Text = "POS -2" + Environment.NewLine + "On HOLD"; 
            button26.Text = "POS -2 HOLD";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox5.Visible = true;
            groupBox10.Visible = false;
            groupBox15.Visible = false;
            //button27.Text = "POS -1" + Environment.NewLine + "On HOLD"; 
            button27.Text = "POS -1 HOLD";
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn dc in dataGridView2.Columns)
            {
                if (dc.Index.Equals(2))
                {
                    dc.ReadOnly = false;
                }
                else
                {
                    dc.ReadOnly = true;
                }

            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                DataSet dsstk1 = new DataSet();
                SQLHelper sqlh = new SQLHelper();
                dsstk1 = sqlh.ExecuteQueries("select * from GetItemsForCashier where barcode='" + dataGridView2.Rows[e.RowIndex].Cells["Barcode"].Value.ToString() + "'");
                if (dsstk1.Tables[0].Rows.Count > 0)
                {
                    label10.Text = "Avail Quantity " + Convert.ToDecimal(dsstk1.Tables[0].Rows[0]["StockQuantity"].ToString());

                    if (!string.IsNullOrEmpty(dataGridView2.Rows[e.RowIndex].Cells["Qty"].Value.ToString()))
                    {
                        if ((Convert.ToDecimal(dataGridView2.Rows[e.RowIndex].Cells["Qty"].Value.ToString())) > (Convert.ToDecimal(dsstk1.Tables[0].Rows[0]["StockQuantity"].ToString())))
                        {
                            FrmMessage.Show("You Cannot take more than " + label10.Text + " for this Item", caption, OkButton, ErrorIcon);
                            dataGridView2.Rows[e.RowIndex].Cells[2].Value = Convert.ToDecimal(dsstk1.Tables[0].Rows[0]["StockQuantity"].ToString());
                        }
                    }
                    else
                    {
                        dataGridView2.Rows[e.RowIndex].Cells["Qty"].Value = "1";
                    }
                }

                pric = 0;
                decimal VatAmount = 0;
                for (int k = 0; k < (dataGridView2.Rows.Count); k++)
                {
                    //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                    pric = Math.Round((pric + (decimal.Parse(dataGridView2.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView2.Rows[k].Cells[3].Value.ToString()))), 2);
                    VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView2.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView2.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView2.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                }
                //txtTotalAmount.Text = pric.ToString();
                txtTotal2.Text = pric.ToString();
                txtVatAmt2.Text = VatAmount.ToString();

                if (txtDisc2.Text != "0")
                {
                    txtAmount2.Text = (Math.Round((decimal.Parse(txtTotal2.Text) - (decimal.Parse(txtDisc2.Text))), 2)).ToString();
                }
                else
                {
                    txtAmount2.Text = txtTotal2.Text;
                }

            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
            // dt.AcceptChanges();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                dataGridView2.SelectedRows[0].Cells["Barcode"].Value.ToString();
                DataSet dsstk = new DataSet();
                SQLHelper sqlh = new SQLHelper();
                dsstk = sqlh.ExecuteQueries("select * from GetItemsForCashier where barcode='" + dataGridView2.SelectedRows[0].Cells["Barcode"].Value.ToString() + "'");
                if (dsstk.Tables[0].Rows.Count > 0)
                {
                    label10.Text = "Avail Quantity " + Convert.ToDecimal(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString());
                }
            }
        }

        private void dataGridView2_Sorted(object sender, EventArgs e)
        {
            pric = 0;
            for (int k = 0; k < (dataGridView2.Rows.Count); k++)
            {
                pric = Math.Round((pric + (decimal.Parse(dataGridView2.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView2.Rows[k].Cells[3].Value.ToString()))), 2);
            }
            txtTotal2.Text = pric.ToString();
            txtAmount2.Text = (Math.Round((decimal.Parse(txtTotal2.Text) - (decimal.Parse(txtDisc2.Text))), 2)).ToString();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDisc2.Text))
                {
                    //   txtBillpaid.Text = Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtGrandTotal.Text) * (decimal.Parse(txtDiscount.Text) / 100))),2).ToString();
                    txtAmount2.Text = Math.Round((decimal.Parse(txtTotal2.Text) - (decimal.Parse(txtDisc2.Text))), 2).ToString();
                }
                else
                {
                    txtDisc2.Text = "0";

                }
            }
            catch (Exception ex)
            {

            }
        }

        DataSet ds1 = new DataSet();
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable dtpopup = new DataTable();
            GlobalData.Dtpopup = new DataTable();
            GlobalData.ItemIDs = string.Empty;

            if (ChkActivatePopup2.Checked == true && !string.IsNullOrEmpty(textBox5.Text.Trim()))
            {
                dtpopup = sqlhelper.ExecuteTables("select ItemID,CategoryID,barcode,ItemName,MRP,saleprice,StockQuantity as [Qty Available],QtyType,VatPercent from GetItemsForCashier where (ItemName like '" + textBox5.Text + "%' or MBarcode like'" + textBox5.Text + "%' or Barcode like'" + textBox5.Text + "%')");
                if (dtpopup.Rows.Count > 0)
                {
                    GlobalData.Dtpopup = dtpopup;
                    FRM_ITEMSPOPUP frm = new FRM_ITEMSPOPUP();
                    frm.ShowDialog();
                    dtpopup = new DataTable();
                    DataView dv = new DataView(GlobalData.Dtpopup);
                    if (!string.IsNullOrEmpty(GlobalData.ItemIDs))
                    {
                        dv.RowFilter = "ItemID in (" + GlobalData.ItemIDs + ")";
                        dtpopup = dv.ToTable();
                    }

                    if (dtpopup.Rows.Count > 0)
                    {

                        for (int j = 0; j < dtpopup.Rows.Count; j++)
                        {
                            if (Convert.ToDecimal(dtpopup.Rows[j]["Qty Available"].ToString()) <= 0)
                            {
                                MessageBox.Show("Stock is not available for one or more seleted items");
                            }
                            else
                            {
                                if (dt1.Columns.Count < 1)
                                {
                                    dt1.Columns.Add("Item");
                                    dt1.Columns.Add("Price");
                                    dt1.Columns.Add("Qty");
                                    dt1.Columns.Add("Type");
                                    dt1.Columns.Add("Barcode");
                                    dt1.Columns.Add("ItemID");
                                    dt1.Columns.Add("CategoryID");
                                    dt1.Columns.Add("Vat(%)");
                                    dt1.Columns.Add("MRP");
                                }

                                //Serial Number Code
                                if (!dt1.Columns.Contains("SNo"))
                                {
                                    dt1.Columns.Add("SNo");


                                }
                                //Serial No Code Ends

                                dt1.AcceptChanges();
                                DataRow row = dt1.NewRow();

                                if (dt1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt1.Rows.Count; i++)
                                    {
                                        if (dt1.Rows[i]["Barcode"].ToString() == dtpopup.Rows[j]["barcode"].ToString())
                                        {
                                            row["Qty"] = dt1.Rows[i]["Qty"].ToString();
                                        }
                                        else
                                        {
                                            row["Qty"] = "1";
                                        }
                                    }
                                }
                                else
                                {
                                    row["Qty"] = "1";
                                }
                                row["ItemID"] = dtpopup.Rows[j]["ItemID"].ToString();
                                row["CategoryID"] = dtpopup.Rows[j]["CategoryID"].ToString();
                                row["Item"] = dtpopup.Rows[j]["ItemName"].ToString();
                                row["Type"] = dtpopup.Rows[j]["QtyType"].ToString();
                                row["Price"] = dtpopup.Rows[j]["saleprice"].ToString();
                                row["Vat(%)"] = dtpopup.Rows[j]["VatPercent"].ToString();
                                row["Barcode"] = dtpopup.Rows[j]["barcode"].ToString();
                                row["MRP"] = dtpopup.Rows[j]["MRP"].ToString();
                                dt1.Rows.Add(row);
                                DataView dView = new DataView(dt1);
                                string[] arrColumns = { "SNo","Item", "Price", "Qty", "Type", "Barcode", "ItemID", "CategoryID", "Vat(%)", "MRP" };
                                dt1 = dView.ToTable(true, arrColumns);
                                dt1.AcceptChanges();


                            }
                        }

                        //Serial Number Code
                        int p = 1;

                        foreach (DataRow dr in dt1.Rows)
                        {
                            dr["SNo"] = p.ToString();
                            p++;
                        }
                        //Serial No Code Ends


                        dataGridView2.DataSource = dt1;
                        dataGridView2.Columns[5].Visible = false;
                        dataGridView2.Columns[6].Visible = false;
                        dataGridView2.Columns[7].Visible = false;
                        dataGridView2.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                        pric = 0;
                        decimal VatAmount = 0;
                        for (int k = 0; k < (dataGridView2.Rows.Count); k++)
                        {
                            //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                            pric = Math.Round((pric + (decimal.Parse(dataGridView2.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView2.Rows[k].Cells[3].Value.ToString()))), 2);
                            VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView2.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView2.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView2.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                        }
                        //txtTotalAmount.Text = pric.ToString();
                        txtTotal2.Text = pric.ToString();
                        txtVatAmt2.Text = VatAmount.ToString();
                        txtAmount2.Text = (Math.Round((decimal.Parse(txtTotal2.Text) - (decimal.Parse(txtDisc2.Text))), 2)).ToString();



                        textBox5.Text = string.Empty;
                    }

                    GlobalData.Dtpopup = new DataTable();
                    GlobalData.ItemIDs = string.Empty;

                }

            }
            else
            {
                if (!string.IsNullOrEmpty(GlobalData.phCustId))
                {
                    textBox5.Text = GlobalData.phCustId;
                }
                ds1 = new DataSet();
                sqlhelper = new SQLHelper();
                if (!string.IsNullOrEmpty(textBox5.Text))
                {
                    ds1 = sqlhelper.ExecuteQueries("select * from GetItemsForCashier where ItemName like'" + textBox5.Text + "' or MBarcode='" + textBox5.Text + "'");

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        label10.Text = string.Empty;
                        label10.Text = "Avail Quantity " + Convert.ToDecimal(ds1.Tables[0].Rows[0]["StockQuantity"].ToString());

                        if (Convert.ToDecimal(ds1.Tables[0].Rows[0]["StockQuantity"].ToString()) <= 0)
                        {
                            MessageBox.Show("Stock is not available for this Item");
                        }
                        else
                        {
                            if (dt1.Columns.Count < 1)
                            {
                                dt1.Columns.Add("Item");
                                dt1.Columns.Add("Price");
                                dt1.Columns.Add("Qty");
                                dt1.Columns.Add("Type");
                                dt1.Columns.Add("Barcode");
                                dt1.Columns.Add("ItemID");
                                dt1.Columns.Add("CategoryID");
                                dt1.Columns.Add("Vat(%)");
                                dt1.Columns.Add("MRP");
                            }

                            //Serial Number Code
                            if (!dt1.Columns.Contains("SNo"))
                            {
                                dt1.Columns.Add("SNo");


                            }
                            //Serial No Code Ends


                            dt1.AcceptChanges();
                            DataRow row = dt1.NewRow();

                            if (dt1.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt1.Rows.Count; i++)
                                {
                                    if (dt1.Rows[i]["Barcode"].ToString() == ds1.Tables[0].Rows[0]["barcode"].ToString())
                                    {
                                        row["Qty"] = dt1.Rows[i]["Qty"].ToString();
                                    }
                                    else
                                    {
                                        row["Qty"] = "1";
                                    }
                                }
                            }
                            else
                            {
                                row["Qty"] = "1";
                            }
                            row["ItemID"] = ds1.Tables[0].Rows[0]["ItemID"].ToString();
                            row["CategoryID"] = ds1.Tables[0].Rows[0]["CategoryID"].ToString();
                            row["Item"] = ds1.Tables[0].Rows[0]["ItemName"].ToString();
                            row["Type"] = ds1.Tables[0].Rows[0]["QtyType"].ToString();
                            row["Price"] = ds1.Tables[0].Rows[0]["saleprice"].ToString();
                            row["Barcode"] = ds1.Tables[0].Rows[0]["barcode"].ToString();
                            row["vat(%)"] = ds1.Tables[0].Rows[0]["VatPercent"].ToString();
                            row["MRP"] = ds1.Tables[0].Rows[0]["MRP"].ToString();
                            dt1.Rows.Add(row);
                            DataView dView = new DataView(dt1);
                            string[] arrColumns = { "SNo","Item", "Price", "Qty", "Type", "Barcode", "ItemID", "CategoryID", "Vat(%)", "MRP" };
                            dt1 = dView.ToTable(true, arrColumns);
                            dt1.AcceptChanges();

                            //Serial Number Code
                            int p = 1;

                            foreach (DataRow dr in dt1.Rows)
                            {
                                dr["SNo"] = p.ToString();
                                p++;
                            }
                            //Serial No Code Ends


                            dataGridView2.DataSource = dt1;
                            dataGridView2.Columns[5].Visible = false;
                            dataGridView2.Columns[6].Visible = false;
                            dataGridView2.Columns[7].Visible = false;
                            dataGridView2.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                            //pric = 0;
                            //for (int k = 0; k < (dataGridView2.Rows.Count); k++)
                            //{
                            //    dataGridView2.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
                            //    //decimal afterdiscountamount = (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()));
                            //    pric = Math.Round((pric + (decimal.Parse(dataGridView2.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView2.Rows[k].Cells[2].Value.ToString()))), 2);

                            //}
                            //txtTotal2.Text = pric.ToString();

                            pric = 0;
                            decimal VatAmount = 0;
                            for (int k = 0; k < (dataGridView2.Rows.Count); k++)
                            {
                                //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                                pric = Math.Round((pric + (decimal.Parse(dataGridView2.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView2.Rows[k].Cells[3].Value.ToString()))), 2);
                                VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView2.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView2.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView2.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                            }
                            //txtTotalAmount.Text = pric.ToString();
                            txtTotal2.Text = pric.ToString();
                            txtVatAmt2.Text = VatAmount.ToString();
                            txtAmount2.Text = (Math.Round((decimal.Parse(txtTotal2.Text) - (decimal.Parse(txtDisc2.Text))), 2)).ToString();



                            textBox5.Text = string.Empty;
                        }
                    }
                }
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox5.Visible = false;
            groupBox10.Visible = false;
            groupBox15.Visible = false;
            //button26.Text = "POS -2" + Environment.NewLine + "On HOLD"; 
            button28.Text = "POS - 3 HOLD";
        }
        //DataSet ds2 = new DataSet();
        private void button28_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox5.Visible = false;
            groupBox10.Visible = true;
            groupBox15.Visible = false;
            panel11.Visible = false;
            checkBox1.Checked = false;



            //DynamicCategorybtn2_Click(btnfirst, e);

            //sqlhelper = new SQLHelper();
            //ds2 = new DataSet();
            //ds2 = sqlhelper.ExecuteQueries("select CategoryID,CategoryName from GetStockCategories");
            //if (ds2.Tables[0].Rows.Count > 0)
            //{
            //    int y = 3;
            //    int x = 3;
            //    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            //    {
            //        System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            //        Button DynamicCategorybtn2 = new Button();
            //        DynamicCategorybtn2.Name = "btn" + ds2.Tables[0].Rows[i]["CategoryID"].ToString();
            //        btnfirst.Name = "btn" + ds2.Tables[0].Rows[0]["CategoryID"].ToString();
            //        DynamicCategorybtn2.Text = ds2.Tables[0].Rows[i]["CategoryName"].ToString();
            //        DynamicCategorybtn2.Size = new Size(145, 40);

            //        ToolTip1.SetToolTip(DynamicCategorybtn2, DynamicCategorybtn2.Text);

            //        DynamicCategorybtn2.Height = 40;
            //        DynamicCategorybtn2.AutoSize = true;
            //        DynamicCategorybtn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //        DynamicCategorybtn2.BackgroundImage = global::Inventory.Properties.Resources.btn_login1;
            //        DynamicCategorybtn2.Cursor = System.Windows.Forms.Cursors.Hand;
            //        //DynamicCategorybtn.BackColor = System.Drawing.Color.Orange;
            //        //DynamicCategorybtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(198)))), ((int)(((byte)(94)))));
            //        //DynamicCategorybtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(133)))), ((int)(((byte)(51)))));
            //        DynamicCategorybtn2.FlatAppearance.BorderSize = 0;
            //        DynamicCategorybtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //        DynamicCategorybtn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            //        DynamicCategorybtn2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            //        DynamicCategorybtn2.UseVisualStyleBackColor = true;

            //        //DynamicCategorybtn.Image = ;
            //        DynamicCategorybtn2.Location = new Point(x, y);
            //        DynamicCategorybtn2.Visible = true;
            //        panel14.Controls.Add(DynamicCategorybtn2);
            //        x = x + DynamicCategorybtn2.Size.Width + 5;
            //        DynamicCategorybtn2.Click += new System.EventHandler(DynamicCategorybtn2_Click);
            //    }
            //}
        }

        private void DynamicCategorybtn2_Click(object sender, EventArgs e)
        {
            panel13.Controls.Clear();
            int y = 5;
            int x = 5;
            int count = 1;
            Button DynamicBtn2 = (sender as Button);
            if (!string.IsNullOrEmpty(DynamicBtn2.Name.ToString()))
            {
                string DynamicCategoryID = DynamicBtn2.Name.Substring(3, DynamicBtn2.Name.Length - 3);
                DataSet dds = new DataSet();
                SQLHelper sqlhelper = new SQLHelper();
                dds = sqlhelper.ExecuteQueries("Select * from GetItemsForCashier where CategoryID=" + DynamicCategoryID + "");
                string dir = Application.StartupPath;//Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                dir = System.IO.Path.Combine(dir, "InventoryImages");
                for (int a = 0; a < dds.Tables[0].Rows.Count; a++)
                {

                    if ((count) % 7 > 0)
                    {
                        Panel panel = new Panel();
                        panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(142)))), ((int)(((byte)(224)))));
                        panel.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        panel.Size = new System.Drawing.Size(62, 55);
                        panel.Location = new Point(x, y);
                        panel.Cursor = System.Windows.Forms.Cursors.Hand;

                        System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();

                        //PictureBox pb = new PictureBox();
                        //pb.Size = new Size(55, 50);
                        //pb.Cursor = System.Windows.Forms.Cursors.Hand;
                        //pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        //pb.Location = new Point(5, 22);
                        //pb.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        //if (!string.IsNullOrEmpty(dds.Tables[0].Rows[a]["ImageName"].ToString()))
                        //{
                        //    pb.Image = System.Drawing.Image.FromFile(dir + "\\" + dds.Tables[0].Rows[a]["ImageName"].ToString());
                        //}


                        // label for displaying Item Name on Image.
                        Label DynamicLabel = new Label();
                        DynamicLabel.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        DynamicLabel.BackColor = Color.Transparent;
                        DynamicLabel.Text = dds.Tables[0].Rows[a]["ItemName"].ToString();
                        DynamicLabel.Location = new Point(1, 8);
                        DynamicLabel.Size = new Size(100, 12);
                        DynamicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        DynamicLabel.Cursor = System.Windows.Forms.Cursors.Hand;

                        // ToolTip1.SetToolTip(pb, DynamicLabel.Text);
                        ToolTip1.SetToolTip(DynamicLabel, DynamicLabel.Text);
                        ///////////////////////////////////////////////////////////////////////////////////////////////

                        // label for displaying Amount
                        Label DynamicLabl = new Label();
                        DynamicLabl.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        DynamicLabl.BackColor = System.Drawing.Color.Transparent;
                        DynamicLabl.Location = new Point(1, 35);
                        DynamicLabl.Text = "Rs:" + dds.Tables[0].Rows[a]["saleprice"].ToString();
                        DynamicLabl.Size = new Size(80, 12);
                        DynamicLabl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        DynamicLabl.Cursor = System.Windows.Forms.Cursors.Hand;
                        ToolTip1.SetToolTip(DynamicLabl, DynamicLabl.Text);
                        /////////////////////////////////////////////////////////////////////////////////////////////

                        //    pb.Controls.Add(DynamicLabel);                    
                        panel.Controls.Add(DynamicLabel);
                        //  panel.Controls.Add(pb);
                        panel.Controls.Add(DynamicLabl);
                        panel13.Controls.Add(panel);
                        // groupBox2.Controls.Add(pb);
                        x = x + 64;
                        // pb.Click += new System.EventHandler(PbItems_Click);
                        DynamicLabl.Click += new System.EventHandler(PbItems2_Click);
                        DynamicLabel.Click += new System.EventHandler(PbItems2_Click);
                        panel.Click += new System.EventHandler(PbItems2_Click);
                        panel.Paint += GroupPanel_Paint;
                    }
                    else
                    {
                        Panel panel = new Panel();
                        panel.BackColor = System.Drawing.Color.WhiteSmoke;
                        panel.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        panel.Size = new System.Drawing.Size(62, 55);
                        panel.Location = new Point(x, y);
                        panel.Cursor = System.Windows.Forms.Cursors.Hand;

                        System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();

                        //PictureBox pb = new PictureBox();
                        //pb.Size = new Size(55, 50);
                        //pb.Cursor = System.Windows.Forms.Cursors.Hand;
                        //pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        //pb.Location = new Point(5, 22);
                        //pb.Name = dds.Tables[0].Rows[a]["barcode"].ToString();

                        //if (!string.IsNullOrEmpty(dds.Tables[0].Rows[a]["ImageName"].ToString()))
                        //{
                        //    pb.Image = System.Drawing.Image.FromFile(dir + "\\" + dds.Tables[0].Rows[a]["ImageName"].ToString());
                        //}


                        // label for displaying Item Name on Image.
                        Label DynamicLabel = new Label();
                        DynamicLabel.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        DynamicLabel.BackColor = Color.Transparent;
                        DynamicLabel.Text = dds.Tables[0].Rows[a]["ItemName"].ToString();
                        DynamicLabel.Location = new Point(1, 8);
                        DynamicLabel.Size = new Size(56, 12);
                        DynamicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        DynamicLabel.Cursor = System.Windows.Forms.Cursors.Hand;

                        // ToolTip1.SetToolTip(pb, DynamicLabel.Text);
                        ToolTip1.SetToolTip(DynamicLabel, DynamicLabel.Text);
                        ////////////////////////////////////////////////////

                        // label for displaying Amount
                        Label DynamicLabl = new Label();
                        DynamicLabl.Name = dds.Tables[0].Rows[a]["barcode"].ToString();
                        DynamicLabl.BackColor = System.Drawing.Color.Transparent;
                        DynamicLabl.Location = new Point(1, 35);
                        DynamicLabl.Text = "Rs:" + dds.Tables[0].Rows[a]["saleprice"].ToString();
                        DynamicLabl.Size = new Size(80, 12);
                        DynamicLabl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        DynamicLabl.Cursor = System.Windows.Forms.Cursors.Hand;

                        ToolTip1.SetToolTip(DynamicLabl, DynamicLabl.Text);
                        ////////////////////////////////////////////////////////////

                        //    pb.Controls.Add(DynamicLabel);                    
                        panel.Controls.Add(DynamicLabel);
                        // panel.Controls.Add(pb);
                        panel.Controls.Add(DynamicLabl);
                        panel13.Controls.Add(panel);
                        x = 5;
                        y = y + 57;
                        //pb.Click += new System.EventHandler(PbItems_Click);
                        DynamicLabl.Click += new System.EventHandler(PbItems2_Click);
                        DynamicLabel.Click += new System.EventHandler(PbItems2_Click);
                        panel.Click += new System.EventHandler(PbItems2_Click);
                        panel.Paint += GroupPanel_Paint;
                    }
                    count++;
                }
            }
            else
            {
                FrmMessage.Show("Stock is not Available. Please Enter the Stock Details First");
            }
        }

        private void PbItems2_Click(object sender, EventArgs e)
        {
            PictureBox DynamicItemsBarcode = (sender as PictureBox);
            Label labelbarcode = (sender as Label);
            Panel GroupbxBarcode = (sender as Panel);
            DataSet dsstk2 = new DataSet();
            //DataSet dt2 = new DataSet();
            SQLHelper sqlh1 = new SQLHelper();
            if (DynamicItemsBarcode == null && GroupbxBarcode == null)
            {
                dsstk2 = sqlh1.ExecuteQueries("select * from GetItemsForCashier where  Barcode='" + labelbarcode.Name.ToString() + "'");
            }
            else if (labelbarcode == null && GroupbxBarcode == null)
            {
                dsstk2 = sqlh1.ExecuteQueries("select * from GetItemsForCashier where  Barcode='" + DynamicItemsBarcode.Name.ToString() + "'");
            }

            else if (labelbarcode == null && DynamicItemsBarcode == null)
            {
                dsstk2 = sqlh1.ExecuteQueries("select * from GetItemsForCashier where Barcode='" + GroupbxBarcode.Name.ToString() + "'");
            }
            if (dsstk2.Tables[0].Rows.Count > 0)
            {
                label16.Text = string.Empty;
                label16.Text = "Avail Quantity " + Convert.ToDecimal(dsstk2.Tables[0].Rows[0]["StockQuantity"].ToString());

                if (Convert.ToDecimal(dsstk2.Tables[0].Rows[0]["StockQuantity"].ToString()) <= 0)
                {
                    FrmMessage.Show("Stock is not available for this Item. Please Re-Order the Stock");
                }
                else
                {
                    if (Convert.ToDecimal(dsstk2.Tables[0].Rows[0]["StockQuantity"].ToString()) <= Convert.ToDecimal(dsstk2.Tables[0].Rows[0]["ReOrderQuantity"].ToString()))
                    {
                        FrmMessage.Show("Stock has reached to the minimum quantity level !!! Please Re-Order the Stock.");
                    }

                    if (dt2.Columns.Count < 1)
                    {
                        dt2.Columns.Add("Item");
                        dt2.Columns.Add("Price");
                        dt2.Columns.Add("Qty");
                        dt2.Columns.Add("Type");
                        dt2.Columns.Add("Barcode");
                        dt2.Columns.Add("ItemID");
                        dt2.Columns.Add("CategoryID");
                        dt2.Columns.Add("Vat(%)");
                        dt2.Columns.Add("MRP");
                    }

                    //Serial Number Code
                    if (!dt2.Columns.Contains("SNo"))
                    {
                        dt2.Columns.Add("SNo");


                    }
                    //Serial No Code Ends

                    dt2.AcceptChanges();
                    DataRow row = dt2.NewRow();
                    if (dt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            if (dt2.Rows[i]["Barcode"].ToString() == dsstk2.Tables[0].Rows[0]["barcode"].ToString())
                            {
                                row["Qty"] = dt2.Rows[i]["Qty"].ToString();
                                break;
                            }
                            else
                            {
                                row["Qty"] = "1";
                            }
                        }
                    }
                    else
                    {
                        row["Qty"] = "1";
                    }
                    row["ItemID"] = dsstk2.Tables[0].Rows[0]["ItemID"].ToString();
                    row["CategoryID"] = dsstk2.Tables[0].Rows[0]["CategoryID"].ToString();
                    row["Item"] = dsstk2.Tables[0].Rows[0]["ItemName"].ToString();
                    row["Type"] = dsstk2.Tables[0].Rows[0]["QtyType"].ToString();
                    row["Price"] = dsstk2.Tables[0].Rows[0]["saleprice"].ToString();
                    row["Barcode"] = dsstk2.Tables[0].Rows[0]["barcode"].ToString();
                    row["Vat(%)"] = dsstk2.Tables[0].Rows[0]["VatPercent"].ToString();
                    row["MRP"] = dsstk2.Tables[0].Rows[0]["MRP"].ToString();
                    dt2.Rows.Add(row);
                    DataView dView = new DataView(dt2);
                    string[] arrColumns = { "SNo","Item", "Price", "Qty", "Type", "Barcode", "ItemID", "CategoryID", "Vat(%)", "MRP" };
                    dt2 = dView.ToTable(true, arrColumns);
                    dt2.AcceptChanges();

                    //Serial Number Code
                    int p = 1;

                    foreach (DataRow dr in dt2.Rows)
                    {
                        dr["SNo"] = p.ToString();
                        p++;
                    }
                    //Serial No Code Ends



                    dataGridView3.DataSource = dt2;
                    dataGridView3.Columns[5].Visible = false;
                    dataGridView3.Columns[6].Visible = false;
                    dataGridView3.Columns[7].Visible = false;
                    dataGridView3.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                    //dataGridView1.CurrentCell = dataGridView1.Rows.OfType<DataGridViewRow>().Last().Cells.OfType<DataGridViewCell>().First();
                    //dataGridView1.ClearSelection();                   

                    //for (int k = 0; k < (dataGridView3.Rows.Count); k++)
                    //{
                    //    dataGridView3.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
                    //    //decimal afterdiscountamount = (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()));
                    //    pric = Math.Round((pric + (decimal.Parse(dataGridView3.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells[2].Value.ToString()))), 2);
                    //}

                    textBox10.Text = string.Empty;

                    pric = 0;
                    decimal VatAmount = 0;
                    for (int k = 0; k < (dataGridView3.Rows.Count); k++)
                    {
                        //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                        pric = Math.Round((pric + (decimal.Parse(dataGridView3.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells[3].Value.ToString()))), 2);
                        VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView3.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView3.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                    }
                    //txtTotalAmount.Text = pric.ToString();
                    txtTotal3.Text = pric.ToString();
                    txtVatAmt3.Text = VatAmount.ToString();
                    txtAmount3.Text = (Math.Round((decimal.Parse(txtTotal3.Text) - (decimal.Parse(txtDis3.Text))), 2)).ToString();
                }
            }
        }


        DataSet ds3 = new DataSet();
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            GlobalData.Dtpopup = new DataTable();
            GlobalData.ItemIDs = string.Empty;
            DataTable dtpopup = new DataTable();

            if (ChkActivatePopup3.Checked == true && !string.IsNullOrEmpty(textBox10.Text.Trim()))
            {
                dtpopup = sqlhelper.ExecuteTables("select ItemID,CategoryID,barcode,ItemName,MRP,saleprice,StockQuantity as [Qty Available],QtyType,VatPercent from GetItemsForCashier where (ItemName like '" + textBox10.Text + "%' or MBarcode like'" + textBox10.Text + "%' or Barcode like'" + textBox10.Text + "%')");
                if (dtpopup.Rows.Count > 0)
                {
                    GlobalData.Dtpopup = dtpopup;
                    FRM_ITEMSPOPUP frm = new FRM_ITEMSPOPUP();
                    frm.ShowDialog();
                    dtpopup = new DataTable();
                    DataView dv = new DataView(GlobalData.Dtpopup);
                    if (!string.IsNullOrEmpty(GlobalData.ItemIDs))
                    {
                        dv.RowFilter = "ItemID in (" + GlobalData.ItemIDs + ")";
                        dtpopup = dv.ToTable();
                    }

                    if (dtpopup.Rows.Count > 0)
                    {

                        for (int j = 0; j < dtpopup.Rows.Count; j++)
                        {
                            if (Convert.ToDecimal(dtpopup.Rows[j]["Qty Available"].ToString()) <= 0)
                            {
                                MessageBox.Show("Stock is not available for one or more seleted items");
                            }
                            else
                            {
                                if (dt2.Columns.Count < 1)
                                {
                                    dt2.Columns.Add("Item");
                                    dt2.Columns.Add("Price");
                                    dt2.Columns.Add("Qty");
                                    dt2.Columns.Add("Type");
                                    dt2.Columns.Add("Barcode");
                                    dt2.Columns.Add("ItemID");
                                    dt2.Columns.Add("CategoryID");
                                    dt2.Columns.Add("Vat(%)");
                                    dt2.Columns.Add("MRP");
                                }

                                //Serial Number Code
                                if (!dt2.Columns.Contains("SNo"))
                                {
                                    dt2.Columns.Add("SNo");


                                }
                                //Serial No Code Ends



                                dt2.AcceptChanges();
                                DataRow row = dt2.NewRow();

                                if (dt2.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt2.Rows.Count; i++)
                                    {
                                        if (dt2.Rows[i]["Barcode"].ToString() == dtpopup.Rows[j]["barcode"].ToString())
                                        {
                                            row["Qty"] = dt2.Rows[i]["Qty"].ToString();
                                        }
                                        else
                                        {
                                            row["Qty"] = "1";
                                        }
                                    }
                                }
                                else
                                {
                                    row["Qty"] = "1";
                                }
                                row["ItemID"] = dtpopup.Rows[j]["ItemID"].ToString();
                                row["CategoryID"] = dtpopup.Rows[j]["CategoryID"].ToString();
                                row["Item"] = dtpopup.Rows[j]["ItemName"].ToString();
                                row["Type"] = dtpopup.Rows[j]["QtyType"].ToString();
                                row["Price"] = dtpopup.Rows[j]["saleprice"].ToString();
                                row["Vat(%)"] = dtpopup.Rows[j]["VatPercent"].ToString();
                                row["Barcode"] = dtpopup.Rows[j]["barcode"].ToString();
                                row["MRP"] = dtpopup.Rows[j]["MRP"].ToString();
                                dt2.Rows.Add(row);
                                DataView dView = new DataView(dt2);
                                string[] arrColumns = { "SNo","Item", "Price", "Qty", "Type", "Barcode", "ItemID", "CategoryID", "Vat(%)", "MRP" };
                                dt2 = dView.ToTable(true, arrColumns);
                                dt2.AcceptChanges();
                            }
                        }

                        //Serial Number Code
                        int p = 1;

                        foreach (DataRow dr in dt2.Rows)
                        {
                            dr["SNo"] = p.ToString();
                            p++;
                        }
                        //Serial No Code Ends


                        dataGridView3.DataSource = dt2;
                        dataGridView3.Columns[5].Visible = false;
                        dataGridView3.Columns[6].Visible = false;
                        dataGridView3.Columns[7].Visible = false;
                        dataGridView3.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                        pric = 0;
                        //for (int k = 0; k < (dataGridView3.Rows.Count); k++)
                        //{
                        //    dataGridView3.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
                        //    //decimal afterdiscountamount = (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()));
                        //    pric = Math.Round((pric + (decimal.Parse(dataGridView3.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells[2].Value.ToString()))), 2);
                        //}

                        textBox10.Text = string.Empty;


                        decimal VatAmount = 0;
                        for (int k = 0; k < (dataGridView3.Rows.Count); k++)
                        {
                            //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                            pric = Math.Round((pric + (decimal.Parse(dataGridView3.Rows[k].Cells["Price"].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells["Qty"].Value.ToString()))), 2);
                            VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView3.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView3.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                        }
                        //txtTotalAmount.Text = pric.ToString();
                        txtTotal3.Text = pric.ToString();
                        txtVatAmt3.Text = VatAmount.ToString();
                        txtAmount3.Text = (Math.Round((decimal.Parse(txtTotal3.Text) - (decimal.Parse(txtDis3.Text))), 2)).ToString();


                    }

                    GlobalData.Dtpopup = new DataTable();
                    GlobalData.ItemIDs = string.Empty;

                }

            }

            else
            {

                if (!string.IsNullOrEmpty(GlobalData.phCustId))
                {
                    textBox10.Text = GlobalData.phCustId;
                }
                ds3 = new DataSet();
                //ds2 = new DataSet();
                sqlhelper = new SQLHelper();
                if (!string.IsNullOrEmpty(textBox10.Text))
                {
                    ds3 = sqlhelper.ExecuteQueries("select * from GetItemsForCashier where ItemName like'" + textBox10.Text + "' or MBarcode='" + textBox10.Text + "'");

                    if (ds3.Tables[0].Rows.Count > 0)
                    {
                        label16.Text = string.Empty;
                        label16.Text = "Avail Quantity " + Convert.ToDecimal(ds3.Tables[0].Rows[0]["StockQuantity"].ToString());

                        if (Convert.ToDecimal(ds3.Tables[0].Rows[0]["StockQuantity"].ToString()) <= 0)
                        {
                            MessageBox.Show("Stock is not available for this Item");
                        }
                        else
                        {
                            if (dt2.Columns.Count < 1)
                            {
                                dt2.Columns.Add("Item");
                                dt2.Columns.Add("Price");
                                dt2.Columns.Add("Qty");
                                dt2.Columns.Add("Type");
                                dt2.Columns.Add("Barcode");
                                dt2.Columns.Add("ItemID");
                                dt2.Columns.Add("CategoryID");
                                dt2.Columns.Add("Vat(%)");
                                dt2.Columns.Add("MRP");
                            }

                            //Serial Number Code
                            if (!dt2.Columns.Contains("SNo"))
                            {
                                dt2.Columns.Add("SNo");


                            }
                            //Serial No Code Ends

                            dt2.AcceptChanges();
                            DataRow row = dt2.NewRow();

                            if (dt2.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt2.Rows.Count; i++)
                                {
                                    if (dt2.Rows[i]["Barcode"].ToString() == ds3.Tables[0].Rows[0]["barcode"].ToString())
                                    {
                                        row["Qty"] = dt2.Rows[i]["Qty"].ToString();
                                    }
                                    else
                                    {
                                        row["Qty"] = "1";
                                    }
                                }
                            }
                            else
                            {
                                row["Qty"] = "1";
                            }
                            row["ItemID"] = ds3.Tables[0].Rows[0]["ItemID"].ToString();
                            row["CategoryID"] = ds3.Tables[0].Rows[0]["CategoryID"].ToString();
                            row["Item"] = ds3.Tables[0].Rows[0]["ItemName"].ToString();
                            row["Price"] = ds3.Tables[0].Rows[0]["saleprice"].ToString();
                            row["Type"] = ds3.Tables[0].Rows[0]["QtyType"].ToString();
                            row["Barcode"] = ds3.Tables[0].Rows[0]["barcode"].ToString();
                            row["Vat(%)"] = ds3.Tables[0].Rows[0]["VatPercent"].ToString();
                            row["MRP"] = ds3.Tables[0].Rows[0]["MRP"].ToString();
                            dt2.Rows.Add(row);
                            DataView dView = new DataView(dt2);
                            string[] arrColumns = { "SNo","Item", "Price", "Qty", "Type", "Barcode", "ItemID", "CategoryID", "Vat(%)", "MRP" };
                            dt2 = dView.ToTable(true, arrColumns);
                            dt2.AcceptChanges();

                            //Serial Number Code
                            int p = 1;

                            foreach (DataRow dr in dt2.Rows)
                            {
                                dr["SNo"] = p.ToString();
                                p++;
                            }
                            //Serial No Code Ends



                            dataGridView3.DataSource = dt2;

                            dataGridView3.Columns[5].Visible = false;
                            dataGridView3.Columns[6].Visible = false;
                            dataGridView3.Columns[7].Visible = false;
                            dataGridView3.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                            pric = 0;
                            //for (int k = 0; k < (dataGridView3.Rows.Count); k++)
                            //{
                            //    dataGridView3.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
                            //    //decimal afterdiscountamount = (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()));
                            //    pric = Math.Round((pric + (decimal.Parse(dataGridView3.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells[2].Value.ToString()))), 2);
                            //}

                            textBox10.Text = string.Empty;


                            decimal VatAmount = 0;
                            for (int k = 0; k < (dataGridView3.Rows.Count); k++)
                            {
                                //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                                pric = Math.Round((pric + (decimal.Parse(dataGridView3.Rows[k].Cells["Price"].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells["Qty"].Value.ToString()))), 2);
                                VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView3.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView3.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                            }
                            //txtTotalAmount.Text = pric.ToString();
                            txtTotal3.Text = pric.ToString();
                            txtVatAmt3.Text = VatAmount.ToString();
                            txtAmount3.Text = (Math.Round((decimal.Parse(txtTotal3.Text) - (decimal.Parse(txtDis3.Text))), 2)).ToString();






                        }
                    }

                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn dc in dataGridView3.Columns)
            {
                if (dc.Index.Equals(2))
                {
                    dc.ReadOnly = false;
                }
                else
                {
                    dc.ReadOnly = true;
                }

            }
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                DataSet dsstk3 = new DataSet();
                SQLHelper sqlh3 = new SQLHelper();
                dsstk3 = sqlh3.ExecuteQueries("select * from GetItemsForCashier where barcode='" + dataGridView3.Rows[e.RowIndex].Cells["Barcode"].Value.ToString() + "'");
                if (dsstk3.Tables[0].Rows.Count > 0)
                {
                    label16.Text = "Avail Quantity " + Convert.ToDecimal(dsstk3.Tables[0].Rows[0]["StockQuantity"].ToString());

                    if (!string.IsNullOrEmpty(dataGridView3.Rows[e.RowIndex].Cells["Qty"].Value.ToString()))
                    {
                        if ((Convert.ToDecimal(dataGridView3.Rows[e.RowIndex].Cells["Qty"].Value.ToString())) > (Convert.ToDecimal(dsstk3.Tables[0].Rows[0]["StockQuantity"].ToString())))
                        {
                            FrmMessage.Show("You Cannot take more than " + label16.Text + " for this Item", caption, OkButton, ErrorIcon);
                            dataGridView3.Rows[e.RowIndex].Cells["Qty"].Value = Convert.ToDecimal(dsstk3.Tables[0].Rows[0]["StockQuantity"].ToString());
                        }
                    }
                    else
                    {
                        dataGridView3.Rows[e.RowIndex].Cells["Qty"].Value = "1";
                    }
                }

                //pric = 0;
                //for (int k = 0; k < (dataGridView3.Rows.Count); k++)
                //{
                //    // decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                //    pric = Math.Round((pric + (decimal.Parse(dataGridView3.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells[2].Value.ToString()))), 2);
                //}
                //txtTotal3.Text = pric.ToString();


                pric = 0;
                decimal VatAmount = 0;
                for (int k = 0; k < (dataGridView3.Rows.Count); k++)
                {
                    //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                    pric = Math.Round((pric + (decimal.Parse(dataGridView3.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells[3].Value.ToString()))), 2);
                    VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView3.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView3.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                }
                //txtTotalAmount.Text = pric.ToString();
                txtTotal3.Text = pric.ToString();
                txtVatAmt3.Text = VatAmount.ToString();


                if (txtDis3.Text != "0")
                {
                    txtAmount3.Text = (Math.Round((decimal.Parse(txtTotal3.Text) - (decimal.Parse(txtDis3.Text))), 2)).ToString();
                }
                else
                {
                    txtAmount3.Text = txtTotal3.Text;
                }

            }
        }

        private void dataGridView3_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void dataGridView3_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
            // dt.AcceptChanges();
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                dataGridView3.SelectedRows[0].Cells["Barcode"].Value.ToString();
                DataSet dsstk3 = new DataSet();
                SQLHelper sqlh3 = new SQLHelper();
                dsstk3 = sqlh3.ExecuteQueries("select * from GetItemsForCashier where barcode='" + dataGridView3.SelectedRows[0].Cells["Barcode"].Value.ToString() + "'");
                if (dsstk3.Tables[0].Rows.Count > 0)
                {
                    label16.Text = "Avail Quantity " + Convert.ToDecimal(dsstk3.Tables[0].Rows[0]["StockQuantity"].ToString());
                }
            }
        }

        private void dataGridView3_Sorted(object sender, EventArgs e)
        {
            pric = 0;
            for (int k = 0; k < (dataGridView3.Rows.Count); k++)
            {
                pric = Math.Round((pric + (decimal.Parse(dataGridView3.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells[3].Value.ToString()))), 2);
            }
            txtTotal3.Text = pric.ToString();
            txtAmount3.Text = (Math.Round((decimal.Parse(txtTotal3.Text) - (decimal.Parse(txtDis3.Text))), 2)).ToString();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDis3.Text))
                {
                    //   txtBillpaid.Text = Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtGrandTotal.Text) * (decimal.Parse(txtDiscount.Text) / 100))),2).ToString();
                    txtAmount3.Text = Math.Round((decimal.Parse(txtTotal3.Text) - (decimal.Parse(txtDis3.Text))), 2).ToString();
                }
                else
                {
                    txtDis3.Text = "0";

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            // dt.AcceptChanges();
            try
            {
                if (string.IsNullOrEmpty(txtAmount2.Text) || dataGridView2.Rows.Count <= 0)
                {
                    FrmMessage.Show("You cannot Generate Bill without Items", caption, OkButton, ErrorIcon);
                }
                //else if (string.IsNullOrEmpty(txtCustName.Text) || string.IsNullOrEmpty(txtCustPhnNo.Text))
                //{
                //    FrmMessage.Show("Customer Details should not be Empty", caption, OkButton, ErrorIcon);
                //}
                else
                {
                    sqlhelper = new SQLHelper();
                    bool result;

                    //result = sqlhelper.ExecuteNonQuery("insert into Customers(CustName,Phone) values ('" + txtCustName.Text + "'," + txtCustPhnNo.Text + ")");
                    //if (result == true)
                    //{

                    ds = new DataSet();
                    int count;
                    ds = sqlhelper.ExecuteQueries("select TranNo from TransactionNo");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["TranNo"].ToString()))
                        {
                            count = 1;
                        }
                        else
                        {
                            count = int.Parse(ds.Tables[0].Rows[0]["TranNo"].ToString()) + 1;
                        }
                    }
                    else
                    {
                        count = 1;
                    }

                    string todaysDate = sqlhelper.ExecuteScalar("select format(date(),'ddmmyyyy')");
                    trnNo = todaysDate + count;
                    result = sqlhelper.ExecuteNonQuery("insert into Payment(TransactionNo,TotalAmount,DiscountAmount,BillPaid,CreatedBy)" +
                                                       "values ('" + trnNo + "','" + txtTotal2.Text + "','" + txtDisc2.Text + "', '" + txtAmount2.Text + "'," +
                                                       "" + GlobalData.UserID + ")");
                    result = sqlhelper.ExecuteNonQuery("insert into TaxHistory(TransactionNo,TotalAmount,DiscountAmount,BillPaid,VATAmount,Paid,CreatedBy)" +
                                                    "values ('" + trnNo + "','" + txtTotal2.Text + "','" + txtDisc2.Text + "', '" + txtAmount2.Text + "', '" + txtVatAmt2.Text + "', '" + txtDue2.Text + "'," +
                                                    "" + GlobalData.UserID + ")");

                    if (result == true)
                    {
                        //string InitCode = "";
                        //int lengthofInitCode = 0;
                        //string MaxCode;

                        string PaymentId = sqlhelper.ExecuteScalar("select max(PaymentID) from Payment");

                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {

                            //InitCode = sqlhelper.ExecuteScalar("select CategoryInitCode from Categories where CategoryID=" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "");
                            //lengthofInitCode = InitCode.Split('-')[0].Length + 1;

                            //MaxCode = sqlhelper.ExecuteScalar("SELECT Max(val(Mid([CodeNo]," + (lengthofInitCode + 1) + "))) as MaxCode FROM Transactions where CategoryID =" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "");
                            //if (string.IsNullOrEmpty(MaxCode))
                            //{
                            //    MaxCode = InitCode.Split('-')[1];
                            //}
                            //InitCode = InitCode.Split('-')[0] + "-";
                            //MaxCode = InitCode + (int.Parse(MaxCode) + 1).ToString();

                            result = sqlhelper.ExecuteNonQuery("insert into Transactions(PaymentID,Barcode,CategoryID,ItemID,SaleQty,VatPercent,ItemPrice,CreatedBy)" +
                                                              "values (" + PaymentId + ",'" + dataGridView2.Rows[i].Cells["Barcode"].Value.ToString() + "'," + dataGridView2.Rows[i].Cells["CategoryID"].Value.ToString() + "," +
                                                              "" + dataGridView2.Rows[i].Cells["ItemID"].Value.ToString() + "," + dataGridView2.Rows[i].Cells["Qty"].Value.ToString() + "," +
                                                              "" + dataGridView2.Rows[i].Cells["Vat(%)"].Value.ToString() + "," + dataGridView2.Rows[i].Cells["Price"].Value.ToString() + "," + GlobalData.UserID + ")");

                            result = sqlhelper.ExecuteNonQuery("Update Stock Set StockQuantity = (StockQuantity - " + dataGridView2.Rows[i].Cells["Qty"].Value.ToString() + ")" +
                                                               " where CategoryID= " + dataGridView2.Rows[i].Cells["CategoryID"].Value.ToString() + " and  " +
                                                               "ItemID=" + dataGridView2.Rows[i].Cells["ItemID"].Value.ToString() + " and Barcode='" + dataGridView2.Rows[i].Cells["Barcode"].Value.ToString() + "'");

                        }

                        if (result == true)
                        {

                            if (checkBox3.Checked == true)
                            {
                                if (string.IsNullOrEmpty(textBox37.Text))
                                {
                                }
                                else
                                {
                                    result = sqlhelper.ExecuteNonQuery("insert into DEALERCREDIT(DealerID,TransactionNo,TotalAmount,DiscountAmount,AfterDiscount,VAT,VATAmount,TOTALDUE,CreatedBy,STATUS)" +
                                                             "values ('" + DEALERID + "','" + trnNo + "','" + txtGrandTotal.Text + "', '" + txtDiscount.Text + "', '" + txtBillpaid.Text + "', " + txtVatAmount.Text + ", " + txtDueAmt.Text + ", " + GlobalData.UserID + ", 'CREDIT')");

                                    checkBox3.Checked = false;
                                    panel16.Visible = false;
                                    textBox38.Text = string.Empty;
                                    textBox39.Text = string.Empty;
                                    textBox40.Text = string.Empty;

                                }
                            }

                            if (checkBox4.Checked == true)
                            {
                                if (string.IsNullOrEmpty(textBox46.Text))
                                {
                                }
                                else
                                {
                                    // BELOW CODE WILL CALCULATE THE AGENT COMISSION EARNED
                                    textBox49.Text = Math.Round((decimal.Parse(txtAmount2.Text) * (decimal.Parse(textBox44.Text) / 100)), 2).ToString();

                                    result = sqlhelper.ExecuteNonQuery("insert into AGENTEARNEDCOMISSION(ANO,TRANSACTIONNO,COMISSIONEARNED,COMISSION)" +
                                                             "values (" + ANO + "," + trnNo + "," + textBox49.Text + ", '" + textBox44.Text + "')");

                                    checkBox4.Checked = false;
                                    panel20.Visible = false;
                                    textBox44.Text = string.Empty;
                                    textBox45.Text = string.Empty;
                                    textBox46.Text = string.Empty;
                                    textBox49.Text = string.Empty;

                                }
                            }


                            //if (checkBox3.Checked == true && checkBox4.Checked == true)
                            //{
                            //    if (string.IsNullOrEmpty(textBox37.Text))
                            //    {
                            //    }
                            //    else
                            //    {
                            //        result = sqlhelper.ExecuteNonQuery("insert into DEALERCREDIT(DealerID,TransactionNo,TotalAmount,DiscountAmount,AfterDiscount,VAT,VATAmount,TOTALDUE,CreatedBy,STATUS)" +
                            //                                 "values ('" + DEALERID + "','" + trnNo + "','" + txtGrandTotal.Text + "', '" + txtDiscount.Text + "', '" + txtBillpaid.Text + "', " + textBox23.Text + ", " + textBox29.Text + ", " + textBox22.Text + ", " + GlobalData.UserID + ", 'CREDIT')");

                            //        checkBox3.Checked = false;
                            //        panel16.Visible = false;
                            //        textBox38.Text = string.Empty;
                            //        textBox39.Text = string.Empty;
                            //        textBox40.Text = string.Empty;

                            //    }

                            //    if (string.IsNullOrEmpty(textBox46.Text))
                            //    {
                            //    }
                            //    else
                            //    {
                            //        // BELOW CODE WILL CALCULATE THE AGENT COMISSION EARNED
                            //        textBox49.Text = Math.Round((decimal.Parse(textBox2.Text) * (decimal.Parse(textBox44.Text) / 100)), 2).ToString();

                            //        result = sqlhelper.ExecuteNonQuery("insert into AGENTEARNEDCOMISSION(ANO,TRANSACTIONNO,COMISSIONEARNED,COMISSION)" +
                            //                                 "values (" + ANO + "," + trnNo + "," + textBox49.Text + ", '" + textBox44.Text + "')");

                            //        checkBox4.Checked = false;
                            //        panel20.Visible = false;
                            //        textBox44.Text = string.Empty;
                            //        textBox45.Text = string.Empty;
                            //        textBox46.Text = string.Empty;
                            //        textBox49.Text = string.Empty;

                            //    }
                            //}


                            string ser = txtAmount2.Text;
                            BillPrintPreview.Document = printDocument1;
                            BillPrintPreview.PrintPreviewControl.Zoom = 1;
                            BillPrintPreview.ShowDialog();



                            // BillPrint.Print();
                        }
                    }

                    //BillPrintPreview2.Document = BillPrint2;
                    //BillPrintPreview2.PrintPreviewControl.Zoom = 1;
                    //BillPrintPreview2.ShowDialog();

                    //BillPrint2.Print();
                    FrmMessage.Show("Transaction Successful", caption, OkButton, InformationIcon);
                    //PhoneOrders f2 = new PhoneOrders();
                    //f2.MdiParent = this.ParentForm;
                    //f2.Show();
                    txtVatAmt2.Text = "0";
                    button52_Click(sender, e);


                    //PhoneOrder1 form = new PhoneOrder1
                    //{
                    //    MdiParent = this.MdiParent,
                    //    Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    //        | System.Windows.Forms.AnchorStyles.Left)
                    //        | System.Windows.Forms.AnchorStyles.Right))),
                    //    Dock = DockStyle.Fill
                    //};

                    //form.Show();

                    //}


                }
            }
            catch (Exception ex)
            {
                FrmMessage.Show(ex.ToString());
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            // dt.AcceptChanges();

            try
            {
                if (string.IsNullOrEmpty(txtAmount3.Text) || dataGridView3.Rows.Count <= 0)
                {
                    FrmMessage.Show("You cannot Generate Bill without Items", caption, OkButton, ErrorIcon);
                }
                //else if (string.IsNullOrEmpty(txtCustName.Text) || string.IsNullOrEmpty(txtCustPhnNo.Text))
                //{
                //    FrmMessage.Show("Customer Details should not be Empty", caption, OkButton, ErrorIcon);
                //}
                else
                {
                    sqlhelper = new SQLHelper();
                    bool result;

                    //result = sqlhelper.ExecuteNonQuery("insert into Customers(CustName,Phone) values ('" + txtCustName.Text + "'," + txtCustPhnNo.Text + ")");
                    //if (result == true)
                    //{

                    ds = new DataSet();
                    int count;
                    ds = sqlhelper.ExecuteQueries("select TranNo from TransactionNo");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["TranNo"].ToString()))
                        {
                            count = 1;
                        }
                        else
                        {
                            count = int.Parse(ds.Tables[0].Rows[0]["TranNo"].ToString()) + 1;
                        }
                    }
                    else
                    {
                        count = 1;
                    }

                    string todaysDate = sqlhelper.ExecuteScalar("select format(date(),'ddmmyyyy')");
                    trnNo = todaysDate + count;
                    result = sqlhelper.ExecuteNonQuery("insert into Payment(TransactionNo,TotalAmount,DiscountAmount,BillPaid,CreatedBy)" +
                                                       "values ('" + trnNo + "','" + txtTotal3.Text + "','" + txtDis3.Text + "', '" + txtAmount3.Text + "'," +
                                                       "" + GlobalData.UserID + ")");

                    result = sqlhelper.ExecuteNonQuery("insert into TaxHistory(TransactionNo,TotalAmount,DiscountAmount,BillPaid,VATAmount,Paid,CreatedBy)" +
                                                      "values ('" + trnNo + "','" + txtTotal3.Text + "','" + txtDis3.Text + "', '" + txtAmount3.Text + "', '" + txtVatAmt3.Text + "', '" + txtDue3.Text + "'," +
                                                      "" + GlobalData.UserID + ")");


                    if (result == true)
                    {
                        //string InitCode = "";
                        //int lengthofInitCode = 0;
                        //string MaxCode;

                        string PaymentId = sqlhelper.ExecuteScalar("select max(PaymentID) from Payment");

                        for (int i = 0; i < dataGridView3.Rows.Count; i++)
                        {

                            //InitCode = sqlhelper.ExecuteScalar("select CategoryInitCode from Categories where CategoryID=" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "");
                            //lengthofInitCode = InitCode.Split('-')[0].Length + 1;

                            //MaxCode = sqlhelper.ExecuteScalar("SELECT Max(val(Mid([CodeNo]," + (lengthofInitCode + 1) + "))) as MaxCode FROM Transactions where CategoryID =" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "");
                            //if (string.IsNullOrEmpty(MaxCode))
                            //{
                            //    MaxCode = InitCode.Split('-')[1];
                            //}
                            //InitCode = InitCode.Split('-')[0] + "-";
                            //MaxCode = InitCode + (int.Parse(MaxCode) + 1).ToString();
                            result = sqlhelper.ExecuteNonQuery("insert into Transactions(PaymentID,Barcode,CategoryID,ItemID,SaleQty,VatPercent,ItemPrice,CreatedBy)" +
                                                                                          "values (" + PaymentId + ",'" + dataGridView3.Rows[i].Cells["Barcode"].Value.ToString() + "'," + dataGridView3.Rows[i].Cells["CategoryID"].Value.ToString() + "," +
                                                                                          "" + dataGridView3.Rows[i].Cells["ItemID"].Value.ToString() + "," + dataGridView3.Rows[i].Cells["Qty"].Value.ToString() + "," +
                                                                                          "" + dataGridView3.Rows[i].Cells["Vat(%)"].Value.ToString() + "," + dataGridView3.Rows[i].Cells["Price"].Value.ToString() + "," + GlobalData.UserID + ")");

                            result = sqlhelper.ExecuteNonQuery("Update Stock Set StockQuantity = (StockQuantity - " + dataGridView3.Rows[i].Cells["Qty"].Value.ToString() + ")" +
                                                               " where CategoryID= " + dataGridView3.Rows[i].Cells["CategoryID"].Value.ToString() + " and  " +
                                                               "ItemID=" + dataGridView3.Rows[i].Cells["ItemID"].Value.ToString() + " and Barcode='" + dataGridView3.Rows[i].Cells["Barcode"].Value.ToString() + "'");

                        }

                        if (result == true)
                        {
                            if (checkBox1.Checked == true)
                            {
                                if (string.IsNullOrEmpty(textBox32.Text))
                                {
                                }
                                else
                                {
                                    result = sqlhelper.ExecuteNonQuery("insert into DEALERCREDIT(DealerID,TransactionNo,TotalAmount,DiscountAmount,AfterDiscount,VATAmount,TOTALDUE,CreatedBy,STATUS)" +
                                                             "values ('" + DEALERID + "','" + trnNo + "','" + txtTotal3.Text + "', '" + txtDis3.Text + "', '" + txtAmount3.Text + "', " + txtVatAmt3.Text + ", " + txtDue3.Text + ", " + GlobalData.UserID + ", 'CREDIT')");
                                    checkBox1.Checked = false;

                                }
                            }

                            if (checkBox6.Checked == true)
                            {
                                if (string.IsNullOrEmpty(textBox57.Text))
                                {
                                }
                                else
                                {
                                    result = sqlhelper.ExecuteNonQuery("insert into AGENTEARNEDCOMISSION(ANO,TransactionNo,COMISSIONEARNED,COMISSION)" +
                                                             "values ('" + ANO + "','" + trnNo + "','" + textBox54.Text + "', '" + textBox55.Text + "')");
                                    checkBox6.Checked = false;

                                }
                            }

                            //if (checkBox1.Checked == true && checkBox6.Checked ==true)
                            //{
                            //    if (string.IsNullOrEmpty(textBox32.Text))
                            //    {
                            //    }
                            //    else
                            //    {
                            //        result = sqlhelper.ExecuteNonQuery("insert into DEALERCREDIT(DealerID,TransactionNo,TotalAmount,DiscountAmount,AfterDiscount,VAT,VATAmount,TOTALDUE,CreatedBy,STATUS)" +
                            //                                 "values ('" + DEALERID + "','" + trnNo + "','" + textBox9.Text + "', '" + textBox8.Text + "', '" + textBox7.Text + "', " + textBox20.Text + ", " + textBox28.Text + ", " + textBox21.Text + ", " + GlobalData.UserID + ", 'CREDIT')");
                            //        checkBox1.Checked = false;

                            //    }
                            //    if (string.IsNullOrEmpty(textBox57.Text))
                            //    {
                            //    }
                            //    else
                            //    {
                            //        result = sqlhelper.ExecuteNonQuery("insert into AGENTEARNEDCOMISSION(ANO,TransactionNo,COMISSIONEARNED,COMISSION)" +
                            //                                 "values ('" + ANO + "','" + trnNo + "','" + textBox54.Text + "', '" + textBox55.Text + "')");
                            //        checkBox6.Checked = false;

                            //    }
                            //}
                            string ser = txtAmount3.Text;
                            BillPrintPreview.Document = printDocument2;
                            BillPrintPreview.PrintPreviewControl.Zoom = 1;
                            BillPrintPreview.ShowDialog();



                            // BillPrint.Print();
                        }
                    }

                    //BillPrintPreview2.Document = BillPrint2;
                    //BillPrintPreview2.PrintPreviewControl.Zoom = 1;
                    //BillPrintPreview2.ShowDialog();

                    //BillPrint2.Print();
                    FrmMessage.Show("Transaction Successful", caption, OkButton, InformationIcon);
                    //PhoneOrders f2 = new PhoneOrders();
                    //f2.MdiParent = this.ParentForm;
                    //f2.Show();
                    button53_Click(sender, e);
                    txtTotal3.Text = "0";
                    txtDis3.Text = "0";
                    txtAmount3.Text = "0";
                    txtVatAmt3.Text = "0";
                    txtDue3.Text = "0";
                    //PhoneOrder1 form = new PhoneOrder1
                    //{
                    //    MdiParent = this.MdiParent,
                    //    Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    //        | System.Windows.Forms.AnchorStyles.Left)
                    //        | System.Windows.Forms.AnchorStyles.Right))),
                    //    Dock = DockStyle.Fill
                    //};

                    //form.Show();

                    //}


                }
            }
            catch (Exception ex)
            {
                FrmMessage.Show(ex.ToString());
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {

            button27.Text = "POS -1";
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dt = new DataTable();

        }

        private void button52_Click(object sender, EventArgs e)
        {
            button26.Text = "POS -2";
            dataGridView2.DataSource = null;
            dataGridView2.Columns.Clear();
            dt1 = new DataTable();
        }

        private void button53_Click(object sender, EventArgs e)
        {

            button28.Text = "POS -3";
            dataGridView3.DataSource = null;
            dataGridView3.Columns.Clear();
            dt2 = new DataTable();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                if (!dt1.Columns.Contains("sno"))
                {

                    dt1.Columns.Add("sno");
                    int k = 1;
                    foreach (DataRow dr in dt1.Rows)
                    {
                        dr["sno"] = k.ToString();
                        k++;
                    }
                }


                Font font = new Font("Courier New", 9, System.Drawing.FontStyle.Bold);

                Font Header = new Font("Calibri", 11, System.Drawing.FontStyle.Bold);
                e.Graphics.DrawString("SALE INVOICE", Header, Brushes.Black, float.Parse("150"), float.Parse("0"));
                e.Graphics.DrawString(dtshop.Rows[0]["ShopName"].ToString(), Header, Brushes.Black, float.Parse("150"), float.Parse("15"));

                e.Graphics.DrawString("Address : " + dtshop.Rows[0]["Address"].ToString(), Header, Brushes.Black, float.Parse("150"), float.Parse("30"));
                //e.Graphics.DrawString("Ph: " + dtshop.Rows[0]["ContactNo"].ToString(), Header, Brushes.Black, float.Parse("50"), float.Parse("45"));
                e.Graphics.DrawString("TIN No : " + dtshop.Rows[0]["TIN"].ToString(), Header, Brushes.Black, float.Parse("150"), float.Parse("45"));



                //Header               

                //  e.Graphics.DrawString("Sales Bill", Header, Brushes.Black, float.Parse("15"), float.Parse("0"));

                e.Graphics.DrawString("Bill Date: " + DateTime.Now.ToString("dd-MM-yyyy"), font, Brushes.Black, float.Parse("5"), float.Parse("60"));

                e.Graphics.DrawString("Bill No: " + trnNo, font, Brushes.Black, float.Parse("5"), float.Parse("75"));

                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), float.Parse("95"));

                e.Graphics.DrawString("S.No", font, Brushes.Black, float.Parse("5"), float.Parse("105"));

                e.Graphics.DrawString("Item(Qty)", font, Brushes.Black, float.Parse("50"), float.Parse("105"));

                e.Graphics.DrawString("MRP", font, Brushes.Black, float.Parse("150"), float.Parse("105"));

                e.Graphics.DrawString("RATE", font, Brushes.Black, float.Parse("235"), float.Parse("105"));
                e.Graphics.DrawString("Total", font, Brushes.Black, float.Parse("320"), float.Parse("105"));

                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), float.Parse("120"));
                //Header

                //Body
                float xx = 135;
                float yy = 5;
                decimal countqty = 0;
                decimal GrandTotal = 0;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    decimal TotalAmount;
                    //dt1.AcceptChanges();
                    if (dt1.Rows[i]["Item"].ToString().Length > 10)
                    {
                        string splitItemName1 = (dt1.Rows[i]["Item"].ToString().Substring(0, 10));
                        string splitItemName2 = (dt1.Rows[i]["Item"].ToString().Substring(10));


                        e.Graphics.DrawString(dt1.Rows[i]["sno"].ToString(), font, Brushes.Black, yy, xx);

                        yy = 50;
                        e.Graphics.DrawString(splitItemName1 + "-", font, Brushes.Black, yy, xx);
                        yy = 50;
                        xx = xx + 15;

                        e.Graphics.DrawString(splitItemName2 + " (" + dt1.Rows[i]["Qty"].ToString() + ")", font, Brushes.Black, yy, xx);
                        //yy = 60;
                        //xx = xx + 15;

                       

                        yy = 150;
                        xx = xx - 15;
                        e.Graphics.DrawString("" + dt1.Rows[i]["MRP"].ToString() + "/" + dt1.Rows[i]["Type"].ToString() + "", font, Brushes.Black, yy, xx);

                        

                        yy = 235;
                        e.Graphics.DrawString(dt1.Rows[i]["Price"].ToString(), font, Brushes.Black, yy, xx);

                       

                        yy = 320;
                        TotalAmount = Math.Round((decimal.Parse(dt1.Rows[i]["Qty"].ToString()) * decimal.Parse(dt1.Rows[i]["Price"].ToString())), 2);
                        e.Graphics.DrawString("" + TotalAmount.ToString(), font, Brushes.Black, yy, xx);
                        //e.Graphics.DrawString("" + dt1.Rows[i]["Vat(%)"].ToString(), font, Brushes.Black, yy, xx);
                        xx = xx + 55;
                        yy = 5;
                    }
                    else
                    {
                        e.Graphics.DrawString(dt1.Rows[i]["sno"].ToString(), font, Brushes.Black, yy, xx);
                        yy = 50;

                        e.Graphics.DrawString(dt1.Rows[i]["Item"].ToString() + " (" + dt1.Rows[i]["Qty"].ToString() + ")", font, Brushes.Black, yy, xx);
                        //yy = 60;
                        //xx = xx + 15;
                        

                        yy = 150;
                        //xx = xx - 15;
                        e.Graphics.DrawString("" + dt1.Rows[i]["MRP"].ToString() + "/" + dt1.Rows[i]["Type"].ToString() + "", font, Brushes.Black, yy, xx);
                       

                        yy = 235;
                        e.Graphics.DrawString(dt1.Rows[i]["Price"].ToString(), font, Brushes.Black, yy, xx);

                        
                        yy = 320;
                        TotalAmount = Math.Round((decimal.Parse(dt1.Rows[i]["Qty"].ToString()) * decimal.Parse(dt1.Rows[i]["Price"].ToString())), 2);
                        e.Graphics.DrawString("" + TotalAmount.ToString(), font, Brushes.Black, yy, xx);

                        //e.Graphics.DrawString("" + dt1.Rows[i]["Vat(%)"].ToString(), font, Brushes.Black, yy, xx);
                        xx = xx + 40;
                        yy = 5;
                    }
                    // countqty = countqty + decimal.Parse(dt1.Rows[i]["Qty"].ToString());
                    GrandTotal = GrandTotal + TotalAmount;
                }
                //Footer
                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);

                xx = xx + 20;
                //e.Graphics.DrawString("Tot Qty:", font, Brushes.Black, float.Parse("5"), xx);

                //e.Graphics.DrawString(countqty.ToString(), font, Brushes.Black, float.Parse("75"), xx);

                e.Graphics.DrawString("Total :", font, Brushes.Black, float.Parse("172"), xx);

                e.Graphics.DrawString("" + GrandTotal.ToString(), font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Discount : ", font, Brushes.Black, float.Parse("150"), xx);

                e.Graphics.DrawString(txtDisc2.Text + "", font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("After Discount : ", font, Brushes.Black, float.Parse("102"), xx);

                e.Graphics.DrawString(txtAmount2.Text + "", font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Vat Amt : ", font, Brushes.Black, float.Parse("155"), xx);

                e.Graphics.DrawString(txtVatAmt2.Text + "", font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Grand Total :", font, Brushes.Black, float.Parse("125"), xx);

                e.Graphics.DrawString(txtDue2.Text, font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                decimal Savings = 0;
                foreach (DataRow dr in dt1.Rows)
                {
                    Savings = Savings + (decimal.Parse(dr["MRP"].ToString()) * decimal.Parse(dr["Qty"].ToString()));

                }


                e.Graphics.DrawString("Your Savings : ", font, Brushes.Black, float.Parse("117"), xx);

                e.Graphics.DrawString((decimal.Parse(Savings.ToString()) - decimal.Parse(txtAmount2.Text)).ToString(), font, Brushes.Black, float.Parse("235"), xx);


                xx = xx + 20;
                Image myimg = Code128Rendering.MakeBarcodeImage(trnNo, 2, true);
                e.Graphics.DrawImage(myimg, 1, xx);

                xx = xx + 60;
                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);
                xx = xx + 20;

                e.Graphics.DrawString("NO EXCHANGE !!!", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;

                e.Graphics.DrawString("GOODS ONCE SOLD CAN NOT BE TAKEN BACK !!!", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;
                e.Graphics.DrawString("*** CONDITION APPLY ***", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;

                e.Graphics.DrawString("Thank You. Visit Again !!!", font, Brushes.Black, float.Parse("8"), xx);
                //Footer
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                if (!dt2.Columns.Contains("sno"))
                {
                    dt2.Columns.Add("sno");

                    int k = 1;
                    foreach (DataRow dr in dt2.Rows)
                    {
                        dr["sno"] = k.ToString();
                        k++;
                    }

                }

                Font font = new Font("Courier New", 9, System.Drawing.FontStyle.Bold);

                Font Header = new Font("Calibri", 11, System.Drawing.FontStyle.Bold);
                e.Graphics.DrawString("SALE INVOICE", Header, Brushes.Black, float.Parse("150"), float.Parse("0"));
                e.Graphics.DrawString(dtshop.Rows[0]["ShopName"].ToString(), Header, Brushes.Black, float.Parse("150"), float.Parse("15"));

                e.Graphics.DrawString("Address : " + dtshop.Rows[0]["Address"].ToString(), Header, Brushes.Black, float.Parse("150"), float.Parse("30"));
                //e.Graphics.DrawString("Ph: " + dtshop.Rows[0]["ContactNo"].ToString(), Header, Brushes.Black, float.Parse("50"), float.Parse("45"));
                e.Graphics.DrawString("TIN No : " + dtshop.Rows[0]["TIN"].ToString(), Header, Brushes.Black, float.Parse("150"), float.Parse("45"));


                //Header               

                //  e.Graphics.DrawString("Sales Bill", Header, Brushes.Black, float.Parse("15"), float.Parse("0"));

                e.Graphics.DrawString("Bill Date: " + DateTime.Now.ToString("dd-MM-yyyy"), font, Brushes.Black, float.Parse("5"), float.Parse("60"));

                e.Graphics.DrawString("Bill No: " + trnNo, font, Brushes.Black, float.Parse("5"), float.Parse("75"));

                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), float.Parse("95"));

                e.Graphics.DrawString("S.No)", font, Brushes.Black, float.Parse("5"), float.Parse("105"));

                e.Graphics.DrawString("Item(Qty)", font, Brushes.Black, float.Parse("50"), float.Parse("105"));
                e.Graphics.DrawString("MRP", font, Brushes.Black, float.Parse("150"), float.Parse("105"));

                e.Graphics.DrawString("Rate", font, Brushes.Black, float.Parse("235"), float.Parse("105"));
                e.Graphics.DrawString("Total", font, Brushes.Black, float.Parse("320"), float.Parse("105"));

                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), float.Parse("120"));
                //Header

                //Body
                float xx = 135;
                float yy = 5;
                decimal countqty = 0;
                decimal GrandTotal = 0;
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    decimal TotalAmount;

                    if (dt2.Rows[i]["Item"].ToString().Length > 10)
                    {
                        string splitItemName1 = (dt2.Rows[i]["Item"].ToString().Substring(0, 10));
                        string splitItemName2 = (dt2.Rows[i]["Item"].ToString().Substring(10));

                        e.Graphics.DrawString("" + dt2.Rows[i]["sno"].ToString(), font, Brushes.Black, yy, xx);
                        yy = 50;

                        e.Graphics.DrawString(splitItemName1 + "-", font, Brushes.Black, yy, xx);
                        yy = 50;
                        xx = xx + 15;

                        e.Graphics.DrawString(splitItemName2 + " (" + dt2.Rows[i]["Qty"].ToString() + ")", font, Brushes.Black, yy, xx);
                        //yy = 60;
                        //xx = xx + 15;

                       

                        yy = 150;
                        xx = xx - 15;
                        e.Graphics.DrawString("" + dt2.Rows[i]["MRP"].ToString() + "/" + dt2.Rows[i]["Type"].ToString() + "", font, Brushes.Black, yy, xx);

                       
                        yy = 235;
                        e.Graphics.DrawString(dt2.Rows[i]["Price"].ToString(), font, Brushes.Black, yy, xx);

                       

                        yy = 320;
                        TotalAmount = Math.Round((decimal.Parse(dt2.Rows[i]["Qty"].ToString()) * decimal.Parse(dt2.Rows[i]["Price"].ToString())), 2);
                        e.Graphics.DrawString("" + TotalAmount.ToString(), font, Brushes.Black, yy, xx);
                        //e.Graphics.DrawString("" + dt2.Rows[i]["Vat(%)"].ToString(), font, Brushes.Black, yy, xx);

                        xx = xx + 55;
                        yy = 5;
                    }
                    else
                    {
                        e.Graphics.DrawString("" + dt2.Rows[i]["sno"].ToString(), font, Brushes.Black, yy, xx);
                        yy = 50;

                        e.Graphics.DrawString(dt2.Rows[i]["Item"].ToString() + " (" + dt2.Rows[i]["Qty"].ToString() + ")", font, Brushes.Black, yy, xx);
                        //yy = 60;
                        //xx = xx + 15;
                        

                        yy = 150;
                        //xx = xx - 15;
                        e.Graphics.DrawString("" + dt2.Rows[i]["MRP"].ToString() + "/" + dt2.Rows[i]["Type"].ToString() + "", font, Brushes.Black, yy, xx);

                        
                        yy = 235;
                        e.Graphics.DrawString(dt2.Rows[i]["Price"].ToString(), font, Brushes.Black, yy, xx);
                        

                        yy = 320;
                        TotalAmount = Math.Round((decimal.Parse(dt2.Rows[i]["Qty"].ToString()) * decimal.Parse(dt2.Rows[i]["Price"].ToString())), 2);
                        e.Graphics.DrawString("" + TotalAmount.ToString(), font, Brushes.Black, yy, xx);
                        //e.Graphics.DrawString("" + dt2.Rows[i]["Vat(%)"].ToString(), font, Brushes.Black, yy, xx);
                        xx = xx + 40;
                        yy = 5;
                    }
                    // countqty = countqty + decimal.Parse(dt2.Rows[i]["Qty"].ToString());
                    GrandTotal = GrandTotal + TotalAmount;
                }
                //Footer
                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);

                xx = xx + 20;
                //e.Graphics.DrawString("Tot Qty:", font, Brushes.Black, float.Parse("5"), xx);

                //e.Graphics.DrawString(countqty.ToString(), font, Brushes.Black, float.Parse("75"), xx);

                e.Graphics.DrawString("Total :", font, Brushes.Black, float.Parse("172"), xx);

                e.Graphics.DrawString("" + GrandTotal.ToString(), font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Discount : ", font, Brushes.Black, float.Parse("150"), xx);

                e.Graphics.DrawString(txtDis3.Text + "", font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("After Discount : ", font, Brushes.Black, float.Parse("102"), xx);

                e.Graphics.DrawString(txtAmount3.Text + "", font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Vat Amt : ", font, Brushes.Black, float.Parse("155"), xx);

                e.Graphics.DrawString(txtVatAmt3.Text + "", font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Grand Total :", font, Brushes.Black, float.Parse("125"), xx);

                e.Graphics.DrawString(txtDue3.Text, font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;


                decimal Savings = 0;
                foreach (DataRow dr in dt2.Rows)
                {
                    Savings = Savings + (decimal.Parse(dr["MRP"].ToString()) * decimal.Parse(dr["Qty"].ToString()));

                }


                e.Graphics.DrawString("Your Savings : ", font, Brushes.Black, float.Parse("117"), xx);

                e.Graphics.DrawString((decimal.Parse(Savings.ToString()) - decimal.Parse(txtAmount3.Text)).ToString(), font, Brushes.Black, float.Parse("235"), xx);


                xx = xx + 20;

                Image myimg = Code128Rendering.MakeBarcodeImage(trnNo, 2, true);
                e.Graphics.DrawImage(myimg, 1, xx);

                xx = xx + 60;

                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);
                xx = xx + 20;

                e.Graphics.DrawString("NO EXCHANGE !!!", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;

                e.Graphics.DrawString("GOODS ONCE SOLD CAN NOT BE TAKEN BACK !!!", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;
                e.Graphics.DrawString("*** CONDITION APPLY ***", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;

                e.Graphics.DrawString("Thank You. Visit Again !!!", font, Brushes.Black, float.Parse("8"), xx);
                //Footer
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSmartPOS_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox5.Visible = false;
            groupBox10.Visible = false;
            groupBox15.Visible = true;


        }

        DataTable dt3 = new DataTable();
        private void txtItemBarcode_TextChanged(object sender, EventArgs e)
        {
            GlobalData.Dtpopup = new DataTable();
            GlobalData.ItemIDs = string.Empty;
            DataTable dtpopup = new DataTable();


            if (ChkActivatePopup.Checked == true && !string.IsNullOrEmpty(txtItemBarcode.Text.Trim()))
            {
                dtpopup = sqlhelper.ExecuteTables("select ItemID,CategoryID,barcode,ItemName,MRP,saleprice,StockQuantity as [Qty Available],QtyType,VatPercent from GetItemsForCashier where (ItemName like '" + txtItemBarcode.Text + "%' or MBarcode like'" + txtItemBarcode.Text + "%' or Barcode like'" + txtItemBarcode.Text + "%')");
                if (dtpopup.Rows.Count > 0)
                {
                    GlobalData.Dtpopup = dtpopup;
                    FRM_ITEMSPOPUP frm = new FRM_ITEMSPOPUP();
                    frm.ShowDialog();
                    dtpopup = new DataTable();
                    DataView dv = new DataView(GlobalData.Dtpopup);
                    if (!string.IsNullOrEmpty(GlobalData.ItemIDs))
                    {
                        dv.RowFilter = "ItemID in (" + GlobalData.ItemIDs + ")";
                        dtpopup = dv.ToTable();
                    }

                    if (dtpopup.Rows.Count > 0)
                    {

                        for (int j = 0; j < dtpopup.Rows.Count; j++)
                        {
                            if (Convert.ToDecimal(dtpopup.Rows[j]["Qty Available"].ToString()) <= 0)
                            {
                                MessageBox.Show("Stock is not available for one or more seleted items");
                            }
                            else
                            {
                                if (dt3.Columns.Count < 1)
                                {
                                    //dt3.Columns.Add("SNo");
                                    dt3.Columns.Add("Item");
                                    dt3.Columns.Add("Price");
                                    dt3.Columns.Add("Qty");
                                    dt3.Columns.Add("Type");
                                    dt3.Columns.Add("Barcode");
                                    dt3.Columns.Add("ItemID");
                                    dt3.Columns.Add("CategoryID");
                                    dt3.Columns.Add("Vat(%)");
                                    dt3.Columns.Add("MRP");                                  
                                }

                                //Serial Number Code
                                if (!dt3.Columns.Contains("SNo"))
                                {
                                    dt3.Columns.Add("SNo");

                                    
                                }
                                //Serial No Code Ends


                                dt3.AcceptChanges();
                                DataRow row = dt3.NewRow();
                                

                                if (dt3.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt3.Rows.Count; i++)
                                    {
                                        if (dt3.Rows[i]["Barcode"].ToString() == dtpopup.Rows[j]["barcode"].ToString())
                                        {
                                            row["Qty"] = dt3.Rows[i]["Qty"].ToString();
                                        }
                                        else
                                        {
                                            row["Qty"] = "1";
                                        }
                                    }
                                }
                                else
                                {
                                    row["Qty"] = "1";
                                }
                                row["ItemID"] = dtpopup.Rows[j]["ItemID"].ToString();
                                row["CategoryID"] = dtpopup.Rows[j]["CategoryID"].ToString();
                                row["Item"] = dtpopup.Rows[j]["ItemName"].ToString();
                                row["Type"] = dtpopup.Rows[j]["QtyType"].ToString();
                                row["Price"] = dtpopup.Rows[j]["saleprice"].ToString();
                                row["Vat(%)"] = dtpopup.Rows[j]["VatPercent"].ToString();
                                row["Barcode"] = dtpopup.Rows[j]["barcode"].ToString();
                                row["MRP"] = dtpopup.Rows[j]["MRP"].ToString();                               
                                dt3.Rows.Add(row);
                                DataView dView = new DataView(dt3);
                                string[] arrColumns = {"SNo", "Item", "Price", "Qty", "Type", "Barcode", "ItemID", "CategoryID", "Vat(%)", "MRP"};
                                dt3 = dView.ToTable(true, arrColumns);
                                dt3.AcceptChanges();                                
                            }
                        }
                        //Serial Number Code
                        int p = 1;

                        foreach (DataRow dr in dt3.Rows)
                        {
                            dr["SNo"] = p.ToString();
                            p++;
                        }
                        //Serial No Code Ends
                        dataGridView4.DataSource = dt3;
                        dataGridView4.Columns[5].Visible = false;
                        dataGridView4.Columns[6].Visible = false;
                        dataGridView4.Columns[7].Visible = false;                        
                        dataGridView4.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                        pric = 0;

                        decimal VatAmount = 0;
                        for (int k = 0; k < (dataGridView4.Rows.Count); k++)
                        {
                            dataGridView4.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
                            //decimal afterdiscountamount = (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()));
                            pric = Math.Round((pric + (decimal.Parse(dataGridView4.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView4.Rows[k].Cells[3].Value.ToString()))), 2);
                            VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView4.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView4.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView4.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                        }
                        txtSTotal.Text = pric.ToString();
                        SVatAmt.Text = VatAmount.ToString();
                        txtSAmount.Text = (Math.Round((decimal.Parse(txtSTotal.Text) - (decimal.Parse(txtSDiscount.Text))), 2)).ToString();
                        txtItemBarcode.Text = string.Empty;                       

                    }

                    GlobalData.Dtpopup = new DataTable();
                    GlobalData.ItemIDs = string.Empty;

                }

            }
            else
            {

                DataSet ds1 = new DataSet();
                sqlhelper = new SQLHelper();
                if (!string.IsNullOrEmpty(txtItemBarcode.Text.Trim()))
                {
                    ds1 = sqlhelper.ExecuteQueries("select * from GetItemsForCashier where ItemName ='" + txtItemBarcode.Text + "' or MBarcode='" + txtItemBarcode.Text + "' or Barcode='" + txtItemBarcode.Text + "'");

                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        //label10.Text = string.Empty;
                        //label10.Text = "Avail Quantity " + Convert.ToInt32(ds1.Tables[0].Rows[0]["StockQuantity"].ToString());

                        if (Convert.ToDecimal(ds1.Tables[0].Rows[0]["StockQuantity"].ToString()) <= 0)
                        {
                            MessageBox.Show("Stock is not available for this Item");
                        }
                        else
                        {
                            if (dt3.Columns.Count < 1)
                            {
                                dt3.Columns.Add("Item");
                                dt3.Columns.Add("Price");
                                dt3.Columns.Add("Qty");
                                dt3.Columns.Add("Type");
                                dt3.Columns.Add("Barcode");
                                dt3.Columns.Add("ItemID");
                                dt3.Columns.Add("CategoryID");
                                dt3.Columns.Add("Vat(%)");
                                dt3.Columns.Add("MRP");                               
                            }

                            //Serial Number Code
                            if (!dt3.Columns.Contains("SNo"))
                            {
                                dt3.Columns.Add("SNo");


                            }
                            //Serial No Code Ends

                            dt3.AcceptChanges();
                            DataRow row = dt3.NewRow();

                            if (dt3.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt3.Rows.Count; i++)
                                {
                                    if (dt3.Rows[i]["Barcode"].ToString() == ds1.Tables[0].Rows[0]["barcode"].ToString())
                                    {
                                        row["Qty"] = dt3.Rows[i]["Qty"].ToString();
                                    }
                                    else
                                    {
                                        row["Qty"] = "1";
                                    }
                                }
                            }
                            else
                            {
                                row["Qty"] = "1";
                            }
                            row["ItemID"] = ds1.Tables[0].Rows[0]["ItemID"].ToString();
                            row["CategoryID"] = ds1.Tables[0].Rows[0]["CategoryID"].ToString();
                            row["Item"] = ds1.Tables[0].Rows[0]["ItemName"].ToString();
                            row["Type"] = ds1.Tables[0].Rows[0]["QtyType"].ToString();
                            row["Price"] = ds1.Tables[0].Rows[0]["saleprice"].ToString();
                            row["Vat(%)"] = ds1.Tables[0].Rows[0]["VatPercent"].ToString();
                            row["Barcode"] = ds1.Tables[0].Rows[0]["barcode"].ToString();
                            row["MRP"] = ds1.Tables[0].Rows[0]["MRP"].ToString();                           
                            dt3.Rows.Add(row);
                            DataView dView = new DataView(dt3);
                            string[] arrColumns = { "SNo", "Item", "Price", "Qty", "Type", "Barcode", "ItemID", "CategoryID", "Vat(%)", "MRP"};
                            dt3 = dView.ToTable(true, arrColumns);
                            dt3.AcceptChanges();

                            int p = 1;
                            foreach (DataRow dr in dt3.Rows)
                            {
                                dr["SNo"] = p.ToString();
                                p++;
                            }


                            dataGridView4.DataSource = dt3;
                            dataGridView4.Columns[5].Visible = false;
                            dataGridView4.Columns[6].Visible = false;
                            dataGridView4.Columns[7].Visible = false;                            
                            dataGridView4.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                            pric = 0;
                            decimal VatAmount = 0;
                            for (int k = 0; k < (dataGridView4.Rows.Count); k++)
                            {
                                dataGridView4.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
                                //decimal afterdiscountamount = (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()));
                                pric = Math.Round((pric + (decimal.Parse(dataGridView4.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView4.Rows[k].Cells[3].Value.ToString()))), 2);
                                VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView4.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView4.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView4.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                            }
                            txtSTotal.Text = pric.ToString();
                            SVatAmt.Text = VatAmount.ToString();
                            txtSAmount.Text = (Math.Round((decimal.Parse(txtSTotal.Text) - (decimal.Parse(txtSDiscount.Text))), 2)).ToString();
                            txtItemBarcode.Text = string.Empty;
                        }
                    }
                }
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn dc in dataGridView4.Columns)
            {
                if (dc.Index.Equals(2))
                {
                    dc.ReadOnly = false;
                }
                else
                {
                    dc.ReadOnly = true;
                }

            }
        }

        private void cancelSmarttrans()
        {
            dataGridView4.DataSource = null;
            dataGridView4.Columns.Clear();
            dt3 = new DataTable();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            cancelSmarttrans();

        }

        private void dataGridView4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();
                DataSet dsstk3 = new DataSet();
                SQLHelper sqlh3 = new SQLHelper();
                dsstk3 = sqlh3.ExecuteQueries("select * from GetItemsForCashier where barcode='" + dataGridView4.Rows[e.RowIndex].Cells["Barcode"].Value.ToString() + "'");
                if (dsstk3.Tables[0].Rows.Count > 0)
                {

                    if (!string.IsNullOrEmpty(dataGridView4.Rows[e.RowIndex].Cells["Qty"].Value.ToString()))
                    {
                        if ((Convert.ToDecimal(dataGridView4.Rows[e.RowIndex].Cells["Qty"].Value.ToString())) > (Convert.ToDecimal(dsstk3.Tables[0].Rows[0]["StockQuantity"].ToString())))
                        {
                            FrmMessage.Show("You Cannot take more than " + dsstk3.Tables[0].Rows[0]["StockQuantity"].ToString() + " for this Item", caption, OkButton, ErrorIcon);
                            dataGridView4.Rows[e.RowIndex].Cells[2].Value = Convert.ToDecimal(dsstk3.Tables[0].Rows[0]["StockQuantity"].ToString());
                        }
                    }
                    else
                    {
                        dataGridView4.Rows[e.RowIndex].Cells["Qty"].Value = "1";
                    }
                }

                pric = 0;
                decimal VatAmount = 0;
                for (int k = 0; k < (dataGridView4.Rows.Count); k++)
                {
                    dataGridView4.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
                    //decimal afterdiscountamount = (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()));
                    pric = Math.Round((pric + (decimal.Parse(dataGridView4.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView4.Rows[k].Cells[3].Value.ToString()))), 2);
                    VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView4.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView4.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView4.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                }
                txtSTotal.Text = pric.ToString();
                SVatAmt.Text = VatAmount.ToString();
                if (txtSDiscount.Text != "0")
                {
                    txtSAmount.Text = (Math.Round((decimal.Parse(txtSTotal.Text) - (decimal.Parse(txtSDiscount.Text))), 2)).ToString();
                }
                else
                {
                    txtSAmount.Text = txtSTotal.Text;
                }

            }
        }

        private void dataGridView4_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
        }

        private void dataGridView4_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                dataGridView4.SelectedRows[0].Cells["Barcode"].Value.ToString();
                DataSet dsstk = new DataSet();
                SQLHelper sqlh = new SQLHelper();
                dsstk = sqlh.ExecuteQueries("select * from GetItemsForCashier where barcode='" + dataGridView4.SelectedRows[0].Cells["Barcode"].Value.ToString() + "'");
                if (dsstk.Tables[0].Rows.Count > 0)
                {
                    // lblMaxQty.Text = "Avail Quantity " + Convert.ToDecimal(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString());
                }
            }
        }

        private void dataGridView4_Sorted(object sender, EventArgs e)
        {
            pric = 0;
            for (int k = 0; k < (dataGridView4.Rows.Count); k++)
            {
                pric = Math.Round((pric + (decimal.Parse(dataGridView4.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView4.Rows[k].Cells[3].Value.ToString()))), 2);
            }
            txtSTotal.Text = pric.ToString();
            txtSAmount.Text = (Math.Round((decimal.Parse(txtSTotal.Text) - (decimal.Parse(txtSDiscount.Text))), 2)).ToString();
        }

        private void txtSDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSDiscount.Text))
                {
                    //   txtBillpaid.Text = Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtGrandTotal.Text) * (decimal.Parse(txtDiscount.Text) / 100))),2).ToString();
                    txtSAmount.Text = Math.Round((decimal.Parse(txtSTotal.Text) - (decimal.Parse(txtSDiscount.Text))), 2).ToString();
                }
                else
                {
                    txtSDiscount.Text = "0";

                }
            }
            catch (Exception ex)
            {

            }
        }


        private void savesmartPos()
        {
            try
            {
                if (string.IsNullOrEmpty(txtSAmount.Text) || dataGridView4.Rows.Count <= 0)
                {
                    FrmMessage.Show("You cannot Generate Bill without Items", caption, OkButton, ErrorIcon);
                }

                else
                {
                    sqlhelper = new SQLHelper();
                    bool result;

                    ds = new DataSet();
                    int count;
                    ds = sqlhelper.ExecuteQueries("select TranNo from TransactionNo");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["TranNo"].ToString()))
                        {
                            count = 1;
                        }
                        else
                        {
                            count = int.Parse(ds.Tables[0].Rows[0]["TranNo"].ToString()) + 1;
                        }
                    }
                    else
                    {
                        count = 1;
                    }

                    string todaysDate = sqlhelper.ExecuteScalar("select format(date(),'ddmmyyyy')");
                    trnNo = todaysDate + count;
                    result = sqlhelper.ExecuteNonQuery("insert into Payment(TransactionNo,TotalAmount,DiscountAmount,BillPaid,CreatedBy)" +
                                                       "values ('" + trnNo + "','" + txtSTotal.Text + "','" + txtSDiscount.Text + "', '" + txtSAmount.Text + "'," +
                                                       "" + GlobalData.UserID + ")");

                    result = sqlhelper.ExecuteNonQuery("insert into TaxHistory(TransactionNo,TotalAmount,DiscountAmount,BillPaid,VATAmount,Paid,CreatedBy)" +
                                                    "values ('" + trnNo + "','" + txtSTotal.Text + "','" + txtSDiscount.Text + "', '" + txtSAmount.Text + "', '" + SVatAmt.Text + "', '" + SDue.Text + "'," +
                                                    "" + GlobalData.UserID + ")");


                    if (result == true)
                    {
                        //string InitCode = "";
                        //int lengthofInitCode = 0;
                        //string MaxCode;

                        string PaymentId = sqlhelper.ExecuteScalar("select max(PaymentID) from Payment");

                        for (int i = 0; i < dataGridView4.Rows.Count; i++)
                        {

                            //InitCode = sqlhelper.ExecuteScalar("select CategoryInitCode from Categories where CategoryID=" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "");
                            //lengthofInitCode = InitCode.Split('-')[0].Length + 1;

                            //MaxCode = sqlhelper.ExecuteScalar("SELECT Max(val(Mid([CodeNo]," + (lengthofInitCode + 1) + "))) as MaxCode FROM Transactions where CategoryID =" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "");
                            //if (string.IsNullOrEmpty(MaxCode))
                            //{
                            //    MaxCode = InitCode.Split('-')[1];
                            //}
                            //InitCode = InitCode.Split('-')[0] + "-";
                            //MaxCode = InitCode + (int.Parse(MaxCode) + 1).ToString();

                            result = sqlhelper.ExecuteNonQuery("insert into Transactions(PaymentID,Barcode,CategoryID,ItemID,SaleQty,VatPercent,ItemPrice,CreatedBy)" +
                                                               "values (" + PaymentId + ",'" + dataGridView4.Rows[i].Cells["Barcode"].Value.ToString() + "'," + dataGridView4.Rows[i].Cells["CategoryID"].Value.ToString() + "," +
                                                               "" + dataGridView4.Rows[i].Cells["ItemID"].Value.ToString() + "," + dataGridView4.Rows[i].Cells["Qty"].Value.ToString() + "," +
                                                               "" + dataGridView4.Rows[i].Cells["Vat(%)"].Value.ToString() + "," + dataGridView4.Rows[i].Cells["Price"].Value.ToString() + "," + GlobalData.UserID + ")");

                            result = sqlhelper.ExecuteNonQuery("Update Stock Set StockQuantity = (StockQuantity - " + dataGridView4.Rows[i].Cells["Qty"].Value.ToString() + ")" +
                                                               " where CategoryID= " + dataGridView4.Rows[i].Cells["CategoryID"].Value.ToString() + " and  " +
                                                               "ItemID=" + dataGridView4.Rows[i].Cells["ItemID"].Value.ToString() + " and Barcode='" + dataGridView4.Rows[i].Cells["Barcode"].Value.ToString() + "'");


                        }

                        if (result == true)
                        {
                            if (checkBox8.Checked == true)
                            {
                                if (string.IsNullOrEmpty(textBox64.Text))
                                {
                                }
                                else
                                {
                                    result = sqlhelper.ExecuteNonQuery("insert into DEALERCREDIT(DealerID,TransactionNo,TotalAmount,DiscountAmount,AfterDiscount,VATAmount,TOTALDUE,CreatedBy,STATUS)" +
                                                             "values ('" + DEALERID + "','" + trnNo + "','" + txtSTotal.Text + "', '" + txtSDiscount.Text + "', '" + txtSAmount.Text + "', " + SVatAmt.Text + ", " + SDue.Text + ", " + GlobalData.UserID + ", 'CREDIT')");
                                    checkBox8.Checked = false;
                                    panel24.Visible = false;
                                    textBox62.Text = string.Empty;
                                    textBox63.Text = string.Empty;
                                    textBox64.Text = string.Empty;

                                }
                            }

                            if (checkBox7.Checked == true)
                            {
                                if (string.IsNullOrEmpty(textBox61.Text))
                                {
                                }
                                else
                                {
                                    result = sqlhelper.ExecuteNonQuery("insert into AGENTEARNEDCOMISSION(ANO,TransactionNo,COMISSIONEARNED,COMISSION)" +
                                                             "values ('" + ANO + "','" + trnNo + "','" + textBox58.Text + "', '" + textBox59.Text + "')");
                                    checkBox7.Checked = false;
                                    panel23.Visible = false;
                                    textBox58.Text = string.Empty;
                                    textBox59.Text = string.Empty;
                                    textBox60.Text = string.Empty;
                                    textBox61.Text = string.Empty;

                                }
                            }


                            BillPrintPreview.Document = printDocument3;
                            BillPrintPreview.PrintPreviewControl.Zoom = 1;
                            BillPrintPreview.ShowDialog();

                            // BillPrint.Print();
                        }
                    }


                    FrmMessage.Show("Transaction Successful", caption, OkButton, InformationIcon);
                    cancelSmarttrans();
                    textBox12.Text = string.Empty;
                    textBox13.Text = string.Empty;
                    textBox14.Text = string.Empty;
                    textBox15.Text = string.Empty;
                    SVatAmt.Text = "0";
                    //textBox16.Text = "0";
                    textBox18.Text = "0";
                    txtSTotal.Text = "0";
                    textBox19.Text = "PACNO";
                    txtSAmount.Text ="0";


                    button10.Visible = true;
                    button8.Visible = false;

                }
            }
            catch (Exception ex)
            {
                FrmMessage.Show(ex.ToString());
            }
        }

        private void savesmartPos1()
        {
            try
            {
                if (string.IsNullOrEmpty(txtSAmount.Text) || dataGridView4.Rows.Count <= 0)
                {
                    FrmMessage.Show("You cannot Generate Bill without Items", caption, OkButton, ErrorIcon);
                }
                else if (string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrEmpty(textBox19.Text))
                {
                    FrmMessage.Show("Redeem Card No should be Entered or Cancel the Redeem", caption, OkButton, ErrorIcon);
                }
                else
                {
                    sqlhelper = new SQLHelper();
                    bool result;

                    //result = sqlhelper.ExecuteNonQuery("insert into Customers(CustName,Phone) values ('" + txtCustName.Text + "'," + txtCustPhnNo.Text + ")");
                    //if (result == true)
                    //{

                    ds = new DataSet();
                    int count;
                    ds = sqlhelper.ExecuteQueries("select TranNo from TransactionNo");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["TranNo"].ToString()))
                        {
                            count = 1;
                        }
                        else
                        {
                            count = int.Parse(ds.Tables[0].Rows[0]["TranNo"].ToString()) + 1;
                        }
                    }
                    else
                    {
                        count = 1;
                    }

                    string todaysDate = sqlhelper.ExecuteScalar("select format(date(),'ddmmyyyy')");
                    trnNo = todaysDate + count;
                    result = sqlhelper.ExecuteNonQuery("insert into Payment(TransactionNo,TotalAmount,DiscountAmount,BillPaid,CreatedBy)" +
                                                       "values ('" + trnNo + "','" + txtSTotal.Text + "','" + txtSDiscount.Text + "', '" + txtSAmount.Text + "'," +
                                                       "" + GlobalData.UserID + ")");

                    result = sqlhelper.ExecuteNonQuery("insert into TaxHistory(TransactionNo,TotalAmount,DiscountAmount,BillPaid,VATAmount,Paid,CreatedBy)" +
                                                    "values ('" + trnNo + "','" + txtSTotal.Text + "','" + txtSDiscount.Text + "', '" + txtSAmount.Text + "','" + SVatAmt.Text + "', '" + SDue.Text + "'," +
                                                    "" + GlobalData.UserID + ")");

                    if (result == true)
                    {


                        string PaymentId = sqlhelper.ExecuteScalar("select max(PaymentID) from Payment");

                        for (int i = 0; i < dataGridView4.Rows.Count; i++)
                        {
                            result = sqlhelper.ExecuteNonQuery("insert into Transactions(PaymentID,Barcode,CategoryID,ItemID,SaleQty,VatPercent,ItemPrice,CreatedBy)" +
                                                               "values (" + PaymentId + ",'" + dataGridView4.Rows[i].Cells["Barcode"].Value.ToString() + "'," + dataGridView4.Rows[i].Cells["CategoryID"].Value.ToString() + "," +
                                                               "" + dataGridView4.Rows[i].Cells["ItemID"].Value.ToString() + "," + dataGridView4.Rows[i].Cells["Qty"].Value.ToString() + "," +
                                                               "" + dataGridView4.Rows[i].Cells["Vat(%)"].Value.ToString() + "," + dataGridView4.Rows[i].Cells["Price"].Value.ToString() + "," + GlobalData.UserID + ")");

                            result = sqlhelper.ExecuteNonQuery("Update Stock Set StockQuantity = (StockQuantity - " + dataGridView4.Rows[i].Cells["Qty"].Value.ToString() + ")" +
                                                               " where CategoryID= " + dataGridView4.Rows[i].Cells["CategoryID"].Value.ToString() + " and  " +
                                                               "ItemID=" + dataGridView4.Rows[i].Cells["ItemID"].Value.ToString() + " and Barcode='" + dataGridView4.Rows[i].Cells["Barcode"].Value.ToString() + "'");

                        }


                        result = sqlhelper.ExecuteNonQuery("insert into RewardPoints(Points, PACNO)" +
                                                          "values (" + textBox15.Text + "," + textBox19.Text + ")");


                        if (redeemclick == true)
                        {
                            result = sqlhelper.ExecuteNonQuery("insert into RewardPointsUsed(TransactionNo, PACNO, POINTSUSED)" +
                                                              "values (" + trnNo + "," + textBox19.Text + "," + textBox18.Text + ")");

                            result = sqlhelper.ExecuteNonQuery("insert into RewardPoints(Points, PACNO)" +
                                                          "values (" + "-" + textBox18.Text + "," + textBox19.Text + ")");


                        }

                        if (result == true)
                        {
                            if (checkBox8.Checked == true)
                            {
                                if (string.IsNullOrEmpty(textBox64.Text))
                                {
                                }
                                else
                                {
                                    result = sqlhelper.ExecuteNonQuery("insert into DEALERCREDIT(DealerID,TransactionNo,TotalAmount,DiscountAmount,AfterDiscount,VATAmount,TOTALDUE,CreatedBy,STATUS)" +
                                                             "values ('" + DEALERID + "','" + trnNo + "','" + txtSTotal.Text + "', '" + txtSDiscount.Text + "', '" + txtSAmount.Text + "', " + SVatAmt.Text + ", " + SDue.Text + ", " + GlobalData.UserID + ", 'CREDIT')");
                                    checkBox8.Checked = false;
                                    panel24.Visible = false;
                                    textBox62.Text = string.Empty;
                                    textBox63.Text = string.Empty;
                                    textBox64.Text = string.Empty;

                                }
                            }

                            if (checkBox7.Checked == true)
                            {
                                if (string.IsNullOrEmpty(textBox61.Text))
                                {
                                }
                                else
                                {
                                    result = sqlhelper.ExecuteNonQuery("insert into AGENTEARNEDCOMISSION(ANO,TransactionNo,COMISSIONEARNED,COMISSION)" +
                                                             "values ('" + ANO + "','" + trnNo + "','" + textBox58.Text + "', '" + textBox59.Text + "')");
                                    checkBox7.Checked = false;
                                    panel23.Visible = false;
                                    textBox58.Text = string.Empty;
                                    textBox59.Text = string.Empty;
                                    textBox60.Text = string.Empty;
                                    textBox61.Text = string.Empty;

                                }
                            }



                            BillPrintPreview.Document = printDocument3;
                            BillPrintPreview.PrintPreviewControl.Zoom = 1;
                            BillPrintPreview.ShowDialog();

                            // BillPrint.Print();
                        }
                    }


                    FrmMessage.Show("Transaction Successful", caption, OkButton, InformationIcon);
                    cancelSmarttrans();
                    textBox12.Text = string.Empty;
                    textBox13.Text = string.Empty;
                    textBox14.Text = string.Empty;
                    textBox15.Text = string.Empty;
                    SVatAmt.Text = "0";
                    //textBox16.Text = string.Empty;
                    textBox18.Text = "0";
                    textBox19.Text = "PACNO";
                    txtSTotal.Text = "0";
                    txtSAmount.Text = "0";
                    button10.Visible = true;
                    button8.Visible = false;




                }
            }
            catch (Exception ex)
            {
                FrmMessage.Show(ex.ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // dt.AcceptChanges();

            savesmartPos();
        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                if (!dt3.Columns.Contains("sno"))
                {
                    dt3.Columns.Add("sno");

                    int k = 1;
                    foreach (DataRow dr in dt3.Rows)
                    {
                        dr["sno"] = k.ToString();
                        k++;
                    }
                }


                Font font = new Font("Courier New", 9, System.Drawing.FontStyle.Bold);

                Font Header = new Font("Calibri", 11, System.Drawing.FontStyle.Bold);
                e.Graphics.DrawString("SALE INVOICE", Header, Brushes.Black, float.Parse("150"), float.Parse("0"));
                e.Graphics.DrawString(dtshop.Rows[0]["ShopName"].ToString(), Header, Brushes.Black, float.Parse("150"), float.Parse("15"));

                e.Graphics.DrawString("Add : " + dtshop.Rows[0]["Address"].ToString(), Header, Brushes.Black, float.Parse("150"), float.Parse("30"));
                //e.Graphics.DrawString("Ph: " + dtshop.Rows[0]["ContactNo"].ToString(), Header, Brushes.Black, float.Parse("50"), float.Parse("45"));
                e.Graphics.DrawString("TIN No : " + dtshop.Rows[0]["TIN"].ToString(), Header, Brushes.Black, float.Parse("150"), float.Parse("45"));


                //Header               

                //  e.Graphics.DrawString("Sales Bill", Header, Brushes.Black, float.Parse("15"), float.Parse("0"));

                e.Graphics.DrawString("Bill Date: " + DateTime.Now.ToString("dd-MM-yyyy"), font, Brushes.Black, float.Parse("5"), float.Parse("60"));

                e.Graphics.DrawString("Bill No: " + trnNo, font, Brushes.Black, float.Parse("5"), float.Parse("75"));

                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), float.Parse("95"));

                e.Graphics.DrawString("S.No", font, Brushes.Black, float.Parse("5"), float.Parse("105"));

                e.Graphics.DrawString("Item(Qty)", font, Brushes.Black, float.Parse("50"), float.Parse("105"));
                e.Graphics.DrawString("MRP", font, Brushes.Black, float.Parse("150"), float.Parse("105"));

                e.Graphics.DrawString("Rate", font, Brushes.Black, float.Parse("235"), float.Parse("105"));
                e.Graphics.DrawString("Total", font, Brushes.Black, float.Parse("320"), float.Parse("105"));

                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), float.Parse("120"));
                //Header

                //Body
                float xx = 135;
                float yy = 5;
                decimal countqty = 0;
                decimal GrandTotal = 0;
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    decimal TotalAmount;

                    if (dt3.Rows[i]["Item"].ToString().Length > 10)
                    {
                       
                        xx = xx + 15;

                        string splitItemName1 = (dt3.Rows[i]["Item"].ToString().Substring(0, 10));
                        string splitItemName2 = (dt3.Rows[i]["Item"].ToString().Substring(10));

                        e.Graphics.DrawString("" + dt3.Rows[i]["sno"].ToString(), font, Brushes.Black, yy, xx);

                        yy = 60;
                        e.Graphics.DrawString(splitItemName1 + "-", font, Brushes.Black, yy, xx);
                        yy = 60;
                        xx = xx + 15;

                        e.Graphics.DrawString(splitItemName2 + " (" + dt3.Rows[i]["Qty"].ToString() + ")", font, Brushes.Black, yy, xx);
                        //yy = 60;
                        //xx = xx + 15;

                       

                        yy = 160;
                        xx = xx - 15;
                        e.Graphics.DrawString("" + dt3.Rows[i]["MRP"].ToString() + "/" + dt3.Rows[i]["Type"].ToString() + "", font, Brushes.Black, yy, xx);

                        

                        yy = 245;
                        e.Graphics.DrawString("" + dt3.Rows[i]["Price"].ToString(), font, Brushes.Black, yy, xx);

                        
                        yy = 330;
                        TotalAmount = Math.Round((decimal.Parse(dt3.Rows[i]["Qty"].ToString()) * decimal.Parse(dt3.Rows[i]["Price"].ToString())), 2);
                        e.Graphics.DrawString("" + TotalAmount.ToString(), font, Brushes.Black, yy, xx);
                        //e.Graphics.DrawString("" + dt3.Rows[i]["Vat(%)"].ToString(), font, Brushes.Black, yy, xx);
                        xx = xx + 55;
                        yy = 5;
                        //e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);
                    }
                    else
                    {
                        
                        xx = xx + 15;

                        e.Graphics.DrawString("" + dt3.Rows[i]["sno"].ToString(), font, Brushes.Black, yy, xx);
                        yy = 60;

                        e.Graphics.DrawString(dt3.Rows[i]["Item"].ToString() + " (" + dt3.Rows[i]["Qty"].ToString() + ")", font, Brushes.Black, yy, xx);
                        //yy = 60;
                        //xx = xx + 15;
                       

                        yy = 160;
                        //xx = xx - 15;
                        e.Graphics.DrawString("" + dt3.Rows[i]["MRP"].ToString() + "/" + dt3.Rows[i]["Type"].ToString() + "", font, Brushes.Black, yy, xx);
                       

                        yy = 245;
                        e.Graphics.DrawString("" + dt3.Rows[i]["Price"].ToString(), font, Brushes.Black, yy, xx);
                        
                        yy = 330;
                        TotalAmount = Math.Round((decimal.Parse(dt3.Rows[i]["Qty"].ToString()) * decimal.Parse(dt3.Rows[i]["Price"].ToString())), 2);
                        e.Graphics.DrawString("" + TotalAmount.ToString(), font, Brushes.Black, yy, xx);
                        //e.Graphics.DrawString("" + dt3.Rows[i]["Vat(%)"].ToString(), font, Brushes.Black, yy, xx);
                        xx = xx + 40;


                        yy = 5;
                        //e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);
                    }
                    // countqty = countqty + decimal.Parse(dt2.Rows[i]["Qty"].ToString());
                    GrandTotal = GrandTotal + TotalAmount;
                }
                //Footer
                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);

                xx = xx + 20;
                //e.Graphics.DrawString("Tot Qty:", font, Brushes.Black, float.Parse("5"), xx);

                //e.Graphics.DrawString(countqty.ToString(), font, Brushes.Black, float.Parse("75"), xx);

                e.Graphics.DrawString("Total :", font, Brushes.Black, float.Parse("172"), xx);

                e.Graphics.DrawString("" + GrandTotal.ToString(), font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Discount :", font, Brushes.Black, float.Parse("150"), xx);

                e.Graphics.DrawString(txtSDiscount.Text + "", font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("After Discount : ", font, Brushes.Black, float.Parse("102"), xx);

                e.Graphics.DrawString(txtSAmount.Text + "", font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Vat Amt : ", font, Brushes.Black, float.Parse("155"), xx);

                e.Graphics.DrawString(SVatAmt.Text + "", font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Grand Total :", font, Brushes.Black, float.Parse("125"), xx);

                e.Graphics.DrawString(SDue.Text, font, Brushes.Black, float.Parse("235"), xx);

                xx = xx + 20;

                decimal Savings = 0;
                foreach (DataRow dr in dt3.Rows)
                {
                    Savings = Savings + (decimal.Parse(dr["MRP"].ToString()) * decimal.Parse(dr["Qty"].ToString()));

                }

                e.Graphics.DrawString("Your Savings : ", font, Brushes.Black, float.Parse("117"), xx);

                e.Graphics.DrawString((decimal.Parse(Savings.ToString()) - decimal.Parse(txtSAmount.Text)).ToString(), font, Brushes.Black, float.Parse("235"), xx);



                xx = xx + 20;

                Image myimg = Code128Rendering.MakeBarcodeImage(trnNo, 2, true);
                e.Graphics.DrawImage(myimg, 1, xx);

                xx = xx + 60;
                e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);
                xx = xx + 20;

                e.Graphics.DrawString("NO EXCHANGE !!!", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;

                e.Graphics.DrawString("GOODS ONCE SOLD CAN NOT BE TAKEN BACK !!!", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;
                e.Graphics.DrawString("*** CONDITION APPLY ***", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;

                e.Graphics.DrawString("Thank You. Visit Again !!!", font, Brushes.Black, float.Parse("8"), xx);
                //Footer
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void openCalcy()
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openCalcy();
        }


        private void ShowStock()
        {
            if (dataGridView4.SelectedRows.Count > 0)
            {
                dataGridView4.SelectedRows[0].Cells["Barcode"].Value.ToString();
                DataSet dsstk = new DataSet();
                SQLHelper sqlh = new SQLHelper();
                dsstk = sqlh.ExecuteQueries("select * from GetItemsForCashier where barcode='" + dataGridView4.SelectedRows[0].Cells["Barcode"].Value.ToString() + "'");
                if (dsstk.Tables[0].Rows.Count > 0)
                {
                    FrmMessage.Show("Avail Quantity " + Convert.ToDecimal(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString()));
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShowStock();
        }


        private void RemoveItemfromGrid()
        {
            if (dt3.Rows.Count > 0)
            {
                foreach (DataRow dr in dt3.Rows)
                {
                    if (dr["Barcode"].ToString() == dataGridView4.CurrentRow.Cells["Barcode"].Value.ToString())
                        dr.Delete();
                }

                dt3.AcceptChanges();
                dataGridView4.DataSource = dt3;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            RemoveItemfromGrid();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox5.Visible = true;
            groupBox10.Visible = false;
            groupBox15.Visible = false;

            groupBox15.Visible = false;
        }



        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            //sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            ds = sqlhelper.ExecuteQueries("select * FROM POINTSCHECK where CARDNUMBER like '" + textBox12.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox13.Text = ds.Tables[0].Rows[0]["name"].ToString();
                textBox14.Text = ds.Tables[0].Rows[0]["Points"].ToString();
                textBox17.Text = ds.Tables[0].Rows[0]["redeemamount"].ToString();
                textBox19.Text = ds.Tables[0].Rows[0]["PACNO"].ToString();
                button8.Visible = true;
                button10.Visible = false;
                button8.Location = new System.Drawing.Point(721, 26);
            }
            else
            {
                //textBox12.Focused;
                textBox13.Text = string.Empty;
                textBox14.Text = string.Empty;
                //textBox15.Text = string.Empty;
                button8.Visible = false;
                button10.Visible = true;

            }
        }

        bool redeemclick = false;
        private void button5_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrEmpty(textBox19.Text))
            {
                FrmMessage.Show("You cannot REDEEM THE POINTS without CARD DETAILS", caption, OkButton, ErrorIcon);
            }
            else
            {
                redeemclick = true;
                txtSDiscount.Text = Math.Round((decimal.Parse(textBox18.Text) * decimal.Parse(textBox17.Text)), 2).ToString();
                button8.Visible = true;
                button10.Visible = false;
                button8.Location = new System.Drawing.Point(721, 26);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            button10.Visible = true;
            button8.Visible = false;
            redeemclick = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            savesmartPos1();
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox18.Text) && !string.IsNullOrEmpty(textBox14.Text))
                {

                    if (decimal.Parse(textBox18.Text) > decimal.Parse(textBox14.Text))
                    {
                        textBox18.Text = textBox14.Text;
                    }
                }
            }
            catch
            {
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox18.Text) && !string.IsNullOrEmpty(textBox14.Text))
                {

                    if (decimal.Parse(textBox18.Text) > decimal.Parse(textBox14.Text))
                    {
                        textBox18.Text = textBox14.Text;
                    }
                }
            }
            catch
            {
            }
        }

        private void txtSTotal_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox16.Text) || decimal.Parse(textBox16.Text) == 0)
            {
            }

            else if (!string.IsNullOrEmpty(txtSAmount.Text))
            {
                textBox15.Text = Math.Round((decimal.Parse(txtSTotal.Text) / decimal.Parse(textBox16.Text)), 2).ToString();
                textBox18.Text = Math.Round((decimal.Parse(txtSTotal.Text) / decimal.Parse(textBox16.Text)), 2).ToString();
            }
        }

        private void txtBillpaid_TextChanged(object sender, EventArgs e)
        {
            if (decimal.Parse(txtBillpaid.Text) != 0)
            {
                txtDueAmt.Text = Math.Round((decimal.Parse(txtBillpaid.Text) + (decimal.Parse(txtVatAmount.Text))), 2).ToString();
                // textBox29.Text = Math.Round(((decimal.Parse(txtBillpaid.Text) * decimal.Parse(textBox23.Text) / 100)), 2).ToString();

                if (checkBox5.Checked == true)
                {
                    if (txtBillpaid.Text == "0" || (string.IsNullOrEmpty(textBox53.Text)))
                    {
                        txtAProfit1.Text = "0";
                    }
                    else
                    {
                        txtAProfit1.Text = Math.Round((decimal.Parse(txtBillpaid.Text) * (decimal.Parse(txtACommission1.Text) / 100)), 2).ToString();
                    }
                }
            }
            else
                txtDueAmt.Text = "0";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (decimal.Parse(txtAmount2.Text) == 0)
                txtDue2.Text = "0";
            else
            {
                txtDue2.Text = Math.Round((decimal.Parse(txtAmount2.Text) + (decimal.Parse(txtVatAmt2.Text))), 2).ToString();
                //txtVatAmt2.Text = Math.Round(((decimal.Parse(txtAmount2.Text) * decimal.Parse(textBox25.Text) / 100)), 2).ToString();
            }

            if (checkBox4.Checked == true)
            {
                if (txtAmount2.Text == "0" || (string.IsNullOrEmpty(textBox46.Text)))
                {
                    textBox49.Text = "0";
                }
                else
                {
                    textBox49.Text = Math.Round((decimal.Parse(txtAmount2.Text) * (decimal.Parse(textBox44.Text) / 100)), 2).ToString();
                }
            }

        }

        private void txtSAmount_TextChanged(object sender, EventArgs e)
        {
            if (Decimal.Parse(txtSAmount.Text) != 0)
            {
                SDue.Text = Math.Round((decimal.Parse(txtSAmount.Text) + (decimal.Parse(SVatAmt.Text))), 2).ToString();
                //SVatAmt.Text = Math.Round(((decimal.Parse(txtSAmount.Text) * decimal.Parse(textBox27.Text) / 100)), 2).ToString();
            }
            else
            {
                SDue.Text = "0";
            }
            if (checkBox7.Checked == true)
            {
                if (txtSAmount.Text == "0" || (string.IsNullOrEmpty(textBox61.Text)))
                {
                    textBox58.Text = "0";
                }
                else
                {
                    textBox58.Text = Math.Round((decimal.Parse(txtSAmount.Text) * (decimal.Parse(textBox59.Text) / 100)), 2).ToString();
                }
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            txtDue3.Text = Math.Round((decimal.Parse(txtAmount3.Text) + (decimal.Parse(txtVatAmt3.Text))), 2).ToString();
            //txtVatAmt3.Text = Math.Round(((decimal.Parse(txtAmount3.Text) * decimal.Parse(textBox20.Text) / 100)), 2).ToString();

            if (checkBox6.Checked == true)
            {
                if (txtAmount3.Text == "0" || (string.IsNullOrEmpty(textBox57.Text)))
                {
                    textBox54.Text = "0";
                }
                else
                {
                    textBox54.Text = Math.Round((decimal.Parse(txtAmount3.Text) * (decimal.Parse(textBox55.Text) / 100)), 2).ToString();
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                panel11.Visible = true;
                textBox32.Text = string.Empty;
                textBox33.Text = string.Empty;
                textBox34.Text = string.Empty;

            }
            else
            {
                panel11.Visible = false;
            }
        }

        Int32 DEALERID = 0;
        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                sqlhelper = new SQLHelper();
                DataSet ds = new DataSet();
                DataSet dsAmer = new DataSet();
                ds = sqlhelper.ExecuteQueries("select * FROM Dealer where MemberNo = '" + textBox32.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox33.Text = ds.Tables[0].Rows[0]["DNAME"].ToString();
                    DEALERID = Int32.Parse(ds.Tables[0].Rows[0]["DEALERID"].ToString());

                    dsAmer = sqlhelper.ExecuteQueries("select * FROM CREDITCHECK where MemberNo = '" + textBox32.Text + "'");

                    textBox34.Text = dsAmer.Tables[0].Rows[0]["DUE"].ToString();
                }
                else
                    FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
            }
            else
            {
            }
        }

        private void textBox32_Leave(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(e.KeyChar) == 13)
            //{
            sqlhelper = new SQLHelper();
            DataSet ds = new DataSet();
            DataSet dsAmer = new DataSet();
            ds = sqlhelper.ExecuteQueries("select * FROM Dealer where MemberNo = '" + textBox32.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox33.Text = ds.Tables[0].Rows[0]["DNAME"].ToString();
                DEALERID = Int32.Parse(ds.Tables[0].Rows[0]["DEALERID"].ToString());


                dsAmer = sqlhelper.ExecuteQueries("select * FROM CREDITCHECK where MemberNo = '" + textBox32.Text + "'");

                textBox34.Text = dsAmer.Tables[0].Rows[0]["DUE"].ToString();
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
            //}
            //else
            //{
            //}
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                panel15.Visible = true;
                txtBal1.Text = string.Empty;
                textBox36.Text = string.Empty;
                textBox37.Text = string.Empty;

            }
            else
            {
                panel15.Visible = false;
            }
        }

        private void textBox37_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                sqlhelper = new SQLHelper();
                DataSet ds = new DataSet();
                DataSet dsAmer1 = new DataSet();
                ds = sqlhelper.ExecuteQueries("select * FROM Dealer where MemberNo = '" + textBox37.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox36.Text = ds.Tables[0].Rows[0]["DNAME"].ToString();
                    DEALERID = Int32.Parse(ds.Tables[0].Rows[0]["DEALERID"].ToString());

                    dsAmer1 = sqlhelper.ExecuteQueries("select * FROM CREDITCHECK where MemberNo = '" + textBox37.Text + "'");

                    txtBal1.Text = dsAmer1.Tables[0].Rows[0]["DUE"].ToString();
                }
                else
                    FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
            }
            else
            {
            }
        }

        private void textBox37_Leave(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(e.KeyChar) == 13)
            //{
            sqlhelper = new SQLHelper();
            DataSet ds = new DataSet();
            DataSet dsAmer1 = new DataSet();
            ds = sqlhelper.ExecuteQueries("select * FROM Dealer where MemberNo = '" + textBox37.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox36.Text = ds.Tables[0].Rows[0]["DNAME"].ToString();
                DEALERID = Int32.Parse(ds.Tables[0].Rows[0]["DEALERID"].ToString());


                dsAmer1 = sqlhelper.ExecuteQueries("select * FROM CREDITCHECK where MemberNo = '" + textBox37.Text + "'");

                txtBal1.Text = dsAmer1.Tables[0].Rows[0]["DUE"].ToString();
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
            //}
            //else
            //{
            //}
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                panel16.Visible = true;
                textBox38.Text = string.Empty;
                textBox39.Text = string.Empty;
                textBox40.Text = string.Empty;

            }
            else
            {
                panel16.Visible = false;
            }
        }

        private void textBox40_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                sqlhelper = new SQLHelper();
                DataSet ds = new DataSet();
                DataSet dsAmer2 = new DataSet();
                ds = sqlhelper.ExecuteQueries("select * FROM Dealer where MemberNo = '" + textBox40.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox39.Text = ds.Tables[0].Rows[0]["DNAME"].ToString();
                    DEALERID = Int32.Parse(ds.Tables[0].Rows[0]["DEALERID"].ToString());

                    dsAmer2 = sqlhelper.ExecuteQueries("select * FROM CREDITCHECK where MemberNo = '" + textBox40.Text + "'");

                    textBox38.Text = dsAmer2.Tables[0].Rows[0]["DUE"].ToString();
                }
                else
                    FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
            }
            else
            {
            }
        }

        private void textBox40_Leave(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(e.KeyChar) == 13)
            //{
            sqlhelper = new SQLHelper();
            DataSet ds = new DataSet();
            DataSet dsAmer2 = new DataSet();
            ds = sqlhelper.ExecuteQueries("select * FROM Dealer where MemberNo = '" + textBox40.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox39.Text = ds.Tables[0].Rows[0]["DNAME"].ToString();
                DEALERID = Int32.Parse(ds.Tables[0].Rows[0]["DEALERID"].ToString());


                dsAmer2 = sqlhelper.ExecuteQueries("select * FROM CREDITCHECK where MemberNo = '" + textBox40.Text + "'");

                textBox38.Text = dsAmer2.Tables[0].Rows[0]["DUE"].ToString();
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
            //}
            //else
            //{
            //}
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            groupBox17.Visible = true;
            groupBox5.Visible = false;
            groupBox10.Visible = false;
            groupBox15.Visible = false;


            textBox42.Text = string.Empty;
            textBox47.Text = "0";
            textBox48.Text = "0";
            textBox41.Text = string.Empty;

            dataGridView5.DataSource = null;
            dataGridView5.Columns.Clear();

            dataGridView6.DataSource = null;
            dataGridView6.Columns.Clear();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            sqlhelper = new SQLHelper();
            DataSet ds_Amer = new DataSet();
            DataSet ds_Amer1 = new DataSet();
            DataSet ds_Amer_2 = new DataSet();
            ds_Amer = sqlhelper.ExecuteQueries("select DealerId,MemberNo as [Member No], TransactionNo as [Bill No], TotalAmount as [Bill Amount], DiscountAmount as [Discount], AfterDiscount as [After Discount],VAT,VATAmount as [VAT Amount],TotalDue as [Due],CreatedDate as [Bill Date] FROM DealerTransaction where MemberNo ='" + textBox41.Text + "'");
            if (ds_Amer.Tables[0].Rows.Count > 0)
            {
                dataGridView5.DataSource = ds_Amer.Tables[0];
                PCUSID = int.Parse(dataGridView5.CurrentRow.Cells[0].Value.ToString());
                dataGridView5.Columns["DealerID"].Visible = false;


                ds_Amer1 = sqlhelper.ExecuteQueries("select * FROM CollectCredit where DealerId =" + PCUSID + "");
                if (ds_Amer1.Tables[0].Rows.Count > 0)
                {
                    dataGridView6.DataSource = ds_Amer1.Tables[0];
                    dataGridView6.Columns["CCID"].Visible = false;
                    dataGridView6.Columns["DealerID"].Visible = false;
                    dataGridView6.Columns["CreatedBy"].Visible = false;

                }


                ds_Amer_2 = sqlhelper.ExecuteQueries("select * FROM TotalCredit where DealerId =" + PCUSID + "");
                if (ds_Amer_2.Tables[0].Rows.Count > 0)
                {

                    textBox47.Text = ds_Amer_2.Tables[0].Rows[0]["DUE"].ToString();
                    textBox42.Text = ds_Amer_2.Tables[0].Rows[0]["DEALERID"].ToString();

                }


            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (string.IsNullOrEmpty(textBox42.Text) || string.IsNullOrEmpty(textBox48.Text))
            {
                FrmMessage.Show("Paying Amount is Mandatory!!!", caption, OkButton, ErrorIcon);
            }
            else
            {

                sqlhelper = new SQLHelper();
                result = sqlhelper.ExecuteNonQuery("insert into CollectCredit(DealerID, TotalAmount,PaidAmount,Balance,CreatedBy) values" +
                                                 "('" + textBox42.Text + "','" + textBox47.Text + "','" + textBox48.Text + "','" + textBox43.Text + "'," + GlobalData.UserID + ")");



                if (result == true)
                {
                    FrmMessage.Show("Transaction Success");
                    dataGridView5.DataSource = null;
                    dataGridView5.Columns.Clear();

                    dataGridView6.DataSource = null;
                    dataGridView6.Columns.Clear();

                    textBox42.Text = string.Empty;
                    textBox47.Text = "0";
                    textBox48.Text = "0";
                    textBox41.Text = string.Empty;

                    textBox41.Focus();



                }
            }
        }

        private void textBox48_TextChanged(object sender, EventArgs e)
        {
            textBox43.Text = Math.Round((decimal.Parse(textBox47.Text) - (decimal.Parse(textBox48.Text))), 2).ToString();
            //textBox21.Text = Math.Round((decimal.Parse(textBox7.Text) + (decimal.Parse(textBox7.Text) * decimal.Parse(textBox20.Text) / 100)), 2).ToString();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                panel20.Visible = true;
                textBox44.Text = string.Empty;
                textBox45.Text = string.Empty;
                textBox46.Text = string.Empty;
                textBox49.Text = string.Empty;

            }
            else
            {
                panel20.Visible = false;
            }
        }

        Int32 ANO = 0;
        private void textBox46_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                sqlhelper = new SQLHelper();
                DataSet dsAgent = new DataSet();

                dsAgent = sqlhelper.ExecuteQueries("select * FROM AGENTCOMISSIONQUERY where MemberNo = '" + textBox46.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox45.Text = dsAgent.Tables[0].Rows[0]["DNAME"].ToString();
                    textBox44.Text = dsAgent.Tables[0].Rows[0]["COMISSION"].ToString();
                    ANO = Int32.Parse(dsAgent.Tables[0].Rows[0]["ANO"].ToString());

                    if (txtAmount2.Text == "0")
                    {
                        textBox49.Text = "0";
                    }
                    else
                    {
                        textBox49.Text = Math.Round((decimal.Parse(txtAmount2.Text) * (decimal.Parse(textBox44.Text) / 100)), 2).ToString();
                    }
                }
                else
                    FrmMessage.Show("No Agent Found with provided Agent #", caption, OkButton, InformationIcon);
            }
            else
            {
            }
        }

        private void textBox46_Leave(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(e.KeyChar) == 13)
            //{

            sqlhelper = new SQLHelper();
            DataSet dsAgent = new DataSet();

            dsAgent = sqlhelper.ExecuteQueries("select * FROM AGENTCOMISSIONQUERY where MemberNo = '" + textBox46.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox45.Text = dsAgent.Tables[0].Rows[0]["DNAME"].ToString();
                textBox44.Text = dsAgent.Tables[0].Rows[0]["COMISSION"].ToString();
                ANO = Int32.Parse(dsAgent.Tables[0].Rows[0]["ANO"].ToString());

                if (txtAmount2.Text == "0")
                {
                    textBox49.Text = "0";
                }
                else
                {
                    textBox49.Text = Math.Round((decimal.Parse(txtAmount2.Text) * (decimal.Parse(textBox44.Text) / 100)), 2).ToString();
                }

            }
            else
                FrmMessage.Show("No Agent Found with provided Agent #", caption, OkButton, InformationIcon);
            //}
            //else
            //{
            //}
        }

        private void textBox53_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                sqlhelper = new SQLHelper();
                DataSet dsAgent = new DataSet();

                dsAgent = sqlhelper.ExecuteQueries("select * FROM AGENTCOMISSIONQUERY where MemberNo = '" + textBox53.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox52.Text = dsAgent.Tables[0].Rows[0]["DNAME"].ToString();
                    txtACommission1.Text = dsAgent.Tables[0].Rows[0]["COMISSION"].ToString();
                    ANO = Int32.Parse(dsAgent.Tables[0].Rows[0]["ANO"].ToString());

                    if (txtBillpaid.Text == "0")
                    {
                        txtAProfit1.Text = "0";
                    }
                    else
                    {
                        txtAProfit1.Text = Math.Round((decimal.Parse(txtBillpaid.Text) * (decimal.Parse(txtACommission1.Text) / 100)), 2).ToString();
                    }
                }
                else
                    FrmMessage.Show("No Agent Found with provided Agent #", caption, OkButton, InformationIcon);
            }
            else
            {
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                panel21.Visible = true;
                txtAProfit1.Text = string.Empty;
                txtACommission1.Text = string.Empty;
                textBox52.Text = string.Empty;
                textBox53.Text = string.Empty;
            }
            else
            {
                panel21.Visible = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                panel22.Visible = true;
                textBox54.Text = string.Empty;
                textBox55.Text = string.Empty;
                textBox56.Text = string.Empty;
                textBox57.Text = string.Empty;
            }
            else
            {
                panel22.Visible = false;
            }
        }

        private void textBox53_Leave(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(e.KeyChar) == 13)
            //{

            sqlhelper = new SQLHelper();
            DataSet dsAgent = new DataSet();

            dsAgent = sqlhelper.ExecuteQueries("select * FROM AGENTCOMISSIONQUERY where MemberNo = '" + textBox53.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox52.Text = dsAgent.Tables[0].Rows[0]["DNAME"].ToString();
                txtACommission1.Text = dsAgent.Tables[0].Rows[0]["COMISSION"].ToString();
                ANO = Int32.Parse(dsAgent.Tables[0].Rows[0]["ANO"].ToString());

                if (txtBillpaid.Text == "0")
                {
                    txtAProfit1.Text = "0";
                }
                else
                {
                    txtAProfit1.Text = Math.Round((decimal.Parse(txtBillpaid.Text) * (decimal.Parse(txtACommission1.Text) / 100)), 2).ToString();
                }
            }
            else
                FrmMessage.Show("No Agent Found with provided Agent #", caption, OkButton, InformationIcon);
            //}
            //else
            //{
            //}
        }

        private void textBox57_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                sqlhelper = new SQLHelper();
                DataSet dsAgent = new DataSet();

                dsAgent = sqlhelper.ExecuteQueries("select * FROM AGENTCOMISSIONQUERY where MemberNo = '" + textBox57.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox56.Text = dsAgent.Tables[0].Rows[0]["DNAME"].ToString();
                    textBox55.Text = dsAgent.Tables[0].Rows[0]["COMISSION"].ToString();
                    ANO = Int32.Parse(dsAgent.Tables[0].Rows[0]["ANO"].ToString());

                    if (txtAmount3.Text == "0")
                    {
                        textBox54.Text = "0";
                    }
                    else
                    {
                        textBox54.Text = Math.Round((decimal.Parse(txtAmount3.Text) * (decimal.Parse(textBox55.Text) / 100)), 2).ToString();
                    }
                }
                else
                    FrmMessage.Show("No Agent Found with provided Agent #", caption, OkButton, InformationIcon);
            }
            else
            {
            }
        }

        private void textBox57_Leave(object sender, EventArgs e)
        {
            sqlhelper = new SQLHelper();
            DataSet dsAgent = new DataSet();

            dsAgent = sqlhelper.ExecuteQueries("select * FROM AGENTCOMISSIONQUERY where MemberNo = '" + textBox57.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox56.Text = dsAgent.Tables[0].Rows[0]["DNAME"].ToString();
                textBox55.Text = dsAgent.Tables[0].Rows[0]["COMISSION"].ToString();
                ANO = Int32.Parse(dsAgent.Tables[0].Rows[0]["ANO"].ToString());

                if (txtAmount3.Text == "0")
                {
                    textBox54.Text = "0";
                }
                else
                {
                    textBox54.Text = Math.Round((decimal.Parse(txtAmount3.Text) * (decimal.Parse(textBox55.Text) / 100)), 2).ToString();
                }
            }
            else
                FrmMessage.Show("No Agent Found with provided Agent #", caption, OkButton, InformationIcon);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                textBox62.Text = string.Empty;
                textBox63.Text = string.Empty;
                textBox64.Text = string.Empty;
                panel24.Visible = true;

            }
            else
            {
                panel24.Visible = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                textBox58.Text = string.Empty;
                textBox59.Text = string.Empty;
                textBox60.Text = string.Empty;
                textBox61.Text = string.Empty;
                panel23.Visible = true;

            }
            else
            {
                panel23.Visible = false;
            }
        }

        private void textBox64_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                sqlhelper = new SQLHelper();
                DataSet ds = new DataSet();
                DataSet dsAmer2 = new DataSet();
                ds = sqlhelper.ExecuteQueries("select * FROM Dealer where MemberNo = '" + textBox64.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox63.Text = ds.Tables[0].Rows[0]["DNAME"].ToString();
                    DEALERID = Int32.Parse(ds.Tables[0].Rows[0]["DEALERID"].ToString());

                    dsAmer2 = sqlhelper.ExecuteQueries("select * FROM CREDITCHECK where MemberNo = '" + textBox64.Text + "'");

                    textBox62.Text = dsAmer2.Tables[0].Rows[0]["DUE"].ToString();
                }
                else
                    FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
            }
            else
            {
            }


        }

        private void textBox61_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {

                sqlhelper = new SQLHelper();
                DataSet dsAgent = new DataSet();

                dsAgent = sqlhelper.ExecuteQueries("select * FROM AGENTCOMISSIONQUERY where MemberNo = '" + textBox61.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    textBox60.Text = dsAgent.Tables[0].Rows[0]["DNAME"].ToString();
                    textBox59.Text = dsAgent.Tables[0].Rows[0]["COMISSION"].ToString();
                    ANO = Int32.Parse(dsAgent.Tables[0].Rows[0]["ANO"].ToString());

                    if (txtSAmount.Text == "0")
                    {
                        textBox58.Text = "0";
                    }
                    else
                    {
                        textBox58.Text = Math.Round((decimal.Parse(txtSAmount.Text) * (decimal.Parse(textBox59.Text) / 100)), 2).ToString();
                    }
                }
                else
                    FrmMessage.Show("No Agent Found with provided Agent #", caption, OkButton, InformationIcon);
            }
            else
            {
            }
        }

        private void textBox64_Leave(object sender, EventArgs e)
        {
            sqlhelper = new SQLHelper();
            DataSet ds = new DataSet();
            DataSet dsAmer2 = new DataSet();
            ds = sqlhelper.ExecuteQueries("select * FROM Dealer where MemberNo = '" + textBox64.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox63.Text = ds.Tables[0].Rows[0]["DNAME"].ToString();
                DEALERID = Int32.Parse(ds.Tables[0].Rows[0]["DEALERID"].ToString());

                dsAmer2 = sqlhelper.ExecuteQueries("select * FROM CREDITCHECK where MemberNo = '" + textBox64.Text + "'");

                textBox62.Text = dsAmer2.Tables[0].Rows[0]["DUE"].ToString();
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void txtVatAmt3_TextChanged(object sender, EventArgs e)
        {
            txtDue3.Text = Math.Round((decimal.Parse(txtAmount3.Text) + (decimal.Parse(txtVatAmt3.Text))), 2).ToString();
            //txtVatAmt3.Text = Math.Round(((decimal.Parse(txtAmount3.Text) * decimal.Parse(textBox20.Text) / 100)), 2).ToString();

            if (checkBox6.Checked == true)
            {
                if (txtAmount3.Text == "0" || (string.IsNullOrEmpty(textBox57.Text)))
                {
                    textBox54.Text = "0";
                }
                else
                {
                    textBox54.Text = Math.Round((decimal.Parse(txtAmount3.Text) * (decimal.Parse(textBox55.Text) / 100)), 2).ToString();
                }
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.Update();
                dt.AcceptChanges();
                pric = 0;
                decimal VatAmount = 0;
                for (int k = 0; k < (dataGridView1.Rows.Count); k++)
                {
                    //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                    pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()))), 2);
                    VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView1.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView1.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                }
                //txtTotalAmount.Text = pric.ToString();
                txtGrandTotal.Text = pric.ToString();
                txtVatAmount.Text = VatAmount.ToString();
                if (txtDiscount.Text != "0")
                {
                    txtBillpaid.Text = (Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2)).ToString();
                }
                else
                {
                    txtBillpaid.Text = txtGrandTotal.Text;
                }

            }
            else if (txtGrandTotal.Text != "0" || txtDueAmt.Text != "0")
            {
                pric = 0;
                decimal VatAmount = 0;
                for (int k = 0; k < (dataGridView1.Rows.Count); k++)
                {
                    //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                    pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()))), 2);
                    VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView1.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView1.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                }
                //txtTotalAmount.Text = pric.ToString();
                txtGrandTotal.Text = pric.ToString();
                txtVatAmount.Text = VatAmount.ToString();
                if (txtDiscount.Text != "0")
                {
                    txtBillpaid.Text = (Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))), 2)).ToString();
                }
                else
                {
                    txtBillpaid.Text = txtGrandTotal.Text;
                }

            }
            else
            {
                txtGrandTotal.Text = "0";
                txtBillpaid.Text = "0";
                txtDiscount.Text = "0";
                lblMaxQty.Text = string.Empty;
                txtVatAmount.Text = "0";
                txtVatAmt3.Text = "0";
            }
            //dt.AcceptChanges();
        }

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dataGridView3.Rows.Count != 0)
            {
                dataGridView3.Update();
                dt2.AcceptChanges();
                pric = 0;
                decimal VatAmount = 0;
                for (int k = 0; k < (dataGridView3.Rows.Count); k++)
                {
                    //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                    pric = Math.Round((pric + (decimal.Parse(dataGridView3.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells[3].Value.ToString()))), 2);
                    VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView3.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView3.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView3.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                }
                //txtTotalAmount.Text = pric.ToString();
                txtTotal3.Text = pric.ToString();
                txtVatAmt3.Text = VatAmount.ToString();

                if (txtDis3.Text != "0")
                {
                    txtAmount3.Text = (Math.Round((decimal.Parse(txtTotal3.Text) - (decimal.Parse(txtDis3.Text))), 2)).ToString();
                }
                else
                {
                    txtAmount3.Text = txtTotal3.Text;
                }

            }
            else
            {
                txtAmount3.Text = "0";
                txtDis3.Text = "0";
                txtTotal3.Text = "0";
                label16.Text = string.Empty;
                txtVatAmt3.Text = "0";
            }
        }

        private void dataGridView4_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dataGridView4.Rows.Count != 0)
            {
                dataGridView4.Update();
                dt3.AcceptChanges();

                pric = 0;
                decimal VatAmount = 0;
                for (int k = 0; k < (dataGridView4.Rows.Count); k++)
                {
                    dataGridView4.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
                    //decimal afterdiscountamount = (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()));
                    pric = Math.Round((pric + (decimal.Parse(dataGridView4.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView4.Rows[k].Cells[3].Value.ToString()))), 2);
                    VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView4.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView4.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView4.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                }
                txtSTotal.Text = pric.ToString();
                SVatAmt.Text = VatAmount.ToString();

                if (txtSDiscount.Text != "0")
                {
                    txtSAmount.Text = (Math.Round((decimal.Parse(txtSTotal.Text) - (decimal.Parse(txtSDiscount.Text))), 2)).ToString();
                }
                else
                {
                    txtSAmount.Text = txtSTotal.Text;
                }

            }
            else
            {
                txtSTotal.Text = "0";
                txtSAmount.Text = "0";
                txtSDiscount.Text = "0";
                SVatAmt.Text = "0";
            }
        }

        private void dataGridView2_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (dataGridView2.Rows.Count != 0)
            {
                dataGridView2.Update();
                dt1.AcceptChanges();

                pric = 0;
                decimal VatAmount = 0;
                for (int k = 0; k < (dataGridView2.Rows.Count); k++)
                {
                    //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                    pric = Math.Round((pric + (decimal.Parse(dataGridView2.Rows[k].Cells[2].Value.ToString())) * (decimal.Parse(dataGridView2.Rows[k].Cells[3].Value.ToString()))), 2);
                    VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView2.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView2.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView2.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                }
                //txtTotalAmount.Text = pric.ToString();
                txtTotal2.Text = pric.ToString();
                txtVatAmt2.Text = VatAmount.ToString();
                if (txtDiscount.Text != "0")
                {
                    txtAmount2.Text = (Math.Round((decimal.Parse(txtTotal2.Text) - (decimal.Parse(txtDisc2.Text))), 2)).ToString();
                }
                else
                {
                    txtAmount2.Text = txtTotal2.Text;
                }

            }
            else
            {
                txtTotal2.Text = "0";
                txtAmount2.Text = "0";
                txtDisc2.Text = "0";
                label10.Text = string.Empty;
                txtVatAmt2.Text = "0";
            }
        }














    }






}











