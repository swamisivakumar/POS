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
    public partial class Racks : Form
    {
        int RNO;
        int RPNO;
        int ITEMID;
        SQLHelper sqlhelp = new SQLHelper();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();

        #region global Declaration for custom messagebox
        FrmMessage.enumMessageIcon InformationIcon = FrmMessage.enumMessageIcon.Information;
        FrmMessage.enumMessageIcon QuestionIcon = FrmMessage.enumMessageIcon.Question;
        FrmMessage.enumMessageIcon ErrorIcon = FrmMessage.enumMessageIcon.Error;

        FrmMessage.enumMessageButton OkButton = FrmMessage.enumMessageButton.OK;
        FrmMessage.enumMessageButton YesNoButton = FrmMessage.enumMessageButton.YesNo;
        FrmMessage.enumMessageButton OkCancelButton = FrmMessage.enumMessageButton.OKCancel;
        string caption = "Inventory Management";
        #endregion


        public Racks()
        {
            InitializeComponent();
        }

        private void btnTbSearch_Click(object sender, EventArgs e)
        {
            SearchGroup.Visible = true;
            AddGroup.Visible = false;
            groupBox3.Visible = false;
            groupBox6.Visible = false;
            btnTbAdd.Text = "Add";
            //clear();
        }

        private void btnTbAdd_Click(object sender, EventArgs e)
        {
            btnTbAdd.Text = "Add";
            SearchGroup.Visible = false;
            AddGroup.Visible = true;
            groupBox3.Visible = false;
            groupBox6.Visible = false;
            //clear();
            btnSave.Text = "Add";
            btnClear.Text = "Clear";
        }

        private void AutoSuggestItemns()
        {
            sqlhelp = new SQLHelper();
            ds = sqlhelp.ExecuteQueries("select ITEMNAME from RACKDETAILS");
            //ds = sqlhelp.ExecuteQueries("select * from RACKDETAILS where ITEMNAME like '" + textBox3.Text + "%' OR BARCODE like '" + textBox3.Text + "%'");

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                col.Add(ds.Tables[0].Rows[i]["ItemName"].ToString());
            }
            textBox3.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox3.AutoCompleteCustomSource = col;
            textBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
        }



        private void Racks_Load(object sender, EventArgs e)
        {
            cmbbxStatus.SelectedIndex = 0;
            AddGroup.Visible = false;
            SearchGroup.Visible = true;
            groupBox3.Visible = false;
            groupBox6.Visible = false;

            AutoSuggestItemns();
            FillRack();

            DataSet ds1 = new DataSet();
            ds1 = sqlhelp.ExecuteQueries("select * FROM ITEMS");
            if (ds1.Tables[0].Rows.Count > 0)
            {
                comboBox5.DisplayMember = "ITEMNAME";
                comboBox5.ValueMember = "ITEMID";
                comboBox5.DataSource = ds1.Tables[0];


            }

        }

        private void FillRack()
        {
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select RNO, RACKNO from RACK");
            if (ds.Tables[0].Rows.Count > 0)
            {
                comboBox2.DisplayMember = "RACKNO";
                comboBox2.ValueMember = "RNO";
                comboBox2.DataSource = ds.Tables[0];

                comboBox3.DisplayMember = "RACKNO";
                comboBox3.ValueMember = "RNO";
                comboBox3.DataSource = ds.Tables[0];
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {

            SearchGroup.Visible = false;
            AddGroup.Visible = false;
            groupBox3.Visible = true;
            groupBox6.Visible = false;
            //clear();
            //btnSave.Text = "Add";
            //btnClear.Text = "Clear";
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchGroup.Visible = false;
            AddGroup.Visible = false;
            groupBox3.Visible = false;
            groupBox6.Visible = true;
            comboBox3.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            textBox1.Text = string.Empty;
            groupBox6.Text = "Assign Location to Item";
            btnAddRacks.Text = "Add";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (string.IsNullOrEmpty(txtRackNo.Text) || string.IsNullOrEmpty(cmbbxStatus.Text) || string.IsNullOrEmpty(txtNoOfSelfs.Text))
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);

            }
            else
            {
                if (btnSave.Text == "Add")
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("insert into RACK(RACKNO,NOOFSELFS,CreatedBy,STATUS) values" +
                                                     "('" + txtRackNo.Text + "','" + txtNoOfSelfs.Text + "'," + GlobalData.UserID + ",'" + cmbbxStatus.Text + "')");


                }
                else
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("UPDATE RACK SET RACKNO='" + txtRackNo.Text + "', NOOFSELFS='" + txtNoOfSelfs.Text + "', STATUS='" + cmbbxStatus.Text + "' where " +
                                                   "RNO=" + RNO + "");


                }

                if (result == true)
                {
                    FrmMessage.Show("Transaction Success");
                    btnTbSearch_Click(sender, e);
                    Cat_ItemGrid.DataSource = null;
                    Cat_ItemGrid.Columns.Clear();
                    FillRack();
                }
            }
        }

        private void btnSrchSupp_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select RNO, RACKNO, NOOFSELFS, CREATEDDATE,STATUS from RACK where RACKNO like '" + textBox2.Text + "%'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Cat_ItemGrid.DataSource = ds.Tables[0];
                Cat_ItemGrid.Columns["RNO"].Visible = false;
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        void clear()
        {
            txtRackNo.Text = string.Empty;
            txtNoOfSelfs.Text = string.Empty;


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
                count = int.Parse(sqlhelp.ExecuteScalar("select count(*) from RACK where RNO= " + RNO + ""));
                if (count > 0)
                {
                    if (DialogResult.OK == FrmMessage.Show("Are you Sure. You want to Delete this RACK ?", caption, OkCancelButton, QuestionIcon))
                    {
                        result = sqlhelp.ExecuteNonQuery("delete from RACK where RNO=" + RNO + "");
                        if (result == true)
                        {
                            FrmMessage.Show("RACK Deleted Successfully", caption, OkButton, InformationIcon);
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
                    FrmMessage.Show("You Cannnot Delete this RACK. First Update / There are items on this RACK", caption, OkButton, InformationIcon);
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
            AddGroup.Location = new System.Drawing.Point(11, 84);
            SearchGroup.Visible = false;
            btnTbAdd.Text = "Edit";
            btnSave.Text = "Update";
            btnClear.Text = "Delete";
            RNO = int.Parse(Cat_ItemGrid.CurrentRow.Cells["RNO"].Value.ToString());
            txtRackNo.Text = Cat_ItemGrid.CurrentRow.Cells["RACKNO"].Value.ToString();
            txtNoOfSelfs.Text = Cat_ItemGrid.CurrentRow.Cells["NOOFSELFS"].Value.ToString();
            cmbbxStatus.Text = Cat_ItemGrid.CurrentRow.Cells["STATUS"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select * from RACKDETAILS where ITEMNAME like '" + textBox3.Text + "%' OR BARCODE like '" + textBox3.Text + "%'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["RNO"].Visible = false;
                dataGridView1.Columns["RPNO"].Visible = false;
                dataGridView1.Columns["ITEMID"].Visible = false;

            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sqlhelp = new SQLHelper();
            ds = new DataSet();
            ds = sqlhelp.ExecuteQueries("select * from RACKDETAILS where RACKNO like '" + comboBox2.Text + "%'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns["RNO"].Visible = false;
                dataGridView1.Columns["RPNO"].Visible = false;
                dataGridView1.Columns["ITEMID"].Visible = false;
            }
            else
                FrmMessage.Show("No Records Found", caption, OkButton, InformationIcon);
        }

        private void btnAddRacks_Click_1(object sender, EventArgs e)
        {
            bool result = false;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                FrmMessage.Show("Fields with * Symbols are Mandatory!!!", caption, OkButton, ErrorIcon);

            }
            else
            {
                if (btnSave.Text == "Add")
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("insert into RACKPOSITION(RNO,ITEMID,SELFPOSITION,CreatedBy) values" +
                                                     "(" + comboBox3.SelectedValue + "," + comboBox5.SelectedValue + ",'" + textBox1.Text + "'," + GlobalData.UserID + ")");
                }
                else
                {
                    sqlhelp = new SQLHelper();
                    result = sqlhelp.ExecuteNonQuery("UPDATE RACKPOSITION SET ITEMID='" + comboBox5.SelectedValue + "', SELFPOSITION='" + textBox1.Text + "' where " +
                                                   "RPNO=" + RPNO + "");
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddGroup.Visible = false;
            AddGroup.Location = new System.Drawing.Point(11, 84);
            SearchGroup.Visible = false;
            groupBox6.Visible = true;
            groupBox3.Visible = false;
            groupBox6.Text = "Edit";
            btnAddRacks.Text = "Update";
            btnClearRacks.Text = "Delete";

            RNO = int.Parse(dataGridView1.CurrentRow.Cells["RNO"].Value.ToString());
            RPNO = int.Parse(dataGridView1.CurrentRow.Cells["RPNO"].Value.ToString());
            ITEMID = int.Parse(dataGridView1.CurrentRow.Cells["RPNO"].Value.ToString());

            comboBox3.Text = dataGridView1.CurrentRow.Cells["RACKNO"].Value.ToString();
            comboBox5.Text = dataGridView1.CurrentRow.Cells["ItemName"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["SelfPosition"].Value.ToString();
        }





    }
}
