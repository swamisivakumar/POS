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
    public partial class ExpenseTypes : Form
    {
        int ExpTypeID;
        SQLHelper sqlhelp = new SQLHelper();
        DataSet ds = new DataSet();

        #region global Declaration for custom messagebox
        FrmMessage.enumMessageIcon InformationIcon = FrmMessage.enumMessageIcon.Information;
        FrmMessage.enumMessageIcon QuestionIcon = FrmMessage.enumMessageIcon.Question;
        FrmMessage.enumMessageIcon ErrorIcon = FrmMessage.enumMessageIcon.Error;

        FrmMessage.enumMessageButton OkButton = FrmMessage.enumMessageButton.OK;
        FrmMessage.enumMessageButton YesNoButton = FrmMessage.enumMessageButton.YesNo;
        FrmMessage.enumMessageButton OkCancelButton = FrmMessage.enumMessageButton.OKCancel;
        string caption = "Inventory Management";
        #endregion

        public ExpenseTypes()
        {
            InitializeComponent();
            

        }
        private void ExpenseTypes_Load(object sender, EventArgs e)
        {
            AddGroup.Visible = false;
            SearchGroup.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtExpDesc.Text) || string.IsNullOrEmpty(txtExpName.Text))
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
            }
            else
            {
                if (btnSave.Text == "Add")
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("insert into ExpenseTypes(ExpenseName,Description,CreatedBy) values" +
                                                     "('" + txtExpName.Text + "','" + txtExpDesc.Text + "'," + GlobalData.UserID + ")");
                }
                else
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("UPDATE ExpenseTypes SET ExpenseName='" + txtExpName.Text + "',Description='" + txtExpDesc.Text + "' where " +
                                                   "ExpTypeID=" + ExpTypeID + "");
                }

                if (result == true)
                {
                    FrmMessage.Show("Transaction Success");
                    btnTbSearch_Click(sender, e);
                }
            }

        }

        private void btnTbSearch_Click(object sender, EventArgs e)
        {
            SearchGroup.Visible = true;

            AddGroup.Visible = false;
            btnTbAdd.Text = "Add";
            clear();
        }

        private void btnTbAdd_Click(object sender, EventArgs e)
        {
            btnTbAdd.Text = "Add";
            SearchGroup.Visible = false;
            AddGroup.Visible = true;
           
            clear();
            btnSave.Text = "Add";
            btnClear.Text = "Clear";
        }
        void clear()
        {
            txtExpDesc.Text = string.Empty;
            txtExpName.Text = string.Empty;
            txtSrchExpNames.Text = string.Empty;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (btnClear.Text == "Clear")
            {
                clear();
            }
            else
            {
                bool result;
                int count;
                sqlhelp = new SQLHelper();
                count = int.Parse(sqlhelp.ExecuteScalar("select count(*) from Expenses where ExpTypeID= " + ExpTypeID + ""));
                if (count == 0)
                {
                    if (DialogResult.OK == FrmMessage.Show("Are you Sure. You want to Delete this ExpenseType ?", caption, OkCancelButton, QuestionIcon))
                    {
                        result = sqlhelp.ExecuteNonQuery("delete from ExpenseTypes where ExpTypeID=" + ExpTypeID + "");
                        if (result == true)
                        {
                            FrmMessage.Show("ExpenseType Deleted Successfully", caption, OkButton, InformationIcon);
                            btnClear.Text = "Clear";
                            btnSave.Text = "Add";
                            btnTbSearch_Click(sender, e);
                        }
                    }
                }
                else
                {
                    FrmMessage.Show("You Cannnot Delete this Category. First Delete the Items of this Category", caption, OkButton, InformationIcon);
                    btnClear.Text = "Clear";
                    btnSave.Text = "Add";
                    btnTbSearch_Click(sender, e);

                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select ExpTypeID,ExpenseName as [Expense Name],Description from ExpenseTypes where ExpenseName like '" + txtSrchExpNames.Text + "%'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Expgrid.DataSource = ds.Tables[0];
                Expgrid.Columns["ExpTypeID"].Visible = false;
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        private void Expgrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddGroup.Visible = true;
            AddGroup.Location = new System.Drawing.Point(20, 38);
            SearchGroup.Visible = false;
            btnTbAdd.Text = "Edit";
            btnSave.Text = "Update";
            btnClear.Text = "Delete";
            ExpTypeID = int.Parse(Expgrid.CurrentRow.Cells[0].Value.ToString());
            txtExpName.Text = Expgrid.CurrentRow.Cells[1].Value.ToString();
            txtExpDesc.Text = Expgrid.CurrentRow.Cells[2].Value.ToString();

        }

        private void ExpenseTypes_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
