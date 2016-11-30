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
    public partial class PayAgentComission : Form
    {
        int PSNo;
        Int32 PCUSID;
        Int32 PSNO;
        SQLHelper sqlhelp = new SQLHelper();
        SQLHelper sqlhelper = new SQLHelper();
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


        public PayAgentComission()
        {
            InitializeComponent();
        }

        private void btnTbSearch_Click(object sender, EventArgs e)
        {
            
            AddGroup.Visible = false;
         
        }

        private void btnTbAdd_Click(object sender, EventArgs e)
        {
           
            AddGroup.Visible = true;
          
            txtMobile.Visible = true;

            btnSave.Text = "Add";
           


        }



        //private void PAssignCards_Load(object sender, EventArgs e)
        //{

        //    textBox3.Visible = false;
        //    label13.Visible = false;
        //    SearchGroup.Visible = true;
        //    AddGroup.Visible = false;
        //    sqlhelp = new SQLHelper();
        //    DataSet ds = new DataSet();

        //}

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
            if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
            }
            else
            {
                
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("insert into comissionpaid(ANO, PAIDAMOUNT) values" +
                                                     "(" + textBox5.Text + "," + textBox1.Text + ")");


                }


                if (result == true)
                {
                    FrmMessage.Show("Transaction Success");
                    
                 dataGridView1.DataSource = null;
                 dataGridView1.Columns.Clear();
                 textBox1.Text = "0";
                 textBox2.Text = "0";
                 textBox6.Text = "0";
                 txtAddr.Text = string.Empty;
                 txtEmpName.Text = string.Empty;
                 txtMobile.Text = string.Empty;
                }
            }

        }

        void clear()
        {
           
            txtEmpName.Text = string.Empty;
            txtAddr.Text = string.Empty;
            txtMobile.Text = string.Empty;
            

        }


        //private void btnSrchSupp_Click(object sender, EventArgs e)
        //{
        //    sqlhelp = new SQLHelper();
        //    DataSet ds = new DataSet();
        //    ds = sqlhelp.ExecuteQueries("Select ANO,DNAME AS [Agent Name],Mobile,Address,EMail,DOB,MEMBERNO as [Agent No],COMISSION as [Comission %],CREATEDDATE as [Agent Since] FROM AGENTCOMISSIONQUERY where Mobile = '" + textBox1.Text + "'");
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //      dataGridView1.DataSource = ds.Tables[0];

        //      dataGridView1.Columns["ANO"].Visible = false;

        //    }
        //    else
        //        FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        //    //Cat_ItemGrid.DataSource = null;
        //    //Cat_ItemGrid.Columns.Clear();
        //}

        private void Cat_ItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            

        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

       

        private void PayAgentComission_Load(object sender, EventArgs e)
        {
           
            AddGroup.Visible = true;
            textBox1.Text = "0";


        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                sqlhelp = new SQLHelper();
                DataSet ds = new DataSet();
                DataSet DS1 = new DataSet();
                DataSet DS2 = new DataSet();

                ds = sqlhelp.ExecuteQueries("select * from AGENT where memberno = '" + textBox4.Text + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtEmpName.Text = ds.Tables[0].Rows[0]["DNAME"].ToString();
                    txtMobile.Text = ds.Tables[0].Rows[0]["MOBILE"].ToString();
                    txtAddr.Text = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                    textBox5.Text = ds.Tables[0].Rows[0]["ANO"].ToString();
                }

                DS1 = sqlhelper.ExecuteQueries("Select ANO, [Agent Name],Mobile, Address,Email,DOB,[AgentNo],transactionno as [Bill No],[comission %],comissionearned as [Comission],[Comission Date] FROM AGENTCOMISSIONEARNEDQUERY where AGENTNO = '" + textBox4.Text + "'");
                if (DS1.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = DS1.Tables[0];
                    dataGridView1.Columns["ANO"].Visible = false;

                }

                DS2 = sqlhelper.ExecuteQueries("Select * FROM COMISSIONBALANCE where ANO = " + textBox5.Text + "");
                if (DS2.Tables[0].Rows.Count > 0)
                {
                    textBox6.Text = DS2.Tables[0].Rows[0]["BALANCE"].ToString();


                }
                else
                {
                    FrmMessage.Show("No AGENT Records Found", caption, OkButton, InformationIcon);
                }
            }

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            DataSet DS1 = new DataSet();
            DataSet DS2 = new DataSet();

            ds = sqlhelp.ExecuteQueries("select * from AGENT where memberno = '" + textBox4.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtEmpName.Text = ds.Tables[0].Rows[0]["DNAME"].ToString();
                txtMobile.Text = ds.Tables[0].Rows[0]["MOBILE"].ToString();
                txtAddr.Text = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                textBox5.Text = ds.Tables[0].Rows[0]["ANO"].ToString();
            }

            DS1 = sqlhelper.ExecuteQueries("Select ANO, [Agent Name],Mobile, Address,Email,DOB,[AgentNo],transactionno as [Bill No],[comission %],comissionearned as [Comission],[Comission Date] FROM AGENTCOMISSIONEARNEDQUERY where AGENTNO = '" + textBox4.Text + "'");
            if (DS1.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = DS1.Tables[0];
                dataGridView1.Columns["ANO"].Visible = false;

            }

            DS2 = sqlhelper.ExecuteQueries("Select * FROM COMISSIONBALANCE where ANO = " + textBox5.Text + "");
            if (DS2.Tables[0].Rows.Count > 0)
            {
                textBox6.Text = DS2.Tables[0].Rows[0]["BALANCE"].ToString();
                

            }
            else
            {
                FrmMessage.Show("No AGENT Records Found", caption, OkButton, InformationIcon);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           textBox2.Text = (Math.Round((decimal.Parse(textBox6.Text) - (decimal.Parse(textBox1.Text))), 2)).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           textBox2.Text = (Math.Round((decimal.Parse(textBox6.Text) - (decimal.Parse(textBox1.Text))), 2)).ToString();
        }

       
    }
    
}
