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
    
    public partial class PurchaseStockAdjist : Form
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

        SQLHelper sqlhelp = new SQLHelper();
        int[] a = new int[100];
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        string BarcodeSt = "";
        string MBarcodeSt = "";

        string ddlSrchCat;
        string ddlSrchitem;
        int stockId;
        int stockId1;
        int stockId2;
        int StockHId;
        int searchid;

        public PurchaseStockAdjist()
        {
            InitializeComponent();
        }

        private void PurchaseStockAdjist_Load(object sender, EventArgs e)
        {
            textBox7.Text = "0";
            //button1.Visible = true;
            sqlhelp = new SQLHelper();
            ds2 = new DataSet();
            ds2 = sqlhelp.ExecuteQueries("select * from Supplier");
            if (ds2.Tables[0].Rows.Count > 0)
            {
                DataRow DR = ds2.Tables[0].NewRow();
                DR["SupplierName"] = "Select";
                DR["SupplierId"] = 0;
                ds2.Tables[0].Rows.InsertAt(DR, 0);
                ddlsrchSupp.DisplayMember = "SupplierName";
                ddlsrchSupp.ValueMember = "SupplierId";
              ddlsrchSupp.DataSource = ds2.Tables[0];
            }

            DataTable dt = new DataTable();
            dt = sqlhelp.ExecuteTables("select * from Categories");
            if (dt.Rows.Count > 0)
            {
                DataRow dr1 = dt.NewRow();
                dr1["CategoryName"] = "Select";
                dt.Rows.InsertAt(dr1, 0);
               ddlSrchCategory.DisplayMember = "CategoryName";
               ddlSrchCategory.ValueMember = "CategoryID";
               ddlSrchCategory.DataSource = dt;
            }

            AutoSuggestItemns();
        }

        private void AutoSuggestItemns()
        {
            sqlhelp = new SQLHelper();
            ds = sqlhelp.ExecuteQueries("select ItemName from SupplierOrder");

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["ItemName"].ToString());
            }
            textBox6.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox6.AutoCompleteCustomSource = col;
            textBox6.AutoCompleteMode = AutoCompleteMode.Suggest;
            
           
        }
        private void ddlSrchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select * from SupplierOrder");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow DR = ds.Tables[0].NewRow();
                DR["ItemName"] = "Select";
                DR["POID"] = 0;
                ds.Tables[0].Rows.InsertAt(DR, 0);
                ddlSrchItems.DisplayMember = "ItemName";
                ddlSrchItems.ValueMember = "POID";
                ddlSrchItems.DataSource = ds.Tables[0];
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            textBox7.Text = "0";
            try
            {
                searchid = 0;
                StockGrid.Visible = true;
                ds = new DataSet();
                StockGrid.DataSource = null;
                StockGrid.Columns.Clear();
                sqlhelp = new SQLHelper();
                string srchBarcode = "";

               

                string wherecondition = "CategoryID like " + ddlSrchCategory.SelectedValue + "" +
                                        " and SupplierID like " + ddlsrchSupp.SelectedValue + " and ItemName Like '" + ddlSrchItems.Text +"'";
                                        
                ds = sqlhelp.ExecuteQueries("Select * from SupplierOrder where " + wherecondition + "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    StockGrid.DataSource = ds.Tables[0];
                    StockGrid.Columns["POID"].Visible = false;
                    StockGrid.Columns["CategoryID"].Visible = false;
                    StockGrid.Columns["SupplierID"].Visible = false;
                    StockGrid.Columns["ReceivedDate"].Visible = false;
                    StockGrid.Columns["TotalAmount"].Visible = false;
                    DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
                    btnUpdate.HeaderText = "Split Quantity";
                    btnUpdate.Text = "Split Quantity";
                    btnUpdate.UseColumnTextForButtonValue = true;
                    btnUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    btnUpdate.FlatStyle = FlatStyle.Standard;
                    btnUpdate.CellTemplate.Style.BackColor = Color.Honeydew;
                    StockGrid.Columns.Add(btnUpdate);
                }
                else
                {
                    StockGrid.DataSource = ds.Tables[0];
                    StockGrid.Columns["POID"].Visible = false;
                    StockGrid.Columns["CategoryID"].Visible = false;
                    StockGrid.Columns["SupplierID"].Visible = false;
                    FrmMessage.Show("No records Found!!!", caption, OkButton, InformationIcon);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void StockGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                stockId = int.Parse(StockGrid.CurrentRow.Cells["POID"].Value.ToString());
                string wherecondition = "CategoryID like " + ddlSrchCategory.SelectedValue + "" +
                                        " and SupplierID like " + ddlsrchSupp.SelectedValue + " and POID Like '" + stockId + "'";

                ds = sqlhelp.ExecuteQueries("Select * from ItemSplit where " + wherecondition + "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    FrmMessage.Show("This Item Has Already Splited, You Can not split this item Again !!");
                }
                else
                {
                    stockId = int.Parse(StockGrid.CurrentRow.Cells["POID"].Value.ToString());
                    stockId1 = int.Parse(StockGrid.CurrentRow.Cells["SupplierID"].Value.ToString());
                    stockId2 = int.Parse(StockGrid.CurrentRow.Cells["CategoryID"].Value.ToString());

                    txtSrchBarcode.Text = StockGrid.CurrentRow.Cells["ItemName"].Value.ToString();
                    textBox1.Text = StockGrid.CurrentRow.Cells["QTY"].Value.ToString();
                    textBox5.Text = StockGrid.CurrentRow.Cells["QtyType"].Value.ToString();
                }
            }
               
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox3.Text) || !string.IsNullOrEmpty(textBox2.Text) || !string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox4.Text = Math.Round((decimal.Parse(textBox2.Text) * decimal.Parse(textBox3.Text)), 2).ToString();
                    textBox7.Text = Math.Round((decimal.Parse(textBox4.Text) - decimal.Parse(textBox7.Text)), 2).ToString();

                }
                else
                {
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) || string.IsNullOrEmpty(textBox2.Text.Trim()) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(txtSrchBarcode.Text) || ddlsrchSupp.SelectedIndex == 0)
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
            }
            else
            {

                foreach (DataGridViewRow dr in GridStockPurchase.Rows)
                {
                    Int32 ITEMID = 0;
                    //int Count = int.Parse(sqlhelp.ExecuteScalar("select count(ItemName) from SupplierOrder where ItemName='" + dr.Cells["Item Name"].Value.ToString() + "' and CategoryID=" + ddlSrchCategory.SelectedValue + " and SupplierID=" + ddlsrchSupp.SelectedValue + ""));
                    //if (Count > 0)
                    {
                        result = sqlhelp.ExecuteNonQuery("insert into ITEMSPLIT (POID,SUPPLIERID,CATEGORYID,ITEMNAME,QTY,QTYTYPE,SPLITTONOOFPACK,EACHPACK,SHORTOFF) " +
                                "values(" + stockId + "," + stockId1 + ",'" + stockId2 + "','" + dr.Cells["Item Name"].Value.ToString() + "'," + textBox1.Text + ",'" + textBox5.Text + "','" + dr.Cells["Packs"].Value.ToString() + "','" + dr.Cells["Weight"].Value.ToString() + "','" + dr.Cells["Total Weight"].Value.ToString() + "')");



                    }

                }



                //sqlhelp = new SQLHelper();
                //result = sqlhelp.ExecuteNonQuery("insert into ITEMSPLIT(POID,SUPPLIERID,CATEGORYID,ITEMNAME,QTY,QTYTYPE,SPLITTONOOFPACK,EACHPACK,SHORTOFF) values" +
                //                                 "(" + stockId + "," + stockId1 + "," + stockId2 + ",'" + txtSrchBarcode.Text + "','" + textBox1.Text + "','" + textBox5.Text + "'," + textBox2.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "')");



                if (result == true)
                {
                    FrmMessage.Show("Transaction Success");
                    StockGrid.DataSource = null;
                    StockGrid.Columns.Clear();

                    GridStockPurchase.DataSource = null;
                    GridStockPurchase.Columns.Clear();
                    txtSrchBarcode.Text = string.Empty;
                    textBox1.Text = "0";
                    textBox5.Text = string.Empty;
                    textBox2.Text = "0";
                    textBox3.Text = "0";
                    textBox4.Text = "0";
                    textBox7.Text = "0";

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox7.Text = "0";
            try
            {
                searchid = 0;
                StockGrid.Visible = true;
                ds = new DataSet();
                StockGrid.DataSource = null;
                StockGrid.Columns.Clear();
                sqlhelp = new SQLHelper();
                string srchBarcode = "";



                //string wherecondition = "ItemName Like '" + textBox6.Text + "'";
                string wherecondition = "CategoryID like " + ddlSrchCategory.SelectedValue + "" +
                                        " and SupplierID like " + ddlsrchSupp.SelectedValue + " and ItemName Like '" + textBox6.Text + "'";
               
                ds = sqlhelp.ExecuteQueries("Select * from SupplierOrder where " + wherecondition + "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    StockGrid.DataSource = ds.Tables[0];
                    StockGrid.Columns["POID"].Visible = false;
                    StockGrid.Columns["CategoryID"].Visible = false;
                    StockGrid.Columns["SupplierID"].Visible = false;
                    StockGrid.Columns["ReceivedDate"].Visible = false;
                    StockGrid.Columns["TotalAmount"].Visible = false;
                    DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
                    btnUpdate.HeaderText = "Split Quantity";
                    btnUpdate.Text = "Split Quantity";
                    btnUpdate.UseColumnTextForButtonValue = true;
                    btnUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    btnUpdate.FlatStyle = FlatStyle.Standard;
                    btnUpdate.CellTemplate.Style.BackColor = Color.Honeydew;
                    StockGrid.Columns.Add(btnUpdate);
                }
                else
                {
                    StockGrid.DataSource = ds.Tables[0];
                    StockGrid.Columns["POID"].Visible = false;
                    StockGrid.Columns["CategoryID"].Visible = false;
                    StockGrid.Columns["SupplierID"].Visible = false;
                    FrmMessage.Show("No records Found!!!", caption, OkButton, InformationIcon);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        DataTable dtStockList = new DataTable();
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSrchBarcode.Text.Trim()) || string.IsNullOrEmpty(textBox2.Text.Trim()) || string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
            }
            else
            {
                if (dtStockList.Columns.Count == 0)
                {
                    dtStockList.Columns.Add("Item Name");
                    dtStockList.Columns.Add("Packs");
                    dtStockList.Columns.Add("Weight");
                    dtStockList.Columns.Add("Total Weight");
                }

                bool AlreadyAddedd = false;

                foreach (DataRow dr in dtStockList.Rows)
                {
                    if (dr["Weight"].ToString() == textBox3.Text.Trim())
                        AlreadyAddedd = true;
                }
                if (AlreadyAddedd == true)
                {
                    FrmMessage.Show("This Weight is already added to list for the selected Item");
                }
                else
                {
                    
                    dtStockList.Rows.Add(txtSrchBarcode.Text.Trim(),textBox2.Text.Trim(),
                       textBox3.Text,textBox4.Text.Trim());
                    dtStockList.AcceptChanges();
                    GridStockPurchase.DataSource = dtStockList;
                    decimal pric = 0;
                    decimal vatAmount = 0;
                    for (int k = 0; k < (GridStockPurchase.Rows.Count); k++)
                    {
                        GridStockPurchase.Columns[k].SortMode = DataGridViewColumnSortMode.NotSortable;
                        //pric = Math.Round((pric + (decimal.Parse(GridStockPurchase.Rows[k].Cells["Total"].Value.ToString()))), 2);
                        //vatAmount = Math.Round((vatAmount + (decimal.Parse(GridStockPurchase.Rows[k].Cells["Total"].Value.ToString())) * (decimal.Parse(GridStockPurchase.Rows[k].Cells["Vat %"].Value.ToString()) / 100)), 2);
                    }
                    //txtVatAmount.Text = vatAmount.ToString();
                    //txtSubTotal.Text = pric.ToString();
                    //clear();
                    textBox2.Text = "0";
                    textBox3.Text = "0";

                }

            }

        }

       
    }
}
