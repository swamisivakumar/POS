using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory
{
    public partial class FRM_ITEMSPOPUP : Form
    {
        public FRM_ITEMSPOPUP()
        {
            InitializeComponent();
        }

        private void FRM_ITEMSPOPUP_Load(object sender, EventArgs e)
        {
            datagridItems.DataSource = null;
            datagridItems.Columns.Clear();

            if (GlobalData.Dtpopup.Rows.Count > 0)
            {
               // datagridItems.DataSource = GlobalData.Dtpopup;

                DataColumn column = GlobalData.Dtpopup.Columns.Add("Select", typeof(Boolean));
                GlobalData.Dtpopup.Columns["Select"].ReadOnly = false;
                datagridItems.DataSource = GlobalData.Dtpopup;

                foreach (DataGridViewColumn dc in datagridItems.Columns)
                {
                    if (dc.Index.Equals(9))
                    {
                        dc.ReadOnly = false;
                    }
                    else
                    {
                        dc.ReadOnly = true;
                    }
                }
                datagridItems.Columns["ItemID"].Visible = false;
                datagridItems.Columns["CategoryID"].Visible = false;
                datagridItems.Columns["QtyType"].Visible = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GlobalData.ItemIDs ="";
            foreach(DataGridViewRow dr in datagridItems.Rows)
            {
                if (dr.Cells["Select"].Value.ToString() == "True")
                {
                    GlobalData.ItemIDs = GlobalData.ItemIDs + "," + dr.Cells["ITEMID"].Value.ToString();
                }
            }
            if(!string.IsNullOrEmpty(GlobalData.ItemIDs))
            GlobalData.ItemIDs = GlobalData.ItemIDs.Substring(1, GlobalData.ItemIDs.Length - 1);
            this.Close();
             
        }

        
    }
}
