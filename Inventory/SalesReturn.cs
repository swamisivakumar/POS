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

namespace Inventory
{
    public partial class SalesReturn : Form
    {
        Hashtable ht = new Hashtable();
        SQLHelper sqlhelp = new SQLHelper();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        decimal TotalActualAmount;

        #region global Declaration for custom messagebox
        FrmMessage.enumMessageIcon InformationIcon = FrmMessage.enumMessageIcon.Information;
        FrmMessage.enumMessageIcon QuestionIcon = FrmMessage.enumMessageIcon.Question;
        FrmMessage.enumMessageIcon ErrorIcon = FrmMessage.enumMessageIcon.Error;

        FrmMessage.enumMessageButton OkButton = FrmMessage.enumMessageButton.OK;
        FrmMessage.enumMessageButton YesNoButton = FrmMessage.enumMessageButton.YesNo;
        FrmMessage.enumMessageButton OkCancelButton = FrmMessage.enumMessageButton.OKCancel;
        string caption = "Inventory Management";
        #endregion

        public SalesReturn()
        {
            InitializeComponent();
        }
        private void AutoSuggestTransaction()
        {
            sqlhelp = new SQLHelper();
            ds = sqlhelp.ExecuteQueries("select TransactionNo from Payment");

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["TransactionNo"].ToString());
            }
            txtSrchTransNo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSrchTransNo.AutoCompleteCustomSource = col;
            txtSrchTransNo.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                sqlhelp = new SQLHelper();
                ds = new DataSet();
                dt = new DataTable();
                if (dt.Columns.Count < 1)
                {
                    dt.Columns.Add("TransactionID");
                    dt.Columns.Add("CategoryID");
                    dt.Columns.Add("Category");
                    dt.Columns.Add("ItemID");
                    dt.Columns.Add("Barcode");
                    dt.Columns.Add("Item");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("Item Price");
                    dt.Columns.Add("Total Amount");
                }


                if (string.IsNullOrEmpty(txtSrchTransNo.Text))
                {
                    FrmMessage.Show("Please Enter Your Bill No", caption, OkButton, ErrorIcon);
                }
                else
                {
                    ds = sqlhelp.ExecuteQueries("select * from TransFetch where TransactionNo='" + txtSrchTransNo.Text.Trim() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //dt = ds.Tables[0].Copy();
                        //DataView dView = new DataView(dt);
                        //string[] arrColumns = { "TransactionNo", "Customer Name", "Phone" };
                        //dt = dView.ToTable(true, arrColumns);
                        //dt.AcceptChanges();
                        //if (dt.Rows.Count > 0)
                        //{

                        lblBillNo.Text = ds.Tables[0].Rows[0]["TransactionNo"].ToString();
                        lblDiscount.Text = ds.Tables[0].Rows[0]["DiscountAmount"].ToString();
                        lblBookingDate.Text = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString()).ToString("dd-MM-yyyy");
                        //*************binding values to gridview********************
                        TransGrid.DataSource = ds.Tables[0];
                        TransGrid.Columns["PaymentID"].Visible = false;
                        TransGrid.Columns["TransactionNo"].Visible = false;
                        TransGrid.Columns["CategoryID"].Visible = false;
                        TransGrid.Columns["ItemID"].Visible = false;
                        TransGrid.Columns["TotalAmount"].Visible = false;
                        TransGrid.Columns["DiscountAmount"].Visible = false;
                        TransGrid.Columns["BillPaid"].Visible = false;
                        TransGrid.Columns["CreatedDate"].Visible = false;
                        TransGrid.Columns["TransactionID"].Visible = false;
                        TransGrid.Columns["RemainingQty"].Visible = false;
                        //}
                        //else
                        //{

                        //}

                        ReturnGrid.DataSource = dt;
                        ReturnGrid.Columns["CategoryID"].Visible = false;
                        ReturnGrid.Columns["ItemID"].Visible = false;
                        ReturnGrid.Columns["TransactionID"].Visible = false;
                    }
                    else
                    {
                        FrmMessage.Show("No Records found !!!", caption, OkButton, InformationIcon);
                        SalesReturn form = new SalesReturn
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
            }
            catch (Exception ex)
            {
            }

        }

        private void TransGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ds = sqlhelp.ExecuteQueries("select * from TransFetch where TransactionNo='" + TransGrid.CurrentRow.Cells["TransactionNo"].Value + "' and CategoryID=" + TransGrid.CurrentRow.Cells["CategoryID"].Value + " and ItemID=" + TransGrid.CurrentRow.Cells["ItemID"].Value + "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RemainingQty"].ToString() != "0")
                {
                    if (dt.Columns.Count < 1)
                    {
                        dt.Columns.Add("TransactionID");
                        dt.Columns.Add("CategoryID");
                        dt.Columns.Add("Category");
                        dt.Columns.Add("ItemID");
                        dt.Columns.Add("Barcode");
                        dt.Columns.Add("Item");
                        dt.Columns.Add("Quantity");
                        dt.Columns.Add("Item Price");
                        dt.Columns.Add("Total Amount");
                    }
                    string ItemCode = "";
                    string TotalAmount = "";
                    string Qty = "";
                    dt.AcceptChanges();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Barcode"].ToString() == ds.Tables[0].Rows[0]["Barcode"].ToString())
                            {
                                    ItemCode = dt.Rows[i]["Barcode"].ToString();
                                    TotalAmount = "-" + Math.Round(((decimal.Parse(dt.Rows[i]["Quantity"].ToString()) * decimal.Parse(ds.Tables[0].Rows[0]["Item Price"].ToString())) - ((decimal.Parse(dt.Rows[i]["Quantity"].ToString()) * decimal.Parse(ds.Tables[0].Rows[0]["Item Price"].ToString())) * (decimal.Parse(lblDiscount.Text) / 100))), 2).ToString();
                                    Qty = dt.Rows[i]["Quantity"].ToString();
                                    break;
                                //}
                                ////else
                                ////{
                                //    ItemCode = ds.Tables[0].Rows[i]["Item Code"].ToString();
                                //    TotalAmount = "-" + Math.Round(((decimal.Parse(ds.Tables[0].Rows[i]["RemainingQty"].ToString()) * decimal.Parse(ds.Tables[0].Rows[i]["Item Price"].ToString())) - ((decimal.Parse(ds.Tables[0].Rows[i]["RemainingQty"].ToString()) * decimal.Parse(ds.Tables[0].Rows[i]["Item Price"].ToString())) * (decimal.Parse(ds.Tables[0].Rows[i]["DiscountAmount"].ToString()) / 100))), 2).ToString();
                                //    Qty = ds.Tables[0].Rows[0]["RemainingQty"].ToString();
                                //    break;
                                //}
                            }
                            else
                            {
                                    ItemCode = ds.Tables[0].Rows[0]["Barcode"].ToString();
                                    TotalAmount = "-" + Math.Round(((decimal.Parse(ds.Tables[0].Rows[0]["RemainingQty"].ToString()) * decimal.Parse(ds.Tables[0].Rows[0]["Item Price"].ToString())) - ((decimal.Parse(ds.Tables[0].Rows[0]["RemainingQty"].ToString()) * decimal.Parse(ds.Tables[0].Rows[0]["Item Price"].ToString())) * (decimal.Parse(ds.Tables[0].Rows[0]["DiscountAmount"].ToString()) / 100))), 2).ToString();
                                    Qty = ds.Tables[0].Rows[0]["RemainingQty"].ToString();                                
                            }
                        }
                    }
                    else
                    {
                            ItemCode = ds.Tables[0].Rows[0]["Barcode"].ToString();
                            TotalAmount = "-" + Math.Round(((decimal.Parse(ds.Tables[0].Rows[0]["RemainingQty"].ToString()) * decimal.Parse(ds.Tables[0].Rows[0]["Item Price"].ToString())) - ((decimal.Parse(ds.Tables[0].Rows[0]["RemainingQty"].ToString()) * decimal.Parse(ds.Tables[0].Rows[0]["Item Price"].ToString())) * (decimal.Parse(ds.Tables[0].Rows[0]["DiscountAmount"].ToString()) / 100))), 2).ToString();
                            Qty = ds.Tables[0].Rows[0]["RemainingQty"].ToString();                       
                    }


                    dt.Rows.Add(ds.Tables[0].Rows[0]["TransactionID"].ToString(), ds.Tables[0].Rows[0]["CategoryID"].ToString(), ds.Tables[0].Rows[0]["Category"].ToString(), ds.Tables[0].Rows[0]["ItemID"].ToString(), ItemCode, ds.Tables[0].Rows[0]["Item"].ToString(), Qty, ds.Tables[0].Rows[0]["Item Price"].ToString(), TotalAmount);
                    DataView dv = new DataView(dt);
                    dt = dv.ToTable(true, "TransactionID", "CategoryID", "Category", "ItemID", "Barcode", "Item", "Quantity", "Item Price", "Total Amount");
                    dt.AcceptChanges();
                    ReturnGrid.DataSource = dt;

                    ReturnGrid.Columns["CategoryID"].Visible = false;
                    ReturnGrid.Columns["ItemID"].Visible = false;
                    ReturnGrid.Columns["TransactionID"].Visible = false;

                    decimal TotalRefund = 0;
                    TotalActualAmount = 0;

                    for (int k = 0; k < (ReturnGrid.Rows.Count); k++)
                    {
                        //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                        TotalRefund = Math.Round((TotalRefund + (decimal.Parse(ReturnGrid.Rows[k].Cells["Total Amount"].Value.ToString()))), 2);
                        TotalActualAmount = Math.Round((TotalActualAmount + (decimal.Parse(ReturnGrid.Rows[k].Cells["Quantity"].Value.ToString()) * decimal.Parse(ReturnGrid.Rows[k].Cells["Item Price"].Value.ToString()))), 2);
                    }

                    txtTotalRefund.Text = TotalRefund.ToString();
                }
                else
                {
                    FrmMessage.Show(" This item is Already Returned");
                }
            }

        }

        private void ReturnGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewColumn dc in ReturnGrid.Columns)
            {
                if (dc.Index.Equals(6))
                {
                    dc.ReadOnly = false;
                }
                else
                {
                    dc.ReadOnly = true;
                }

            }
        }

        private void ReturnGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < TransGrid.Rows.Count; i++)
            {
                if (ReturnGrid.CurrentRow.Cells["Barcode"].Value.ToString() == TransGrid.Rows[i].Cells["Barcode"].Value.ToString())
                {
                    if (!string.IsNullOrEmpty(ReturnGrid.CurrentRow.Cells["Quantity"].Value.ToString()))
                    {
                        if (int.Parse(ReturnGrid.CurrentRow.Cells["Quantity"].Value.ToString()) > int.Parse(TransGrid.Rows[i].Cells["RemainingQty"].Value.ToString()))
                        {
                            FrmMessage.Show("Sorry! You have exceeded the max quantity for this item");
                            ReturnGrid.CurrentRow.Cells["Quantity"].Value = TransGrid.Rows[i].Cells["RemainingQty"].Value.ToString();
                            break;
                        }
                        else
                        {
                            ReturnGrid.CurrentRow.Cells["Total Amount"].Value = "-" + Math.Round((decimal.Parse(ReturnGrid.CurrentRow.Cells["Quantity"].Value.ToString()) * (decimal.Parse(ReturnGrid.CurrentRow.Cells["Item Price"].Value.ToString()) - (decimal.Parse(ReturnGrid.CurrentRow.Cells["Item Price"].Value.ToString()) * (decimal.Parse(lblDiscount.Text) / 100)))), 2).ToString();
                            break;
                        }
                    }
                    else
                    {
                        ReturnGrid.CurrentRow.Cells["Quantity"].Value = TransGrid.Rows[i].Cells["RemainingQty"].Value.ToString();
                        break;
                    }
                }
            }

            decimal TotalRefund = 0;
            TotalActualAmount = 0;

            for (int k = 0; k < (ReturnGrid.Rows.Count); k++)
            {
                //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                TotalRefund = Math.Round((TotalRefund + (decimal.Parse(ReturnGrid.Rows[k].Cells["Total Amount"].Value.ToString()))), 2);
                TotalActualAmount = Math.Round((TotalActualAmount + (decimal.Parse(ReturnGrid.Rows[k].Cells["Quantity"].Value.ToString()) * decimal.Parse(ReturnGrid.Rows[k].Cells["Item Price"].Value.ToString()))), 2);
            }


            txtTotalRefund.Text = TotalRefund.ToString();
        }

        private void ReturnGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
        }

        private void ReturnGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            decimal TotalRefund = 0;
            TotalActualAmount = 0;

            for (int k = 0; k < (ReturnGrid.Rows.Count); k++)
            {
                //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                TotalRefund = Math.Round((TotalRefund + (decimal.Parse(ReturnGrid.Rows[k].Cells["Total Amount"].Value.ToString()))), 2);
                TotalActualAmount = Math.Round((TotalActualAmount + (decimal.Parse(ReturnGrid.Rows[k].Cells["Quantity"].Value.ToString()) * decimal.Parse(ReturnGrid.Rows[k].Cells["Item Price"].Value.ToString()))), 2);
            }

            txtTotalRefund.Text = TotalRefund.ToString();
        }

        private void SalesReturn_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ReturnGrid.Rows.Count > 0)
            {


                bool result = false;
                sqlhelp = new SQLHelper();

                result = sqlhelp.ExecuteNonQuery("insert into Payment(TransactionNo,TotalAmount,DiscountAmount,BillPaid,CreatedBy) values" +
                                         "('" + lblBillNo.Text + "'," + "-" + TotalActualAmount + "," + lblDiscount.Text + "," + txtTotalRefund.Text + "," + GlobalData.UserID + ")");
                if (result == true)
                {

                    string PaymentId = sqlhelp.ExecuteScalar("select max(PaymentID) from Payment");
                    for (int i = 0; i < ReturnGrid.Rows.Count; i++)
                    {
                        result = sqlhelp.ExecuteNonQuery("Update Transactions set ReturnQty= ((ReturnQty) + (" + int.Parse("-" + ReturnGrid.Rows[i].Cells["Quantity"].Value.ToString()) + ")) where TransactionID=" + ReturnGrid.Rows[i].Cells["TransactionID"].Value.ToString() + "");
                        result = sqlhelp.ExecuteNonQuery("Insert into Transactions(PaymentID,CategoryID,ItemID,Barcode,ItemPrice,SaleQty,ReturnQty,CreatedBy) Values" +
                                                         "(" + PaymentId + "," +
                                                         "" + ReturnGrid.Rows[i].Cells["CategoryID"].Value.ToString() + "," +
                                                         "" + ReturnGrid.Rows[i].Cells["ItemID"].Value.ToString() + "," +
                                                         "'" + ReturnGrid.Rows[i].Cells["Barcode"].Value.ToString() + "'," +
                                                         "" + ReturnGrid.Rows[i].Cells["Item Price"].Value.ToString() + "," +
                                                         "" + int.Parse("-" + ReturnGrid.Rows[i].Cells["Quantity"].Value.ToString()) + "," +
                                                         "" + int.Parse(ReturnGrid.Rows[i].Cells["Quantity"].Value.ToString()) + "," +
                                                         "" + GlobalData.UserID + ")");
                        result = sqlhelp.ExecuteNonQuery("update Stock set StockQuantity= (StockQuantity+" + int.Parse(ReturnGrid.Rows[i].Cells["Quantity"].Value.ToString()) + ")" +
                                                         " where CategoryID=" + ReturnGrid.Rows[i].Cells["CategoryID"].Value.ToString() + "" +
                                                         " and ItemID=" + ReturnGrid.Rows[i].Cells["ItemID"].Value.ToString() + " and Barcode='" + ReturnGrid.Rows[i].Cells["Barcode"].Value.ToString() + "'");

                    }
                }
                if (result == true)
                {
                    FrmMessage.Show("Refund Transaction Successful", caption, OkButton, InformationIcon);
                    SalesReturn f2 = new SalesReturn
                    {
                        MdiParent = this.MdiParent,
                        Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right))),
                        Dock = DockStyle.Fill
                    };
                    f2.Show();
                }
            }
            else
            {
                FrmMessage.Show("Please select the Items which you want to return");
            }
        }

        private void SalesReturn_Load(object sender, EventArgs e)
        {           
            AutoSuggestTransaction();
        }

    }
}
