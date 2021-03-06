﻿using System;
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
    public partial class Employees : Form
    {
        #region global Declaration for custom messagebox
        FrmMessage.enumMessageIcon InformationIcon = FrmMessage.enumMessageIcon.Information;
        FrmMessage.enumMessageIcon QuestionIcon = FrmMessage.enumMessageIcon.Question;
        FrmMessage.enumMessageIcon ErrorIcon = FrmMessage.enumMessageIcon.Error;
        FrmMessage.enumMessageButton OkButton = FrmMessage.enumMessageButton.OK;
        FrmMessage.enumMessageButton YesNoButton = FrmMessage.enumMessageButton.YesNo;        
        string caption = "Inventory Management";
        #endregion

        SQLHelper sqlhelp = new SQLHelper();
        DataSet ds = new DataSet();
        bool status;
        int EmpId;
        public Employees()
        {
            InitializeComponent();
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            AddGroup.Visible = false;
            SearchGroup.Visible = true;
            LoadRolesDropDown();
            EmpGrid.Visible = false;
        }
        private void LoadRolesDropDown()
        {
            sqlhelp = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("Select RoleID,RoleName from Roles");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["RoleName"] = "Select";
                dr["RoleID"] = 0;
                ds.Tables[0].Rows.InsertAt(dr, 0);
                ddlRole.DataSource = ds.Tables[0];
                ddlRole.DisplayMember = "RoleName";
                ddlRole.ValueMember = "RoleID";

                // bind search dropdown
                SrchddlRole.DataSource = ds.Tables[0];
                SrchddlRole.DisplayMember = "RoleName";
                SrchddlRole.ValueMember = "RoleID";
            }
        }

        private void btnTbSearch_Click(object sender, EventArgs e)
        {
            SearchGroup.Visible = true;
            AddGroup.Visible = false;
            EmpGrid.Visible = false;
            btnTbAdd.Text = "Add";
            txtSrchName.Text = string.Empty;
            SrchddlRole.SelectedValue = "0";
        }

        private void btnTbAdd_Click(object sender, EventArgs e)
        {
            btnTbAdd.Text = "Add";
            btnSave.Text = "Add";
            btnClear.Text = "Clear";
            SearchGroup.Visible = false;
            AddGroup.Visible = true;
            EnableTextboxes(true);
            txtLoginId.Enabled = true;
            ClearTextboxes();           
            ddlRole.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result;

            if (string.IsNullOrEmpty(txtAddr.Text.Trim()) || string.IsNullOrEmpty(txtEmpName.Text.Trim()) || string.IsNullOrEmpty(txtLoginId.Text.Trim()) || string.IsNullOrEmpty(txtMobile.Text.Trim()) || ddlRole.SelectedValue.ToString() == "0")
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory !!!");
            }

            else
            {

                if (btnSave.Text == "Add")
                {
                    if (string.IsNullOrEmpty(txtPwd.Text) || string.IsNullOrEmpty(txtRePwd.Text))
                    {
                        FrmMessage.Show("Fields with * Symbols are Mandatory !!!");
                    }
                    else
                    {
                        if (lblmsg.Visible == true)
                        {
                        }
                        else
                        {
                            int count = int.Parse(sqlhelp.ExecuteScalar("select count(*) from Users where LoginID = '" + txtLoginId.Text.Trim() + "'"));
                            if (count == 0)
                            {
                                status = true;
                                result = sqlhelp.ExecuteNonQuery("INSERT INTO Users([RoleID],[Name],[Address],[Email],[Mobile]," +
                                                        "[LoginID],[Password],[CreatedBy],[IsActive]) Values (" + ddlRole.SelectedValue + ",'" + txtEmpName.Text + "'" +
                                                        ",'" + txtAddr.Text + "','" + txtEmail.Text + "','" + txtMobile.Text + "','" + txtLoginId.Text + "'," +
                                                        " '" + txtPwd.Text + "', " + GlobalData.UserID + "," + status + ")");
                                if (result == true)
                                {
                                    FrmMessage.Show(" Transaction Completed Successfully !!", caption, OkButton, InformationIcon);
                                    ClearTextboxes();
                                }
                                else
                                {
                                    FrmMessage.Show("Transaction Unsuccessful.", caption, OkButton, ErrorIcon);
                                }
                            }
                            else
                            {
                                FrmMessage.Show("This LoginID is already in use !!!", caption, OkButton, ErrorIcon);
                            }
                        }
                    }
                }
                else
                {
                    result = sqlhelp.ExecuteNonQuery("UPDATE Users SET RoleID=" + ddlRole.SelectedValue + "," +
                    "Name='" + txtEmpName.Text + "',Address='" + txtAddr.Text + "',Email='" + txtEmail.Text + "'," +
                    "Mobile='" + txtMobile.Text + "' where UserID=" + EmpId + "");
                    if (result == true)
                    {
                        FrmMessage.Show(" Transaction Completed Successfully !!", caption, OkButton, InformationIcon);
                        btnTbAdd_Click(sender, e);
                    }
                    else
                    {
                        FrmMessage.Show("Transaction Unsuccessful", caption, OkButton, ErrorIcon);
                    }
                }
            }
        }

        private void ClearTextboxes()
        {
            txtAddr.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtEmpName.Text = string.Empty;
            txtLoginId.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtPwd.Text = string.Empty;
            txtRePwd.Text = string.Empty;
            ddlRole.SelectedValue = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (btnClear.Text == "Clear")
            {
                ClearTextboxes();
            }
            else if (btnClear.Text == "DeActivate")
            {

                if (DialogResult.Yes == FrmMessage.Show("Are You Sure You want to Deactivate", caption, YesNoButton, QuestionIcon))
                {
                    
                    if (EmpId == 1)
                    {
                        FrmMessage.Show("You can't De-activate the Main Admin User !!!", caption, OkButton, InformationIcon);
                    }
                    else if (EmpId != 1)
                    {
                        if (int.Parse(GlobalData.UserID) == EmpId)
                        {
                            FrmMessage.Show("You can't De-activate the loggedin User !!!", caption, OkButton, InformationIcon);
                        }
                        else
                        {
                            sqlhelp = new SQLHelper();
                            bool result = sqlhelp.ExecuteNonQuery("Update Users set IsActive=False where UserID= " + EmpId + "");
                            if (result == true)
                            {
                                FrmMessage.Show("Deactivated the user Successfully !!", caption, OkButton, InformationIcon);
                            }
                        }
                    }
                    
                }

                SearchGroup.Visible = true;
                AddGroup.Visible = false;
                btnTbAdd.Text = "Add";
                EmpGrid.Visible = false;
                txtSrchName.Text = string.Empty;
                SrchddlRole.SelectedIndex = 0;
            }
            else if (btnClear.Text == "Activate")
            {
                sqlhelp = new SQLHelper();
                bool result = sqlhelp.ExecuteNonQuery("Update Users set IsActive=True where UserID= " + EmpId + "");
                if (result == true)
                {
                    FrmMessage.Show("Activated the user Successfully", caption, OkButton, InformationIcon);
                }
                SearchGroup.Visible = true;
                AddGroup.Visible = false;
                btnTbAdd.Text = "Add";
                EmpGrid.Visible = false;
                txtSrchName.Text = string.Empty;
                SrchddlRole.SelectedIndex = 0;
            }
        }

        private void txtRePwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPwd.Text == txtRePwd.Text)
                {
                    btnSave_Click(sender, e);
                }
                else
                {
                    lblmsg.Visible = true;
                    txtRePwd.Text = string.Empty;
                }

            }
        }

        private void txtRePwd_TextChanged(object sender, EventArgs e)
        {
            if (txtPwd.Text != txtRePwd.Text)
            {
                lblmsg.Visible = true;
            }
            else
            {
                lblmsg.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EmpGrid.Visible = true;
            string EmpRole = "";
            if (SrchddlRole.SelectedValue.ToString() == "0")
            {
                EmpRole = "%";
            }
            else
            {
                EmpRole = SrchddlRole.SelectedValue.ToString();
            }
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("Select U.UserID,R.RoleID,U.LoginID,R.RoleName,U.Name,U.Address,U.Email," +
                        "U.Mobile,U.IsActive as [Status] from Users U, Roles R where U.RoleID=R.RoleID and U.Name like '" + txtSrchName.Text + "%'" +
                        " and U.RoleID like '" + EmpRole + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                EmpGrid.DataSource = ds.Tables[0];
                EmpGrid.Columns["UserID"].Visible = false;
                EmpGrid.Columns["RoleID"].Visible = false;
            }
            else
            {
                FrmMessage.Show("No Records Found !!!");
                EmpGrid.DataSource = null;
                EmpGrid.Columns.Clear();
            }


        }

        private void EmpGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AddGroup.Visible = true;
                SearchGroup.Visible = false;
                EnableTextboxes(false);
                btnSave.Text = "Update";
                btnTbAdd.Text = "Edit";
                bool status = bool.Parse(EmpGrid.CurrentRow.Cells[8].Value.ToString());
                if (status == true)
                {
                    btnClear.Text = "DeActivate";
                }
                else
                {
                    btnClear.Text = "Activate";
                }
                EmpId = int.Parse(EmpGrid.CurrentRow.Cells[0].Value.ToString());
                if (GlobalData.UserID == "1")
                {
                    ddlRole.Enabled = true;
                }
                else
                {
                    ddlRole.Enabled = false;
                }
                ddlRole.SelectedValue = EmpGrid.CurrentRow.Cells[1].Value;
                txtLoginId.Text = EmpGrid.CurrentRow.Cells[2].Value.ToString();
                txtLoginId.Enabled = false;
                txtEmpName.Text = EmpGrid.CurrentRow.Cells[4].Value.ToString();
                txtAddr.Text = EmpGrid.CurrentRow.Cells[5].Value.ToString();
                txtEmail.Text = EmpGrid.CurrentRow.Cells[6].Value.ToString();
                txtMobile.Text = EmpGrid.CurrentRow.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void EnableTextboxes(bool flag)
        {
            txtPwd.Visible = flag;
            txtRePwd.Visible = flag;
            lblPwd.Visible = flag;
            lblPwdStar.Visible = flag;
            lblRePwd.Visible = flag;
            lblRepwdStar.Visible = flag;
        }

        private void EmpGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (EmpGrid.Columns[e.ColumnIndex].Name == "Status")
            {
                bool columnValue = false;
                if (e.Value != null && bool.TryParse(e.Value.ToString(), out columnValue))
                {
                    if (columnValue == true)
                    {
                        e.Value = "True";
                    }
                    else
                    {
                        e.Value = "False";
                    }
                }
            }
        }

        private void Employees_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
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
