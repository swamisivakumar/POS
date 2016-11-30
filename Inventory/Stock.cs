using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMEntity;
using System.IO;
using IMDal;
using System.Collections;

namespace Inventory
{
    public partial class Stock : Form
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

        string BarcodeSt = "";
        string MBarcodeSt = "";

        string ddlSrchCat;
        string ddlSrchitem;
        int stockId;
        int StockHId;
        int searchid;

        public Stock()
        {
            InitializeComponent();
            fillSuppliers(ddlSupp);
            fillSuppliers(ddlsrchSupp);
            fillCategory(cmbSTKcategories);
            fillCategory(ddlSrchCategory);
        }
        void fillCategory(ComboBox cmb)
        {
            DataSet DS = new DataSet();
            ECategory Ecategory = new ECategory();
            DS = Ecategory.GETALLCATEGORY(Ecategory);
            DataRow dr = DS.Tables[0].NewRow();
            dr["CategoryName"] = "Select";
            if (cmb.Name == "cmbSTKcategories")
            {
                dr["CategoryID"] = 0;
            }
            else
            {
                dr["CategoryID"] = "%";
            }
            DS.Tables[0].Rows.InsertAt(dr, 0);
            cmb.DataSource = DS.Tables[0];
            cmb.DisplayMember = "CategoryName";
            cmb.ValueMember = "CategoryID";

        }
        void fillSuppliers(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt = sqlhelp.ExecuteTables("select cstr(SupplierID) as SupplierID,SupplierName from Supplier");
            DataRow dr = dt.NewRow();
            dr["SupplierName"] = "Select";
            if (cmb.Name == "ddlSupp")
            {
                dr["SupplierID"] = 0;
            }
            else
            {
                dr["SupplierID"] = "%";
            }
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "SupplierName";
            cmb.ValueMember = "SupplierID";
        }
        void fillITems(ComboBox cmb)
        {
            DataSet DS = new DataSet();
            EItems eitem = new EItems();
            eitem.Categoryid = cmbSTKcategories.SelectedValue.ToString();
            DS = eitem.GETALLITEMS(eitem);
            DataRow dr = DS.Tables[0].NewRow();
            dr["ItemName"] = "Select";
            dr["ItemID"] = "%";
            DS.Tables[0].Rows.InsertAt(dr, 0);
            cmb.DataSource = DS.Tables[0];
            cmb.DisplayMember = "ItemName";
            cmb.ValueMember = "ItemID";
        }
        private void AutoSuggestItems()
        {
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select distinct(ItemName) from SupplierOrder where SupplierID="+ ddlSupp.SelectedValue +" and CategoryID="+ cmbSTKcategories.SelectedValue +"");

            if (ds.Tables[0].Rows.Count > 0)
            {
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["ItemName"].ToString());
                }
                txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtItemName.AutoCompleteCustomSource = col;
                txtItemName.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
        }
        private void copyimage()
        {
            try
            {
                if (PriviewPic.Image != null)
                {
                    string dir = Application.StartupPath;
                    dir = System.IO.Path.Combine(dir, "InventoryImages");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                        PriviewPic.Image.Save(dir + "\\" + ImageName);
                    }
                    else
                    {
                        PriviewPic.Image.Save(dir + "\\" + ImageName);
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
        private void BtnAddStock_Click(object sender, EventArgs e)
        {
            if (cmbSTKcategories.SelectedValue.ToString() == "0" || ddlVat.SelectedIndex == 0 || string.IsNullOrEmpty(txtItemName.Text.Trim()) || string.IsNullOrEmpty(txtMRP.Text.Trim()) || string.IsNullOrEmpty(txtReOrderQty.Text) || string.IsNullOrEmpty(txtStkQuantity.Text) || string.IsNullOrEmpty(txtunitprice.Text) || string.IsNullOrEmpty(txtsaleprice.Text) || comboBox2.SelectedIndex == 0)
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
            }
            else
            {
                sqlhelp = new SQLHelper();
                bool result;
                if (BtnAddStock.Text == "Add")
                {
                    int ITEMID = 0;
                    int Count = int.Parse(sqlhelp.ExecuteScalar("select count(ItemName) from Items where ItemName='" + txtItemName.Text + "' and CategoryID=" + cmbSTKcategories.SelectedValue + " and SupplierID=" + ddlSupp.SelectedValue + ""));
                    if (Count == 0)
                    {
                        if (string.IsNullOrEmpty(ImageName))
                        {
                            ImageName = "NoImage.jpg";
                        }

                        result = sqlhelp.ExecuteNonQuery("insert into Items (SupplierID,CategoryID,ItemName,ImageName,CreatedBy) " +
                                "values(" + ddlSupp.SelectedValue + "," + cmbSTKcategories.SelectedValue + ",'" + txtItemName.Text + "','" + ImageName + "'," + GlobalData.UserID + ")");

                        if (result == true)
                        {
                            copyimage();
                        }
                    }
                    ITEMID = int.Parse(sqlhelp.ExecuteScalar("select ItemID from Items where ItemName='" + txtItemName.Text.Trim() + "' and CategoryID=" + cmbSTKcategories.SelectedValue + " and SupplierID=" + ddlSupp.SelectedValue + ""));
                    result = sqlhelp.ExecuteNonQuery("insert into Stock(SupplierID,Barcode,MBarcode,ItemID,CategoryID,Createdby," +
                                       "StockDescription,StockQuantity,ReOrderQuantity,ExpiryDate,QtyType) values(" + ddlSupp.SelectedValue + ",'" + BarcodeSt + "','" + MBarcodeSt + "'," +
                                       "" + ITEMID + "," + cmbSTKcategories.SelectedValue + "," +
                                       "" + GlobalData.UserID + ",'" + rtbDesStock.Text + "'," +
                                       "" + txtStkQuantity.Text + "," + txtReOrderQty.Text + ", '" + ddlExpiryDate.Text + "', '" + comboBox2.Text + "')");

                    int stockid = int.Parse(sqlhelp.ExecuteScalar("select max(StockID) from Stock"));

                    result = sqlhelp.ExecuteNonQuery("insert into StockHistory(StockID,SupplierID,Barcode,ItemID,CategoryID,Createdby,VatPercent,InvoiceAmount," +
                                           "Qty,ReOrderQty,UnitPrice,MRP,SalePrice,ExpiryDate,QtyType) values(" + stockid + "," + ddlSupp.SelectedValue + ",'" + BarcodeSt + "'," +
                                           "" + ITEMID + "," + cmbSTKcategories.SelectedValue + "," +
                                           "" + GlobalData.UserID + ","+ ddlVat.SelectedValue +"," + txtStkInvoice.Text + "," +
                                           "" + txtStkQuantity.Text + "," + txtReOrderQty.Text + "," + txtunitprice.Text + "," + txtMRP.Text + "," + txtsaleprice.Text + ",'" + ddlExpiryDate.Text + "', '" + comboBox2.Text + "')");

                    result = sqlhelp.ExecuteNonQuery("insert into ItemPrice(ItemID,Barcode,VatPercent,MRP,SalePrice,Createdby)" +
                                     " values(" + ITEMID + ",'" + BarcodeSt + "',"+ ddlVat.SelectedValue +","+ txtMRP.Text +"," + txtsaleprice.Text + "," +
                                     "" + GlobalData.UserID + ")");

                    if (result == true)
                    {
                        FrmMessage.Show("Stock Added Successfully ", caption, OkButton, InformationIcon);
                        btnClear_Click(sender, e);
                        AutoSuggestItems();
                    }
                }
                else if (BtnAddStock.Text == "Update Stock")
                {
                    // result = sqlhelp.ExecuteNonQuery("Update Items set ItemName='" + txtItemName.Text.Trim() + "',ImageName='" + ImageName + "' where ItemID=" + UpdateItemID + "");
                    result = sqlhelp.ExecuteNonQuery("Update Stock set " +
                                       "StockDescription='" + rtbDesStock.Text + "',StockQuantity= (StockQuantity + " + txtStkQuantity.Text + ")," +
                                       "ReOrderQuantity=" + txtReOrderQty.Text + " where StockID=" + stockId + "");

                    result = sqlhelp.ExecuteNonQuery("insert into StockHistory(StockID,SupplierID,Barcode,ItemID,CategoryID,Createdby,InvoiceAmount," +
                                           "Qty,ReOrderQty,UnitPrice,SalePrice,MRP,ExpiryDate,QtyType) values(" + stockId + "," + ddlSupp.SelectedValue + ",'" + BarcodeSt + "'," +
                                           "" + UpdateItemID + "," + cmbSTKcategories.SelectedValue + "," +
                                           "" + GlobalData.UserID + "," + txtStkInvoice.Text + "," +
                                           "" + txtStkQuantity.Text + "," + txtReOrderQty.Text + "," + txtunitprice.Text + "," + txtsaleprice.Text + "," + txtMRP.Text + ",'" + ddlExpiryDate.Text + "', '" + comboBox2.Text + "')");

                    result = sqlhelp.ExecuteNonQuery("Update ItemPrice set " +
                                                     "SalePrice=" + txtsaleprice.Text + ",VatPercent="+ ddlVat.SelectedValue +"," +
                                                     "MRP="+ txtMRP.Text +",UpdatedBy=" + GlobalData.UserID + ",UpdatedDate='" + System.DateTime.Today.ToString() + "'" +
                                                     " where Barcode='" + BarcodeSt + "'");


                    if (result == true)
                    {
                        // copyimage();
                        FrmMessage.Show("Stock Quantity Updated Successfully ", caption, OkButton, InformationIcon);
                        BtnAddStock.Text = "Add";
                        btnClear.Text = "Clear";
                        btnClear_Click(sender, e);
                        btnTbSearch_Click(sender, e);
                    }

                }

                else if (BtnAddStock.Text == "Update")
                {
                    result = sqlhelp.ExecuteNonQuery("update Items set ItemName='" + txtItemName.Text.Trim() + "',ImageName='" + ImageName + "' where ItemID=" + UpdateItemID + " and SupplierID=" + ddlSupp.SelectedValue + " and CategoryID=" + cmbSTKcategories.SelectedValue + "");
                    if (result == true && ImageStaus == true)
                    {
                        copyimage();
                    }

                    result = sqlhelp.ExecuteNonQuery("Update StockHistory Set Barcode='" + updatebarcode + "',MRP="+ txtMRP.Text +", UnitPrice= "+ txtunitprice.Text +",VatPercent="+ ddlVat.SelectedValue +",InvoiceAmount =" + txtStkInvoice.Text + ",Qty= " + txtStkQuantity.Text + ",ReOrderQty=" + txtReOrderQty.Text + ",SalePrice=" + txtsaleprice.Text + ",ExpiryDate='" + ddlExpiryDate.Text + "',QtyType= '" + comboBox2.Text + "'" +
                                                    " where StockHID=" + StockHId + "");
                    DataSet ds = new DataSet();
                    ds = sqlhelp.ExecuteQueries("select Barcode,sum(Qty) as [Qnty] from StockHistory where StockID = " + stockId + " group by Barcode");
                    decimal remainingQty = decimal.Parse(sqlhelp.ExecuteScalar("select IIF(sum(SaleQty) is null,0,sum(SaleQty)) from Transactions where CategoryID =" + cmbSTKcategories.SelectedValue.ToString() + " and ItemID=" + UpdateItemID + " and Barcode = '" + BarcodeSt + "'"));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        remainingQty = decimal.Parse(ds.Tables[0].Rows[0]["Qnty"].ToString()) - remainingQty;
                        result = sqlhelp.ExecuteNonQuery("Update Stock set Barcode='" + updatebarcode + "',Mbarcode='" + MBarcodeSt + "',StockQuantity=(" + remainingQty + "),ReOrderQuantity=" + txtReOrderQty.Text + "" +
                                                  ",ExpiryDate='" + ddlExpiryDate.Text + "',QtyType= '" + comboBox2.Text + "' where StockID=" + stockId + "");
                        result = sqlhelp.ExecuteNonQuery("Update ItemPrice set Barcode='" + updatebarcode + "',MRP="+ txtMRP.Text +",VatPercent="+ ddlVat.SelectedValue +",SalePrice=" + txtsaleprice.Text + "" +
                                                " where Barcode='" + BarcodeSt + "'");
                    }

                    if (result == true)
                    {
                        FrmMessage.Show("Stock Updated Successfully ", caption, OkButton, InformationIcon);
                        BtnAddStock.Text = "Add";
                        btnClear.Text = "Clear";
                        btnClear_Click(sender, e);
                        btnTbSearch_Click(sender, e);
                    }




                }


            }
        }

        private void txtStkQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        BarcodeLib.Barcode b = new BarcodeLib.Barcode();
        private void Stock_Load(object sender, EventArgs e)
        {
           

            // ******************************************************
            SearchGroup.Visible = true;
            AddGroup.Visible = false;
            AutoSuggestBarcodes();
        //    AutoSuggestItems();

            sqlhelp = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select * from UNITS");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow DR = ds.Tables[0].NewRow();
                DR["UNIT"] = "Select";
                DR["UNITID"] = 0;
                ds.Tables[0].Rows.InsertAt(DR, 0);
                comboBox2.DisplayMember = "UNIT";
                comboBox2.ValueMember = "UNITID";
              comboBox2.DataSource = ds.Tables[0];
              
                
            }

            DataTable dt = new DataTable();
            dt = sqlhelp.ExecuteTables("select cstr([Tax]) as [Tax] from Tax");
            if (dt.Rows.Count > 0)
            {
                DataRow dr1 = dt.NewRow();
                dr1["Tax"] = "Select";               
                dt.Rows.InsertAt(dr1, 0);
                ddlVat.DisplayMember = "Tax";
                ddlVat.ValueMember = "Tax";
                ddlVat.DataSource = dt;
            }         
        }

        private void AutoSuggestBarcodes()
        {
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select Barcode from Stock");

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["Barcode"].ToString());
            }
            txtSrchBarcode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtSrchBarcode.AutoCompleteCustomSource = col;
            txtSrchBarcode.AutoCompleteMode = AutoCompleteMode.Suggest;
        }





        private void Stock_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTbSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchGroup.Visible = true;
                AddGroup.Visible = false;
                StockGrid.Visible = false;
                btnTbAdd.Text = "Add";
                MBarcodeSt = string.Empty;
                BarcodeSt = string.Empty;
                AutoSuggestBarcodes();
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

        }

        private void btnTbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                btnTbAdd.Text = "Add";
                SearchGroup.Visible = false;
                AddGroup.Visible = true;
                BtnAddStock.Text = "Add";
                btnClear.Text = "Clear";
                btnClear_Click(sender, e);
                btnClear.Visible = true;
                txtMnBarcode.Enabled = true;
                MBarcodeSt = string.Empty;
                BarcodeSt = string.Empty;
                UpdateStock = false;
                AutoSuggestItems();


            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

        }

        private void txtStkInvoice_TextChanged(object sender, EventArgs e)
        {
            
        }
        Hashtable ht = new Hashtable();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchid = 0;
                StockGrid.Visible = true;
                ds = new DataSet();
                StockGrid.DataSource = null;
                StockGrid.Columns.Clear();
                sqlhelp = new SQLHelper();
                string srchBarcode = "";

                if (string.IsNullOrEmpty(txtSrchBarcode.Text))
                {
                    srchBarcode = "%";
                }
                else
                {
                    srchBarcode = txtSrchBarcode.Text;
                }

                string wherecondition = "CategoryID like '" + ddlSrchCat + "'" +
                                        "and ItemID like '" + ddlSrchitem + "'" +
                                        " and SupplierID like '" + ddlsrchSupp.SelectedValue + "'" +
                                        " and Barcode like'" + srchBarcode + "'";
                ds = sqlhelp.ExecuteQueries("Select * from GetStock where " + wherecondition + "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    StockGrid.DataSource = ds.Tables[0];
                    StockGrid.Columns["StockID"].Visible = false;
                    StockGrid.Columns["CategoryID"].Visible = false;
                    StockGrid.Columns["ItemID"].Visible = false;
                    StockGrid.Columns["SupplierID"].Visible = false;
                    StockGrid.Columns["ImageName"].Visible = false;
                    StockGrid.Columns["StockDescription"].Visible = false;
                    DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
                    btnUpdate.HeaderText = "Add Quantity";
                    btnUpdate.Text = "Add Quantity";
                    btnUpdate.UseColumnTextForButtonValue = true;
                    btnUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    btnUpdate.FlatStyle = FlatStyle.Standard;
                    btnUpdate.CellTemplate.Style.BackColor = Color.Honeydew;
                    StockGrid.Columns.Add(btnUpdate);
                }
                else
                {
                    StockGrid.DataSource = ds.Tables[0];
                    StockGrid.Columns["StockID"].Visible = false;
                    StockGrid.Columns["CategoryID"].Visible = false;
                    StockGrid.Columns["ItemID"].Visible = false;
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

        private void ddlSrchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSrchCategory.SelectedIndex == 0)
                {
                    ddlSrchCat = "%";
                }
                else
                {
                    ddlSrchCat = ddlSrchCategory.SelectedValue.ToString();
                }
                ds = new DataSet();
                sqlhelp = new SQLHelper();
                ds = sqlhelp.ExecuteQueries("select ItemID,ItemName from Items where CategoryID like '" + ddlSrchCat + "'");
                DataRow dr = ds.Tables[0].NewRow();
                dr["ItemName"] = "Select";
                dr["ItemID"] = 0;
                ds.Tables[0].Rows.InsertAt(dr, 0);
                ddlSrchItems.DataSource = ds.Tables[0];
                ddlSrchItems.DisplayMember = "ItemName";
                ddlSrchItems.ValueMember = "ItemID";
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

        }

        private void ddlSrchItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlSrchItems.Text))
            {
                if (ddlSrchItems.SelectedIndex == 0)
                {
                    ddlSrchitem = "%";
                }
                else
                {
                    ddlSrchitem = ddlSrchItems.SelectedValue.ToString();
                }
            }
            else
            {
                ddlSrchitem = "%";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnClear.Text == "Clear")
                {
                    cmbSTKcategories.Enabled = true;
                    cmbSTKcategories.SelectedIndex = 0;
                    lblBarcode.Text = string.Empty;
                    lblBarcodeText.Text = string.Empty;
                    txtStkInvoice.Text = string.Empty;
                    txtStkQuantity.Text = string.Empty;
                    txtunitprice.Text = string.Empty;
                    txtReOrderQty.Text = "1";
                    txtsaleprice.Text = string.Empty;
                    rtbDesStock.Text = string.Empty;
                    txtPreQty.Text = "0";
                    txtPreSalePrice.Text = "0";
                    txtImage.Text = string.Empty;
                    txtItemName.Text = string.Empty;
                    ddlSupp.Enabled = true;
                    txtItemName.Enabled = true;
                    txtMnBarcode.Enabled = true;
                    ddlSupp.SelectedIndex = 0;
                    BtnImageupld.Enabled = true;
                    txtMnBarcode.Text = string.Empty;
                    if (PriviewPic.Image != null)
                    {
                        PriviewPic.Image = null;
                    }
                    PriviewPic.Image = PriviewPic.InitialImage;
                    ImageName = string.Empty;

                    barcodepic.Image = null;
                }
                else if (btnClear.Text == "Delete")
                {
                    bool Result;
                    sqlhelp = new SQLHelper();
                    if (DialogResult.Yes == FrmMessage.Show("Are you Sure. You want to Delete this Stock ?", caption, YesNoButton, QuestionIcon))
                    {
                        int remainingQty = int.Parse(sqlhelp.ExecuteScalar("select IIF(sum(SaleQty) is null,0,sum(SaleQty)) from Transactions where CategoryID =" + cmbSTKcategories.SelectedValue.ToString() + " and ItemID=" + UpdateItemID + " and Barcode='" + BarcodeSt + "'"));
                        if (remainingQty == 0)
                        {
                            Result = sqlhelp.ExecuteNonQuery("delete from StockHistory where StockHID=" + StockHId + "");

                            ds = new DataSet();
                            ds = sqlhelp.ExecuteQueries("select Barcode,sum(Qty) as [Qnty] from StockHistory where StockID = " + stockId + " group by Barcode");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                remainingQty = int.Parse(ds.Tables[0].Rows[0]["Qnty"].ToString()) - remainingQty;
                                Result = sqlhelp.ExecuteNonQuery("Update Stock set StockQuantity=(" + remainingQty + "),ReOrderQuantity=" + txtReOrderQty.Text + "" +
                                                          " where StockID=" + stockId + "");
                                Result = sqlhelp.ExecuteNonQuery("Update ItemPrice set SalePrice=" + txtsaleprice.Text + "" +
                                                        " where Barcode='" + ds.Tables[0].Rows[0]["Barcode"].ToString() + "'");
                            }
                            else
                            {
                                Result = sqlhelp.ExecuteNonQuery("delete from Stock where StockID=" + stockId + "");
                                Result = sqlhelp.ExecuteNonQuery("delete from ItemPrice where Barcode='" + BarcodeSt + "'");                                
                            }
                            if (int.Parse(sqlhelp.ExecuteScalar("select Count(*) from Stock where ItemID=" + UpdateItemID + "")) == 0)
                            {
                                Result = sqlhelp.ExecuteNonQuery("delete from Items where ITEMID=" + UpdateItemID + "");
                            }
                            if (Result == true)
                            {
                                FrmMessage.Show("Stock Deleted Successfully", caption, OkButton, InformationIcon);
                                btnClear.Text = "Clear";
                                BtnAddStock.Text = "Add";
                                btnTbSearch_Click(sender, e);
                            }
                        }
                        else
                        {
                            FrmMessage.Show("This Stock Cannot be deleted. It is already used in Sales", caption, OkButton, InformationIcon);
                            btnClear.Text = "Clear";
                            BtnAddStock.Text = "Add";
                            btnTbSearch_Click(sender, e);
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

        //private void StockGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    btnTbAdd_Click(sender, e);
        //    btnTbAdd.Text = "Edit";
        //    stockId = int.Parse(StockGrid.CurrentRow.Cells[0].Value.ToString());
        //    cmbSTKcategories.SelectedValue = StockGrid.CurrentRow.Cells[1].Value;
        //    cmbSTKcategories.Enabled = false;
        //    cmbSTKItems.Enabled = false;
        //    cmbSTKItems.SelectedValue = StockGrid.CurrentRow.Cells[2].Value;
        //    lblBarcode.Text = StockGrid.CurrentRow.Cells[3].Value.ToString();
        //    lblBarcodeText.Text = StockGrid.CurrentRow.Cells[3].Value.ToString();
        //    txtStkQuantity.Text = StockGrid.CurrentRow.Cells[6].Value.ToString();
        //    txtReOrderQty.Text = StockGrid.CurrentRow.Cells[7].Value.ToString();            
        //    txtunitprice.Text = StockGrid.CurrentRow.Cells[8].Value.ToString();
        //    txtsaleprice.Text = StockGrid.CurrentRow.Cells[9].Value.ToString();            
        //    rtbDesStock.Text = StockGrid.CurrentRow.Cells[10].Value.ToString();
        //    btnClear.Text = "Delete";
        //    BtnAddStock.Text = "Update";
        //}

        private void txtStkQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStkInvoice.Text) && !string.IsNullOrEmpty(txtStkQuantity.Text) && !string.IsNullOrEmpty(txtunitprice.Text))
            {
                if (txtStkQuantity.Text != "0")
                {
                    txtStkInvoice.Text = Math.Round((decimal.Parse(txtunitprice.Text) * decimal.Parse(txtStkQuantity.Text)), 2).ToString();
                }
                else
                {
                    txtStkInvoice.Text = "0";
                }
            }
            else
            {
                txtStkInvoice.Text = "0";
            }
        }

        private void txtStkInvoice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMnBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (UpdateStock == false)
                {
                    if (!string.IsNullOrEmpty(txtMnBarcode.Text.Trim()))
                    {
                        int CountMnBarcode = int.Parse(sqlhelp.ExecuteScalar("select Count(MBarcode) from Stock where MBarcode='" + txtMnBarcode.Text.Trim() + "'"));
                        if (CountMnBarcode == 0)
                        {
                            lblBarcode.Text = txtMnBarcode.Text;
                            lblBarcodeText.Text = txtMnBarcode.Text;
                            MBarcodeSt = txtMnBarcode.Text;

                        }
                        else
                        {
                            FrmMessage.Show("This barcode is already exist.Please Enter other barcode");
                            txtMnBarcode.Text = string.Empty;
                        }
                    }
                    else
                    {
                        txtItemName_TextChanged(sender, e);
                    }
                }
                else if (UpdateStock == true)
                {
                    if (!string.IsNullOrEmpty(txtMnBarcode.Text.Trim()))
                    {
                        if (MBarcodeSt != txtMnBarcode.Text.Trim())
                        {
                            int CountMnBarcode = int.Parse(sqlhelp.ExecuteScalar("select Count(MBarcode) from Stock where MBarcode='" + txtItemName.Text.Trim() + txtMnBarcode.Text.Trim() + "'"));
                            if (CountMnBarcode == 0)
                            {
                                lblBarcode.Text = txtMnBarcode.Text;
                                lblBarcodeText.Text = txtMnBarcode.Text;
                                MBarcodeSt = txtMnBarcode.Text;
                            }
                            else
                            {
                                FrmMessage.Show("This barcode is already exist.Please Enter other barcode");
                                txtMnBarcode.Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        lblBarcode.Text = updatebarcode;
                        lblBarcodeText.Text = updatebarcode;
                        MBarcodeSt = string.Empty;
                    }

                }

                /// Barcode**************************************                        
                int W = Convert.ToInt32(260);
                int H = Convert.ToInt32(60);
                b.Alignment = BarcodeLib.AlignmentPositions.CENTER;

                //barcode alignment

                BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;
                try
                {
                    if (type != BarcodeLib.TYPE.UNSPECIFIED)
                    {
                        b.IncludeLabel = true;

                        b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone", true);

                        //label alignment and position                                
                        b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;


                        barcodepic.Image = b.Encode(type, this.lblBarcodeText.Text.Trim(), Color.Black, Color.White, W, H);

                    }//if

                    barcodepic.Width = barcodepic.Image.Width;
                    barcodepic.Height = barcodepic.Image.Height;

                    //reposition the barcode image to the middle
                    barcodepic.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - barcodepic.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - barcodepic.Height / 2);
                }//try
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }//catch


            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void btnBarcodePrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoPrint.Text) || string.IsNullOrEmpty(txtMRP.Text.Trim()) || string.IsNullOrEmpty(txtItemName.Text.Trim()))
            {
                FrmMessage.Show("Please Enter Number of prints and MRP and ItemName.");
            }
            else
            {
                GlobalData.BarcodeImage = imageToByteArray(barcodepic.Image);
                GlobalData.NoofBarcode = Int32.Parse(txtNoPrint.Text);
                GlobalData.ItemAndPrice = "Product :" + txtItemName.Text + "  MRP : " + txtMRP.Text;

                FRM_BarcodeRpt frm = new FRM_BarcodeRpt();
                frm.ShowDialog();

               // BillPrintPreview.Document = BillPrint;
               //// BillPrintPreview.PrintPreviewControl.Zoom = 1;
               // BillPrintPreview.ShowDialog();




            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        private void BillPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font Header = new System.Drawing.Font("code 128", 48, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));

                Font font = new Font("Times New Roman", 9, System.Drawing.FontStyle.Bold);

                float xx = 0;
                float yy = 10;
                int count = 1;
                for (int i = 0; i < int.Parse(txtNoPrint.Text); i++)
                {
                    if ((count) % 4 > 0)
                    {

                        e.Graphics.DrawImage(barcodepic.Image,xx,yy);

                        //Graphics g = e.Graphics;
                        //Brush br = new SolidBrush(Color.Black);
                        //// the Asterisk (*) is used to delimit the barcode, and is required as the start and stop charachters by the 3of9 Symbology.
                        //g.DrawString("" + lblBarcode.Text + "", Header, br, xx, yy);
                        yy = yy + 120;
                        xx = xx + 10;
                        ////g.DrawString(lblBarcodeText.Text, font, br, xx, yy);
                        //yy = yy - 40;
                        //xx = xx + 190;
                    }
                    else
                    {
                        e.Graphics.DrawImage(barcodepic.Image, xx, yy);


                        //Graphics g = e.Graphics;
                        //Brush br = new SolidBrush(Color.Black);
                        //// the Asterisk (*) is used to delimit the barcode, and is required as the start and stop charachters by the 3of9 Symbology.
                        //g.DrawString("" + lblBarcode.Text + "", Header, br, xx, yy);
                        yy = yy + 60;
                        xx = 0;
                    }
                    count++;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool UpdateStock = false;
        int UpdateItemID = 0;
        string PrevItemName = string.Empty;
        private void StockGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (searchid == 0)
                {
                    if (e.ColumnIndex == 18)
                    {
                        btnTbAdd_Click(sender, e);
                        btnTbAdd.Text = "Edit";
                        stockId = int.Parse(StockGrid.CurrentRow.Cells["StockID"].Value.ToString());
                        cmbSTKcategories.SelectedValue = StockGrid.CurrentRow.Cells["CategoryID"].Value;
                        cmbSTKcategories.Enabled = false;
                        ddlSupp.Enabled = false;
                        ddlSupp.SelectedValue = StockGrid.CurrentRow.Cells["SupplierID"].Value.ToString();
                        cmbSTKcategories.Enabled = false;
                        UpdateStock = true;
                        //cmbSTKItems.Enabled = false;
                        if (!string.IsNullOrEmpty(StockGrid.CurrentRow.Cells["ImageName"].Value.ToString()))
                        {
                            string dir = Application.StartupPath;
                            dir = System.IO.Path.Combine(dir, "InventoryImages");
                            if (Directory.Exists(dir))
                            {
                                string[] ImgName;
                                txtImage.Text = dir + "\\" + StockGrid.CurrentRow.Cells["ImageName"].Value.ToString();
                                ImgName = txtImage.Text.Split('\\');
                                ImageName = ImgName[ImgName.Length - 1];
                                if (PriviewPic.Image != null)
                                {
                                    PriviewPic.Image = null;
                                }
                                PriviewPic.Image = System.Drawing.Image.FromFile(txtImage.Text);
                                // ImageStaus = false;
                            }

                        }
                        else
                        {
                            txtImage.Text = string.Empty;
                            if (PriviewPic.Image != null)
                            {
                                PriviewPic.Image = null;
                                PriviewPic.Image = PriviewPic.InitialImage;
                            }
                            ImageName = string.Empty;
                            // ImageStaus = false;
                        }

                        if (string.IsNullOrEmpty(StockGrid.CurrentRow.Cells["MBarcode"].Value.ToString()))
                        {
                            lblBarcode.Text = StockGrid.CurrentRow.Cells["Barcode"].Value.ToString();
                            lblBarcodeText.Text = StockGrid.CurrentRow.Cells["Barcode"].Value.ToString();
                            BarcodeSt = StockGrid.CurrentRow.Cells["Barcode"].Value.ToString();
                            txtMnBarcode.Text = string.Empty;
                        }
                        else
                        {
                            lblBarcode.Text = StockGrid.CurrentRow.Cells["MBarcode"].Value.ToString();
                            lblBarcodeText.Text = StockGrid.CurrentRow.Cells["MBarcode"].Value.ToString();
                            MBarcodeSt = StockGrid.CurrentRow.Cells["MBarcode"].Value.ToString();
                            BarcodeSt = StockGrid.CurrentRow.Cells["Barcode"].Value.ToString();
                            txtMnBarcode.Text = StockGrid.CurrentRow.Cells["MBarcode"].Value.ToString();
                        }
                        txtPreQty.Text = StockGrid.CurrentRow.Cells["Quantity"].Value.ToString();
                        txtPreSalePrice.Text = StockGrid.CurrentRow.Cells["SalePrice"].Value.ToString();
                        rtbDesStock.Text = StockGrid.CurrentRow.Cells["StockDescription"].Value.ToString();
                        txtReOrderQty.Text = StockGrid.CurrentRow.Cells["ReOrder Qty"].Value.ToString();
                        //btnClear.Text = "Delete";
                        BtnAddStock.Text = "Update Stock";
                        btnClear.Visible = false;
                        txtMnBarcode.Enabled = false;
                        UpdateItemID = int.Parse(StockGrid.CurrentRow.Cells["ItemID"].Value.ToString());
                        PrevItemName = StockGrid.CurrentRow.Cells["ItemName"].Value.ToString();
                        txtItemName.Text = StockGrid.CurrentRow.Cells["ItemName"].Value.ToString();
                        txtItemName.Enabled = false;
                        BtnImageupld.Enabled = false;
                        comboBox2.Text = StockGrid.CurrentRow.Cells["QtyType"].Value.ToString();
                        ddlExpiryDate.Text = StockGrid.CurrentRow.Cells["ExpiryDate"].Value.ToString();
                       

                    }
                }
                else
                {
                    if (e.ColumnIndex == 20)
                    {
                        StockHId = int.Parse(StockGrid.CurrentRow.Cells[0].Value.ToString());
                        stockId = int.Parse(StockGrid.CurrentRow.Cells[1].Value.ToString());
                        sqlhelp = new SQLHelper();
                        int CheckStockHID;
                        CheckStockHID = int.Parse(sqlhelp.ExecuteScalar(" select max(val(StockHID)) from StockHistory where StockID= " + stockId + ""));
                        if (StockHId < CheckStockHID)
                        {
                            FrmMessage.Show("You Cannot Update the previous Stock. Please select the latest Stock of this Item");
                        }
                        else
                        {

                            btnTbAdd_Click(sender, e);
                            btnTbAdd.Text = "Edit";
                            ddlSupp.SelectedValue = StockGrid.CurrentRow.Cells["SupplierID"].Value;
                            ddlSupp.Enabled = false;
                            cmbSTKcategories.SelectedValue = StockGrid.CurrentRow.Cells["CategoryID"].Value;
                            cmbSTKcategories.Enabled = false;
                            //cmbSTKItems.Enabled = false;
                            // cmbSTKItems.SelectedValue = StockGrid.CurrentRow.Cells["ItemID"].Value;
                            UpdateItemID = int.Parse(StockGrid.CurrentRow.Cells["ItemID"].Value.ToString());
                            UpdateStock = true;
                            if (!string.IsNullOrEmpty(StockGrid.CurrentRow.Cells["ImageName"].Value.ToString()))
                            {
                                string dir = Application.StartupPath;
                                dir = System.IO.Path.Combine(dir, "InventoryImages");
                                if (Directory.Exists(dir))
                                {
                                    string[] ImgName;
                                    txtImage.Text = dir + "\\" + StockGrid.CurrentRow.Cells["ImageName"].Value.ToString();
                                    ImgName = txtImage.Text.Split('\\');
                                    ImageName = ImgName[ImgName.Length - 1];
                                    if (PriviewPic.Image != null)
                                    {
                                        PriviewPic.Image = null;
                                    }
                                    PriviewPic.Image = System.Drawing.Image.FromFile(txtImage.Text);
                                    // ImageStaus = false;
                                }

                            }
                            else
                            {
                                txtImage.Text = string.Empty;
                                if (PriviewPic.Image != null)
                                {
                                    PriviewPic.Image = null;
                                }
                                PriviewPic.Image = PriviewPic.InitialImage;
                                ImageName = string.Empty;
                                // ImageStaus = false;
                            }
                            //if (string.IsNullOrEmpty(StockGrid.CurrentRow.Cells["MBarcode"].Value.ToString()))
                            //{
                                lblBarcode.Text = StockGrid.CurrentRow.Cells["Barcode"].Value.ToString();
                                lblBarcodeText.Text = StockGrid.CurrentRow.Cells["Barcode"].Value.ToString();
                                BarcodeSt = StockGrid.CurrentRow.Cells["Barcode"].Value.ToString();
                                updatebarcode = StockGrid.CurrentRow.Cells["Barcode"].Value.ToString();
                                txtMnBarcode.Text = string.Empty;
                            //}
                            //else
                            //{
                            //    lblBarcode.Text = StockGrid.CurrentRow.Cells["MBarcode"].Value.ToString();
                            //    lblBarcodeText.Text = StockGrid.CurrentRow.Cells["MBarcode"].Value.ToString();
                            //    MBarcodeSt = StockGrid.CurrentRow.Cells["MBarcode"].Value.ToString();
                            //    BarcodeSt = StockGrid.CurrentRow.Cells["Barcode"].Value.ToString();
                            //    updatebarcode = StockGrid.CurrentRow.Cells["Barcode"].Value.ToString();
                            //    txtMnBarcode.Text = StockGrid.CurrentRow.Cells["MBarcode"].Value.ToString();
                            //}
                            txtReOrderQty.Text = StockGrid.CurrentRow.Cells["ReOrderQty"].Value.ToString();
                            txtStkQuantity.Text = StockGrid.CurrentRow.Cells["Quantity"].Value.ToString();
                            txtStkInvoice.Text = StockGrid.CurrentRow.Cells["Purchase Amount"].Value.ToString();
                            txtsaleprice.Text = StockGrid.CurrentRow.Cells["SalePrice"].Value.ToString();
                            ddlVat.SelectedValue = StockGrid.CurrentRow.Cells["VatPercent"].Value;
                            txtMRP.Text = StockGrid.CurrentRow.Cells["MRP"].Value.ToString();
                            btnClear.Text = "Delete";
                            BtnAddStock.Text = "Update";
                            PrevItemName = StockGrid.CurrentRow.Cells["ItemName"].Value.ToString();
                            txtItemName.Text = StockGrid.CurrentRow.Cells["ItemName"].Value.ToString();
                            comboBox2.Text = StockGrid.CurrentRow.Cells["QtyType"].Value.ToString();
                            ddlExpiryDate.Text = StockGrid.CurrentRow.Cells["ExpiryDate"].Value.ToString();
                            txtunitprice.Text = StockGrid.CurrentRow.Cells["unitprice"].Value.ToString();
                           
                        }
                    }
                }
            }
        }

        private void btnStockHistory_Click(object sender, EventArgs e)
        {
            searchid = 1;
            StockGrid.Visible = true;
            ds = new DataSet();
            StockGrid.DataSource = null;
            StockGrid.Columns.Clear();
            sqlhelp = new SQLHelper();
            string srchBarcode = "";

            if (string.IsNullOrEmpty(txtSrchBarcode.Text))
            {
                srchBarcode = "%";
            }
            else
            {
                srchBarcode = txtSrchBarcode.Text;
            }
            string wherecondition = "CategoryID like '" + ddlSrchCat + "'" +
                                       "and ItemID like '" + ddlSrchitem + "'" +
                                       " and SupplierID like '" + ddlsrchSupp.SelectedValue + "'" +
                                       " and Barcode like'" + srchBarcode + "'";

            ds = sqlhelp.ExecuteQueries("Select * from getStockHistory where " + wherecondition + "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                StockGrid.DataSource = ds.Tables[0];
                StockGrid.Columns["StockHID"].Visible = false;
                StockGrid.Columns["StockID"].Visible = false;
                StockGrid.Columns["CategoryID"].Visible = false;
                StockGrid.Columns["ItemID"].Visible = false;
                StockGrid.Columns["SupplierID"].Visible = false;
                StockGrid.Columns["ImageName"].Visible = false;

                DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
                btnUpdate.HeaderText = "Edit";
                btnUpdate.Text = "Edit";
                btnUpdate.UseColumnTextForButtonValue = true;
                btnUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdate.FlatStyle = FlatStyle.Standard;
                btnUpdate.CellTemplate.Style.BackColor = Color.Honeydew;
                StockGrid.Columns.Add(btnUpdate);
            }
            else
            {
                StockGrid.DataSource = ds.Tables[0];
                StockGrid.Columns["StockHID"].Visible = false;
                StockGrid.Columns["StockID"].Visible = false;
                StockGrid.Columns["CategoryID"].Visible = false;
                StockGrid.Columns["ItemID"].Visible = false;
                StockGrid.Columns["SupplierID"].Visible = false;
                StockGrid.Columns["ImageName"].Visible = false;
                FrmMessage.Show("No records Found!!!", caption, OkButton, InformationIcon);
            }
        }

        private void txtsaleprice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtReOrderQty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNoPrint_KeyPress(object sender, KeyPressEventArgs e)
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
        string updatebarcode = string.Empty;
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtItemName.Text.Trim()))
            {
                try
                {
                    if (UpdateStock == false)
                    {
                        sqlhelp = new SQLHelper();
                        DataSet ds = new DataSet();
                        int count = 0;
                        //ds = sqlhelp.ExecuteQueries("select BarcodeNo,ItemId from BarcodeQuery where ItemName='" + txtItemName.Text.Trim() + "'");

                        ds = sqlhelp.ExecuteQueries("select iif(Max(ItemId) is null,0,Max(ItemID)) as [ItemId] from Items"); 
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            count = int.Parse(ds.Tables[0].Rows[0]["ItemId"].ToString()) + 1;
                        }
                        else
                        {
                            count = 1;
                        }

                        //if (count > 1)
                        //{
                        //    if (DialogResult.Yes == FrmMessage.Show("This item already exist in the stock. Do you want to store it with another barcode ?", caption, YesNoButton, QuestionIcon))
                        //    {
                        //        count = int.Parse(ds.Tables[0].Rows[0]["ItemId"].ToString()) + 1;
                        //        lblBarcodeText.Text = System.DateTime.Today.ToString("ddMMyyyy") + "-" + count;
                        //        //lblBarcodeText.Text = System.DateTime.Today.ToString("ddMMyyyy") + txtItemName.Text.Trim() + "-" + count;
                        //        lblBarcode.Text = lblBarcodeText.Text;
                        //        BarcodeSt = lblBarcodeText.Text;
                        //        MBarcodeSt = string.Empty;
                                
                        //    }
                        //    else
                        //    {
                        //        lblBarcode.Text = string.Empty;
                        //        lblBarcodeText.Text = string.Empty;
                        //        BarcodeSt = string.Empty;
                        //        txtItemName.Text = string.Empty;
                        //        txtItemName.Focus();
                        //    }
                        //}
                        //else
                        //{
                            lblBarcodeText.Text = System.DateTime.Today.ToString("ddMMyyyy") + "-" + count;
                            //lblBarcodeText.Text = System.DateTime.Today.ToString("ddMMyyyy") + txtItemName.Text.Trim() + "-" + count;
                            lblBarcode.Text = lblBarcodeText.Text;
                            BarcodeSt = lblBarcodeText.Text;
                            MBarcodeSt = string.Empty;
                       // }


                        /// Barcode**************************************                        
                        int W = Convert.ToInt32(460);
                        int H = Convert.ToInt32(60);
                        b.Alignment = BarcodeLib.AlignmentPositions.CENTER;

                        //barcode alignment

                        BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;
                        try
                        {
                            if (type != BarcodeLib.TYPE.UNSPECIFIED)
                            {
                                b.IncludeLabel = true;

                                b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone", true);

                                //label alignment and position                                
                                b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;


                                barcodepic.Image = b.Encode(type, this.lblBarcodeText.Text.Trim(), Color.Black, Color.White, W, H);

                            }//if

                            barcodepic.Width = barcodepic.Image.Width;
                            barcodepic.Height = barcodepic.Image.Height;

                            //reposition the barcode image to the middle
                            barcodepic.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - barcodepic.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - barcodepic.Height / 2);
                        }//try
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }//catch
                        // ********************************************************************************************************



                    }
                    else if (UpdateStock == true)
                    {
                        int count = 0;
                        if (PrevItemName != txtItemName.Text.Trim() && string.IsNullOrEmpty(txtMnBarcode.Text.Trim()))
                        {
                            if (int.Parse(sqlhelp.ExecuteScalar("select Count(*) from Transactions where Barcode='" + BarcodeSt + "'")) > 0)
                            {
                                FrmMessage.Show("You cannot change the Barcode as it is being referenced in the sales. If you still want to change then Enter the barcode Manually.");
                            }
                            else
                            {
                                sqlhelp = new SQLHelper();
                                DataSet ds = new DataSet();
                                ds = sqlhelp.ExecuteQueries("select iif(Max(ItemId) is null,0,Max(ItemID)) as [ItemId] from Items"); 
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    count = int.Parse(ds.Tables[0].Rows[0]["ItemId"].ToString()) + 1;
                                }
                                else
                                {
                                    count = 1;
                                }

                                //if (count > 1)
                                //{
                                //    if (DialogResult.Yes == FrmMessage.Show("This item already exist in the stock. Do you want to store it with another barcode ?", caption, YesNoButton, QuestionIcon))
                                //    {
                                //        count = int.Parse(ds.Tables[0].Rows[0]["ItemId"].ToString()) + 1;
                                //        lblBarcodeText.Text = System.DateTime.Today.ToString("ddMMyyyy") + "-" + count;
                                //        lblBarcode.Text = lblBarcodeText.Text;
                                //        updatebarcode = lblBarcode.Text;
                                //        MBarcodeSt = string.Empty;
                                //    }
                                //    else
                                //    {
                                //        lblBarcode.Text = BarcodeSt;
                                //        lblBarcodeText.Text = BarcodeSt;
                                //        txtItemName.Text = PrevItemName;
                                //        updatebarcode = lblBarcode.Text;
                                //        MBarcodeSt = string.Empty;
                                //    }
                                //}
                                //else
                                //{
                                    lblBarcodeText.Text = System.DateTime.Today.ToString("ddMMyyyy") + "-" + count;
                                    lblBarcode.Text = lblBarcodeText.Text;
                                    updatebarcode = lblBarcode.Text;
                                    MBarcodeSt = string.Empty;
                                //}
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txtMnBarcode.Text.Trim()))
                            {
                                lblBarcodeText.Text = BarcodeSt;
                                lblBarcode.Text = lblBarcodeText.Text;
                                updatebarcode = lblBarcode.Text;
                                MBarcodeSt = string.Empty;
                            }
                        }
                    }

                    /// Barcode**************************************                        
                    int Width = Convert.ToInt32(260);
                    int Height = Convert.ToInt32(60);
                    b.Alignment = BarcodeLib.AlignmentPositions.CENTER;

                    //barcode alignment

                    BarcodeLib.TYPE type1 = BarcodeLib.TYPE.CODE128;
                    try
                    {
                        if (type1 != BarcodeLib.TYPE.UNSPECIFIED)
                        {
                            b.IncludeLabel = true;

                            b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone", true);

                            //label alignment and position                                
                            b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;


                            barcodepic.Image = b.Encode(type1, this.lblBarcodeText.Text.Trim(), Color.Black, Color.White, Width, Height);

                        }//if

                        barcodepic.Width = barcodepic.Image.Width;
                        barcodepic.Height = barcodepic.Image.Height;

                        //reposition the barcode image to the middle
                        barcodepic.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - barcodepic.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - barcodepic.Height / 2);
                    }//try
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }//catch

                }
                catch (Exception Ex)
                {
                }
            }
            else
            {
                if (UpdateStock == false)
                {
                    lblBarcodeText.Text = string.Empty;
                    lblBarcode.Text = string.Empty;
                    BarcodeSt = string.Empty;
                    MBarcodeSt = string.Empty;
                }
                else
                {
                    lblBarcodeText.Text = string.Empty;
                    lblBarcode.Text = string.Empty;
                }
            }
        }
        OpenFileDialog op1 = new OpenFileDialog();
        string ImageName;
        bool ImageStaus = false;
        private void BtnImageupld_Click(object sender, EventArgs e)
        {
            try
            {
                op1 = new OpenFileDialog();
                op1.Multiselect = false;
                op1.Filter = "Image Files (*.jpg, *.jpeg, *.gif, *.bmp, *.png, *.out)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.out";
                DialogResult result = op1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (PriviewPic.Image != null)
                    {
                        PriviewPic.Image = null;
                    }
                    txtImage.Text = op1.FileName;
                    string[] fname;
                    PriviewPic.Image = System.Drawing.Image.FromFile(op1.FileName);
                    fname = txtImage.Text.Split('\\');
                    fname = fname[fname.Length - 1].ToString().Split('.');
                    ImageName = txtItemName.Text + "." + fname[fname.Length - 1].ToString();
                    op1.RestoreDirectory = true;
                    ImageStaus = true;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void txtMRP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtunitprice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtunitprice.Text) && !string.IsNullOrEmpty(txtStkQuantity.Text))
            {
                if (txtunitprice.Text != "0" && txtStkInvoice.Text != ".")
                {
                    txtStkInvoice.Text = Math.Round((decimal.Parse(txtunitprice.Text) * decimal.Parse(txtStkQuantity.Text)), 2).ToString();
                }
                else
                {
                    txtStkInvoice.Text = "0";
                    txtunitprice.Text = "0";
                }
            }
            else
            {
                txtStkInvoice.Text = "0";
                txtunitprice.Text = "0";
            }
        }

        private void cmbSTKcategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlSupp.SelectedIndex!=0 && cmbSTKcategories.SelectedIndex !=0)
            AutoSuggestItems();
        }

        private void ddlSupp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSupp.SelectedIndex != 0 && cmbSTKcategories.SelectedIndex != 0)
                AutoSuggestItems();
        }

        private void txtunitprice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void AddGroup_Enter(object sender, EventArgs e)
        {

        }

        private void SearchGroup_Enter(object sender, EventArgs e)
        {

        }

     



    }
}
