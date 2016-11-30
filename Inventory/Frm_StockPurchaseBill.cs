using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using IMDal;

namespace Inventory
{
    public partial class Frm_StockPurchaseBill : Form
    {
        OleDbDataAdapter da;
        OleDbDataAdapter da1;
        SQLHelper sqlhelp = new SQLHelper();
        DataSetReports dsr = new DataSetReports();
        DataSetReports dsr1 = new DataSetReports();

        public Frm_StockPurchaseBill()
        {
            InitializeComponent();
        }

        private void Frm_StockPurchaseBill_Load(object sender, EventArgs e)
        {
            loadReport();   
        }
        void loadReport()
        {
            try
            {

                dsr = new DataSetReports();
                da = new OleDbDataAdapter("SELECT * from SupplierOrderInvoice where InvoiceNo='" + GlobalData.Invoiceno + "'", sqlhelp.Con);

                da.Fill(dsr.Tables["PurchaseInvoice"]);


                //*********************

                dsr1 = new DataSetReports();
                da1 = new OleDbDataAdapter("select * from ShopDetails", sqlhelp.Con);
                da1.Fill(dsr1.Tables["ShopDetails"]);

                //*********************


                if (dsr.Tables["PurchaseInvoice"].Rows.Count > 0 || dsr1.Tables["ShopDetails"].Rows.Count > 0)
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.PurchaseInvoice.rdlc";
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ShopDetails", dsr1.Tables["ShopDetails"]));
                    reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("PurchaseInvoice", dsr.Tables["PurchaseInvoice"]));
                    reportViewer1.DocumentMapCollapsed = true;
                    reportViewer1.RefreshReport();
                    reportViewer1.Visible = true;
                }
                else
                {
                    reportViewer1.Visible = false;
                    FrmMessage.Show("No Records Found");
                }


            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
    }
}
