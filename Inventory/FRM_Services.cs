using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMDal;
using System.IO;

namespace Inventory
{
    public partial class FRM_Services : Form
    {
        SQLHelper sqlhelp = new SQLHelper();
        OpenFileDialog op1 = new OpenFileDialog();
        string ImageName;
        bool ImageStaus = false;
        #region global Declaration for custom messagebox
        FrmMessage.enumMessageIcon InformationIcon = FrmMessage.enumMessageIcon.Information;
        FrmMessage.enumMessageIcon QuestionIcon = FrmMessage.enumMessageIcon.Question;
        FrmMessage.enumMessageIcon ErrorIcon = FrmMessage.enumMessageIcon.Error;

        FrmMessage.enumMessageButton OkButton = FrmMessage.enumMessageButton.OK;
        FrmMessage.enumMessageButton YesNoButton = FrmMessage.enumMessageButton.YesNo;
        FrmMessage.enumMessageButton OkCancelButton = FrmMessage.enumMessageButton.OKCancel;
        string caption = "Inventory Management";
        #endregion     
       
        public FRM_Services()
        {
            InitializeComponent();
        }

        private void FRM_Services_Load(object sender, EventArgs e)
        {
            SearchGroup.Visible = true;
            AddGroup.Visible = false;            
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
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;
                if (string.IsNullOrEmpty(txtServiceName.Text.Trim()) || string.IsNullOrEmpty(txtSrChrg.Text.Trim()))
                {
                    FrmMessage.Show("Fields with * Symbols are Mandatory!!!");
                }
                    
                else if (BtnAdd.Text == "Add")
                {
                    if (Int32.Parse(sqlhelp.ExecuteScalar("select count(ServiceID) from Services where ServiceName='" + txtServiceName.Text.Trim() + "' and ServiceCharge=" + txtSrChrg.Text.Trim() + "")) == 0)
                    {
                        if (string.IsNullOrEmpty(ImageName))
                        {
                            ImageName = "NoImage.jpg";
                        }
                        result = sqlhelp.ExecuteNonQuery("insert into Services([ServiceName],[Image],[ServiceCharge],[Description],[CreatedBy]) Values ('" + txtServiceName.Text.Trim() + "'," +
                         "'" + ImageName + "'," + txtSrChrg.Text.Trim() + ",'" + txtDesc.Text.Trim() + "'," + GlobalData.UserID + ")");
                        if (result == true)
                        {
                            copyimage();
                            FrmMessage.Show("Service Added Successfully ");
                            btnClear.Text = "Clear";
                            btnClear_Click(sender, e);
                        }
                    }
                    else
                    {
                        FrmMessage.Show("Service Name already exists with the specified Service Charge.");
                    }
                }
                else
                {
                    if (Int32.Parse(sqlhelp.ExecuteScalar("select count(ServiceID) from Services where ServiceName='" + txtServiceName.Text.Trim() + "' and ServiceCharge=" + txtSrChrg.Text.Trim() + " and ServiceID <> " + ServicesGrid.CurrentRow.Cells["ServiceID"].Value + "")) == 0)
                    {
                        result = sqlhelp.ExecuteNonQuery("update Services set [ServiceName] ='" + txtServiceName.Text.Trim() + "'," +
                        "[Image]='" + ImageName + "',[ServiceCharge]=" + txtSrChrg.Text.Trim() + ",[Description]='" + txtDesc.Text.Trim() + "' where [ServiceID]=" + ServicesGrid.CurrentRow.Cells["ServiceID"].Value + "");
                        if (result == true)
                        {
                            if (ImageStaus == true)
                            {
                                copyimage();
                            }
                           
                            FrmMessage.Show("Service Updated Successfully ");
                            btnClear.Text = "Clear";
                            btnClear_Click(sender, e);
                        }
                    }
                    else
                    {
                        FrmMessage.Show("This service is already exists.Please try to add another service");
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
                        PriviewPic.Image.Dispose();
                    }
                    txtImage.Text = op1.FileName;
                    string[] fname;
                    PriviewPic.Image = System.Drawing.Image.FromFile(op1.FileName);
                    fname = txtImage.Text.Split('\\');
                    fname = fname[fname.Length - 1].ToString().Split('.');
                    ImageName = txtServiceName.Text.Trim() + txtSrChrg.Text.Trim() + "." + fname[fname.Length - 1].ToString();
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

        private void btnTbAdd_Click(object sender, EventArgs e)
        {

            try
            {
                btnTbAdd.Text = "Add";
                SearchGroup.Visible = false;
                AddGroup.Visible = true;
                BtnAdd.Text = "Add";
                btnClear.Text = "Clear";
                btnClear_Click(sender, e);
                btnClear.Visible = true;
               
                if (string.IsNullOrEmpty(txtSrChrg.Text.Trim()) || decimal.Parse(txtSrChrg.Text) == 0)
                {
                    BtnImageupld.Enabled = false;
                }
                else
                {
                    BtnImageupld.Enabled = true;
                }
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

            try
            {
                SearchGroup.Visible = true;
                AddGroup.Visible = false;
                ServicesGrid.Visible = false;
                btnTbAdd.Text = "Add";
               
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (btnClear.Text == "Clear")
            {
                txtImage.Text = string.Empty;
                txtServiceName.Text = string.Empty;
                BtnImageupld.Enabled = true;
                if (PriviewPic.Image != null)
                {
                    PriviewPic.Image.Dispose();
                }
                this.PriviewPic.InitialImage = global::Inventory.Properties.Resources.Noimage;
                PriviewPic.Image = PriviewPic.InitialImage;
                ImageName = string.Empty;
                txtDesc.Text = string.Empty;
                txtSrChrg.Text = string.Empty;
                btnTbAdd.Text = "Add";
                BtnAdd.Text = "Add";
            }

            else
            {
                if (DialogResult.Yes == FrmMessage.Show("Are you Sure. You want to Delete this Service ?", caption, YesNoButton, QuestionIcon))
                {
                    if (Int32.Parse(sqlhelp.ExecuteScalar("select count(serviceID) from STransDetails where serviceID=" + ServicesGrid.CurrentRow.Cells["ServiceID"].Value + "")) == 0)
                    {
                        sqlhelp.ExecuteNonQuery("delete from Service where ServiceID=" + ServicesGrid.CurrentRow.Cells["ServiceID"].Value + "");
                    }
                    else
                    {
                        FrmMessage.Show("You cannot delete this service as it is referred in ServiceAccounts");
                    }
                }
            }
        }

      

        private void txtSrChrg_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSrChrg.Text.Trim()) || decimal.Parse(txtSrChrg.Text) == 0)
                {
                    BtnImageupld.Enabled = false;
                }
                else
                {
                    BtnImageupld.Enabled = true;
                }
            }
            catch (Exception ex)
            { 
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ServicesGrid.DataSource = null;
                ServicesGrid.Columns.Clear();
                ServicesGrid.Visible = true;
                DataTable dt = new DataTable();
                dt = sqlhelp.ExecuteTables("select ServiceID,ServiceName,ServiceCharge,Description,[Image] from Services where ServiceName like'" + txtServiceName.Text.Trim() + "%'");
                if (dt.Rows.Count > 0)
                {
                    ServicesGrid.DataSource = dt;
                    ServicesGrid.Columns["ServiceID"].Visible = false;
                    ServicesGrid.Columns["Image"].Visible = false;
                }
                else
                {
                    FrmMessage.Show("No Records Found !!");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void FRM_Services_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSrChrg_KeyPress(object sender, KeyPressEventArgs e)
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

        private void ServicesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddGroup.Visible = true;
            SearchGroup.Visible = false;
            BtnAdd.Text = "Update";
            btnClear.Text = "Delete";
            btnTbAdd.Text = "Edit";
            txtServiceName.Text = ServicesGrid.CurrentRow.Cells["ServiceName"].Value.ToString();
            txtSrChrg.Text = ServicesGrid.CurrentRow.Cells["ServiceCharge"].Value.ToString();
            txtDesc.Text = ServicesGrid.CurrentRow.Cells["Description"].Value.ToString();
            if (!string.IsNullOrEmpty(ServicesGrid.CurrentRow.Cells["Image"].Value.ToString()))
            {
                string dir = Application.StartupPath;
                dir = System.IO.Path.Combine(dir, "InventoryImages");
                if (Directory.Exists(dir))
                {
                    string[] ImgName;
                    txtImage.Text = dir + "\\" + ServicesGrid.CurrentRow.Cells["Image"].Value.ToString();
                    ImgName = txtImage.Text.Split('\\');
                    ImageName = ImgName[ImgName.Length - 1];
                    if (PriviewPic.Image != null)
                    {
                        PriviewPic.Image.Dispose();
                    }
                    PriviewPic.Image = System.Drawing.Image.FromFile(txtImage.Text);
                    ImageStaus = false;
                }
            }
            else
            {
                txtImage.Text = string.Empty;
                if (PriviewPic.Image != null)
                {
                    PriviewPic.Image.Dispose();
                }
                this.PriviewPic.InitialImage = global::Inventory.Properties.Resources.Noimage;
                PriviewPic.Image = PriviewPic.InitialImage;
                ImageName = string.Empty;
                ImageStaus = false;
            }
           
        }
    }
}
