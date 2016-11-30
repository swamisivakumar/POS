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
    public partial class SupplierReport : Form
    {
        SQLHelper sqlhelp = new SQLHelper();
        DataTable dtTran = new DataTable();
        DataTable dtTran1 = new DataTable();
        DataTable dtReturnSale = new DataTable();
        DataTable dtReturnSale1 = new DataTable();
        DataSetReports dsr = new DataSetReports();
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbDataAdapter da1 = new OleDbDataAdapter();
        DataSetReports dsr1 = new DataSetReports();

        #region global Declaration for custom messagebox
        FrmMessage.enumMessageIcon InformationIcon = FrmMessage.enumMessageIcon.Information;
        FrmMessage.enumMessageIcon QuestionIcon = FrmMessage.enumMessageIcon.Question;
        FrmMessage.enumMessageIcon ErrorIcon = FrmMessage.enumMessageIcon.Error;
        FrmMessage.enumMessageButton OkButton = FrmMessage.enumMessageButton.OK;
        FrmMessage.enumMessageButton YesNoButton = FrmMessage.enumMessageButton.YesNo;
        string caption = "Inventory Management";
        #endregion
        public SupplierReport()
        {
            InitializeComponent();
        }

        private void SupplierReport_Load(object sender, EventArgs e)
        {
            FillSuppliers(ddlcatname);
        }

        private void FillSuppliers(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt = sqlhelp.ExecuteTables("select cstr(SupplierID) as [SUPPID] ,SupplierName from Supplier");
            DataRow dr = dt.NewRow();
            dr["SUPPID"] = "%";
            dr["SupplierName"] = "Select";
            dt.Rows.InsertAt(dr, 0);
            cmb.DisplayMember = "SupplierName";
            cmb.ValueMember = "SUPPID";
            cmb.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (GlobalData.ReportName == "StockPurchase1")
                {
                    string ddlcategory = "";
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
                    da = new OleDbDataAdapter("select * from SupplierOrder where SupplierId Like '" + ddlcategory + "' and Cdate(Format(InvoiceDate,'dd-MMM-yy')) Between cdate(format('" + ddlFromDate.Text + "','dd-MMM-yy')) and cdate(format('" + ddlToDate.Text + "','dd-MMM-yy')) ", sqlhelp.Con);
                    da.Fill(dsr.Tables["StockPurchaseRpt"]);
                    if (dsr.Tables["StockPurchaseRpt"].Rows.Count > 0)
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.StockPurchase.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("StockPurchaseRpt", dsr.Tables["StockPurchaseRpt"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        FrmMessage.Show("No Records Found");
                    }
                }

                else if (GlobalData.ReportName == "SupplierReturn")
                {
                    string ddlcategory = "";
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
                    da = new OleDbDataAdapter("select * from ReturnItemsToSupplier where SupplierId Like '" + ddlcategory + "' and Cdate(Format(CreatedDate,'dd-MMM-yy')) Between cdate(format('" + ddlFromDate.Text + "','dd-MMM-yy')) and cdate(format('" + ddlToDate.Text + "','dd-MMM-yy')) ", sqlhelp.Con);
                    da.Fill(dsr.Tables["SupplierReturn"]);
                    if (dsr.Tables["SupplierReturn"].Rows.Count > 0)
                    {
                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.SupplierReturn.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("SupplierReturn", dsr.Tables["SupplierReturn"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        FrmMessage.Show("No Records Found");
                    }
                }

                else if (GlobalData.ReportName == "SupplierPayment")
                {
                    string ddlcategory = "";
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
                    da = new OleDbDataAdapter("select * from SupplierOrderQ where SupplierId Like '" + ddlcategory + "' and Cdate(Format(InvoiceDate,'dd-MMM-yy')) Between cdate(format('" + ddlFromDate.Text + "','dd-MMM-yy')) and cdate(format('" + ddlToDate.Text + "','dd-MMM-yy')) ", sqlhelp.Con);
                    da.Fill(dsr.Tables["SupplierPayment"]);

                    
                    da1 = new OleDbDataAdapter("select * from SPaidAmount where SupplierId Like '" + ddlcategory + "'", sqlhelp.Con);
                    da1.Fill(dsr.Tables["SupplierPayment1"]);

                    if (dsr.Tables["SupplierPayment"].Rows.Count > 0 || dsr.Tables["SupplierPayment1"].Rows.Count > 0)
                    
                    {

                       

                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.SupplierPayment.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("SupplierPayment", dsr.Tables["SupplierPayment"]));
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("SupplierPayment1", dsr.Tables["SupplierPayment1"]));
                        reportViewer1.DocumentMapCollapsed = true;
                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        FrmMessage.Show("No Records Found");
                    }
                }


            }
            catch (Exception ex)
            {
            }
        }

        
    }
}
