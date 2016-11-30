using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMDal;
namespace Inventory
{
    public partial class FRM_SERVICEACCOUNT : Form
    {
        SQLHelper sqlhelp = new SQLHelper();
        decimal pric = 0;
        DataTable dt = new DataTable();
        public FRM_SERVICEACCOUNT()
        {
            InitializeComponent();
        }

        private void FRM_SERVICEACCOUNT_Load(object sender, EventArgs e)
        {
            loadservices();
           // AutoSuggestCustMobile();
            //loademp();
        }

        ////private void AutoSuggestCustMobile()
        //{
        //    sqlhelp = new SQLHelper();
        //    DataTable dt = new DataTable();
        //    dt = sqlhelp.ExecuteTables("select Phone from Customers");

        //    AutoCompleteStringCollection col = new AutoCompleteStringCollection();          
        //    for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //    {
        //        col.Add(dt.Rows[i]["Phone"].ToString());
               
        //    }
        //    txtCustMobile.AutoCompleteSource = AutoCompleteSource.CustomSource;
        //    txtCustMobile.AutoCompleteCustomSource = col;
        //    txtCustMobile.AutoCompleteMode = AutoCompleteMode.Suggest;
        //}
        private void loadservices()
        {
            GroupPanel.Controls.Clear();
            int y = 10;
            int x = 5;
            int count = 1;

            DataSet dds = new DataSet();
            SQLHelper sqlhelper = new SQLHelper();
            dds = sqlhelper.ExecuteQueries("Select * from services");
            string dir = Application.StartupPath;//Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            dir = System.IO.Path.Combine(dir, "InventoryImages");
            for (int a = 0; a < dds.Tables[0].Rows.Count; a++)
            {
                Panel panel = new Panel();
                panel.BackColor = System.Drawing.Color.WhiteSmoke;
                panel.Name = dds.Tables[0].Rows[a]["ServiceID"].ToString();
                panel.Size = new System.Drawing.Size(100, 119);
                panel.Location = new Point(x, y);
                panel.Cursor = System.Windows.Forms.Cursors.Hand;

                System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();

                PictureBox pb = new PictureBox();
                pb.Size = new Size(85, 80);
                pb.Cursor = System.Windows.Forms.Cursors.Hand;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Location = new Point(5, 22);
                pb.Name = dds.Tables[0].Rows[a]["ServiceID"].ToString();
                if (!string.IsNullOrEmpty(dds.Tables[0].Rows[a]["Image"].ToString()))
                {
                    pb.Image = System.Drawing.Image.FromFile(dir + "\\" + dds.Tables[0].Rows[a]["Image"].ToString());
                }


                // label for displaying Item Name on Image.
                Label DynamicLabel = new Label();
                DynamicLabel.Name = dds.Tables[0].Rows[a]["ServiceID"].ToString();
                DynamicLabel.BackColor = Color.Transparent;
                DynamicLabel.Text = dds.Tables[0].Rows[a]["ServiceName"].ToString();
                DynamicLabel.Location = new Point(5, 8);
                DynamicLabel.Size = new Size(100, 12);
                DynamicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                DynamicLabel.Cursor = System.Windows.Forms.Cursors.Hand;

                ToolTip1.SetToolTip(pb, DynamicLabel.Text);
                ToolTip1.SetToolTip(DynamicLabel, DynamicLabel.Text);
                ///////////////////////////////////////////////////////////////////////////////////////////////

                // label for displaying Amount
                Label DynamicLabl = new Label();
                DynamicLabl.Name = dds.Tables[0].Rows[a]["ServiceID"].ToString();
                DynamicLabl.BackColor = System.Drawing.Color.Transparent;
                DynamicLabl.Location = new Point(3, 103);
                DynamicLabl.Text = "Rs:  " + dds.Tables[0].Rows[a]["ServiceCharge"].ToString();
                DynamicLabl.Size = new Size(80, 12);
                DynamicLabl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                DynamicLabl.Cursor = System.Windows.Forms.Cursors.Hand;
                ToolTip1.SetToolTip(DynamicLabl, DynamicLabl.Text);
                /////////////////////////////////////////////////////////////////////////////////////////////

                //    pb.Controls.Add(DynamicLabel);                    
                panel.Controls.Add(DynamicLabel);
                panel.Controls.Add(pb);
                panel.Controls.Add(DynamicLabl);
                GroupPanel.Controls.Add(panel);

                pb.Click += new System.EventHandler(PbItems_Click);
                DynamicLabl.Click += new System.EventHandler(PbItems_Click);
                DynamicLabel.Click += new System.EventHandler(PbItems_Click);
                panel.Click += new System.EventHandler(PbItems_Click);
                panel.Paint += GroupPanel_Paint;

                if ((count) % 4 > 0)
                {
                    x = x + 100;
                }
                else
                {
                    x = 5;
                    y = y + 130;
                }
                count++;
            }

        }

        private void GroupPanel_Paint(object Sender, PaintEventArgs e)
        {
            Panel GBDynamic = (Panel)Sender;
            e.Graphics.Clear(SystemColors.Control);
            e.Graphics.DrawString(GBDynamic.Text, GBDynamic.Font, Brushes.Black, 0, 0);
            Rectangle Rect = GBDynamic.ClientRectangle;
            ControlPaint.DrawBorder3D(e.Graphics, Rect, Border3DStyle.RaisedInner);

        }
        private void PbItems_Click(object sender, EventArgs e)
        {
            try
            {
                PictureBox DynamicItemsBarcode = (sender as PictureBox);
                Label labelbarcode = (sender as Label);
                Panel GroupbxBarcode = (sender as Panel);
                DataSet dsstk = new DataSet();
                SQLHelper sqlh = new SQLHelper();
                if (DynamicItemsBarcode == null && GroupbxBarcode == null)
                {
                    dsstk = sqlh.ExecuteQueries("select * from Services where  ServiceID=" + labelbarcode.Name.ToString() + "");
                }
                else if (labelbarcode == null && GroupbxBarcode == null)
                {
                    dsstk = sqlh.ExecuteQueries("select * from Services where  ServiceID=" + DynamicItemsBarcode.Name.ToString() + "");
                }

                else if (labelbarcode == null && DynamicItemsBarcode == null)
                {
                    dsstk = sqlh.ExecuteQueries("select * from Services where  ServiceID=" + GroupbxBarcode.Name.ToString() + "");
                }
                if (dsstk.Tables[0].Rows.Count > 0)
                {
                    //FRM_POPUPEMP emp = new FRM_POPUPEMP();
                    //emp.ShowDialog();

                    //if (!string.IsNullOrEmpty(GlobalData.EmpID))
                    //{
                        if (dt.Columns.Count < 1)
                        {
                            dt.Columns.Add("ServiceID");
                            dt.Columns.Add("Service Name");
                            dt.Columns.Add("Service Charge");
                            //dt.Columns.Add("EmpID");
                            //dt.Columns.Add("Employee Name");
                        }
                        dt.AcceptChanges();
                        DataRow row = dt.NewRow();
                        row["ServiceID"] = dsstk.Tables[0].Rows[0]["ServiceID"].ToString();
                        row["Service Name"] = dsstk.Tables[0].Rows[0]["ServiceName"].ToString();
                        row["Service Charge"] = dsstk.Tables[0].Rows[0]["ServiceCharge"].ToString();
                        //row["EmpID"] = GlobalData.EmpID;
                        //row["Employee Name"] = GlobalData.EmpName;
                        dt.Rows.Add(row);
                        DataView dView = new DataView(dt);
                        //string[] arrColumns = { "ServiceID", "Service Name", "Service Charge", "EmpID", "Employee Name" };
                    string[] arrColumns = { "ServiceID", "Service Name", "Service Charge"};
                        dt = dView.ToTable(true, arrColumns);
                        dt.AcceptChanges();
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["ServiceID"].Visible = false;
                        // dataGridView1.Columns["EmpID"].Visible = false;
                        dataGridView1.Rows.OfType<DataGridViewRow>().Last().Selected = true;
                        pric = 0;
                        for (int k = 0; k < (dataGridView1.Rows.Count); k++)
                        {
                            pric = Math.Round((pric + (decimal.Parse(dataGridView1.Rows[k].Cells["Service Charge"].Value.ToString()))), 2);
                        }
                        txtGrandTotal.Text = pric.ToString();
                        txtBillpaid.Text = (Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtGrandTotal.Text) * (decimal.Parse(txtDiscount.Text) / 100))), 2)).ToString();

                    }
                }
            
            catch (Exception ex)
            {
            }
            finally
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

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("calc");
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }


        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtDiscount.Text))
                {
                    txtBillpaid.Text = Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtGrandTotal.Text) * (decimal.Parse(txtDiscount.Text) / 100))), 2).ToString();
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



        private void txtEmpNo_KeyPress(object sender, KeyPressEventArgs e)
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
        string TransID = "";
        string CustID = "";
        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBillpaid.Text) || dataGridView1.Rows.Count <= 0)
                {
                    FrmMessage.Show("Please select atleast one service to generate a bill");
                }
                //else if (string.IsNullOrEmpty(txtCustMobile.Text.Trim()) || string.IsNullOrEmpty(txtName.Text.Trim()))
                //{
                //    FrmMessage.Show("Please enter the Customer Name and Mobile");
                //}
                else
                {
                    sqlhelp = new SQLHelper();
                    bool result = false;
                    //if (Int32.Parse(sqlhelp.ExecuteScalar("select count(Phone) from Customers where Phone='" + txtCustMobile.Text + "'")) == 0)
                    //{
                    //    result = sqlhelp.ExecuteNonQuery("insert into Customers (CustName,Phone) values('" + txtName.Text.Trim() + "','" + txtCustMobile.Text.Trim() + "')");
                    //    CustID = sqlhelp.ExecuteScalar("select max(CustID) from Customers");
                    //}
                    //else
                    //{
                    //    result = true;
                    //}
                    //if (result == true)
                    //{
                        result = sqlhelp.ExecuteNonQuery("insert into ServiceTransactions(TotalAmount,DiscountPercent,BillPaid,CreatedBy)" +
                                                         "values (" + txtGrandTotal.Text + "," + txtDiscount.Text.Trim() + ", " + txtBillpaid.Text + "," +
                                                         "" + GlobalData.UserID + ")");
                        if (result == true)
                        {
                            TransID = sqlhelp.ExecuteScalar("select max(STransID) from ServiceTransactions");

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                               // decimal Commission = 0;
                                decimal ServiceAmount = 0;
                                ServiceAmount = (Math.Round((decimal.Parse(dataGridView1.Rows[i].Cells["Service Charge"].Value.ToString()) - (decimal.Parse(dataGridView1.Rows[i].Cells["Service Charge"].Value.ToString()) * (decimal.Parse(txtDiscount.Text) / 100))), 2));
                               // Commission = (Math.Round(((ServiceAmount * (decimal.Parse(Int32.Parse(sqlhelp.ExecuteScalar("select COMMISSION from employees where ISACTIVE=True and EMPID=" + dataGridView1.Rows[i].Cells["EMPID"].Value.ToString() + "")).ToString()) / 100))), 2));
                                result = sqlhelp.ExecuteNonQuery("insert into STransDetails(STransID,ServiceID,ServiceCharge,DiscountPercent)" +
                                                                   "values (" + TransID + "," + dataGridView1.Rows[i].Cells["ServiceID"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Service Charge"].Value.ToString() + "," +
                                                                   "" + txtDiscount.Text + ")");
                            }
                            if (result == true)
                            {
                                BillPrintPreview.Document = BillPrint;
                                BillPrintPreview.PrintPreviewControl.Zoom = 1;
                                BillPrintPreview.ShowDialog();

                            }
                        }



                        FrmMessage.Show("Transaction Successful");

                        FRM_SERVICEACCOUNT form = new FRM_SERVICEACCOUNT
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
            }
            finally
            {
            }
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                dataGridView1.Update();
                txtGrandTotal.Text = Math.Round(decimal.Parse(dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => decimal.Parse(t.Cells["Service Charge"].Value.ToString())).ToString()), 2).ToString();
                if (txtDiscount.Text != "0")
                {
                    txtBillpaid.Text = (Math.Round((decimal.Parse(txtGrandTotal.Text) - (decimal.Parse(txtGrandTotal.Text) * (decimal.Parse(txtDiscount.Text) / 100))), 2)).ToString();
                }
                else
                {
                    txtBillpaid.Text = txtGrandTotal.Text;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        FrmMessage.enumMessageButton YesNoButton = FrmMessage.enumMessageButton.YesNo;
        FrmMessage.enumMessageIcon QuestionIcon = FrmMessage.enumMessageIcon.Question;

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (DialogResult.Yes == FrmMessage.Show("Are You Sure You want to Delete from the list", "Saloon Management", YesNoButton, QuestionIcon))
                {
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void BillPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataTable dtbranch = new DataTable();
            try
            {
                //DataTable dtfeecat = new DataTable();

                //dtbranch = sqlhelp.ExecuteTables("Select ShopName,contactNo,Address from ShopDetails");

                Font font = new Font("Courier New", 9, System.Drawing.FontStyle.Bold);

                Font Header = new Font("Calibri", 13, System.Drawing.FontStyle.Bold);

                //Header               

                e.Graphics.DrawString("Service Bill", Header, Brushes.Black, float.Parse("30"), float.Parse("0"));
                e.Graphics.DrawString("Bill Date: " + DateTime.Now.ToString("dd-MM-yyyy"), font, Brushes.Black, float.Parse("5"), float.Parse("20"));
                /////////
                int x = 0, y = 10, xx = 0;
                //if (dtbranch.Rows[0]["Address"].ToString().Trim().Length > 40)
                //{
                //    string[] splitItemName = new string[5];
                //    int add = dtbranch.Rows[0]["Address"].ToString().Length;
                //    int k = (dtbranch.Rows[0]["Address"].ToString().Length / 40);

                //    for (int i = 0; i <= (dtbranch.Rows[0]["Address"].ToString().Length / 40); i++)
                //    {
                //        if ((dtbranch.Rows[0]["Address"].ToString().Length - (xx)) > 40)
                //        {
                //            splitItemName[i] = dtbranch.Rows[0]["Address"].ToString().Substring(0 + x, 40);
                //        }
                //        else
                //        {
                //            splitItemName[i] = dtbranch.Rows[0]["Address"].ToString().Substring(xx);
                //        }
                //        e.Graphics.DrawString(splitItemName[i], font, Brushes.Black, float.Parse("5"), y);
                //        x = 40;
                //        xx = xx + 40;
                //        y = y + 16;
                //    }
                //    y = y - 16;
                //}
                //else
                //{
                //    e.Graphics.DrawString(dtbranch.Rows[0]["Address"].ToString(), font, Brushes.Black, float.Parse("15"), y);
                //}

              //  e.Graphics.DrawString("Contact No : " + dtbranch.Rows[0]["CONTACTNO"].ToString(), font, Brushes.Black, float.Parse("5"), y + 16);

                e.Graphics.DrawString("---------------------------------------------", font, Brushes.Black, float.Parse("5"), y + 26);

                e.Graphics.DrawString(" Service Charges ", font, Brushes.Black, float.Parse("30"), y + 36);

                e.Graphics.DrawString("---------------------------------------------", font, Brushes.Black, float.Parse("5"), y + 46);

                e.Graphics.DrawString("Service", font, Brushes.Black, float.Parse("5"), y + 56);

                e.Graphics.DrawString("Amount", font, Brushes.Black, float.Parse("180"), y + 56);

                e.Graphics.DrawString("---------------------------------------------", font, Brushes.Black, float.Parse("5"), y + 66);

                //Header

                //Body
                xx = y + 81;
                float yy = 5;
                decimal TotalAmount;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells["Service Name"].Value.ToString(), font, Brushes.Black, yy, xx);
                    yy = 180;

                    TotalAmount = (decimal.Parse(dataGridView1.Rows[i].Cells["Service Charge"].Value.ToString()));
                    e.Graphics.DrawString("" + TotalAmount.ToString(), font, Brushes.Black, yy, xx);
                    xx = xx + 20;
                    yy = 5;
                }
                //Footer
                e.Graphics.DrawString("---------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);
                xx = xx + 20;
                e.Graphics.DrawString("Total:", font, Brushes.Black, float.Parse("100"), xx);

                e.Graphics.DrawString("" + txtGrandTotal.Text.ToString(), font, Brushes.Black, float.Parse("170"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Discount : ", font, Brushes.Black, float.Parse("80"), xx);

                e.Graphics.DrawString(txtDiscount.Text + "%", font, Brushes.Black, float.Parse("170"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Grand Total :", font, Brushes.Black, float.Parse("70"), xx);

                e.Graphics.DrawString(txtBillpaid.Text, font, Brushes.Black, float.Parse("170"), xx);

                xx = xx + 20;

                e.Graphics.DrawString("Thank You. Visit Again !!!", font, Brushes.Black, float.Parse("8"), xx);

                xx = xx + 20;
                e.Graphics.DrawString("---------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);

                e.Graphics.DrawString("Generated by:" + GlobalData.UserName + " On: " + DateTime.Now.ToString("dd-MM-yyyy"), font, Brushes.Black, float.Parse("5"), xx + 16);

                xx = xx + 16;
                e.Graphics.DrawString("---------------------------------------------", font, Brushes.Black, float.Parse("5"), xx + 16);

                Font font1 = new Font("Courier New", 8, System.Drawing.FontStyle.Bold);

                e.Graphics.DrawString("    ** Powered By Coderobotics **      ", font1, Brushes.Black, float.Parse("5"), xx + 30);

                //Footer
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void groupBox1_Paint(object sender, PaintEventArgs e)
        //{
        //    GroupBox GBDynamic = (GroupBox)sender;
        //    e.Graphics.Clear(System.Drawing.Color.WhiteSmoke);
        //    Rectangle Rect = GBDynamic.ClientRectangle;
        //    ControlPaint.DrawBorder3D(e.Graphics, Rect, Border3DStyle.Flat);
        //    ControlPaint.DrawBorder(e.Graphics, Rect, System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(142)))), ((int)(((byte)(224))))), 2, ButtonBorderStyle.Solid, System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(142)))), ((int)(((byte)(224))))), 2, ButtonBorderStyle.Solid, System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(142)))), ((int)(((byte)(224))))), 2, ButtonBorderStyle.Solid, System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(142)))), ((int)(((byte)(224))))), 2, ButtonBorderStyle.Solid);
        //}

        //private void txtCustMobile_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void txtCustMobile_Leave(object sender, EventArgs e)
        //{
        //    getCustName();

        //}        

        //private void getCustName()
        //{
        //    try
        //    {
            
        //            DataTable dt = new DataTable();
        //            dt = sqlhelp.ExecuteTables("select CustID,CustName from Customers where Phone='" + txtCustMobile.Text + "'");
        //            if (dt.Rows.Count > 0)
        //            {
        //                txtName.Text = dt.Rows[0]["CustName"].ToString();                       
        //                CustID = dt.Rows[0]["CustID"].ToString();
        //                txtName.Enabled = false;                        
        //            }
        //            else
        //            {
        //                txtName.Text = string.Empty;
        //                txtName.Enabled = true;
        //            }
                
                
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //private void txtCustMobile_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        getCustName();
        //    }
        //}

        private void FRM_SERVICEACCOUNT_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
