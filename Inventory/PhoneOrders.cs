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

namespace Inventory
{
    public partial class PhoneOrders : Form
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
        decimal pric = 0;
        Bitmap bm;
        int i = 0;
        DataTable dt = new DataTable();
        int PostCodeID = 0;
        int AreaID = 0;
        int CustID = 0;
        Button btnfirst = new Button();
        public PhoneOrders()
        {
            InitializeComponent();
        }


        #region Common Variables

        double firstNum;    //contains first number value
        double secondNum;   //contains second number value
        double result;      //contains result
        string operation = "";
        bool operationPending = false;
        bool point = false;
        int pointClicked = 0;

        #endregion


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
                        DynamicLabel.Location = new Point(5, 8);
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
                        DynamicLabel.Location = new Point(5, 8);
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
                        DynamicLabl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
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
                lblMaxQty.Text = "Avail Quantity " + Convert.ToInt32(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString());

                if (Convert.ToInt32(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString()) <= 0)
                {
                    FrmMessage.Show("Stock is not available for this Item. Please Re-Order the Stock");
                }
                else
                {
                    if (Convert.ToInt32(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString()) <= Convert.ToInt32(dsstk.Tables[0].Rows[0]["ReOrderQuantity"].ToString()))
                    {
                        FrmMessage.Show("Stock has reached to the minimum quantity level !!! Please Re-Order the Stock.");
                    }

                    if (dt.Columns.Count < 1)
                    {
                        dt.Columns.Add("Item");
                        dt.Columns.Add("Price");
                        dt.Columns.Add("Qty");
                        dt.Columns.Add("Barcode");
                        dt.Columns.Add("ItemID");
                        dt.Columns.Add("CategoryID");
                    }
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
                    row["Price"] = dsstk.Tables[0].Rows[0]["saleprice"].ToString();
                    row["Barcode"] = dsstk.Tables[0].Rows[0]["barcode"].ToString();
                    dt.Rows.Add(row);
                    DataView dView = new DataView(dt);
                    string[] arrColumns = { "Item", "Price", "Qty", "Barcode", "ItemID", "CategoryID" };
                    dt = dView.ToTable(true, arrColumns);
                    dt.AcceptChanges();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                    //dataGridView1.CurrentCell = dataGridView1.Rows.OfType<DataGridViewRow>().Last().Cells.OfType<DataGridViewCell>().First();
                    //dataGridView1.ClearSelection();

                    pric = 0;
                    for (int k = 0; k < (dataGridView1.Rows.Count); k++)
                    {
                        //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                        pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString()))), 2);
                    }
                    //txtTotalAmount.Text = pric.ToString();
                    txtGrandTotal.Text = pric.ToString();
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
        }

        static string trnNo;

        private void btnPay_Click(object sender, EventArgs e)
        {
           // dt.AcceptChanges();
            try
            {
                if (string.IsNullOrEmpty(txtBillpaid.Text) || dataGridView1.Rows.Count<=0)
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
                            if (result == true)
                            {
                                //string InitCode = "";
                                //int lengthofInitCode = 0;
                                //string MaxCode;

                                string PaymentId = sqlhelper.ExecuteScalar("select max(PaymentID) from Payment");

                                for (int i = 0; i < dataGridView1.Rows.Count; i++)
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

                                    result = sqlhelper.ExecuteNonQuery("insert into Transactions(PaymentID,Barcode,CategoryID,ItemID,SaleQty,ItemPrice,CreatedBy)" +
                                                                       "values (" + PaymentId + ",'" + dataGridView1.Rows[i].Cells["Barcode"].Value.ToString() +"'," + dataGridView1.Rows[i].Cells[5].Value.ToString() + "," +
                                                                       "" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "," + dataGridView1.Rows[i].Cells[2].Value.ToString() + "," +
                                                                       "" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "," + GlobalData.UserID + ")");

                                    result = sqlhelper.ExecuteNonQuery("Update Stock Set StockQuantity = (StockQuantity - " + dataGridView1.Rows[i].Cells[2].Value.ToString() + ")"+
                                                                       " where CategoryID= " + dataGridView1.Rows[i].Cells[5].Value.ToString() + " and  "+
                                                                       "ItemID=" + dataGridView1.Rows[i].Cells[4].Value.ToString()+" and Barcode='" + dataGridView1.Rows[i].Cells["Barcode"].Value.ToString() +"'");                                        
                                       
                                }

                                if (result == true)
                                {
                                    string ser = txtBillpaid.Text;
                                    BillPrintPreview.Document = BillPrint;
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

                            PhoneOrders form = new PhoneOrders
                            {
                                MdiParent = this.MdiParent,
                                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                    | System.Windows.Forms.AnchorStyles.Left)
                                    | System.Windows.Forms.AnchorStyles.Right))),
                                Dock = DockStyle.Fill
                            };

                            form.Show();

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
                dsstk = sqlh.ExecuteQueries("select * from GetItemsForCashier where barcode='" + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + "'");
                if (dsstk.Tables[0].Rows.Count > 0)
                {
                    lblMaxQty.Text = "Avail Quantity " + Convert.ToInt32(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString());

                    if (!string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()))
                    {
                        if ((Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString())) > (Convert.ToInt32(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString())))
                        {
                            FrmMessage.Show("You Cannot take more than " + lblMaxQty.Text + " for this Item", caption, OkButton, ErrorIcon);
                            dataGridView1.Rows[e.RowIndex].Cells[2].Value = Convert.ToInt32(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString());
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = "1";
                    }
                }

                pric = 0;
                for (int k = 0; k < (dataGridView1.Rows.Count); k++)
                {
                    // decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                    pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString()))), 2);
                }
                txtGrandTotal.Text = pric.ToString();
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
            if (dataGridView1.Rows.Count != 0)
            {
                pric = 0;
                for (int k = 0; k < (dataGridView1.Rows.Count); k++)
                {

                    // decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                    pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString()))), 2);
                }

                txtGrandTotal.Text = pric.ToString();                
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
            }
           // dt.AcceptChanges();
        }


        private void BillPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font font = new Font("Courier New", 9, System.Drawing.FontStyle.Bold);

                Font Header = new Font("Calibri", 11, System.Drawing.FontStyle.Bold);

                //Header               

                e.Graphics.DrawString("Sales Bill", Header, Brushes.Black, float.Parse("15"), float.Parse("0"));
                                              
                e.Graphics.DrawString("Bill Date: " + DateTime.Now.ToString("dd-MM-yyyy"), font, Brushes.Black, float.Parse("5"), float.Parse("15"));

                e.Graphics.DrawString("Bill No: " + trnNo, font, Brushes.Black, float.Parse("5"), float.Parse("30"));
                
                e.Graphics.DrawString("------------------------------", font, Brushes.Black, float.Parse("5"), float.Parse("50"));

                e.Graphics.DrawString("Item(Qty)", font, Brushes.Black, float.Parse("5"), float.Parse("60"));

                e.Graphics.DrawString("TotalPrice", font, Brushes.Black, float.Parse("160"), float.Parse("60"));

                e.Graphics.DrawString("------------------------------", font, Brushes.Black, float.Parse("5"), float.Parse("70"));

                //Header

                //Body
                float xx = 90;
                float yy = 5;
                int countqty = 0;
                decimal GrandTotal = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal TotalAmount;

                    if (dt.Rows[i]["Item"].ToString().Length > 15)
                    {
                        string splitItemName1 = (dt.Rows[i]["Item"].ToString().Substring(0, 15));
                        string splitItemName2 = (dt.Rows[i]["Item"].ToString().Substring(15));


                        e.Graphics.DrawString(splitItemName1 + "-", font, Brushes.Black, yy, xx);
                        yy = 5;
                        xx = xx + 15;

                        e.Graphics.DrawString(splitItemName2 + " (" + dt.Rows[i]["Qty"].ToString() + ")", font, Brushes.Black, yy, xx);
                        yy = 10;
                        xx = xx + 15;

                        e.Graphics.DrawString("" + dt.Rows[i]["Price"].ToString() + "%)/Unit", font, Brushes.Black, yy, xx);

                        yy = 160;
                        xx = xx - 30;
                        TotalAmount = (decimal.Parse(dt.Rows[i]["Qty"].ToString()) * decimal.Parse(dt.Rows[i]["Price"].ToString()));
                        e.Graphics.DrawString("" + TotalAmount.ToString(), font, Brushes.Black, yy, xx);
                        xx = xx + 55;
                        yy = 5;
                    }
                    else
                    {
                        e.Graphics.DrawString(dt.Rows[i]["Item"].ToString() + " (" + dt.Rows[i]["Qty"].ToString() + ")", font, Brushes.Black, yy, xx);
                        yy = 10;
                        xx = xx + 15;
                        e.Graphics.DrawString("" + dt.Rows[i]["Price"].ToString() + ")/Unit", font, Brushes.Black, yy, xx);

                        yy = 160;
                        xx = xx - 15;
                        TotalAmount = (decimal.Parse(dt.Rows[i]["Qty"].ToString()) * decimal.Parse(dt.Rows[i]["Price"].ToString()));
                        e.Graphics.DrawString("" + TotalAmount.ToString(), font, Brushes.Black, yy, xx);
                        xx = xx + 40;
                        yy = 5;
                    }
                    countqty = countqty + int.Parse(dt.Rows[i]["Qty"].ToString());
                    GrandTotal = GrandTotal + TotalAmount;
                }
                //Footer
                e.Graphics.DrawString("------------------------------", font, Brushes.Black, float.Parse("5"), xx);

                xx = xx + 20;
                e.Graphics.DrawString("Tot Qty:", font, Brushes.Black, float.Parse("5"), xx);

                e.Graphics.DrawString(countqty.ToString(), font, Brushes.Black, float.Parse("75"), xx);

                e.Graphics.DrawString("Total:", font, Brushes.Black, float.Parse("100"), xx);

                e.Graphics.DrawString("" + GrandTotal.ToString(), font, Brushes.Black, float.Parse("170"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Discount : ", font, Brushes.Black, float.Parse("80"), xx);
                
                e.Graphics.DrawString(txtDiscount.Text + "", font, Brushes.Black, float.Parse("170"), xx);
               
                xx = xx + 20;

                e.Graphics.DrawString("Grand Total :", font, Brushes.Black, float.Parse("70"), xx);

                e.Graphics.DrawString(txtBillpaid.Text, font, Brushes.Black, float.Parse("170"), xx);

                xx = xx + 20;              

                e.Graphics.DrawString("Thank You. Visit Again !!!", font, Brushes.Black, float.Parse("8"), xx);


                xx = xx + 20;

                e.Graphics.DrawString("Powered By Coderobotics (www.coderobotics.com)", font, Brushes.Black, float.Parse("8"), xx);
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
                    lblMaxQty.Text = "Avail Quantity " + Convert.ToInt32(dsstk.Tables[0].Rows[0]["StockQuantity"].ToString());
                }
            }
        }



        private void txtBarcodetext_TextChanged(object sender, EventArgs e)
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
                    lblMaxQty.Text = "Avail Quantity " + Convert.ToInt32(ds.Tables[0].Rows[0]["StockQuantity"].ToString());

                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["StockQuantity"].ToString()) <= 0)
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
                            dt.Columns.Add("Barcode");
                            dt.Columns.Add("ItemID");
                            dt.Columns.Add("CategoryID");
                        }
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
                        row["Price"] = ds.Tables[0].Rows[0]["saleprice"].ToString();

                        row["Barcode"] = ds.Tables[0].Rows[0]["barcode"].ToString();
                        dt.Rows.Add(row);
                        DataView dView = new DataView(dt);
                        string[] arrColumns = { "Item", "Price", "Qty", "Barcode", "ItemID", "CategoryID" };
                        dt = dView.ToTable(true, arrColumns);
                        dt.AcceptChanges();
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[3].Visible = false;
                        dataGridView1.Columns[4].Visible = false;
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                        pric = 0;
                        for (int k = 0; k < (dataGridView1.Rows.Count); k++)
                        {
                            dataGridView1.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
                            //decimal afterdiscountamount = (decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()));
                            pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString()))), 2);
                        }
                        txtGrandTotal.Text = pric.ToString();
                        txtItemName.Text = string.Empty;
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
            if (decimal.Parse(txtBillpaid.Text) < Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))),2))
            {
                FrmMessage.Show("You Cannot Generate a Bill until you pay the Total Amount");
            }
            else if (decimal.Parse(txtBillpaid.Text) > Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))),2))
            {
                FrmMessage.Show("Return Amount is " + Math.Round((decimal.Parse(txtBillpaid.Text) - (decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text)))),2));
            }
            txtBillpaid.Text = Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))),2).ToString();
        }


        private void digitClicked(string digit)
        {
            string display = lblresult.Text;
            int count = display.Length;
            if (point == false)
            {
                if (operationPending == false)
                {
                    if (display == "0")
                    {
                        lblresult.Text = digit;
                    }
                    else
                    {
                        lblresult.Text = display.Insert(count, digit);
                    }
                }
                else if (operationPending == true)
                {
                    operationPending = false;
                    lblresult.Text = digit;
                }

            }
            else
            {
                if (operationPending == false)
                {
                    if (display == "0")
                    {
                        lblresult.Text = "0." + digit;
                    }
                    else
                    {
                        lblresult.Text = display + "." + digit;
                    }
                }
                else if (operationPending == true)
                {
                    operationPending = false;
                    lblresult.Text = "0." + digit;
                }
                point = false;
            }
        }

        private void GetNumberWithOperationName(string operationName)
        {
            string display = lblresult.Text;
            firstNum = Convert.ToDouble(display);
            operation = operationName;
            operationPending = true;
            pointClicked = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblresult.Text = "0";
            firstNum = 0;
            secondNum = 0;
            pointClicked = 0;
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (lblresult.Text != "0")
            {
                string display = lblresult.Text;
                int count = display.Length;
                if (count == 1)
                {
                    lblresult.Text = "0";
                }
                else
                {
                    display = display.Remove(count - 1, 1);
                    lblresult.Text = display;
                }
            }
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            digitClicked("0");
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            string display = lblresult.Text;

            if (pointClicked == 0)
            {
                if (operationPending == true)
                {
                    if (display == "0.")
                    {
                        lblresult.Text = "0.";
                    }
                    else
                    {
                        //txtResultBox.Text = display.Insert(count - 1, "7");

                    }
                }
                else if (operationPending == true)
                {
                    operationPending = false;
                    lblresult.Text = "0.";
                }
                point = true;
            }
            pointClicked += 1;
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            digitClicked("1");
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            digitClicked("2");
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            digitClicked("3");
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            digitClicked("4");
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            digitClicked("5");
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            digitClicked("6");
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            digitClicked("7");
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            digitClicked("8");
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            digitClicked("9");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            GetNumberWithOperationName("Multiply");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            GetNumberWithOperationName("Divide");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GetNumberWithOperationName("Add");
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            GetNumberWithOperationName("Subtract");
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string display = lblresult.Text;
            secondNum = Convert.ToDouble(display);

            if (operation == "Divide")
            {
                try
                {
                    result = firstNum / secondNum;
                    display = result.ToString();
                    lblresult.Text = display;
                }
                catch (DivideByZeroException ex)
                {
                    lblresult.Text = "Cannot divide by zero.";
                }
                catch
                {
                }
            }
            else if (operation == "Multiply")
            {
                result = firstNum * secondNum;
                display = result.ToString();
                lblresult.Text = display;
            }
            else if (operation == "Subtract")
            {
                result = firstNum - secondNum;
                display = result.ToString();
                lblresult.Text = display;
            }
            else if (operation == "Add")
            {
                result = firstNum + secondNum;
                display = result.ToString();
                lblresult.Text = display;
            }
            else if (operation == "Percentage")
            {
                result = firstNum * (secondNum / 100);
                display = result.ToString();
                lblresult.Text = display;
            }

            operation = "Equal";
            operationPending = true;
            pointClicked = 0;
        }

        private void btnPercentage_Click(object sender, EventArgs e)
        {
            GetNumberWithOperationName("Percentage");
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
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            } 
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            pric = 0;
            for (int k = 0; k < (dataGridView1.Rows.Count); k++)
            {                
                pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString())) * (decimal.Parse(dataGridView1.Rows[k].Cells[2].Value.ToString()))), 2);
            }            
            txtGrandTotal.Text = pric.ToString();
            txtBillpaid.Text = (Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtDiscount.Text))),2)).ToString();
        }

      

       
        

        








    }
}
