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
    public partial class AgentComission : Form
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


        public AgentComission()
        {
            InitializeComponent();
        }

        private void btnTbSearch_Click(object sender, EventArgs e)
        {
            SearchGroup.Visible = true;
            AddGroup.Visible = false;
            btnTbAdd.Text = "Add";
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void btnTbAdd_Click(object sender, EventArgs e)
        {
            btnTbAdd.Text = "Add";
            SearchGroup.Visible = false;
            AddGroup.Visible = true;
            //textBox4.Visible = false;
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
            if (string.IsNullOrEmpty(textBox3.Text) || comboBox1.SelectedIndex == 0)
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
            }
            else
            {
                if (btnSave.Text == "Add")
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("insert into AGENTCOMISSION(ANO, COMISSION,CreatedBy) values" +
                                                     "(" + comboBox1.SelectedValue + ",'" + textBox3.Text + "'," + GlobalData.UserID + ")");
                    
                   
                }

                else
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("UPDATE AGENTCOMISSION SET COMISSION ='" + textBox3.Text + "' where " +
                                                   "ANO=" + comboBox1.SelectedValue + "");


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
           //txtEmail.Text = string.Empty;
           txtEmpName.Text = string.Empty;
           txtAddr.Text = string.Empty;
           txtMobile.Text = string.Empty;
           //txtPwd.Text = string.Empty;
           textBox3.Text = string.Empty;
           //textBox4.Text = string.Empty;

        }


        private void btnSrchSupp_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
           DataSet ds = new DataSet();
           ds = sqlhelp.ExecuteQueries("Select ANO,DNAME AS [Agent Name],Mobile,Address,EMail,DOB,MEMBERNO as [Agent No],COMISSION as [Comission %],CREATEDDATE as [Agent Since] FROM AGENTCOMISSIONQUERY where Mobile = '" + textBox1.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Cat_ItemGrid.DataSource = ds.Tables[0];
               
                Cat_ItemGrid.Columns["ANO"].Visible = false;
               
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
            //Cat_ItemGrid.DataSource = null;
            //Cat_ItemGrid.Columns.Clear();
        }

        private void Cat_ItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddGroup.Visible = true;
            AddGroup.Location = new System.Drawing.Point(20, 38);
            SearchGroup.Visible = false;
            //txtMobile.Visible = false;
            //textBox4.Visible = true;
            //textBox3.Visible = true;
            label13.Visible = true;

          

            btnTbAdd.Text = "Edit";
            btnSave.Text = "Update";
            //btnClear.Text = "Delete";
            btnClear.Visible = false;
            PCUSID = int.Parse(Cat_ItemGrid.CurrentRow.Cells["ANO"].Value.ToString());
           
            txtEmpName.Text = Cat_ItemGrid.CurrentRow.Cells["DNAME"].Value.ToString();
            txtMobile.Text = Cat_ItemGrid.CurrentRow.Cells["MOBILE"].Value.ToString();
            txtAddr.Text = Cat_ItemGrid.CurrentRow.Cells["ADDRESS"].Value.ToString();
           
             textBox3.Text = Cat_ItemGrid.CurrentRow.Cells["COMISSION"].Value.ToString();
            comboBox1.Text = Cat_ItemGrid.CurrentRow.Cells["MEMBERNO"].Value.ToString();
          
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

    

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select ANO,DNAME AS [Agent Name],Mobile,Address,EMail,DOB,MEMBERNO as [Agent No],COMISSION as [Comission %],CREATEDDATE as [Agent Since] FROM AGENTCOMISSIONQUERY where MemberNo = '" + textBox2.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Cat_ItemGrid.DataSource = ds.Tables[0];
                //Cat_ItemGrid.Columns["PCUSID"].Visible = false;
                Cat_ItemGrid.Columns["ANO"].Visible = false;
                //Cat_ItemGrid.Columns["CreatedBy"].Visible = false;
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("Select ANO,DNAME AS [Agent Name],Mobile,Address,EMail,DOB,MEMBERNO as [Agent No],COMISSION as [Comission %],CREATEDDATE as [Agent Since] FROM AGENTCOMISSIONQUERY");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Cat_ItemGrid.DataSource = ds.Tables[0];
                //Cat_ItemGrid.Columns["PCUSID"].Visible = false;
                Cat_ItemGrid.Columns["ANO"].Visible = false;
                //Cat_ItemGrid.Columns["CreatedBy"].Visible = false;
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

        private void AgentComission_Load(object sender, EventArgs e)
            
        {

            SearchGroup.Visible = true;
            AddGroup.Visible = false;

            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select * from AGENT");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow DR = ds.Tables[0].NewRow();
                DR["MEMBERNO"] = "Select";
                DR["ANO"] = 0;
                ds.Tables[0].Rows.InsertAt(DR, 0);
                comboBox1.DisplayMember = "MEMBERNO";
                comboBox1.ValueMember = "ANO";
                comboBox1.DataSource = ds.Tables[0];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                DataSet ds = new DataSet();
                ds = sqlhelp.ExecuteQueries("select * from AGENT where ANO =" + comboBox1.SelectedValue + "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtEmpName.Text = ds.Tables[0].Rows[0]["DNAME"].ToString();
                   txtMobile.Text = ds.Tables[0].Rows[0]["MOBILE"].ToString();
                   txtAddr.Text = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                }
            }
        }

       
    }
}
