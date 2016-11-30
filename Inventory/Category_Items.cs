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
using System.Collections;
using IMDal;

namespace Inventory
{
    public partial class Category_Items : Form
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

        // DataSet ds = new DataSet();
        SQLHelper sqlhelp = new SQLHelper();
        bool Result = false;
        OpenFileDialog op1 = new OpenFileDialog();
        string ImageName;
        int CatID;
        int ItemID;
        int SupplierID;
        bool ImageStaus;

        int SearchID;

        public Category_Items()
        {
            InitializeComponent();
            fillSearchCategory();          
            fillSupplier(ddlsrchSupp);           
        }

        private void fillSearchCategory()
        {
            try
            {
                DataSet DS = new DataSet();
                ECategory Ecategory = new ECategory();
                DS = Ecategory.GETALLCATEGORY(Ecategory);
                DataRow dr = DS.Tables[0].NewRow();
                dr["CategoryName"] = "Select";
                dr["CategoryID"] = "%";
                DS.Tables[0].Rows.InsertAt(dr, 0);
                // search category box filling
                SrchcmbCategory.DataSource = DS.Tables[0];
                SrchcmbCategory.DisplayMember = "CategoryName";
                SrchcmbCategory.ValueMember = "CategoryID";


            }
            catch (Exception ex)
            {
            }
        }
        private void fillSupplier(ComboBox cmb)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = sqlhelp.ExecuteTables("select cstr(SupplierID) as [SupplierID],SupplierName from Supplier");
                DataRow dr = dt.NewRow();
                dr["SupplierName"] = "Select";
                if (cmb.Name == "ddlsupp")
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
            catch (Exception ex)
            {
            }
            finally
            {
            }

        }

        private void btnaddcategory_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtnewCategory.Text.Trim()))
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
            }
            else
            {
                if (btnaddcategory.Text == "Add")
                {
                    Result = sqlhelp.ExecuteNonQuery("insert into Categories (CategoryName,CategoryDescription,Createdby) " +
                             "values('" + txtnewCategory.Text.Trim() + "','" + rtbDescCategory.Text + "'," + GlobalData.UserID + ")");
                    if (Result == true)
                    {
                        FrmMessage.Show("Category Added successfully", caption, OkButton, InformationIcon);                  
                        fillSearchCategory();
                        ClearCategoryTextBoxes();
                    }
                }

                else
                {
                    Result = sqlhelp.ExecuteNonQuery("Update Categories Set CategoryName = '" + txtnewCategory.Text + "'," +
                                                    "CategoryDescription='" + rtbDescCategory.Text + "',UpdatedBy=" + GlobalData.UserID + "" +
                                                    " where CategoryID= " + CatID + "");

                    if (Result == true)
                    {
                        FrmMessage.Show("Category Updated successfully", caption, OkButton, InformationIcon);                        
                        fillSearchCategory();
                        btnTbSearch_Click(sender, e);
                    }
                }

            }

        }

      
        private void Category_Items_Load(object sender, EventArgs e)
        {
            AddGroup.Visible = false;
            SearchGroup.Visible = true;
            Cat_ItemGrid.Visible = false;           
        }

        private void Category_Items_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTbSearch_Click(object sender, EventArgs e)
        {
            SearchGroup.Visible = true;
            AddGroup.Visible = false;
            btnTbAdd.Text = "Add";
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = false;
            Cat_ItemGrid.Visible = false;
        }

        private void btnTbAdd_Click(object sender, EventArgs e)
        {
            btnTbAdd.Text = "Add";
            SearchGroup.Visible = false;
            AddGroup.Visible = true;
            SuppGroup.Visible = true;
            CatGroup.Visible = true;
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = false;
            btnaddcategory.Text = "Add";
            btnClearCat.Text = "Clear";
            btnSupplier.Text = "Add";
            btnClearSup.Text = "Clear";
            ClearCategoryTextBoxes();
            btnClearSup_Click(sender, e);
            
           
        }

        private void BtnSrchCategory_Click(object sender, EventArgs e)
        {
            try
            {
                SearchID = 0;
                Cat_ItemGrid.Visible = true;
                Cat_ItemGrid.DataSource = null;
                Cat_ItemGrid.Columns.Clear();
                string Category = "";
                if (SrchcmbCategory.SelectedValue.ToString() == "0")
                {
                    Category = "%";
                }
                else
                {
                    Category = SrchcmbCategory.SelectedValue.ToString();
                }
                DataSet ds = new DataSet();
                ds = sqlhelp.ExecuteQueries("select CategoryID,CategoryName,CategoryDescription from Categories where " +
                                            "CategoryID like '" + Category + "'");
                Cat_ItemGrid.DataSource = ds.Tables[0];
                Cat_ItemGrid.Columns["CategoryID"].Visible = false;

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

        }

       
       
       
        private void btnClearCat_Click(object sender, EventArgs e)
        {
            if (btnClearCat.Text == "Delete")
            {
                int count;
                bool Result;
                sqlhelp = new SQLHelper();
                count = int.Parse(sqlhelp.ExecuteScalar("select count(*) from Items where CategoryID= " + CatID + ""));
                if (count == 0)
                {
                    if (DialogResult.Yes == FrmMessage.Show("Are you Sure. You want to Delete this Category ?", caption, YesNoButton, QuestionIcon))
                    {
                        Result = sqlhelp.ExecuteNonQuery("delete from Categories where CategoryID=" + CatID + "");
                        if (Result == true)
                        {
                            FrmMessage.Show("Category Deleted Successfully", caption, OkButton, InformationIcon);
                            btnClearCat.Text = "Clear";
                            btnaddcategory.Text = "Add";                            
                            fillSearchCategory();
                            btnTbSearch_Click(sender, e);
                        }
                    }
                }
                else
                {
                    FrmMessage.Show("You Cannot Delete this Category. First Delete the Items of this Category", caption, OkButton, InformationIcon);
                    btnClearCat.Text = "Clear";
                    btnaddcategory.Text = "Add";
                    btnTbSearch_Click(sender, e);

                }
            }
            else
            {
                ClearCategoryTextBoxes();
            }
        }      

        private void ClearCategoryTextBoxes()
        {
            txtnewCategory.Text = string.Empty;
            rtbDescCategory.Text = string.Empty;

        }
     

        private void Cat_ItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddGroup.Visible = true;
            SearchGroup.Visible = false;
            btnTbAdd.Text = "Edit";
            if (SearchID == 0)
            {
                btnaddcategory.Text = "Update";
                btnClearCat.Text = "Delete";
                splitContainer1.Panel2Collapsed = false;
                splitContainer1.Panel1Collapsed = true;
                SuppGroup.Visible = false;
                CatGroup.Visible = true;
                CatID = int.Parse(Cat_ItemGrid.CurrentRow.Cells["CategoryID"].Value.ToString());

                txtnewCategory.Text = Cat_ItemGrid.CurrentRow.Cells["CategoryName"].Value.ToString();
                rtbDescCategory.Text = Cat_ItemGrid.CurrentRow.Cells["CategoryDescription"].Value.ToString();
            }
            else if (SearchID == 2)
            {

                btnSupplier.Text = "Update";
                btnClearSup.Text = "Delete";
                splitContainer1.Panel2Collapsed = true;
                splitContainer1.Panel1Collapsed = false;
                SuppGroup.Visible = true;
                CatGroup.Visible = false;
                SupplierID = int.Parse(Cat_ItemGrid.CurrentRow.Cells["SupplierID"].Value.ToString());
                textBox2.Enabled = false;
                textBox2.Text = Cat_ItemGrid.CurrentRow.Cells["SupplierID"].Value.ToString();
                txtSupName.Text = Cat_ItemGrid.CurrentRow.Cells["S Name"].Value.ToString();
                txtSupPhone.Text = Cat_ItemGrid.CurrentRow.Cells["S Phone"].Value.ToString();
                txtaddress.Text = Cat_ItemGrid.CurrentRow.Cells["Address"].Value.ToString();

                cmbSTKcategories.Text = Cat_ItemGrid.CurrentRow.Cells["Supplier Type"].Value.ToString();
                textBox1.Text = Cat_ItemGrid.CurrentRow.Cells["Incharge"].Value.ToString();
                textBox3.Text = Cat_ItemGrid.CurrentRow.Cells["Incharge Phone"].Value.ToString();
                textBox5.Text = Cat_ItemGrid.CurrentRow.Cells["City"].Value.ToString();
                textBox6.Text = Cat_ItemGrid.CurrentRow.Cells["State"].Value.ToString();
                textBox4.Text = Cat_ItemGrid.CurrentRow.Cells["Email"].Value.ToString();
                textBox7.Text = Cat_ItemGrid.CurrentRow.Cells["CST Reg No"].Value.ToString();
                textBox8.Text = Cat_ItemGrid.CurrentRow.Cells["GST No"].Value.ToString();
                textBox9.Text = Cat_ItemGrid.CurrentRow.Cells["TIN NO"].Value.ToString();
                textBox10.Text = Cat_ItemGrid.CurrentRow.Cells["Remarks"].Value.ToString();

                textBox11.Text = Cat_ItemGrid.CurrentRow.Cells["Bank Name"].Value.ToString();
                textBox12.Text = Cat_ItemGrid.CurrentRow.Cells["Acc No"].Value.ToString();
                textBox13.Text = Cat_ItemGrid.CurrentRow.Cells["Bank Code"].Value.ToString();
            }
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (string.IsNullOrEmpty(txtSupName.Text.Trim()) || string.IsNullOrEmpty(txtSupPhone.Text.Trim()))
            //    {
            //        FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
            //    }
            //    else
            //    {
                                    

            //        if (btnSupplier.Text == "Add")
            //        {
            //            if (int.Parse(sqlhelp.ExecuteScalar("select Count(*) from Supplier where SupplierName='" + txtSupName.Text.Trim() + "'")) != 0)
            //            {
            //                FrmMessage.Show("Supplier Already Exists");
            //            }
            //            else
            //            {
            //                bool result = sqlhelp.ExecuteNonQuery("insert into Supplier (SupplierName,SupplierPhone,Address,CreatedBy) values " +
            //                    "('" + txtSupName.Text.Trim() + "','" + txtSupPhone.Text.Trim() + "','" + txtaddress.Text.Trim() + "'," + GlobalData.UserID + ")");
            //                if (result == true)
            //                {
            //                    FrmMessage.Show("Supplier Added successfully");                                
            //                    btnClearSup_Click(sender, e);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (int.Parse(sqlhelp.ExecuteScalar("select Count(*) from Supplier where SupplierName='" + txtSupName.Text.Trim() + "' and SupplierID <> " + SupplierID + " ")) != 0)
            //            {
            //                FrmMessage.Show("Supplier Already Exists");
            //            }
            //            else
            //            {
            //                bool result = sqlhelp.ExecuteNonQuery("Update Supplier set SupplierName='" + txtSupName.Text.Trim() + "'," +
            //                    "SupplierPhone='" + txtSupPhone.Text.Trim() + "',Address='" + txtaddress.Text.Trim() + "',CreatedBy=" + GlobalData.UserID + "" +
            //                    " where SupplierID=" + SupplierID + "");
            //                if (result == true)
            //                {
            //                    FrmMessage.Show("Supplier Updated successfully");
            //                    btnTbAdd_Click(sender, e);
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}

            try
            {
                if (string.IsNullOrEmpty(txtSupName.Text.Trim()) || string.IsNullOrEmpty(txtSupPhone.Text.Trim()))
                {
                    FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
                }
                else
                {


                    if (btnSupplier.Text == "Add")
                    {
                        if (int.Parse(sqlhelp.ExecuteScalar("select Count(*) from Supplier where SupplierName='" + txtSupName.Text.Trim() + "'")) != 0)
                        {
                            FrmMessage.Show("Supplier Already Exists");
                        }
                        else
                        {
                            bool result = sqlhelp.ExecuteNonQuery("insert into Supplier (SupplierName,SupplierPhone,Address,CreatedBy,SupplierType,ContactPerson,ContactPersonPhone,City,State,Email,CSTRegNo,APGSTNo,TINNo,Remarks,BankName,AccNo,BankCode) values " +
                                "('" + txtSupName.Text.Trim() + "','" + txtSupPhone.Text.Trim() + "','" + txtaddress.Text.Trim() + "'," + GlobalData.UserID + ",'" + cmbSTKcategories.Text.Trim() + "','" + textBox1.Text.Trim() + "','" + textBox3.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox4.Text.Trim() + "','" + textBox7.Text.Trim() + "','" + textBox8.Text.Trim() + "','" + textBox9.Text.Trim() + "','" + textBox10.Text.Trim() + "','" + textBox11.Text.Trim() + "','" + textBox12.Text.Trim() + "','" + textBox13.Text.Trim() + "')");
                            if (result == true)
                            {
                                FrmMessage.Show("Supplier Added successfully");
                                btnClearSup_Click(sender, e);
                            }
                        }
                    }
                    else
                    {
                        if (int.Parse(sqlhelp.ExecuteScalar("select Count(*) from Supplier where SupplierName='" + txtSupName.Text.Trim() + "' and SupplierID <> " + SupplierID + " ")) != 0)
                        {
                            FrmMessage.Show("Supplier Already Exists");
                        }
                        else
                        {
                            bool result = sqlhelp.ExecuteNonQuery("Update Supplier set SupplierName='" + txtSupName.Text.Trim() + "'," +
                                "SupplierPhone='" + txtSupPhone.Text.Trim() + "',Address='" + txtaddress.Text.Trim() + "',CreatedBy=" + GlobalData.UserID + ",SupplierType='" + cmbSTKcategories.Text.Trim() + "',ContactPerson='" + textBox1.Text.Trim() + "',ContactPersonPhone='" + textBox3.Text.Trim() + "',City='" + textBox5.Text.Trim() + "',State='" + textBox6.Text.Trim() + "',Email='" + textBox4.Text.Trim() + "',CSTRegNo='" + textBox7.Text.Trim() + "',APGSTNo='" + textBox8.Text.Trim() + "',TINNo='" + textBox9.Text.Trim() + "',Remarks='" + textBox10.Text.Trim() + "',BankName='" + textBox11.Text.Trim() + "',AccNo='" + textBox12.Text.Trim() + "',BankCode='" + textBox13.Text.Trim() + "'" +
                                " where SupplierID=" + SupplierID + "");
                            if (result == true)
                            {
                                FrmMessage.Show("Supplier Updated successfully");
                                btnTbAdd_Click(sender, e);
                                SearchGroup.Visible = true;
                                AddGroup.Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnClearSup_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnClearSup.Text == "Clear")
                {
                    txtaddress.Text = string.Empty;
                    txtSupName.Text = string.Empty;
                    txtSupPhone.Text = string.Empty;
                    txtSupName.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    //cmbSTKcategories.SelectedValue = 1;
                    txtSupPhone.Text = string.Empty;
                    textBox1.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    txtaddress.Text = string.Empty;
                    textBox5.Text = string.Empty;
                    textBox6.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    textBox7.Text = string.Empty;
                    textBox8.Text = string.Empty;
                    textBox9.Text = string.Empty;
                    textBox10.Text = string.Empty;
                    textBox11.Text = string.Empty;
                    textBox12.Text = string.Empty;
                    textBox13.Text = string.Empty;
                }
                else
                {
                    int count = int.Parse(sqlhelp.ExecuteScalar("select count(*) from Items where SupplierID= " + SupplierID + ""));
                    if (count == 0)
                    {
                        if (DialogResult.Yes == FrmMessage.Show("Are you Sure. You want to Delete this Supplier ?", caption, YesNoButton, QuestionIcon))
                        {
                            bool result = sqlhelp.ExecuteNonQuery("delete from Supplier where SupplierID=" + SupplierID + "");
                        }
                    }
                    else
                    {
                        FrmMessage.Show("You Cannot Delete this Supplier. First Delete the Items of this Supplier from Stock", caption, OkButton, InformationIcon);
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

        private void btnSrchSupp_Click(object sender, EventArgs e)
        {
            try
            {
                SearchID = 2;
                Cat_ItemGrid.Visible = true;
                Cat_ItemGrid.DataSource = null;
                Cat_ItemGrid.Columns.Clear();
                DataSet ds = new DataSet();
                ds = sqlhelp.ExecuteQueries("select supplierID,suppliername as [S Name], SupplierPhone as [S Phone],Address,SupplierType as [Supplier Type],contactperson as [Incharge],contactpersonphone as [Incharge Phone],City,State, Email,CSTRegNo as [CST Reg No], APGSTNo as [GST No],TINNo as [TIN No],Remarks, BankName as [Bank Name], ACCNO as [Acc No],BankCode as [Bank Code] from Supplier where " +
                                            "SupplierID like '" + ddlsrchSupp.SelectedValue.ToString() + "'");
                Cat_ItemGrid.DataSource = ds.Tables[0];
                Cat_ItemGrid.Columns["SupplierID"].Visible = false;
                Cat_ItemGrid.Columns["CreatedBy"].Visible = false;
                Cat_ItemGrid.Columns["CreatedDate"].Visible = false;
                Cat_ItemGrid.Columns["UpdatedBy"].Visible = false;
                Cat_ItemGrid.Columns["UpdatedDate"].Visible = false;

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void txtSupPhone_KeyPress(object sender, KeyPressEventArgs e)
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


    }
}
