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
    public partial class PCard : Form
    {
        int PSNo;
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


        public PCard()
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
            //clear();
            btnSave.Text = "Add";
            btnClear.Text = "Clear";
        }

        private void PCard_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            AddGroup.Visible = false;
            SearchGroup.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtExpAmount.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);
            }
            else
            {
                if (btnSave.Text == "Add")
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("insert into Pcard(CardNumber,CreatedBy,IsActive) values" +
                                                     "('" + txtExpAmount.Text + "'," + GlobalData.UserID + ",'" + comboBox1.Text + "')");
                }
                else
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("UPDATE Pcard SET CardNumber='" + txtExpAmount.Text + "',IsActive='" + comboBox1.Text + "' where " +
                                                   "PSNo=" + PSNo + "");
                }

                if (result == true)
                {
                    FrmMessage.Show("Transaction Success");
                    btnTbSearch_Click(sender, e);
                    Cat_ItemGrid.DataSource = null;
                    Cat_ItemGrid.Columns.Clear();
                }
            }

        }

        void clear()
        {
           txtExpAmount.Text = string.Empty;
          
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
                count = int.Parse(sqlhelp.ExecuteScalar("select count(*) from PCard where PSNo= " + PSNo + ""));
                if (count > 0)
                {
                    if (DialogResult.OK == FrmMessage.Show("Are you Sure. You want to Delete this Card ?", caption, OkCancelButton, QuestionIcon))
                    {
                        result = sqlhelp.ExecuteNonQuery("delete from PCard where PSNo=" + PSNo + "");
                        if (result == true)
                        {
                            FrmMessage.Show("Card Deleted Successfully", caption, OkButton, InformationIcon);
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
            PSNo = int.Parse(Cat_ItemGrid.CurrentRow.Cells[0].Value.ToString());
           txtExpAmount.Text = Cat_ItemGrid.CurrentRow.Cells[1].Value.ToString();
           comboBox1.Text = Cat_ItemGrid.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnSrchSupp_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select PSNo, CardNumber as [Card Number],IsActive as [Status] from Pcard where CardNumber like '" + txtExpAmount.Text + "%'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Cat_ItemGrid.DataSource = ds.Tables[0];
                Cat_ItemGrid.Columns["PSNo"].Visible = false;
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        
    }
}
