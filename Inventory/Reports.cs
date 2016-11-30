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
    public partial class Reports : Form
    {
        DataSetReports dsr = new DataSetReports();
        SQLHelper sqlhelp = new SQLHelper();
        OleDbDataAdapter da = new OleDbDataAdapter();
        public Reports()
        {
            InitializeComponent();
            

        }
        private void Reports_Load(object sender, EventArgs e)
        {
            fillCategory();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.NoRecordReport.rdlc";
            reportViewer1.RefreshReport();
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

                if (GlobalData.ReportName == "StockReport")
                {
                    string ddlcategory ="";
                    if (ddlcatname.Text == string.Empty)
                    {
                        FrmMessage.Show("No Records Found");
                    }
                    else
                    {
                        if (ddlcatname.SelectedIndex == 0)
                        {
                            ddlcategory = "%";
                        }
                        else
                        {
                            ddlcategory = ddlcatname.SelectedValue.ToString();

                        }
                    }

                    dsr = new DataSetReports();
                    da = new OleDbDataAdapter("select * from StockReport where Category Like '"+ ddlcategory +"'", sqlhelp.Con);
                    da.Fill(dsr.Tables["DT_StockHistory"]);
                    if (dsr.Tables["DT_StockHistory"].Rows.Count > 0)
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.StockRpt.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsr.Tables["DT_StockHistory"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        FrmMessage.Show("No Records Found");
                    }
                }
                else if (GlobalData.ReportName == "BillReport")
                {
                    string ddlcategory;
                   
                        dsr = new DataSetReports();
                        da = new OleDbDataAdapter("select TransactionNo,PaymentId,TotalAmount, DiscountAmount,BillPaid,CreatedDate from Payment where Cdate(Format(CreatedDate,'dd-MMM-yy')) Between cdate(format('" + ddlFromDate.Text + "','dd-MMM-yy')) and cdate(format('" + ddlToDate.Text + "','dd-MMM-yy'))", sqlhelp.Con);
                        da.Fill(dsr.Tables["SummaryReport"]);
                        if (dsr.Tables["SummaryReport"].Rows.Count > 0)
                        {
                            //BillCReport BCR = new BillCReport();
                            //BCR.SetDataSource(dsr.Tables["DT_BillReport"]);
                            //ReportsView.ReportSource = BCR;
                            reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.SummaryReport.rdlc";
                            reportViewer1.LocalReport.DataSources.Clear();
                            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsr.Tables["SummaryReport"]));
                            reportViewer1.DocumentMapCollapsed = true;
                            reportViewer1.RefreshReport();
                            //ReportDataSource sReportDataSource = new ReportDataSource();
                            //sReportDataSource.Name = "DataSet1";
                            //sReportDataSource.Value = dsr.Tables["DT_BillReport"];
                            //reportViewer1.LocalReport.DataSources.Add(sReportDataSource);
                            //reportViewer1.RefreshReport();
                        }
                        else
                        {
                            reportViewer1.LocalReport.DataSources.Clear();
                            FrmMessage.Show("No Records Found");
                        }
                    }
                //}

                else if (GlobalData.ReportName == "VATReport")
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
                    da = new OleDbDataAdapter("select TransactionNo,TotalAmount,DiscountAmount, BillPaid,VAT,VATAmount,Paid,CreatedDate from TaxHistory where Cdate(Format(CreatedDate,'dd-MMM-yy')) Between cdate(format('" + ddlFromDate.Text + "','dd-MMM-yy')) and cdate(format('" + ddlToDate.Text + "','dd-MMM-yy')) and TransactionNo like '" + ddlcategory + "'", sqlhelp.Con);
                    da.Fill(dsr.Tables["TaxHistory"]);
                    if (dsr.Tables["TaxHistory"].Rows.Count > 0)
                    {
                        
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.TaxHistory.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsr.Tables["TaxHistory"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();
                       
                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        FrmMessage.Show("No Records Found");
                    }
                }
                //}


                else if (GlobalData.ReportName == "DueReport")
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
                    da = new OleDbDataAdapter("select * from DueReport where MemberNo like '" + ddlcategory + "'", sqlhelp.Con);
                    da.Fill(dsr.Tables["DueReport"]);
                    if (dsr.Tables["DueReport"].Rows.Count > 0)
                    {

                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.DUEREPORT.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsr.Tables["DueReport"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();

                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        FrmMessage.Show("No Records Found");
                    }
                }

                else if (GlobalData.ReportName == "BestProduct")
                {

                   
                    dsr = new DataSetReports();
                    da = new OleDbDataAdapter("select CategoryName,ItemName,ItemCount,SaleQty from BestProGraph1", sqlhelp.Con);
                    da.Fill(dsr.Tables["BestProduct"]);
                    if (dsr.Tables["BestProduct"].Rows.Count > 0)
                    {

                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.BestProduct.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsr.Tables["BestProduct"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();

                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        FrmMessage.Show("No Records Found");
                    }
                }
                //}

                else if (GlobalData.ReportName == "BillDetailReport")
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
                    da = new OleDbDataAdapter("select TransactionNo,CreatedDate,BarCode, ItemName,ItemPrice,SaleQty from BillDetailReport where Cdate(Format(CreatedDate,'dd-MMM-yy')) Between cdate(format('" + ddlFromDate.Text + "','dd-MMM-yy')) and cdate(format('" + ddlToDate.Text + "','dd-MMM-yy')) and TransactionNo like '" + ddlcategory + "'", sqlhelp.Con);
                    da.Fill(dsr.Tables["BillDetailReport"]);
                    if (dsr.Tables["BillDetailReport"].Rows.Count > 0)
                    {
                        //BillCReport BCR = new BillCReport();
                        //BCR.SetDataSource(dsr.Tables["DT_BillReport"]);
                        //ReportsView.ReportSource = BCR;
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.BillDetailReport.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsr.Tables["BillDetailReport"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();
                        //ReportDataSource sReportDataSource = new ReportDataSource();
                        //sReportDataSource.Name = "DataSet1";
                        //sReportDataSource.Value = dsr.Tables["DT_BillReport"];
                        //reportViewer1.LocalReport.DataSources.Add(sReportDataSource);
                        //reportViewer1.RefreshReport();
                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        FrmMessage.Show("No Records Found");
                    }
                }
                //}
                else if (GlobalData.ReportName == "POINTSUSEDREPORT")
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
                    da = new OleDbDataAdapter("select * from POINTSUSEDREPORT where Cdate(Format(CreatedDate,'dd-MMM-yy')) Between cdate(format('" + ddlFromDate.Text + "','dd-MMM-yy')) and cdate(format('" + ddlToDate.Text + "','dd-MMM-yy')) and CARDNUMBER like '" + ddlcategory + "'", sqlhelp.Con);
                    da.Fill(dsr.Tables["POINTSUSEDREPORT"]);
                    if (dsr.Tables["POINTSUSEDREPORT"].Rows.Count > 0)
                    {
                        //BillCReport BCR = new BillCReport();
                        //BCR.SetDataSource(dsr.Tables["DT_BillReport"]);
                        //ReportsView.ReportSource = BCR;
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.POINTSUSEDREPORT.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsr.Tables["POINTSUSEDREPORT"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();
                        //ReportDataSource sReportDataSource = new ReportDataSource();
                        //sReportDataSource.Name = "DataSet1";
                        //sReportDataSource.Value = dsr.Tables["DT_BillReport"];
                        //reportViewer1.LocalReport.DataSources.Add(sReportDataSource);
                        //reportViewer1.RefreshReport();
                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        FrmMessage.Show("No Records Found");
                    }
                }
                //}


                else if (GlobalData.ReportName == "MemberCardReport")
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
                    da = new OleDbDataAdapter("select * from MemberCardReport where CARDNUMBER like '" + ddlcategory + "'", sqlhelp.Con);
                    da.Fill(dsr.Tables["MemberCard"]);
                    if (dsr.Tables["MemberCard"].Rows.Count > 0)
                    {
                        //BillCReport BCR = new BillCReport();
                        //BCR.SetDataSource(dsr.Tables["DT_BillReport"]);
                        //ReportsView.ReportSource = BCR;
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.MemberCardReport.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsr.Tables["MemberCard"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();
                        //ReportDataSource sReportDataSource = new ReportDataSource();
                        //sReportDataSource.Name = "DataSet1";
                        //sReportDataSource.Value = dsr.Tables["DT_BillReport"];
                        //reportViewer1.LocalReport.DataSources.Add(sReportDataSource);
                        //reportViewer1.RefreshReport();
                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        FrmMessage.Show("No Records Found");
                    }
                }
                //}


                else if (GlobalData.ReportName == "ExpenseReport")
                {
                    dsr = new DataSetReports();
                    da = new OleDbDataAdapter("select * from GetExpense where cdate(format(ExpenseDate,'dd-MMM-yy')) Between cdate(format('" + ddlFromDate.Text + "','dd-MMM-yy')) and cdate(format('" + ddlToDate.Text + "','dd-MMM-yy'))", sqlhelp.Con);
                    da.Fill(dsr.Tables["DT_Expenses"]);
                    if (dsr.Tables["DT_Expenses"].Rows.Count > 0)
                    {
                       // ExpensesCReport ECR = new ExpensesCReport();
                       // ECR.SetDataSource(dsr.Tables["DT_Expenses"]);
                       //// ReportsView.ReportSource = ECR;

                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.Expense.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetExpense", dsr.Tables["DT_Expenses"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        FrmMessage.Show("No Records Found");
                    }
                }
                else if (GlobalData.ReportName == "TBalReport")
                {
                    dsr = new DataSetReports();
                    da = new OleDbDataAdapter("select * from TrailBal where cdate(format([Date],'dd-MMM-yy')) Between cdate(format('" + ddlFromDate.Text + "','dd-MMM-yy')) and cdate(format('" + ddlToDate.Text + "','dd-MMM-yy'))", sqlhelp.Con);
                    da.Fill(dsr.Tables["DT_TrailBal"]);
                    if (dsr.Tables["DT_TrailBal"].Rows.Count > 0)
                    {
                       // TrailBalCReport TCR = new TrailBalCReport();
                       // TCR.SetDataSource(dsr.Tables["DT_TrailBal"]);
                       //// ReportsView.ReportSource = TCR;
                        

                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.TrialBalReport.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DSTrailBal", dsr.Tables["DT_TrailBal"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();

                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        FrmMessage.Show("No Records Found");
                    }
                }

                //else if (GlobalData.ReportName == "DueBillReport")
                //{
                //    dsr = new DataSetReports();
                //    da = new OleDbDataAdapter("select * from DuesFetch where CreatedDate Between cdate('" + ddlFromDate.Text + "') and cdate('" + ddlToDate.Text + "')", sqlhelp.Con);
                //    da.Fill(dsr.Tables["DT_DueBill"]);
                //    if (dsr.Tables["DT_DueBill"].Rows.Count > 0)
                //    {
                //        DueBillingsCReport TCR = new DueBillingsCReport();
                //        TCR.SetDataSource(dsr.Tables["DT_DueBill"]);
                //        //ReportsView.ReportSource = TCR;
                //    }
                //    else
                //    {
                //        FrmMessage.Show("No Records Found");
                //    }
                //}
            }
            catch (Exception ex)
            {
            }
        }
    }
}
