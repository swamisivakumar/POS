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
    public partial class AgentReports : Form
    {
        DataSetReports dsr = new DataSetReports();
        SQLHelper sqlhelp = new SQLHelper();
        OleDbDataAdapter da = new OleDbDataAdapter();
        public AgentReports()
        {
            InitializeComponent();
            

        }
        private void Reports_Load(object sender, EventArgs e)
        {
          
            reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.NoRecordReport.rdlc";
            reportViewer1.RefreshReport();
        }
       

        private void Reports_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //else if (GlobalData.ReportName == "MemberCardReport")
                //{
                    string ddlcategory;
                    if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
                    {
                        ddlcategory = "%";
                    }
                    else
                    {
                        ddlcategory = textBox1.Text;
                        ddlcategory = textBox2.Text;

                    }
                    dsr = new DataSetReports();
                    da = new OleDbDataAdapter("select * from COMISSIONQUERY where MEMBERNO = '" + textBox1.Text + "' OR MOBILE = '" + textBox2.Text + "'", sqlhelp.Con);
                    da.Fill(dsr.Tables["AGENTCOMISSIONREPORT"]);
                    if (dsr.Tables["AGENTCOMISSIONREPORT"].Rows.Count > 0)
                    {

                        reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.AGENTCOMISSIONREPORT.rdlc";
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsr.Tables["AGENTCOMISSIONREPORT"]));
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


            
              

            
            //}
            catch (Exception ex)
            {
            }
        }

        private void AgentReports_Load(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.NoRecordReport.rdlc";
            reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //else if (GlobalData.ReportName == "MemberCardReport")
                //{
                string ddlcategory;
               
                dsr = new DataSetReports();
                da = new OleDbDataAdapter("select * from COMISSIONQUERY", sqlhelp.Con);
                da.Fill(dsr.Tables["AGENTCOMISSIONREPORT"]);
                if (dsr.Tables["AGENTCOMISSIONREPORT"].Rows.Count > 0)
                {

                    reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.AGENTCOMISSIONREPORT.rdlc";
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsr.Tables["AGENTCOMISSIONREPORT"]));
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






            //}
            catch (Exception ex)
            {
            }
        }

      
    }
}
