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
    public partial class PAssignCards : Form
    {
        int PSNo;
        Int32 PCUSID;
        Int32 PSNO;
        SQLHelper sqlhelp = new SQLHelper();
        //DataSet ds = new DataSet();

        #region global Declaration for custom messagebox
        FrmMessage.enumMessageIcon InformationIcon = FrmMessage.enumMessageIcon.Information;
        FrmMessage.enumMessageIcon QuestionIcon = FrmMessage.enumMessageIcon.Question;
        FrmMessage.enumMessageIcon ErrorIcon = FrmMessage.enumMessageIcon.Error;

        FrmMessage.enumMessageButton OkButton = FrmMessage.enumMessageButton.OK;
        FrmMessage.enumMessageButton YesNoButton = FrmMessage.enumMessageButton.YesNo;
        FrmMessage.enumMessageButton OkCancelButton = FrmMessage.enumMessageButton.OKCancel;
        string caption = "Inventory Management";
        #endregion


        public PAssignCards()
        {
            InitializeComponent();
        }

        private void btnTbSearch_Click(object sender, EventArgs e)
        {
            SearchGroup.Visible = true;
            AddGroup.Visible = false;
            btnTbAdd.Text = "Add";
            //clear();
        }

        private void btnTbAdd_Click(object sender, EventArgs e)
        {
            btnTbAdd.Text = "Add";
            SearchGroup.Visible = false;
            AddGroup.Visible = true;
            //clear();
            btnSave.Text = "Add";
            btnClear.Text = "Clear";

            textBox3.Visible = false;
            label13.Visible = false;

            //DataSet ds = new DataSet();
            //ds = sqlhelp.ExecuteQueries("select PSNo, CARDNUMBER from CARDFREE");
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    ddlRole.DisplayMember = "CARDNUMBER";
            //    ddlRole.ValueMember = "PSNo";
            //    ddlRole.DataSource = ds.Tables[0];

               

            //}
        }

       

        private void PAssignCards_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox3.Visible = false;
            label13.Visible = false;
            SearchGroup.Visible = true;
            AddGroup.Visible = false;
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select PSNo, CARDNUMBER from CARDFREE");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlRole.DisplayMember = "CARDNUMBER";
                ddlRole.ValueMember = "PSNo";
                ddlRole.DataSource = ds.Tables[0]; 
            }
        }

        private void fillddlrole()
    {
        sqlhelp = new SQLHelper();
        DataSet ds = new DataSet();
        ds = sqlhelp.ExecuteQueries("select PSNo, CARDNUMBER from CARDFREE");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlRole.DisplayMember = "CARDNUMBER";
            ddlRole.ValueMember = "PSNo";
            ddlRole.DataSource = ds.Tables[0];



        }
    }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtEmpName.Text) || string.IsNullOrEmpty(txtMobile.Text) || string.IsNullOrEmpty(txtAddr.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPwd.Text) || string.IsNullOrEmpty(ddlRole.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
            }
            else
            {
                if (btnSave.Text == "Add")
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("insert into PCUSTOMER(NAME, MOBILE, ADDRESS, EMAIL, PROFESSION, DOB,CreatedBy,ISACTIVE) values" +
                                                     "('" + txtEmpName.Text + "','" + txtMobile.Text + "','" + txtAddr.Text + "','" + txtEmail.Text + "','" + txtPwd.Text + "','" + ddlFromDate.Text + "'," + GlobalData.UserID + ",'" + comboBox1.Text + "')");
                    PCUSID = Int32.Parse(sqlhelp.ExecuteScalar("select Max(PCUSID) from PCUSTOMER"));

                    result = sqlhelp.ExecuteNonQuery("insert into PASSIGNCARDS (PCUSID, PSNO,CreatedBy,ISACTIVE) values" +
                                                         "('" + PCUSID + "','" + ddlRole.SelectedValue + "'," + GlobalData.UserID + ",'" + comboBox1.Text + "')");

                }

                else
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("UPDATE PCUSTOMER SET NAME ='" + txtEmpName.Text + "', MOBILE='" + txtMobile.Text + "', ADDRESS='" + txtAddr.Text + "', EMAIL='" + txtEmail.Text + "', PROFESSION='" + txtPwd.Text + "', DOB='" + ddlFromDate.Text + "' where " +
                                                   "PCUSID=" + PCUSID + "");

                    result = sqlhelp.ExecuteNonQuery("UPDATE PASSIGNCARDS SET PSNO ='" + ddlRole.SelectedValue + "' where " +
                                                  "PCUSID=" + PCUSID + "");


                }

                if (result == true)
                {
                    FrmMessage.Show("Transaction Success");
                    clear();
                    fillddlrole();
                    btnTbSearch_Click(sender, e);
                    Cat_ItemGrid.DataSource = null;
                    Cat_ItemGrid.Columns.Clear();
                }
            }

        }

        void clear()
        {
           txtEmail.Text = string.Empty;
           txtEmpName.Text = string.Empty;
           txtAddr.Text = string.Empty;
           txtMobile.Text = string.Empty;
           txtPwd.Text = string.Empty;
           textBox1.Text = string.Empty;
           textBox2.Text = string.Empty;

        }


        private void btnSrchSupp_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
           DataSet ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select * FROM PCARDSEARCH where name like '"+ textBox2.Text +"%' or cardnumber like '" + textBox1.Text + "%'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Cat_ItemGrid.DataSource = ds.Tables[0];
                //Cat_ItemGrid.Columns["PCUSID"].Visible = false;
                Cat_ItemGrid.Columns["PSNO"].Visible = false;
                Cat_ItemGrid.Columns["PACNO"].Visible = false;
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        private void Cat_ItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddGroup.Visible = true;
            AddGroup.Location = new System.Drawing.Point(20, 38);
            SearchGroup.Visible = false;

            textBox3.Visible = true;
            label13.Visible = true;

          

            btnTbAdd.Text = "Edit";
            btnSave.Text = "Update";
            btnClear.Text = "Delete";
            PCUSID = int.Parse(Cat_ItemGrid.CurrentRow.Cells[0].Value.ToString());
            PSNO = int.Parse(Cat_ItemGrid.CurrentRow.Cells[8].Value.ToString());
            txtEmpName.Text = Cat_ItemGrid.CurrentRow.Cells[1].Value.ToString();
            txtMobile.Text = Cat_ItemGrid.CurrentRow.Cells[2].Value.ToString();
            txtAddr.Text = Cat_ItemGrid.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = Cat_ItemGrid.CurrentRow.Cells[4].Value.ToString();
            txtPwd.Text = Cat_ItemGrid.CurrentRow.Cells[5].Value.ToString();
            ddlFromDate.Text = Cat_ItemGrid.CurrentRow.Cells[6].Value.ToString();
             textBox3.Text = Cat_ItemGrid.CurrentRow.Cells[10].Value.ToString();
            comboBox1.Text = Cat_ItemGrid.CurrentRow.Cells[9].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

       
    }
}
