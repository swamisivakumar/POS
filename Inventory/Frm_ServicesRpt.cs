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

namespace Inventory
{
    public partial class Frm_ServicesRpt : Form
    {
        SQLHelper sqlhelp = new SQLHelper();
        OleDbDataAdapter da;

        public Frm_ServicesRpt()
        {
            InitializeComponent();
        }

     
        private void Frm_ServicesRpt_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.NoRecordReport.rdlc";
            reportViewer1.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                DataSetReports dsr = new DataSetReports();
                da = new OleDbDataAdapter("select * from GetServicesDone where cdate(format(ServiceDate,'dd-MMMM-yyyy')) between cdate(format('" + ddlFromDate.Text + "','dd-MMM-yyyy')) and cdate(format('" + ddlToDate.Text + "','dd-MMM-yyyy')) ", sqlhelp.Con);
                da.Fill(dsr.Tables["ServiceRpt"]);
                if (dsr.Tables["ServiceRpt"].Rows.Count > 0)
                {
                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.ServiceRpts.rdlc";
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ServiceRpt", dsr.Tables["ServiceRpt"]));
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

        private void Frm_ServicesRpt_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
