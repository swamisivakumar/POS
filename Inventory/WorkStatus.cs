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
    public partial class WorkStatus : Form
    {
        SQLHelper sqlhelper = new SQLHelper();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        public WorkStatus()
        {
            InitializeComponent();
        }

        private void WorkStatus_Load(object sender, EventArgs e)
        {

        }

        private void WorkStatus_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           string BillNo;
            string Status;
            if (string.IsNullOrEmpty(txtTransactionNo.Text))
            {
                BillNo = "%";
            }
            else
            {
                BillNo = txtTransactionNo.Text;
            }

            if (string.IsNullOrEmpty(ddlSrchStatus.Text) || ddlSrchStatus.Text=="All")
            {
                Status = "%";
            }
            else
            {
                Status = ddlSrchStatus.Text;
            }

            try
            {
                sqlhelper = new SQLHelper();
                statusGrid.DataSource = null;
                statusGrid.Columns.Clear();
                ds = new DataSet();
                ds = sqlhelper.ExecuteQueries("select TransactionNo as [Bill No],CustName as [Customer Name],Phone,DeliveryDate as [Delivery Date],Status,EmpID from workStatus where TransactionNo like '"+ BillNo +"' and Status like'"+ Status +"'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    statusGrid.DataSource = ds.Tables[0];
                    
                    
                    DataGridViewComboBoxColumn ddlStatus = new DataGridViewComboBoxColumn();

                    statusGrid.Columns.Remove("Status"); // Remove original
                    ddlStatus.HeaderText = "Status";

                    ddlStatus.MaxDropDownItems = 3;
                    ddlStatus.Items.Add("Pending");
                    ddlStatus.Items.Add("Working");
                    ddlStatus.Items.Add("Completed");

                    //ddlStatus.DataSource = ds.Tables[0];
                    //ddlStatus.DisplayMember = "Status";
                    ddlStatus.Width = 140;
                    // Hide drop-down arrow until selected
                    ddlStatus.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    // Allow sorting...
                    ddlStatus.SortMode = DataGridViewColumnSortMode.Automatic;
                    // Add ColumnDepartment onto DataGridView layout
                    statusGrid.Columns.Add(ddlStatus);

                    ds1 = new DataSet();
                    ds1 = sqlhelper.ExecuteQueries("select UserID,Name from Users");
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds1.Tables[0].NewRow();
                        dr["Name"] = "Select";
                        dr["UserID"] = 0;
                        ds1.Tables[0].Rows.InsertAt(dr, 0);

                        DataGridViewComboBoxColumn ddlEmp = new DataGridViewComboBoxColumn();
                        statusGrid.Columns.Remove("EmpID"); // Remove original
                        ddlEmp.HeaderText = "Employee";
                        ddlEmp.DataSource = ds1.Tables[0];
                        ddlEmp.DisplayMember = "Name";
                        ddlEmp.ValueMember = "UserID";
                        ddlEmp.Width = 140;
                        // Hide drop-down arrow until selected
                        ddlEmp.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                        // Allow sorting...
                        ddlEmp.SortMode = DataGridViewColumnSortMode.Automatic;
                        // Add ColumnDepartment onto DataGridView layout
                        statusGrid.Columns.Add(ddlEmp);


                        DataGridViewButtonColumn btnUpdate = new DataGridViewButtonColumn();
                        btnUpdate.HeaderText = "Update";
                        btnUpdate.Text = "Update";
                        btnUpdate.UseColumnTextForButtonValue = true;
                        btnUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        btnUpdate.FlatStyle = FlatStyle.Standard;
                        btnUpdate.CellTemplate.Style.BackColor = Color.Honeydew;
                        statusGrid.Columns.Add(btnUpdate);

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            statusGrid.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i]["Status"].ToString();

                            if (string.IsNullOrEmpty(ds.Tables[0].Rows[i]["EmpID"].ToString()))
                            {
                                statusGrid.Rows[i].Cells[5].Value = int.Parse(ds1.Tables[0].Rows[0]["UserID"].ToString());
                            }
                            else
                            {
                                statusGrid.Rows[i].Cells[5].Value = int.Parse(ds.Tables[0].Rows[i]["EmpID"].ToString());
                            }
                        }
                        foreach (DataGridViewColumn dc in statusGrid.Columns)
                        {
                            if (dc.Index.Equals(4) || dc.Index.Equals(5))
                            {
                                dc.ReadOnly = false;
                            }
                            else
                            {
                                dc.ReadOnly = true;
                            }
                        }
                    }
                    else
                    {
                        FrmMessage.Show("Employees are not Found. Please Insert Employees First");
                    }

                }
                else
                {
                    FrmMessage.Show("No Records Found");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void statusGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDownList;
            }
            if (e.Control is Button)
            {
                Button Update = e.Control as Button;
                Update.Click -= new EventHandler(Update_Click);
                Update.Click += new EventHandler(Update_Click);
            }

        }
        private void Update_Click(object sender, EventArgs e)
        {
            int i = this.statusGrid.CurrentCell.RowIndex;

            if (statusGrid.Rows[i].Cells[5].Value.ToString() == "0")
            {
                sqlhelper.ExecuteNonQuery("Update Payment set Status='" + statusGrid.Rows[i].Cells[4].Value + "' and EmpID=" + statusGrid.Rows[i].Cells[5].Value + "" +
                                          " where TransactionNo='" + statusGrid.Rows[i].Cells[0].Value + "'");
            }

        }



        private void statusGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                int i = this.statusGrid.CurrentCell.RowIndex;

                if (statusGrid.Rows[i].Cells[5].Value.ToString() == "0")
                {
                    FrmMessage.Show("Please Select the Employee for this Work");
                }
                else
                {
                    bool result;
                    result = sqlhelper.ExecuteNonQuery("Update Payment set Status='" + statusGrid.Rows[i].Cells[4].Value + "', EmpID=" + statusGrid.Rows[i].Cells[5].Value + "" +
                                              " where TransactionNo='" + statusGrid.Rows[i].Cells[0].Value + "'");
                    if (result == true)
                    {
                        FrmMessage.Show("Transaction Successful");
                    }
                }
            }
        }
    }
}
