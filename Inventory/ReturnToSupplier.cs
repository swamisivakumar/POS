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
    public partial class ReturnToSupplier : Form
    {
        SQLHelper sqlhelp = new SQLHelper();
        DataTable dtTran = new DataTable();
        DataTable dtTran1 = new DataTable();
        DataTable dtReturnSale = new DataTable();
        DataTable dtReturnSale1 = new DataTable();
        #region global Declaration for custom messagebox
        FrmMessage.enumMessageIcon InformationIcon = FrmMessage.enumMessageIcon.Information;
        FrmMessage.enumMessageIcon QuestionIcon = FrmMessage.enumMessageIcon.Question;
        FrmMessage.enumMessageIcon ErrorIcon = FrmMessage.enumMessageIcon.Error;
        FrmMessage.enumMessageButton OkButton = FrmMessage.enumMessageButton.OK;
        FrmMessage.enumMessageButton YesNoButton = FrmMessage.enumMessageButton.YesNo;
        string caption = "Inventory Management";
        #endregion
        public ReturnToSupplier()
        {
            InitializeComponent();
        }

        private void ReturnToSupplier_Load(object sender, EventArgs e)
        {
            try
            {
                FillSuppliers(ddlsrchsupp);
                FillSuppliers(comboBox1);
                groupBox4.Visible = true;
                groupBox2.Visible = false;
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void FillSuppliers(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt = sqlhelp.ExecuteTables("select cstr(SupplierID) as [SUPPID] ,SupplierName from Supplier");
            DataRow dr = dt.NewRow();
            dr["SUPPID"] = "%";
            dr["SupplierName"] = "Select";
            dt.Rows.InsertAt(dr, 0);
            cmb.DisplayMember = "SupplierName";
            cmb.ValueMember = "SUPPID";
            cmb.DataSource = dt;
        }
        //private void FillSuppliers1(ComboBox cmb)
        //{
        //    DataTable dt = new DataTable();
        //    dt = sqlhelp.ExecuteTables("select cstr(SupplierID) as [SUPPID] ,SupplierName from Supplier");
        //    DataRow dr = dt.NewRow();
        //    dr["SUPPID"] = "%";
        //    dr["SupplierName"] = "Select";
        //    dt.Rows.InsertAt(dr, 0);
        //    cmb.DisplayMember = "SupplierName";
        //    cmb.ValueMember = "SUPPID";
        //    cmb.DataSource = dt;
        //}
        private void FillSrchCategories(ComboBox cmb, string SupID)
        {
            DataTable dt = new DataTable();
            dt = sqlhelp.ExecuteTables("select Distinct cstr(S.CategoryID) as [CatID],C.CategoryName from Categories C,Stock S where " +
                                       "S.CategoryID=C.CategoryID and S.SupplierID like'" + SupID + "'");
            DataRow dr = dt.NewRow();
            dr["CatID"] = "%";
            dr["CATEGORYNAME"] = "Select";
            dt.Rows.InsertAt(dr, 0);
            cmb.DisplayMember = "CATEGORYNAME";
            cmb.ValueMember = "CatID";
            cmb.DataSource = dt;
        }

        private void FillItems(ComboBox cmb, string SupID, string CatID)
        {
            DataTable dt = new DataTable();
            dt = sqlhelp.ExecuteTables("select distinct cstr(S.ItemID) as [ITEMID],I.ITEMNAME from Stock S, Items I where S.ItemID=I.ItemID and " +
                "S.SupplierID=I.SupplierID and S.CategoryID=I.CategoryID and S.SUPPLIERID like'" + SupID + "' and S.CategoryID like'" + CatID + "'");
            DataRow dr = dt.NewRow();
            dr["ITEMID"] = "%";
            dr["ITEMNAME"] = "Select";
            dt.Rows.InsertAt(dr, 0);
            cmb.DisplayMember = "ITEMNAME";
            cmb.ValueMember = "ITEMID";
            cmb.DataSource = dt;
        }

        private void ddlsrchsupp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlsrchsupp.SelectedIndex != 0)
                {
                    FillSrchCategories(ddlSrchCat, ddlsrchsupp.SelectedValue.ToString());
                }
                else
                {
                    FillSrchCategories(ddlSrchCat, "0");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void ddlSrchCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSrchCat.SelectedIndex != 0)
                {
                    FillItems(ddlsrchitem, ddlsrchsupp.SelectedValue.ToString(), ddlSrchCat.SelectedValue.ToString());
                }
                else
                {
                    FillItems(ddlsrchitem, "0", "0");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void btnSrchItems_Click(object sender, EventArgs e)
        {
            try
            {
                dtTran = new DataTable();
                dtTran1 = new DataTable();

                dtTran = sqlhelp.ExecuteTables("Select GS.*,(SH.InvoiceAmount/SH.Qty) as [ItemPrice] from GetStock GS, StockHistory SH where GS.StockID=SH.StockID and GS.SupplierID like'" + ddlsrchsupp.SelectedValue + "' and GS.CategoryID like'" + ddlSrchCat.SelectedValue + "' and GS.ItemID like'" + ddlsrchitem.SelectedValue + "'");
                if (dtTran.Rows.Count > 0)
                {
                    dtTran1 = sqlhelp.ExecuteTables("Select * from ItemSplit where SupplierID like'" + ddlsrchsupp.SelectedValue + "' and CategoryID like'" + ddlSrchCat.SelectedValue + "' and ItemName ='" + ddlsrchitem.Text + "'");
                    if (dtTran1.Rows.Count > 0)
                    {
                        FrmMessage.Show("You can not return this Item, Beacuse This Item Has Splited to lesser Qty !!!");
                    }
                    else
                    {

                        TransGrid.DataSource = dtTran;
                        TransGrid.Columns["ItemPrice"].HeaderText = "Item Price";
                        TransGrid.Columns["StockID"].Visible = false;
                        TransGrid.Columns["SupplierID"].Visible = false;
                        TransGrid.Columns["ItemID"].Visible = false;
                        TransGrid.Columns["CategoryID"].Visible = false;
                        TransGrid.Columns["ImageName"].Visible = false;
                        TransGrid.Columns["ReOrder Qty"].Visible = false;
                        TransGrid.Columns["StockDescription"].Visible = false;
                    }
                }
                else
                {
                    FrmMessage.Show("No Records Found !!!");
                    ReturnToSupplier rtnStock = new ReturnToSupplier
                    {
                        MdiParent = this,
                        Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right))),
                        Dock = DockStyle.Fill
                    };

                    rtnStock.Show();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        decimal TotalActualAmount;

        private void TransGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable dtTransact = new DataTable();
                dtTransact = dtTran;
                DataView dv1 = new DataView(dtTransact);
                dv1.RowFilter = "StockID=" + TransGrid.CurrentRow.Cells["StockID"].Value + " and SupplierID='" + TransGrid.CurrentRow.Cells["SUPPLIERID"].Value + "' and CategoryID=" + TransGrid.CurrentRow.Cells["CategoryID"].Value + " and ItemID=" + TransGrid.CurrentRow.Cells["ITEMID"].Value + " and Barcode='" + TransGrid.CurrentRow.Cells["Barcode"].Value + "'";
                dtTransact = dv1.ToTable();

                if (dtTransact.Rows[0]["Quantity"].ToString() != "0")
                {
                    if (dtReturnSale.Columns.Count < 1)
                    {
                        dtReturnSale.Columns.Add("StockID");
                        dtReturnSale.Columns.Add("SupplierID");
                        dtReturnSale.Columns.Add("Supplier");
                        dtReturnSale.Columns.Add("CategoryID");
                        dtReturnSale.Columns.Add("Category");
                        dtReturnSale.Columns.Add("ItemID");
                        dtReturnSale.Columns.Add("Item");
                        dtReturnSale.Columns.Add("Barcode");
                        dtReturnSale.Columns.Add("Quantity");
                        dtReturnSale.Columns.Add("Item Price");
                        dtReturnSale.Columns.Add("Total Amount");
                    }

                    string TotalAmount = "";
                    string Qty = "";

                    dtReturnSale.AcceptChanges();
                    if (dtReturnSale.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtReturnSale.Rows.Count; i++)
                        {
                            if (dtReturnSale.Rows[i]["StockID"].ToString() == dtTransact.Rows[0]["StockID"].ToString())
                            {
                                TotalAmount = "" + Math.Round(((decimal.Parse(dtReturnSale.Rows[i]["Quantity"].ToString()) * decimal.Parse(TransGrid.CurrentRow.Cells["ItemPrice"].Value.ToString()))), 2).ToString();
                                Qty = dtReturnSale.Rows[i]["Quantity"].ToString();
                                break;
                            }
                            else
                            {
                                TotalAmount = "" + Math.Round(((decimal.Parse(dtTransact.Rows[0]["Quantity"].ToString()) * decimal.Parse(dtTransact.Rows[0]["ItemPrice"].ToString()))), 2).ToString();
                                Qty = dtTransact.Rows[0]["Quantity"].ToString();
                            }
                        }
                    }
                    else
                    {
                        TotalAmount = "" + Math.Round(((decimal.Parse(dtTransact.Rows[0]["Quantity"].ToString()) * decimal.Parse(dtTransact.Rows[0]["ItemPrice"].ToString()))), 2).ToString();
                        Qty = dtTransact.Rows[0]["Quantity"].ToString();
                    }
                    dtReturnSale.Rows.Add(dtTransact.Rows[0]["StockID"].ToString(), dtTransact.Rows[0]["SupplierID"].ToString(), dtTransact.Rows[0]["SupplierName"].ToString(), dtTransact.Rows[0]["CategoryID"].ToString(), dtTransact.Rows[0]["CategoryName"].ToString(), dtTransact.Rows[0]["ItemID"].ToString(), dtTransact.Rows[0]["ItemName"].ToString(), dtTransact.Rows[0]["Barcode"].ToString(), Qty, dtTransact.Rows[0]["ItemPrice"].ToString(), TotalAmount);
                    DataView dv = new DataView(dtReturnSale);
                    dtReturnSale = dv.ToTable(true, "StockID", "SupplierID", "Supplier", "CategoryID", "Category", "ItemID", "Item", "Barcode", "Quantity", "Item Price", "Total Amount");
                    dtReturnSale.AcceptChanges();
                    ReturnGrid.DataSource = dtReturnSale;
                    foreach (DataGridViewColumn dc in ReturnGrid.Columns)
                    {
                        if (dc.Index.Equals(8))
                        {
                            dc.ReadOnly = false;
                        }
                        else
                        {
                            dc.ReadOnly = true;
                        }

                    }
                    ReturnGrid.Columns["SupplierID"].Visible = false;
                    ReturnGrid.Columns["CategoryID"].Visible = false;
                    ReturnGrid.Columns["ItemID"].Visible = false;
                    ReturnGrid.Columns["StockID"].Visible = false;

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
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void ReturnGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < TransGrid.Rows.Count; i++)
                {
                    if (ReturnGrid.CurrentRow.Cells["StockID"].Value.ToString() == TransGrid.Rows[i].Cells["StockID"].Value.ToString())
                    {
                        if (!string.IsNullOrEmpty(ReturnGrid.CurrentRow.Cells["Quantity"].Value.ToString()))
                        {
                            if (double.Parse(ReturnGrid.CurrentRow.Cells["Quantity"].Value.ToString()) > double.Parse(TransGrid.Rows[i].Cells["Quantity"].Value.ToString()) || int.Parse(ReturnGrid.CurrentRow.Cells["Quantity"].Value.ToString()) == 0)
                            {
                                FrmMessage.Show("Quanity should be between 1 and max quantity " + TransGrid.Rows[i].Cells["Quantity"].Value.ToString());
                                ReturnGrid.CurrentRow.Cells["Quantity"].Value = TransGrid.Rows[i].Cells["Quantity"].Value.ToString();
                                break;
                            }
                            else
                            {
                                ReturnGrid.CurrentRow.Cells["Total Amount"].Value = "" + Math.Round((decimal.Parse(ReturnGrid.CurrentRow.Cells["Quantity"].Value.ToString()) * (decimal.Parse(ReturnGrid.CurrentRow.Cells["Item Price"].Value.ToString()))), 2).ToString();
                                break;
                            }
                        }
                        else
                        {
                            ReturnGrid.CurrentRow.Cells["Quantity"].Value = TransGrid.Rows[i].Cells["Available Quantity"].Value.ToString();
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
            catch (Exception ex)
            {
            }
            finally
            {
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

        private void ReturnGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                if (e.Control is TextBox) //If it is a DataGridViewTextBoxCell
                {
                    (e.Control as TextBox).MaxLength = 8; //Set the MaxLength to 4
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ReturnGrid.Rows.Count == 0 || TransGrid.Rows.Count == 0)
                {
                    FrmMessage.Show("No items were selected for return.");
                }
                else if (string.IsNullOrEmpty(txtReason.Text.Trim()))
                {
                    FrmMessage.Show("Please Enter the reason for return.");
                }
                else
                {
                    if (DialogResult.Yes == FrmMessage.Show("Are You Sure You want to return these items.", caption, YesNoButton, QuestionIcon))
                    {

                        bool result = false;
                        for (int i = 0; i < ReturnGrid.Rows.Count; i++)
                        {
                            result = sqlhelp.ExecuteNonQuery("insert into RETURNTOSUPPLIER (StockID,SUPPLIERID,CATEGORYID,ITEMID,Barcode,RETURNQTY,ITEMPRICE,TOTALAMOUNT,Reason,CREATEDBY) Values " +
                                "(" + ReturnGrid.Rows[i].Cells["StockID"].Value.ToString() + "," + ReturnGrid.Rows[i].Cells["SupplierID"].Value.ToString() + "," + ReturnGrid.Rows[i].Cells["CategoryID"].Value.ToString() + "," +
                                "" + ReturnGrid.Rows[i].Cells["ItemID"].Value.ToString() + ",'" + ReturnGrid.Rows[i].Cells["Barcode"].Value.ToString() + "'," + ReturnGrid.Rows[i].Cells["Quantity"].Value.ToString() + "," +
                                "" + ReturnGrid.Rows[i].Cells["Item Price"].Value.ToString() + "," + ReturnGrid.Rows[i].Cells["Total Amount"].Value.ToString() + ",'" + txtReason.Text.Trim() + "'," + GlobalData.UserID + ")");

                            result = sqlhelp.ExecuteNonQuery("update Stock set StockQuantity= (StockQuantity-" + int.Parse(ReturnGrid.Rows[i].Cells["Quantity"].Value.ToString()) + ")" +
                                                                 " where SUPPLIERID=" + ReturnGrid.Rows[i].Cells["SupplierID"].Value.ToString() + " and CATEGORYID=" + ReturnGrid.Rows[i].Cells["CategoryID"].Value.ToString() + "" +
                                                                 " and ITEMID=" + ReturnGrid.Rows[i].Cells["ItemID"].Value.ToString() + " and StockID=" + ReturnGrid.Rows[i].Cells["StockID"].Value.ToString() + "");
                        }
                        if (result == true)
                        {
                            FrmMessage.Show("Returned Items to Supplier Successfully");
                            ReturnToSupplier form = new ReturnToSupplier
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
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void ReturnToSupplier_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void btnTbSearch_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox2.Visible = false;
        }

        private void btnTbAdd_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            groupBox2.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = sqlhelp.ExecuteTables("select Distinct cstr(S.CategoryID) as [CatID],C.CategoryName from Categories C,Stock S where " +
                                       "S.CategoryID=C.CategoryID and S.SupplierID like'" + comboBox2.SelectedValue + "'");
            DataRow dr = dt.NewRow();
            dr["CatID"] = "%";
            dr["CATEGORYNAME"] = "Select";
            dt.Rows.InsertAt(dr, 0);
           comboBox2.DisplayMember = "CATEGORYNAME";
           comboBox2.ValueMember = "CatID";
           comboBox2.DataSource = dt;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = sqlhelp.ExecuteTables("select POID,ITEMNAME from SupplierOrder where SUPPLIERID like'" + comboBox1.SelectedValue + "' and CategoryID like'" + comboBox2.SelectedValue + "'");
            DataRow dr = dt.NewRow();
            dr["POID"] = "0";
            dr["ITEMNAME"] = "Select";
            dt.Rows.InsertAt(dr, 0);
           comboBox3.DisplayMember = "ITEMNAME";
           comboBox3.ValueMember = "POID";
           comboBox3.DataSource = dt;
        }

        DataTable dtTran2 = new DataTable();
        DataTable dtTran3 = new DataTable();

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dtTran2 = new DataTable();
               // dtTran3 = new DataTable();

                dtTran2 = sqlhelp.ExecuteTables("Select * from ReturnItemSupplier where SupplierId like " + comboBox1.SelectedValue + " and CategoryID like " +comboBox2.SelectedValue + " and ItemName like'" + comboBox3.Text + "'");
                if (dtTran2.Rows.Count > 0)
                {

                    dataGridView1.DataSource = dtTran2;
                    //dataGridView1.Columns["ItemPrice"].HeaderText = "Item Price";
                    dataGridView1.Columns["POID"].Visible = false;
                    dataGridView1.Columns["SupplierID"].Visible = false;
                    dataGridView1.Columns["CategoryID"].Visible = false;
                    dataGridView1.Columns["InvoiceNo"].HeaderText = "Invoice No";
                    dataGridView1.Columns["InvoiceDate"].HeaderText = "Invoice Date";
                    dataGridView1.Columns["ItemName"].HeaderText = "Item Name";
                    dataGridView1.Columns["UnitPrice"].HeaderText = "Item Price";
                    dataGridView1.Columns["Qty"].HeaderText = "Qty";
                    dataGridView1.Columns["QtyType"].HeaderText = "Qty Type";
                    dataGridView1.Columns["VatPercentage"].HeaderText = "VAT %";
                    dataGridView1.Columns["TotalAmount"].HeaderText = "Total Amount";
                    dataGridView1.Columns["AfterVat"].HeaderText = "Inc VAT Amount";
                    dataGridView1.Columns["createddate"].HeaderText = "Invoice Date";


                    
                }
                else
                {
                    FrmMessage.Show("No Records Found !!!");
                    
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

       

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable dtTransact = new DataTable();
                dtTransact = dtTran2;
                DataView dv1 = new DataView(dtTransact);
                dv1.RowFilter = "POID=" + dataGridView1.CurrentRow.Cells["POID"].Value + " and SupplierID='" + dataGridView1.CurrentRow.Cells["SUPPLIERID"].Value + "' and CategoryID=" + dataGridView1.CurrentRow.Cells["CategoryID"].Value + " and ItemName='" + dataGridView1.CurrentRow.Cells["ItemName"].Value + "'";
                dtTransact = dv1.ToTable();

                if (dtTransact.Rows[0]["Qty"].ToString() != "0")
                {
                    if (dtReturnSale1.Columns.Count < 1)
                    {
                        dtReturnSale1.Columns.Add("POID");
                        dtReturnSale1.Columns.Add("SupplierID");
                        dtReturnSale1.Columns.Add("CategoryID");
                        dtReturnSale1.Columns.Add("ItemName");
                        dtReturnSale1.Columns.Add("Qty");
                        dtReturnSale1.Columns.Add("Vat%");
                        dtReturnSale1.Columns.Add("UnitPrice");
                        dtReturnSale1.Columns.Add("BeforeVat");
                        dtReturnSale1.Columns.Add("AfterVat");
                    }

                    string TotalAmount = "";
                    string TotalAmount1 = "";
                    string Qty = "";

                    dtReturnSale1.AcceptChanges();
                    if (dtReturnSale1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtReturnSale1.Rows.Count; i++)
                        {
                            if (dtReturnSale1.Rows[i]["POID"].ToString() == dtTransact.Rows[0]["POID"].ToString())
                            {
                                TotalAmount = Math.Round(((decimal.Parse(dtReturnSale1.Rows[i]["Qty"].ToString()) * decimal.Parse(dataGridView1.CurrentRow.Cells["UnitPrice"].Value.ToString())) * (decimal.Parse(dataGridView1.CurrentRow.Cells["VatPercentage"].Value.ToString()) / 100)), 2).ToString();
                                Qty = dtReturnSale1.Rows[i]["Qty"].ToString();
                                TotalAmount1 = Math.Round(((decimal.Parse(dtReturnSale1.Rows[i]["Qty"].ToString()) * decimal.Parse(dataGridView1.CurrentRow.Cells["UnitPrice"].Value.ToString()))), 2).ToString();
                                break;
                            }
                            else
                            {
                                TotalAmount = Math.Round(((decimal.Parse(dtTransact.Rows[0]["Qty"].ToString()) * decimal.Parse(dtTransact.Rows[0]["UnitPrice"].ToString())) * (decimal.Parse(dtTransact.Rows[0]["VatPercentage"].ToString()) / 100)), 2).ToString();
                                Qty = dtTransact.Rows[0]["Qty"].ToString();
                                TotalAmount1 = Math.Round(((decimal.Parse(dtTransact.Rows[0]["Qty"].ToString()) * decimal.Parse(dtTransact.Rows[0]["UnitPrice"].ToString()))), 2).ToString();
                            }
                        }
                    }
                    else
                    {
                        TotalAmount = Math.Round(((decimal.Parse(dtTransact.Rows[0]["Qty"].ToString()) * decimal.Parse(dtTransact.Rows[0]["UnitPrice"].ToString())) + (decimal.Parse(dtTransact.Rows[0]["Qty"].ToString()) * decimal.Parse(dtTransact.Rows[0]["UnitPrice"].ToString())) * (decimal.Parse(dtTransact.Rows[0]["VatPercentage"].ToString()) / 100)), 2).ToString();
                        Qty = dtTransact.Rows[0]["Qty"].ToString();
                        TotalAmount1 = Math.Round(((decimal.Parse(dtTransact.Rows[0]["Qty"].ToString()) * decimal.Parse(dtTransact.Rows[0]["UnitPrice"].ToString()))), 2).ToString();
                    }
                    dtReturnSale1.Rows.Add(dtTransact.Rows[0]["POID"].ToString(), dtTransact.Rows[0]["SupplierID"].ToString(), dtTransact.Rows[0]["CategoryID"].ToString(), dtTransact.Rows[0]["ItemName"].ToString(), Qty,dtTransact.Rows[0]["VatPercentage"].ToString(), dtTransact.Rows[0]["UnitPrice"].ToString(),TotalAmount1, TotalAmount);
                    DataView dv = new DataView(dtReturnSale1);
                    dtReturnSale1 = dv.ToTable(true, "POID", "SupplierID", "CategoryID", "ItemName", "Qty","Vat%", "UnitPrice", "BeforeVAT", "AfterVat");
                    dtReturnSale1.AcceptChanges();
                    dataGridView2.DataSource = dtReturnSale1;
                    foreach (DataGridViewColumn dc in dataGridView2.Columns)
                    {
                        if (dc.Index.Equals(4))
                        {
                            dc.ReadOnly = false;
                        }
                        else
                        {
                            dc.ReadOnly = true;
                        }

                    }
                  dataGridView2.Columns["SupplierID"].Visible = false;
                  dataGridView2.Columns["CategoryID"].Visible = false;
                  dataGridView2.Columns["POID"].Visible = false;
                  //dataGridView2.Columns["StockID"].Visible = false;

                    decimal TotalRefund = 0;
                    TotalActualAmount = 0;

                    for (int k = 0; k < (dataGridView2.Rows.Count); k++)
                    {
                        //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                        TotalRefund = Math.Round((TotalRefund + (decimal.Parse(dataGridView2.Rows[k].Cells["AfterVat"].Value.ToString()))), 2);
                        TotalActualAmount = Math.Round((TotalActualAmount + (decimal.Parse(dataGridView2.Rows[k].Cells["Qty"].Value.ToString()) * decimal.Parse(dataGridView2.Rows[k].Cells["UnitPrice"].Value.ToString()))), 2);
                    }

                   textBox2.Text = TotalRefund.ToString();
                }
                else
                {
                    FrmMessage.Show(" This item is Already Returned");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView2.CurrentRow.Cells["POID"].Value.ToString() == dataGridView1.Rows[i].Cells["POID"].Value.ToString())
                    {
                        if (!string.IsNullOrEmpty(dataGridView2.CurrentRow.Cells["Qty"].Value.ToString()))
                        {
                            if (double.Parse(dataGridView2.CurrentRow.Cells["Qty"].Value.ToString()) > double.Parse(dataGridView1.Rows[i].Cells["Qty"].Value.ToString()) || int.Parse(dataGridView2.CurrentRow.Cells["Qty"].Value.ToString()) == 0)
                            {
                                FrmMessage.Show("Quanity should be between 1 and max quantity " + dataGridView1.Rows[i].Cells["Qty"].Value.ToString());
                                dataGridView2.CurrentRow.Cells["Qty"].Value = dataGridView1.Rows[i].Cells["Qty"].Value.ToString();
                                break;
                            }
                            else
                            {
                                dataGridView2.CurrentRow.Cells["AfterVat"].Value = "" + Math.Round((decimal.Parse(dataGridView2.CurrentRow.Cells["Qty"].Value.ToString()) * (decimal.Parse(dataGridView2.CurrentRow.Cells["UnitPrice"].Value.ToString()))) + ((decimal.Parse(dataGridView2.CurrentRow.Cells["Qty"].Value.ToString()) * (decimal.Parse(dataGridView2.CurrentRow.Cells["UnitPrice"].Value.ToString())))*(decimal.Parse(dataGridView2.CurrentRow.Cells["vat%"].Value.ToString())/100)), 2).ToString();
                                dataGridView2.CurrentRow.Cells["BeforeVat"].Value = "" + Math.Round((decimal.Parse(dataGridView2.CurrentRow.Cells["Qty"].Value.ToString()) * (decimal.Parse(dataGridView2.CurrentRow.Cells["UnitPrice"].Value.ToString()))), 2).ToString();
                                break;
                            }
                        }
                        else
                        {
                            dataGridView2.CurrentRow.Cells["Qty"].Value = dataGridView1.Rows[i].Cells["Qty"].Value.ToString();
                            break;
                        }
                    }
                }

                decimal TotalRefund = 0;
                TotalActualAmount = 0;

                for (int k = 0; k < (dataGridView2.Rows.Count); k++)
                {
                    //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                    TotalRefund = Math.Round((TotalRefund + (decimal.Parse(dataGridView2.Rows[k].Cells["AfterVat"].Value.ToString()))), 2);
                    TotalActualAmount = Math.Round((TotalActualAmount + (decimal.Parse(dataGridView2.Rows[k].Cells["Qty"].Value.ToString()) * decimal.Parse(dataGridView2.Rows[k].Cells["UnitPrice"].Value.ToString()))), 2);
                }


               textBox2.Text = TotalRefund.ToString();
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                if (e.Control is TextBox) //If it is a DataGridViewTextBoxCell
                {
                    (e.Control as TextBox).MaxLength = 8; //Set the MaxLength to 4
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            decimal TotalRefund = 0;
            TotalActualAmount = 0;

            for (int k = 0; k < (dataGridView2.Rows.Count); k++)
            {
                //decimal afterdiscountamount = Math.Round(((decimal.Parse(dataGridView1.Rows[k].Cells[3].Value.ToString()) / 100) * (decimal.Parse(dataGridView1.Rows[k].Cells[1].Value.ToString()))), 2);
                TotalRefund = Math.Round((TotalRefund + (decimal.Parse(dataGridView2.Rows[k].Cells["AfterVat"].Value.ToString()))), 2);
                TotalActualAmount = Math.Round((TotalActualAmount + (decimal.Parse(dataGridView2.Rows[k].Cells["Qty"].Value.ToString()) * decimal.Parse(dataGridView2.Rows[k].Cells["UnitPrice"].Value.ToString()))), 2);
            }
           textBox2.Text = TotalRefund.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0 || dataGridView2.Rows.Count == 0)
                {
                    FrmMessage.Show("No items were selected for return.");
                }
                else if (string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    FrmMessage.Show("Please Enter the reason for return.");
                }
                else
                {
                    if (DialogResult.Yes == FrmMessage.Show("Are You Sure You want to return these items to Supplier.", caption, YesNoButton, QuestionIcon))
                    {

                        bool result = false;
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            result = sqlhelp.ExecuteNonQuery("insert into RETURNITEMSTOSUPPLIER (POID,SUPPLIERID,CATEGORYID,ITEMNAME,RETURNQTY,ITEMPRICE,TOTALAMOUNT,Reason,CREATEDBY) Values " +
                                "(" + dataGridView2.Rows[i].Cells["POID"].Value.ToString() + "," + dataGridView2.Rows[i].Cells["SupplierID"].Value.ToString() + "," + dataGridView2.Rows[i].Cells["CategoryID"].Value.ToString() + "," +
                                "'" + dataGridView2.Rows[i].Cells["ItemName"].Value.ToString() + "'," + dataGridView2.Rows[i].Cells["Qty"].Value.ToString() + "," +
                                "" + dataGridView2.Rows[i].Cells["UnitPrice"].Value.ToString() + "," + dataGridView2.Rows[i].Cells["AfterVat"].Value.ToString() + ",'" + textBox1.Text.Trim() + "'," + GlobalData.UserID + ")");

                            result = sqlhelp.ExecuteNonQuery("update SupplierOrder set Qty= (Qty-" + dataGridView2.Rows[i].Cells["Qty"].Value + "),TotalAmount = (TotalAmount-" + dataGridView2.Rows[i].Cells["BeforeVat"].Value + ")" +
                                                                 " where SUPPLIERID=" + dataGridView2.Rows[i].Cells["SupplierID"].Value.ToString() + " and CATEGORYID=" + dataGridView2.Rows[i].Cells["CategoryID"].Value.ToString() + "" +
                                                                 " and POID=" + dataGridView2.Rows[i].Cells["POID"].Value.ToString() + " and ItemName='" + dataGridView2.Rows[i].Cells["ItemName"].Value.ToString() + "'");
                        }
                        if (result == true)
                        {
                            FrmMessage.Show("Returned Items to Supplier Successfully Make Sure you Return the Items from Stock for this Item !!");
                            ReturnToSupplier form = new ReturnToSupplier
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
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

     

    }
}
