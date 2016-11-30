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
    public partial class Expense : Form
    {
        SQLHelper sqlhelp = new SQLHelper();
        DataSet ds = new DataSet();
        int ExpenseID;

        public Expense()
        {
            InitializeComponent();
        }

        private void Expense_Load(object sender, EventArgs e)
        {
            try
            {
                fillsrchExpenseType();
                fillExpenseType();
                btnTbSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }

        }

        void fillExpenseType()
        {
            sqlhelp = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select ExpTypeID,ExpenseName from ExpenseTypes");
            DataRow dr = ds.Tables[0].NewRow();
            dr["ExpenseName"] = "Select";
            dr["ExpTypeID"] = 0;
            ds.Tables[0].Rows.InsertAt(dr, 0);
            ddlexpensetypes.DataSource = ds.Tables[0];
            ddlexpensetypes.DisplayMember = "ExpenseName";
            ddlexpensetypes.ValueMember = "ExpTypeID";
        }

        void fillsrchExpenseType()
        {
            sqlhelp = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select ExpTypeID,ExpenseName from ExpenseTypes");
            DataRow dr = ds.Tables[0].NewRow();
            dr["ExpenseName"] = "-- All --";
            dr["ExpTypeID"] = 0;
            ds.Tables[0].Rows.InsertAt(dr, 0);
            SrchddlExpTypes.DataSource = ds.Tables[0];
            SrchddlExpTypes.DisplayMember = "ExpenseName";
            SrchddlExpTypes.ValueMember = "ExpTypeID";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtExpAmount.Text) || string.IsNullOrEmpty(ddlExpDate.Text) || ddlexpensetypes.SelectedIndex == 0)
                {
                    FrmMessage.Show("Fields with * Symbols are Mandatory!!!");
                }

                else
                {
                    bool result = false;
                    sqlhelp = new SQLHelper();

                    if (btnSave.Text == "Add")
                    {
                        result = sqlhelp.ExecuteNonQuery("insert into Expenses(ExpTypeID,ExpenseDate,Amount,Description,CreatedBy) values" +
                                                         "(" + ddlexpensetypes.SelectedValue + ",cdate('" + ddlExpDate.Text + "')," + txtExpAmount.Text + "," +
                                                         "'" + txtExpDesc.Text + "'," + GlobalData.UserID + ")");
                    }

                    else
                    {
                        result = sqlhelp.ExecuteNonQuery("Update Expenses set ExpTypeID=" + ddlexpensetypes.SelectedValue + ",ExpenseDate=cdate('" + ddlExpDate.Text + "')," +
                            "Amount =" + txtExpAmount.Text + ",Description='" + txtExpDesc.Text + "',UpdatedDate=,UpdatedBy=" + GlobalData.UserID + "" +
                            " where ExpenseID=" + ExpenseID + "");
                    }
                    if (result == true)
                    {
                        FrmMessage.Show("Transaction Successful");
                        btnTbSearch_Click(sender, e);
                    }
                    else
                    {
                        FrmMessage.Show("Transaction UnSuccessful");
                        btnTbSearch_Click(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void Expense_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }


        void clear()
        {
            try
            {
                txtExpAmount.Text = string.Empty;
                ddlexpensetypes.SelectedIndex = 0;
                SrchddlExpTypes.SelectedIndex = 0;
                txtExpDesc.Text = string.Empty;
                ddlExpDate.Value = DateTime.Parse(DateTime.Today.ToShortDateString());
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                sqlhelp = new SQLHelper();
                ds = new DataSet();
                string ExpTypeSrchID = "";
                if (SrchddlExpTypes.SelectedIndex == 0)
                {
                    ExpTypeSrchID = "%";
                }
                else
                {
                    ExpTypeSrchID = SrchddlExpTypes.SelectedValue.ToString();
                }
                ds = sqlhelp.ExecuteQueries("select ExpenseID,ExpTypeID,[ExpenseName],[ExpenseDate],Amount,Description from GetExpense where ExpTypeID like '" + ExpTypeSrchID + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ExpenseGrid.DataSource = ds.Tables[0];
                    ExpenseGrid.Columns["ExpenseID"].Visible = false;
                    ExpenseGrid.Columns["ExpTypeID"].Visible = false;
                }
                else
                {
                    FrmMessage.Show("No records found !!!");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void ExpenseGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddGroup.Visible = true;
            AddGroup.Location = new System.Drawing.Point(20, 38);
            SearchGroup.Visible = false;
            btnTbAdd.Text = "Edit";
            btnSave.Text = "Update";
            btnClear.Text = "Delete";
            ExpenseID = int.Parse(ExpenseGrid.CurrentRow.Cells[0].Value.ToString());
            ddlexpensetypes.SelectedValue = ExpenseGrid.CurrentRow.Cells[1].Value;
            ddlExpDate.Text = ExpenseGrid.CurrentRow.Cells[3].Value.ToString();
            txtExpAmount.Text = ExpenseGrid.CurrentRow.Cells[4].Value.ToString();
            txtExpDesc.Text = ExpenseGrid.CurrentRow.Cells[5].Value.ToString();
        }

        private void txtExpAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }
    }
}
