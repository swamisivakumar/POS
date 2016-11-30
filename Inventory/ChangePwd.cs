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
    public partial class ChangePwd : Form
    {
        SQLHelper sqlhelp = new SQLHelper();

        public ChangePwd()
        {
            InitializeComponent();            
        }

        private void btnChngePwd_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            bool result;
            ds = sqlhelp.ExecuteQueries("Select [Password] from Users where UserID = " + GlobalData.UserID + "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (txtOldPwd.Text == ds.Tables[0].Rows[0]["Password"].ToString())
                {
                    result = sqlhelp.ExecuteNonQuery("Update Users set [Password]='" + txtNewPwd.Text + "' where UserID = " + GlobalData.UserID + "");
                    if (result == true)
                    {
                        FrmMessage.Show("Password has been Changed Successfully");
                    }
                }
                else
                {
                    FrmMessage.Show("Please Enter the Correct Old Password and Try again !!!");
                    txtOldPwd.Text = string.Empty;
                    txtNewPwd.Text = string.Empty;
                }
            }

        }
        
    }
}
