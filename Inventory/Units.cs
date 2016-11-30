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
    public partial class Units : Form
    {

        int PSNo;
        int UNITID;
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


        public Units()
        {
            InitializeComponent();
        }

        private void Units_Load(object sender, EventArgs e)
        {
            AddGroup.Visible = false;
            SearchGroup.Visible = true;

            sqlhelp = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select * from UNITS");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Cat_ItemGrid.DataSource = ds.Tables[0];
                Cat_ItemGrid.Columns["UNITID"].Visible = false;
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        private void btnTbSearch_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select * from UNITS");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Cat_ItemGrid.DataSource = ds.Tables[0];
                Cat_ItemGrid.Columns["UNITID"].Visible = false;
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        private void btnTbAdd_Click(object sender, EventArgs e)
        {
            btnTbAdd.Text = "Add";
            SearchGroup.Visible = false;
            AddGroup.Visible = true;
            //clear();
            btnSave.Text = "Add";
            btnClear.Text = "Clear";
        }

        void clear()
        {
            txtExpAmount.Text = string.Empty;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtExpAmount.Text))
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
            }
            else
            {
                if (btnSave.Text == "Add")
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("insert into UNITS(UNIT) values" +
                                                     "('" + txtExpAmount.Text + "')");
                }
                else
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("UPDATE UNITS SET UNIT='" + txtExpAmount.Text + "' where " +
                                                   "UNITID=" + UNITID + "");
                }

                if (result == true)
                {
                    FrmMessage.Show("Transaction Success");
                    btnTbSearch_Click(sender, e);

                    Cat_ItemGrid.DataSource = null;
                    Cat_ItemGrid.Columns.Clear();

                    btnTbAdd.Text = "Add";
                    SearchGroup.Visible = true;
                    AddGroup.Visible = false;
                }
            }
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
                count = int.Parse(sqlhelp.ExecuteScalar("select count(*) from UNITS where UNITID= " + UNITID + ""));
                if (count > 0)
                {
                    if (DialogResult.OK == FrmMessage.Show("Are you Sure. You want to Delete this UNITS DETAILS ?", caption, OkCancelButton, QuestionIcon))
                    {
                        result = sqlhelp.ExecuteNonQuery("delete from UNITS where UNITID=" + UNITID + "");
                        if (result == true)
                        {
                            FrmMessage.Show("UNITS Details Deleted Successfully", caption, OkButton, InformationIcon);
                            btnClear.Text = "Clear";
                            btnSave.Text = "Add";
                            btnTbSearch_Click(sender, e);
                            Cat_ItemGrid.DataSource = null;
                            Cat_ItemGrid.Columns.Clear();

                        }
                    }
                }
                else
                {
                    FrmMessage.Show("You Cannnot Delete this Card. First Update / Delete the card details from the Customer Card", caption, OkButton, InformationIcon);
                    btnClear.Text = "Clear";
                    btnSave.Text = "Add";
                    btnTbSearch_Click(sender, e);

                    Cat_ItemGrid.DataSource = null;
                    Cat_ItemGrid.Columns.Clear();


                }
            }
        }

        private void Cat_ItemGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddGroup.Visible = true;
            AddGroup.Location = new System.Drawing.Point(20, 38);
            SearchGroup.Visible = false;
            btnTbAdd.Text = "Edit";
            btnSave.Text = "Update";
            btnClear.Text = "Delete";
            UNITID = int.Parse(Cat_ItemGrid.CurrentRow.Cells["UNITID"].Value.ToString());
            txtExpAmount.Text = Cat_ItemGrid.CurrentRow.Cells["UNIT"].Value.ToString();
            
        }
    }
}
