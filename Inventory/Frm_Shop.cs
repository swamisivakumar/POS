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
    public partial class Frm_Shop : Form
    {
        SQLHelper sqlhelp = new SQLHelper();
        public Frm_Shop()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtShopName.Text.Trim()) || string.IsNullOrEmpty(txtContact.Text.Trim()) || string.IsNullOrEmpty(txtAddress.Text.Trim()))
                {
                    FrmMessage.Show("Please Enter the Shop Details");
                }
                else
                {
                    if (string.IsNullOrEmpty(ImageName))
                    {
                        ImageName = "NoImage.jpg";
                    }

                    bool result = sqlhelp.ExecuteNonQuery("Update ShopDetails set ShopName='" + txtShopName.Text.Trim() + "'"+
                        ", ContactNo='" + txtContact.Text.Trim() + "',Address = '" + txtAddress.Text.Trim() + "',Logo='" + ImageName + "',DLNO1 = '" + textBox11.Text.Trim() + "',DLNO2 = '" + textBox12.Text.Trim() + "',TIN = '" + textBox13.Text.Trim() + "',CST = '" + textBox6.Text.Trim() + "',PAN = '" + textBox7.Text.Trim() + "'");
                    if (result == true)
                    {
                        copyimage();
                        // ((FrmMain)this.MdiParent).LogoPic.Image=
                        GlobalData.ShopName = txtShopName.Text.Trim();
                        ((FrmMain)this.MdiParent).lblShopName.Text = txtShopName.Text.Trim();
                        GlobalData.Logo = ImageName;
                        FrmMessage.Show("Shop Details Updated Successfully");
                        this.Close();
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

        private void Frm_Shop_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = sqlhelp.ExecuteTables("select ShopID,ShopName,ContactNo,Address,Logo,DLNO1,DLNO2,TIN,CST,PAN from ShopDetails");
            if (dt.Rows.Count > 0)
            {
                txtShopName.Text = dt.Rows[0]["ShopName"].ToString();
                txtContact.Text = dt.Rows[0]["ContactNo"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                textBox11.Text = dt.Rows[0]["DLNO1"].ToString();
                textBox12.Text = dt.Rows[0]["DLNO2"].ToString();
                textBox13.Text = dt.Rows[0]["TIN"].ToString();
                textBox6.Text = dt.Rows[0]["CST"].ToString();
                textBox7.Text = dt.Rows[0]["PAN"].ToString();

                if (!string.IsNullOrEmpty(dt.Rows[0]["Logo"].ToString()))
                {
                    string dir = Application.StartupPath;
                    dir = System.IO.Path.Combine(dir, "ShopImages");
                    if (Directory.Exists(dir))
                    {
                        string[] ImgName;
                        txtImage.Text = dir + "\\" + dt.Rows[0]["Logo"].ToString();
                        ImgName = txtImage.Text.Split('\\');
                        ImageName = ImgName[ImgName.Length - 1];
                        if (((FrmMain)this.MdiParent).LogoPic.Image != null)
                        {
                            ((FrmMain)this.MdiParent).LogoPic.Image.Dispose();
                        }
                        ((FrmMain)this.MdiParent).LogoPic.Image = System.Drawing.Image.FromFile(txtImage.Text);
                        imagePreview.Image = System.Drawing.Image.FromFile(txtImage.Text);
                    }

                }
                else
                {
                    txtImage.Text = string.Empty;
                    if (((FrmMain)this.MdiParent).LogoPic.Image != null)
                    {
                        ((FrmMain)this.MdiParent).LogoPic.Image.Dispose();                        
                    }
                    ImageName = string.Empty;                    
                }
            }
        }

        private void Frm_Shop_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        OpenFileDialog op1 = new OpenFileDialog();
        string ImageName;
        private void copyimage()
        {
            try
            {
                if (imgLogo != null)
                {
                    if (((FrmMain)this.MdiParent).LogoPic.Image != null)
                        ((FrmMain)this.MdiParent).LogoPic.Image.Dispose();

                    ((FrmMain)this.MdiParent).LogoPic.Image = imgLogo;
                    string dir = Application.StartupPath;
                    dir = System.IO.Path.Combine(dir, "ShopImages");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                        ((FrmMain)this.MdiParent).LogoPic.Image.Save(dir + "\\" + ImageName);

                    }
                    else
                    {
                        ((FrmMain)this.MdiParent).LogoPic.Image.Save(dir + "\\" + ImageName);
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
        Image imgLogo;
        private void BtnImageupld_Click(object sender, EventArgs e)
        {
            try
            {
                op1 = new OpenFileDialog();
                op1.Multiselect = false;
                op1.Filter = "Image Files (*.jpg, *.jpeg, *.gif, *.bmp, *.png, *.out)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*.out";
                DialogResult result = op1.ShowDialog();

                if (imagePreview.Image != null)
                {
                    imagePreview.Image.Dispose();
                }

                if (result == DialogResult.OK)
                {
                    txtImage.Text = op1.FileName;
                    string[] fname;
                    imagePreview.Image = System.Drawing.Image.FromFile(op1.FileName);
                    imgLogo = System.Drawing.Image.FromFile(op1.FileName);
                    fname = txtImage.Text.Split('\\');
                    fname = fname[fname.Length - 1].ToString().Split('.');
                    ImageName = "Logo." + fname[fname.Length - 1].ToString();
                    op1.RestoreDirectory = true;
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
    }
}
