using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMEntity;
using System.Diagnostics;
using IMDal;
using System.IO;
namespace Inventory
{
    public partial class frmLogin : Form
    {
        bool _bTrial = true;
        DataTable dt = new DataTable();
        Boolean var_drag;
        Point var_ClickedAt;
        ELogin elogin;
        SQLHelper sqlhelp = new SQLHelper();
        object obj;
        SecureDongle SecDongle = new SecureDongle();
        #region global Declaration for custom messagebox
        FrmMessage.enumMessageIcon InformationIcon = FrmMessage.enumMessageIcon.Information;
        FrmMessage.enumMessageIcon ErrorIcon = FrmMessage.enumMessageIcon.Error;
        FrmMessage.enumMessageButton OkButton = FrmMessage.enumMessageButton.OK;
        string caption = "Inventory Management";
        #endregion

        public frmLogin(bool bTrial)
        {
            _bTrial = bTrial;
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //string error = SecDongle.SecureDongleCheck();
            //if (error != null)
            //{
            //    FrmMessage.Show(error, caption, OkButton, ErrorIcon);
            //    Application.ExitThread();
            //}
            pnlLogin.Visible = true;
            pnlForgetpwd.Visible = false;
            pnlShop.Visible = false;
            // ddlRes.Text = "1280 x 1024";

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                const int WS_CAPTION = 0xC00000;
                cp.Style = cp.Style & ~WS_CAPTION;
                return cp;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            try
            {
                Application.ExitThread();
            }
            catch (Exception ex)
            {


            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }

        private void LoginCheck()
        {
            try
            {
                elogin = new ELogin();
                elogin.LoginID = txtLoginId.Text;
                elogin.Password = txtPwd.Text;
                obj = new object();
                obj = elogin.CheckLogin(elogin);
                DataSet ds = (DataSet)obj;
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    if (dr["Password"].ToString() == txtPwd.Text)
                    {
                        GlobalData.UserID = dr["UserID"].ToString();
                        GlobalData.RoleId = dr["RoleID"].ToString();
                        GlobalData.RoleName = dr["RoleName"].ToString();
                        GlobalData.UserName = dr["Name"].ToString();

                        if (int.Parse(sqlhelp.ExecuteScalar("select Count(ShopID) from ShopDetails")) == 0)
                        {
                            pnlLogin.Visible = false;
                            pnlForgetpwd.Visible = false;
                            pnlShop.Visible = true;
                        }
                        else
                        {
                            DataTable dtshopdet = new DataTable();
                            dtshopdet = sqlhelp.ExecuteTables("select ShopName,Logo from ShopDetails");
                            GlobalData.ShopName = dtshopdet.Rows[0]["ShopName"].ToString();
                            GlobalData.Logo = dtshopdet.Rows[0]["Logo"].ToString();
                            this.Hide();
                            FrmMain main = new FrmMain();
                            main.Show();
                        }


                        //if (GlobalData.RoleId == "1")
                        //{
                        //    this.Hide();
                        //    FrmMain main = new FrmMain();
                        //    main.Show();

                        //}
                        //else if (GlobalData.RoleId == "2")
                        //{
                        //    this.Hide();
                        //    FrmMain main = new FrmMain();
                        //    main.Show();
                        //}
                        //else if (GlobalData.RoleId == "3")
                        //{
                        //    this.Hide();
                        //    FrmMain main = new FrmMain();
                        //    main.Show();
                        //}

                    }
                    else
                        FrmMessage.Show("Invalid Password.Password is Case Sensitive");
                }
                else
                    FrmMessage.Show("Invalid User ID/ Password. Please try again.");
            }
            catch (Exception ex)
            {

            }
            finally
            { }
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var_drag = true;
                var_ClickedAt = new Point(e.X, e.Y);
            }
            else
            {
                var_drag = false;
            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            var_drag = false;
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (var_drag == true)
            {
                Point var_point;
                var_point = this.PointToScreen(new Point(e.X, e.Y));
                var_point.Offset(-var_ClickedAt.X, -var_ClickedAt.Y);
                this.Location = var_point;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtLoginId.Text = string.Empty;
            txtPwd.Text = string.Empty;
            txtLoginId.Focus();
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void lnkFrgtPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlLogin.Visible = false;
            pnlForgetpwd.Visible = true;
            pnlShop.Visible = false;
        }

        private void btnCnl_Click(object sender, EventArgs e)
        {
            pnlLogin.Visible = true;
            pnlForgetpwd.Visible = false;
            pnlShop.Visible = false;

        }

        private void btngetpwd_Click(object sender, EventArgs e)
        {
            try
            {
                sqlhelp = new SQLHelper();
                dt = new DataTable();
                dt = sqlhelp.ExecuteTables("SELECT U.[LoginID],U.[Password] " +
                                                "FROM Users U,Roles R WHERE R.RoleID=U.RoleID AND " +
                                                "U.LoginID = '" + txtFrgLoginID.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    txtFrgPwd.Text = dt.Rows[0]["Password"].ToString();
                }
                else
                {
                    FrmMessage.Show("Invalid LoginID.Please Re-Enter the LoginID");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.coderobotics.com");
        }

        private void copyimage()
        {
            try
            {
                if (PriviewPic.Image != null)
                {
                    string dir = Application.StartupPath;
                    dir = System.IO.Path.Combine(dir, "ShopImages");
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
        OpenFileDialog op1 = new OpenFileDialog();
        string ImageName;

        private void btnUpload_Click(object sender, EventArgs e)
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
                    txtlogo.Text = op1.FileName;
                    string[] fname;
                    PriviewPic.Image = System.Drawing.Image.FromFile(op1.FileName);
                    fname = txtlogo.Text.Split('\\');
                    fname = fname[fname.Length - 1].ToString().Split('.');
                    ImageName = "Logo" + "." + fname[fname.Length - 1].ToString();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;
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
                    result = sqlhelp.ExecuteNonQuery("insert into ShopDetails([ShopName],[ContactNo],[Address],[Logo],[CreatedBy]) values('" + txtShopName.Text.Trim() + "'," +
                                        "'" + txtContact.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + ImageName + "'," + GlobalData.UserID + ")");
                }

                if (result == true)
                {
                    copyimage();
                    FrmMessage.Show("Shop Details addedd successfully");

                    GlobalData.ShopName = txtShopName.Text.Trim();
                    GlobalData.Logo = ImageName;
                    this.Hide();
                    FrmMain main = new FrmMain();
                    main.Show();
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
