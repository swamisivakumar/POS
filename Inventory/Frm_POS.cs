using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMDal;
using GenCode128;

namespace Inventory
{
    public partial class Frm_POS : Form
    {
        SQLHelper sqlhelper = new SQLHelper();
        public Frm_POS()
        {
            InitializeComponent();
        }
        DataTable dtshop = new DataTable();
        private void Frm_POS_Load(object sender, EventArgs e)
        {
            try
            {
                button8.Visible = false;
                dataGridView4.ColumnCount = 10;
                dataGridView4.Columns[0].Name = "SNo.";
                DataGridViewColumn column = dataGridView4.Columns[0];
                column.Width = 50;
                dataGridView4.Columns[1].Name = "Item";
                DataGridViewColumn column1 = dataGridView4.Columns[1];
                column1.Width = 250;
                dataGridView4.Columns[2].Name = "MRP";
                dataGridView4.Columns[3].Name = "Price";
                dataGridView4.Columns[4].Name = "Qty";
                DataGridViewColumn column4 = dataGridView4.Columns[4];
                column4.Width = 50;
                dataGridView4.Columns[5].Name = "Type";
                DataGridViewColumn column5 = dataGridView4.Columns[5];
                column5.Width = 70;
                dataGridView4.Columns[6].Name = "Barcode";
                dataGridView4.Columns[7].Name = "ItemID";
                dataGridView4.Columns[8].Name = "CategoryID";
                dataGridView4.Columns[9].Name = "Vat(%)";
                DataGridViewColumn column9 = dataGridView4.Columns[9];
                column9.Width = 60;          

                dataGridView4.Columns[6].Visible = false;
                dataGridView4.Columns[7].Visible = false;
                dataGridView4.Columns[8].Visible = false;
              
                dtshop = sqlhelper.ExecuteTables("select * from ShopDetails");
            }
            catch (Exception)
            {
            }
        }
        public AutoCompleteStringCollection AutoCompleteLoad()
        {
            AutoCompleteStringCollection str = new AutoCompleteStringCollection();
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteTables("select ItemName from GetItemsForCashier");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str.Add(dt.Rows[i]["ItemName"].ToString());
            }

            return str;
        }

        private void dataGridView4_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                int column = dataGridView4.CurrentCell.ColumnIndex;

                string headerText = dataGridView4.Columns[column].HeaderText;

                if (headerText.Equals("Item"))
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        tb.AutoCompleteCustomSource = AutoCompleteLoad();
                        tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        decimal pric = 0;
        private void dataGridView4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int column = dataGridView4.CurrentCell.ColumnIndex;

                string headerText = dataGridView4.Columns[column].HeaderText;

                if (headerText.Equals("Item"))
                {
                    DataTable dtitems = new DataTable();
                    dtitems = sqlhelper.ExecuteTables("select * from GetItemsForCashier where ItemName='" + dataGridView4.CurrentRow.Cells["Item"].Value.ToString() + "'");
                    if (dtitems.Rows.Count > 0)
                    {
                        dataGridView4.CurrentRow.Cells["Price"].Value = dtitems.Rows[0]["saleprice"].ToString();
                        dataGridView4.CurrentRow.Cells["Qty"].Value = 1;
                        dataGridView4.CurrentRow.Cells["Type"].Value = dtitems.Rows[0]["QtyType"].ToString();
                        dataGridView4.CurrentRow.Cells["Barcode"].Value = dtitems.Rows[0]["barcode"].ToString();
                        dataGridView4.CurrentRow.Cells["ItemID"].Value = dtitems.Rows[0]["ItemID"].ToString();
                        dataGridView4.CurrentRow.Cells["CategoryID"].Value = dtitems.Rows[0]["CategoryID"].ToString();
                        dataGridView4.CurrentRow.Cells["Vat(%)"].Value = dtitems.Rows[0]["VatPercent"].ToString();
                        dataGridView4.CurrentRow.Cells["MRP"].Value = dtitems.Rows[0]["MRP"].ToString();
                       
                    }
                    else
                    {
                        FrmMessage.Show("Product is not available");
                        dataGridView4.CurrentRow.Cells["Item"].Value = "";
                    }
                }
                pric = 0;
                decimal VatAmount = 0;
                for (int k = 0; k < (dataGridView4.Rows.Count - 1); k++)
                {
                    pric = Math.Round((pric + (decimal.Parse(dataGridView4.Rows[k].Cells["Price"].Value.ToString())) * (decimal.Parse(dataGridView4.Rows[k].Cells["Qty"].Value.ToString()))), 2);
                    VatAmount = Math.Round((VatAmount + (decimal.Parse(dataGridView4.Rows[k].Cells["Price"].Value.ToString()) * decimal.Parse(dataGridView4.Rows[k].Cells["Qty"].Value.ToString())) * (decimal.Parse(dataGridView4.Rows[k].Cells["Vat(%)"].Value.ToString()) / 100)), 2);
                }
                txtSTotal.Text = pric.ToString();
                SVatAmt.Text = VatAmount.ToString();
                txtSAmount.Text = (Math.Round((decimal.Parse(txtSTotal.Text) - (decimal.Parse(txtSDiscount.Text))), 2)).ToString();



            }
            catch (Exception ex)
            {
            }
        }

        private void dataGridView4_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Index == 1)
            {
                dataGridView4.Rows[0].Cells["SNo."].Value = 1;
            }
            else
            {
                int last_id = (int)(dataGridView4.Rows[e.Row.Index - 2].Cells["SNo."].Value);
                dataGridView4.Rows[e.Row.Index - 1].Cells["SNo."].Value = last_id + 1;
            }

        }

        private void txtSTotal_TextChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
            }
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

        private void txtSAmount_TextChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {

            }
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
            try
            {
                ShowStock();
            }
            catch (Exception ex)
            {
            }


        }

        private void openCalcy()
        {
            System.Diagnostics.Process.Start("calc");
        }
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                openCalcy();
            }
            catch (Exception ex)
            {
            }
        }


        private void cancelSmarttrans()
        {
            dataGridView4.DataSource = null;
            dataGridView4.Columns.Clear();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                cancelSmarttrans();
            }
            catch (Exception)
            {

            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            try
            {
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
            catch (Exception ex)
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

        bool redeemclick = false;
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrEmpty(textBox19.Text))
                {
                    FrmMessage.Show("You cannot REDEEM THE POINTS without CARD DETAILS");
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
            catch (Exception ex)
            {
            }

        }
        Int32 DEALERID = 0;
        private void textBox64_Leave(object sender, EventArgs e)
        {
            try
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
                    FrmMessage.Show("No Records Found");
            }
            catch (Exception ex)
            {
            }
        }

        private void textBox64_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
                        FrmMessage.Show("No Records Found");
                }
                else
                {
                }
            }
            catch (Exception)
            {


            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {


            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
            }
        }
        Int32 ANO = 0;
        private void textBox61_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(e.KeyChar) == 13)
                {

                    sqlhelper = new SQLHelper();
                    DataSet dsAgent = new DataSet();

                    dsAgent = sqlhelper.ExecuteQueries("select * FROM AGENTCOMISSIONQUERY where MemberNo = '" + textBox61.Text + "'");
                    if (dsAgent.Tables[0].Rows.Count > 0)
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
                        FrmMessage.Show("No Agent Found with provided Agent #");
                }
                else
                {
                }
            }
            catch (Exception)
            {


            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            savesmartPos1();
        }

        static string trnNo;

        private void savesmartPos1()
        {
            try
            {
                if (string.IsNullOrEmpty(txtSAmount.Text) || dataGridView4.Rows.Count <= 0)
                {
                    FrmMessage.Show("You cannot Generate Bill without Items");
                }
                else if (string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrEmpty(textBox19.Text))
                {
                    FrmMessage.Show("Redeem Card No should be Entered or Cancel the Redeem");
                }
                else
                {
                    sqlhelper = new SQLHelper();
                    bool result;

                    //result = sqlhelper.ExecuteNonQuery("insert into Customers(CustName,Phone) values ('" + txtCustName.Text + "'," + txtCustPhnNo.Text + ")");
                    //if (result == true)
                    //{

                   DataSet ds = new DataSet();
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


                    FrmMessage.Show("Transaction Successful");
                    Frm_POS form = new Frm_POS
                    {
                        MdiParent = this.MdiParent,
                        Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right))),
                        Dock = DockStyle.Fill
                    };

                    form.Show();




                }
            }
            catch (Exception ex)
            {
                FrmMessage.Show(ex.ToString());
            }
        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
               

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
                for (int i = 0; i < dataGridView4.Rows.Count-1; i++)
                {
                    decimal TotalAmount;

                    if (dataGridView4.Rows[i].Cells["Item"].Value.ToString().Length > 10)
                    {
                        
                        xx = xx + 15;

                        string splitItemName1 = (dataGridView4.Rows[i].Cells["Item"].Value.ToString().Substring(0, 10));
                        string splitItemName2 = (dataGridView4.Rows[i].Cells["Item"].Value.ToString().Substring(10));

                        e.Graphics.DrawString("" + dataGridView4.Rows[i].Cells["SNo."].Value.ToString(), font, Brushes.Black, yy, xx);

                        yy = 60;
                        e.Graphics.DrawString(splitItemName1 + "-", font, Brushes.Black, yy, xx);
                        yy = 60;
                        xx = xx + 15;

                        e.Graphics.DrawString(splitItemName2 + " (" + dataGridView4.Rows[i].Cells["Qty"].Value.ToString() + ")", font, Brushes.Black, yy, xx);
                        //yy = 60;
                        //xx = xx + 15;



                        yy = 160;
                        xx = xx - 15;
                        e.Graphics.DrawString("" + dataGridView4.Rows[i].Cells["MRP"].Value.ToString() + "/" + dataGridView4.Rows[i].Cells["Type"].Value.ToString() + "", font, Brushes.Black, yy, xx);



                        yy = 245;
                        e.Graphics.DrawString("" + dataGridView4.Rows[i].Cells["Price"].Value.ToString(), font, Brushes.Black, yy, xx);


                        yy = 330;
                        TotalAmount = Math.Round((decimal.Parse(dataGridView4.Rows[i].Cells["Qty"].Value.ToString()) * decimal.Parse(dataGridView4.Rows[i].Cells["Price"].Value.ToString())), 2);
                        e.Graphics.DrawString("" + TotalAmount.ToString(), font, Brushes.Black, yy, xx);
                        //e.Graphics.DrawString("" + dt3.Rows[i]["Vat(%)"].ToString(), font, Brushes.Black, yy, xx);
                        xx = xx + 55;
                        yy = 5;
                        //e.Graphics.DrawString("-----------------------------------------------", font, Brushes.Black, float.Parse("5"), xx);
                    }
                    else
                    {
                       
                        xx = xx + 15;

                        e.Graphics.DrawString("" + dataGridView4.Rows[i].Cells["SNo."].Value.ToString(), font, Brushes.Black, yy, xx);
                        yy = 60;

                        e.Graphics.DrawString(dataGridView4.Rows[i].Cells["Item"].Value.ToString() + " (" + dataGridView4.Rows[i].Cells["Qty"].Value.ToString() + ")", font, Brushes.Black, yy, xx);
                        //yy = 60;
                        //xx = xx + 15;


                        yy = 160;
                        //xx = xx - 15;
                        e.Graphics.DrawString("" + dataGridView4.Rows[i].Cells["MRP"].Value.ToString() + "/" + dataGridView4.Rows[i].Cells["Type"].Value.ToString() + "", font, Brushes.Black, yy, xx);


                        yy = 245;
                        e.Graphics.DrawString("" + dataGridView4.Rows[i].Cells["Price"].Value.ToString(), font, Brushes.Black, yy, xx);

                        yy = 330;
                        TotalAmount = Math.Round((decimal.Parse(dataGridView4.Rows[i].Cells["Qty"].Value.ToString()) * decimal.Parse(dataGridView4.Rows[i].Cells["Price"].Value.ToString())), 2);
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
                for (int j = 0; j < dataGridView4.Rows.Count -1 ;j++)
                {
                    Savings = Savings + (decimal.Parse(dataGridView4.Rows[j].Cells["MRP"].Value.ToString()) * decimal.Parse(dataGridView4.Rows[j].Cells["Qty"].Value.ToString()));

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

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                savesmartPos();
            }
            catch (Exception)
            {
            }
        }



        private void savesmartPos()
        {
            try
            {
                if (string.IsNullOrEmpty(txtSAmount.Text) || dataGridView4.Rows.Count <= 0)
                {
                    FrmMessage.Show("You cannot Generate Bill without Items");
                }

                else
                {
                    sqlhelper = new SQLHelper();
                    bool result;

                    DataSet ds = new DataSet();
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

                        for (int i = 0; i < dataGridView4.Rows.Count-1; i++)
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


                    FrmMessage.Show("Transaction Successful");


                    Frm_POS form = new Frm_POS
                    {
                        MdiParent = this.MdiParent,
                        Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right))),
                        Dock = DockStyle.Fill
                    };

                    form.Show();

                    //cancelSmarttrans();
                    //textBox12.Text = string.Empty;
                    //textBox13.Text = string.Empty;
                    //textBox14.Text = string.Empty;
                    //textBox15.Text = string.Empty;
                    //SVatAmt.Text = "0";
                    ////textBox16.Text = "0";
                    //textBox18.Text = "0";
                    //txtSTotal.Text = "0";
                    //textBox19.Text = "PACNO";
                    //txtSAmount.Text = "0";


                    //button10.Visible = true;
                    //button8.Visible = false;

                }
            }
            catch (Exception ex)
            {
                FrmMessage.Show(ex.ToString());
            }
        }

        private void Frm_POS_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void dataGridView4_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        //{
        //    if (dataGridView4[1, e.RowIndex].Value == null)
        //        e.Cancel = true;
        //}


    }
}
