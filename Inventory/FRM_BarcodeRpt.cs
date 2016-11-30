using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Inventory
{
    public partial class FRM_BarcodeRpt : Form
    {
        BarcodeLib.Barcode b = new BarcodeLib.Barcode();
        public FRM_BarcodeRpt()
        {
            InitializeComponent();
        }
       

        private void FRM_BarcodeRpt_Load(object sender, EventArgs e)
        {
            DataSetReports dsr = new DataSetReports();

            for (int j = 0; j < GlobalData.NoofBarcode; j++)            
            {
                DataRow dr = dsr.Tables["BarcodeRpt"].NewRow();
                dr["Barcode"] = GlobalData.BarcodeImage;
                dr["Item_Price"] = GlobalData.ItemAndPrice;
                dsr.Tables["BarcodeRpt"].Rows.Add(dr);
            }

            reportViewer1.Visible = true;
            reportViewer1.LocalReport.ReportEmbeddedResource = "Inventory.BarcodeRpt.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("BarcodeReport", dsr.Tables["BarcodeRpt"]));
            reportViewer1.DocumentMapCollapsed = true;
            reportViewer1.RefreshReport();            
        }
    }
}
