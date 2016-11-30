using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMDal;
using System.Data.OleDb;
using IMEntity;
using Microsoft.Reporting.WinForms;

namespace Inventory
{
    public partial class SubReports : Form
    {
        DataSetReports dsr = new DataSetReports();
        SQLHelper sqlhelp = new SQLHelper();
        OleDbDataAdapter da = new OleDbDataAdapter();
        public SubReports()
        {
            InitializeComponent();
            

        }
        private void Reports_Load(object sender, EventArgs e)
        {
            fillCategory();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.NoRecordReport.rdlc";
            reportViewer1.RefreshReport();
            AutoSuggestTransaction();
            AutoSuggestCard();
        }
       
        private void AutoSuggestTransaction()
        {
            DataTable dt = new DataTable();
            sqlhelp = new SQLHelper();
            dt = sqlhelp.ExecuteTables("select TransactionNo from Payment");

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                col.Add(dt.Rows[i]["TransactionNo"].ToString());
            }
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = col;
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private void AutoSuggestCard()
        {
            DataTable dt = new DataTable();
            sqlhelp = new SQLHelper();
            dt = sqlhelp.ExecuteTables("select CardNumber from PCard");

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                col.Add(dt.Rows[i]["CardNumber"].ToString());
            }
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = col;
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
        }
        private void fillCategory()
        {
            DataSet DS = new DataSet();
            ECategory Ecategory = new ECategory();
            DS = Ecategory.GETALLCATEGORY(Ecategory);
            if (DS.Tables.Count > 0)
            {
                if (DS.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = DS.Tables[0].NewRow();
                    dr["CategoryName"] = "All";
                    dr["CategoryID"] = 0;
                    DS.Tables[0].Rows.InsertAt(dr, 0);

                    // add Category Filling
                    ddlcatname.DataSource = DS.Tables[0];
                    ddlcatname.DisplayMember = "CategoryName";
                    ddlcatname.ValueMember = "CategoryID";


                }
            }
        }
        private void Reports_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                 {
                    string ddlcategory;
                    if (textBox1.Text == string.Empty)
                    {
                         ddlcategory = "%";
                    }
                    else
                        {
                            ddlcategory = textBox1.Text;

                        }
                    dsr = new DataSetReports();
                    da = new OleDbDataAdapter("select TransactionNo,format(CreatedDate, 'dd-MMM-yyyy') as [CreatedDate],BarCode, ItemName,ItemPrice,SaleQty,CNAME from BillDetailReport1 where Cdate(Format(CreatedDate,'dd-MMM-yy')) Between cdate(format('" + ddlFromDate.Text + "','dd-MMM-yy')) and cdate(format('" + ddlToDate.Text + "','dd-MMM-yy')) and CNAME like '" + ddlcategory + "'", sqlhelp.Con);
                    da.Fill(dsr.Tables["BillDetailReport1"]);
                    if (dsr.Tables["BillDetailReport1"].Rows.Count > 0)
                    {
                        //BillCReport BCR = new BillCReport();
                        //BCR.SetDataSource(dsr.Tables["DT_BillReport"]);
                        //ReportsView.ReportSource = BCR;
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.BillDetailReport1.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsr.Tables["BillDetailReport1"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();
                        //ReportDataSource sReportDataSource = new ReportDataSource();
                        //sReportDataSource.Name = "DataSet1";
                        //sReportDataSource.Value = dsr.Tables["DT_BillReport"];
                        //reportViewer1.LocalReport.DataSources.Add(sReportDataSource);
                        //reportViewer1.RefreshReport();
                        textBox1.Text = string.Empty;
                    }
                    else
                    {
                        FrmMessage.Show("No Records Found");
                        textBox1.Text = string.Empty;
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.RefreshReport();
                       
                    }
               
                }

            }
            catch (Exception ex)
            {
            }
        }

     
    }
}
