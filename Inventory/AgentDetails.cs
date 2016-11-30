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
    public partial class AgentDetails : Form
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


        public AgentDetails()
        {
            InitializeComponent();
        }

        private void btnTbSearch_Click(object sender, EventArgs e)
        {
            SearchGroup.Visible = true;
            AddGroup.Visible = false;
            btnTbAdd.Text = "Add";
            
        }

        private void btnTbAdd_Click(object sender, EventArgs e)
        {
            btnTbAdd.Text = "Add";
            SearchGroup.Visible = false;
            AddGroup.Visible = true;
            textBox4.Visible = false;
            txtMobile.Visible = true;
         
            btnSave.Text = "Add";
            btnClear.Text = "Clear";

           
        }

       

        private void PAssignCards_Load(object sender, EventArgs e)
        {
           
            textBox3.Visible = false;
            label13.Visible = false;
            SearchGroup.Visible = true;
            AddGroup.Visible = false;
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
          
        }

        private void fillddlrole()
    {
        sqlhelp = new SQLHelper();
        DataSet ds = new DataSet();
        ds = sqlhelp.ExecuteQueries("select PSNo, CARDNUMBER from CARDFREE");
        if (ds.Tables[0].Rows.Count > 0)
        {
        
        }
    }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtEmpName.Text) || string.IsNullOrEmpty(txtMobile.Text) || string.IsNullOrEmpty(txtAddr.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
            }
            else
            {
                if (btnSave.Text == "Add")
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("insert into AGENT(DNAME, MOBILE, ADDRESS, EMAIL, DOB,MemberNo,CreatedBy,ISACTIVE) values" +
                                                     "('" + txtEmpName.Text + "','" + txtMobile.Text + "','" + txtAddr.Text + "','" + txtEmail.Text + "','" + ddlFromDate.Text + "','" + textBox3.Text + "'," + GlobalData.UserID + ",'" + comboBox1.Text + "')");
                    
                   
                }

                else
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("UPDATE AGENT SET DNAME ='" + txtEmpName.Text + "', MOBILE='" + textBox4.Text + "', ADDRESS='" + txtAddr.Text + "', EMAIL='" + txtEmail.Text + "', DOB='" + ddlFromDate.Text + "' where " +
                                                   "ANO=" + PCUSID + "");


                }

                if (result == true)
                {
                    FrmMessage.Show("Transaction Success");
                    clear();
                    fillddlrole();
                    SearchGroup.Visible = true;
                    AddGroup.Visible = false;

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
           //txtPwd.Text = string.Empty;
           textBox3.Text = string.Empty;
           textBox4.Text = string.Empty;

        }


        private void btnSrchSupp_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
           DataSet ds = new DataSet();
           ds = sqlhelp.ExecuteQueries("select * FROM AGENT where Mobile = '" + textBox1.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Cat_ItemGrid.DataSource = ds.Tables[0];
                //Cat_ItemGrid.Columns["PCUSID"].Visible = false;
                Cat_ItemGrid.Columns["DealerID"].Visible = false;
                Cat_ItemGrid.Columns["CreatedBy"].Visible = false;
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        private void Cat_ItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddGroup.Visible = true;
            AddGroup.Location = new System.Drawing.Point(20, 38);
            SearchGroup.Visible = false;
            txtMobile.Visible = false;
            textBox4.Visible = true;
            textBox3.Visible = true;
            label13.Visible = true;

          

            btnTbAdd.Text = "Edit";
            btnSave.Text = "Update";
            btnClear.Text = "Delete";
            PCUSID = int.Parse(Cat_ItemGrid.CurrentRow.Cells[0].Value.ToString());
            //PSNO = int.Parse(Cat_ItemGrid.CurrentRow.Cells[8].Value.ToString());
            txtEmpName.Text = Cat_ItemGrid.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = Cat_ItemGrid.CurrentRow.Cells[2].Value.ToString();
            txtMobile.Text = Cat_ItemGrid.CurrentRow.Cells[1].Value.ToString(); //dummy field to stop recheck on mobile
            txtAddr.Text = Cat_ItemGrid.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = Cat_ItemGrid.CurrentRow.Cells[4].Value.ToString();
            //txtPwd.Text = Cat_ItemGrid.CurrentRow.Cells[5].Value.ToString();
            ddlFromDate.Text = Cat_ItemGrid.CurrentRow.Cells[5].Value.ToString();
             textBox3.Text = Cat_ItemGrid.CurrentRow.Cells[6].Value.ToString();
            comboBox1.Text = Cat_ItemGrid.CurrentRow.Cells[9].Value.ToString();
            textBox3.Visible = false;
            label13.Visible = false;

        }

        private void DealerDetails_Load(object sender, EventArgs e)
        {
           comboBox1.SelectedIndex = 0;
            //textBox3.Visible = false;
            //label13.Visible = false;
            SearchGroup.Visible = true;
            AddGroup.Visible = false;
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select PSNo, CARDNUMBER from CARDFREE");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //ddlRole.DisplayMember = "CARDNUMBER";
                //ddlRole.ValueMember = "PSNo";
                //ddlRole.DataSource = ds.Tables[0];
            }
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            //textBox3.Text = txtMobile.Text;

        }

        private void txtAddr_Enter(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select * FROM AGENT where MOBILE = '" + txtMobile.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                FrmMessage.Show("This Mobile No is Already Registered, Please try with Different Mobile No", caption, OkButton, InformationIcon);
                txtMobile.Focus();

               
                
            }
            else
            {
                textBox3.Text = txtMobile.Text;
                txtAddr.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select * FROM AGENT where MemberNo = '" + textBox2.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Cat_ItemGrid.DataSource = ds.Tables[0];
                //Cat_ItemGrid.Columns["PCUSID"].Visible = false;
                Cat_ItemGrid.Columns["ANO"].Visible = false;
                Cat_ItemGrid.Columns["CreatedBy"].Visible = false;
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select * FROM AGENT");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Cat_ItemGrid.DataSource = ds.Tables[0];
                //Cat_ItemGrid.Columns["PCUSID"].Visible = false;
                Cat_ItemGrid.Columns["ANO"].Visible = false;
                Cat_ItemGrid.Columns["CreatedBy"].Visible = false;
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        private void DealerDetails_Load_1(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            
            SearchGroup.Visible = true;
            AddGroup.Visible = false;
            

        }

       
    }
}
