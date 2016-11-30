using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.IO;
using IMDal;
using System.Windows.Forms.DataVisualization.Charting;
namespace Inventory
{
    public partial class FrmMain : Form
    {
        Boolean var_drag;
        Point var_ClickedAt;
        SQLHelper sqlhelp = new SQLHelper();

        public FrmMain()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                const int WS_CAPTION = 0xC00000;
                cp.Style = cp.Style & ~WS_CAPTION;
                return cp;
            }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblShopName.Text = GlobalData.ShopName;
            lblUserName.Text = "Welcome, " + GlobalData.UserName;
            MdiClient ctlMDI;

            try
            {

                if (!string.IsNullOrEmpty(GlobalData.Logo))
                {
                    string dir = Application.StartupPath;
                    dir = System.IO.Path.Combine(dir, "ShopImages");
                    if (Directory.Exists(dir))
                    {
                        if (LogoPic.Image != null)
                        {
                            LogoPic.Image = null;
                        }
                        LogoPic.Image = System.Drawing.Image.FromFile(dir + "\\" + GlobalData.Logo);
                    }
                }
                else
                {
                    if (LogoPic.Image != null)
                    {
                        LogoPic.Image = null;
                    }
                    this.LogoPic.InitialImage = global::Inventory.Properties.Resources.Noimage;
                    LogoPic.Image = LogoPic.InitialImage;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
            }


            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;
                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }
            //graphimage.Location = new System.Drawing.Point(18, 61);

            LoadWeeklyChart();
            loadStockGraph();
            LoadBestProChart();
            toolTip1.SetToolTip(PicHome, "Home");
            toolTip1.SetToolTip(btnLogOut, "Log Out");

        }

        private void loadStockGraph()
        {
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            StockGraph.Invalidate();
            ds = sqlhelp.ExecuteQueries("select I.ItemName,S.StockQuantity from stock S,Items I where StockQuantity<=ReOrderQuantity and S.ItemID=I.ItemID");
            StockGraph.DataSource = ds.Tables[0];
            StockGraph.Series["StockAvail"].XValueMember = "ItemName";
            StockGraph.Series["StockAvail"].YValueMembers = "StockQuantity";
            StockGraph.Series["StockAvail"].ToolTip = "Quantity = #VALY";
            StockGraph.Visible = true;
        }

        private void LoadWeeklyChart()
        {
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            WeeklyChart.Invalidate();
            ds = sqlhelp.ExecuteQueries("select sum(Total) as [Total Amount],format(Dates,'dd-MM') as [WDate] from weekGraph group by Dates");
            WeeklyChart.DataSource = ds.Tables[0];
            WeeklyChart.Series["Weekly Sale"].YValueMembers = "Total Amount";
            WeeklyChart.Series["Weekly Sale"].ToolTip = "Amount = #VALY";
            WeeklyChart.Visible = true;
        }

        private void LoadBestProChart()
        {
            sqlhelp = new SQLHelper();
            DataSet ds = new DataSet();
            BestProductChart.Invalidate();
            ds = sqlhelp.ExecuteQueries("select Top 5 * from BestProGraph");
            BestProductChart.DataSource = ds.Tables[0];
            BestProductChart.Series["Best Product Sale"].YValueMembers = "Sale Qty";
            BestProductChart.Series["Best Product Sale"].XValueMember = "ItemName";
            BestProductChart.Series["Best Product Sale"].ToolTip = "Quantity = #VALY";
            BestProductChart.Visible = true;
        }
        //void LoadBestProSale()
        //{
        //    sqlhelp = new SQLHelper();
        //    ds = new DataSet();
        //    ChartBestPro.Invalidate();
        //    ds = sqlhelp.ExecuteQueries("select Top 5 * from BestProGraph");
        //    ChartBestPro.DataSource = ds.Tables[0];
        //    ChartBestPro.Series["StockAvail"].YValueMembers = "Sale Qty";
        //    ChartBestPro.Series["StockAvail"].XValueMember = "ItemName";
        //    ChartBestPro.Series["StockAvail"].ToolTip = "Quantity = #VALY";
        //    ChartBestPro.Visible = true; 
        //}



        private void btnLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (var_drag == true)
            {
                Point var_point;
                var_point = this.PointToScreen(new Point(e.X, e.Y));
                var_point.Offset(-var_ClickedAt.X, -var_ClickedAt.Y);
                this.Location = var_point;
            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            var_drag = false;
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var_drag = true;
                var_ClickedAt = new Point(e.X, e.Y);
            }
            else
            {
                var_drag = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.coderobotics.com");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Application.ExitThread();
            }
            catch (Exception ex)
            {
                Application.Exit();
            }
        }



        private void btnAdministrator_Click(object sender, EventArgs e)
        {
            //AdministratorMenu adminmenu = new AdministratorMenu(this);
            //adminmenu.Show();

            if (GlobalData.RoleId == "2")
            {
                FrmMessage.Show("You dont have enough permissions to acces this");
            }

            else if (GlobalData.RoleId == "3")
            {
                foreach (Form frm in this.MdiChildren)
                {
                    frm.Close();
                }
                pnlAdmin.Visible = true;
                pnlLogo.Visible = false;
                pnlAccounts.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;

            }
            else
            {

                foreach (Form frm in this.MdiChildren)
                {
                    frm.Close();
                }
                pnlAdmin.Visible = true;
                pnlLogo.Visible = false;
                pnlAccounts.Visible = false;
                panel2.Visible = true;
                panel4.Visible = false;
                panel6.Visible = false;
            }
            LoadWeeklyChart();
            LoadBestProChart();
            loadStockGraph();
            //LoadBestProSale();
        }

        private void btnMngEmp_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = true;
            panel2.Visible = false;
            Employees emp = new Employees
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            emp.Show();
        }

        private void btnMngCat_Item_Click(object sender, EventArgs e)
        {
            pnlAdmin.Visible = true;
            pnlLogo.Visible = false;
            panel2.Visible = false;
            Category_Items sup = new Category_Items
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            sup.Show();
        }

        private void btnStockManage_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = true;
            panel2.Visible = false;
            Inventory.Stock stock = new Inventory.Stock
            // stock.MdiParent = this;
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            stock.Show();

        }

        private void AutoFitToScreen()
        {
            // Retrieve the working rectangle from the Screen class
            // using the PrimaryScreen and the WorkingArea properties.
            System.Drawing.Rectangle workingRectangle =
            Screen.PrimaryScreen.WorkingArea;


            int newHeight = workingRectangle.Height;
            int newWidth = workingRectangle.Width;
        }


        private void btnphnOrder_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            pnlAccounts.Visible = true;
            //Inventory.PhoneOrders phcashier = new Inventory.PhoneOrders();
            //phcashier.MdiParent = this;
            //phcashier.Show();

            PhoneOrders form = new PhoneOrders
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            form.Show();

        }

        private void linkChngPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            ChangePwd ManPstCodes = new ChangePwd();
            ManPstCodes.MdiParent = this;
            ManPstCodes.Show();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string FileName = "";
                saveFileDialog1.InitialDirectory = "C:";
                saveFileDialog1.FileName = "InventoryWindows";
                saveFileDialog1.Title = "Backup";
                saveFileDialog1.DefaultExt = "mdb";
                saveFileDialog1.Filter = "Ms-Access Files (*.mdb)|*.mdb|All Files|*.*";
                //SaveFD1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"; 
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog1.FileName;
                    Backup(FileName);
                    FrmMessage.Show("Backup Process is Completed Successfully !");
                }
            }
            catch
            {
                MessageBox.Show("Error while backup", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }


        protected void Backup(string path)
        {
            // ----------------------------------- 
            // -- CREATE FILE BACKUP 
            // ----------------------------------- 
            string src = Application.StartupPath + @"\InventoryWindows.mdb";
            string dst = path;


            System.IO.File.Copy(src, dst, true);

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Multiselect = false;
                openFileDialog.FileName = "InventoryWindows";
                openFileDialog.Filter = "AccessDb Files (*.mdb, *.out) |*.mdb;*.out";
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string dbFileName = "InventoryWindows.mdb";
                    string pathBackup = openFileDialog.FileName; //you may use file dialog to select this backuppath
                    string CurrentDatabasePath = Path.Combine(Environment.CurrentDirectory, dbFileName);
                    File.Copy(pathBackup, CurrentDatabasePath, true);
                    FrmMessage.Show("Database Successfully Restored! ");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            pnlAccounts.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            // Inventory.Expense phcashier = new Inventory.Expense();
            Expense form = new Expense
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            Inventory.WorkStatus phcashier = new Inventory.WorkStatus();
            phcashier.MdiParent = this;
            phcashier.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            pnlAdmin.Visible = false;
            pnlAccounts.Visible = false;
            pnlLogo.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            pnlLogo.Location = new System.Drawing.Point(3, 120);
        }

        private void btnMngExpenseTypes_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = true;
            panel2.Visible = false;
            Inventory.ExpenseTypes phcashier = new Inventory.ExpenseTypes
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            phcashier.Show();
        }

        private void WSReport_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "WorkStatus";
            Inventory.Reports phcashier = new Inventory.Reports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            panel2.Visible = false;
            phcashier.lblCatName.Visible = false;
            phcashier.ddlcatname.Visible = false;
            
            phcashier.Show();
        }

        private void BillReport_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "BillReport";
            panel2.Visible = false;
            Inventory.Reports phcashier = new Inventory.Reports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            phcashier.lblCatName.Visible = false;
            phcashier.ddlcatname.Visible = false;
            phcashier.label2.Visible = false;
            phcashier.textBox1.Visible = false;
            phcashier.label4.Visible = false;
            phcashier.label3.Visible = false;
            phcashier.Show();
        }

        private void ExpenseReport_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "ExpenseReport";
            panel2.Visible = false;
            Inventory.Reports phcashier = new Inventory.Reports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            phcashier.lblCatName.Visible = false;
            phcashier.ddlcatname.Visible = false;
            phcashier.label2.Visible = false;
            phcashier.textBox1.Visible = false;
            phcashier.label4.Visible = false;
            phcashier.Show();

        }

        private void TBReport_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "TBalReport";
            panel2.Visible = false;
            Inventory.Reports phcashier = new Inventory.Reports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            phcashier.lblCatName.Visible = false;
            phcashier.ddlcatname.Visible = false;
            phcashier.label2.Visible = false;
            phcashier.textBox1.Visible = false;
            phcashier.label4.Visible = false;
            phcashier.Show();
        }

        private void DueBillReport_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "DueBillReport";
            Inventory.Reports phcashier = new Inventory.Reports {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            phcashier.lblCatName.Visible = false;
            phcashier.ddlcatname.Visible = false;
            phcashier.Show();
        }



        private void btnReturns_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            pnlAccounts.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            ////Inventory.EditTransaction EditTran = new Inventory.EditTransaction();
            //foreach (var mdiChild in MdiChildren)
            //    mdiChild.Close();
            //var EditTran = new EditTransaction
            //{
            //    MdiParent = this,
            //    Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //        | System.Windows.Forms.AnchorStyles.Left)
            //        | System.Windows.Forms.AnchorStyles.Right))),
            //    Dock = DockStyle.Fill
            //};
            //EditTran.Show();
            //EditTran.MdiParent = this;
            //EditTran.Show();
            SalesReturn form = new SalesReturn
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "StockReport";
            Inventory.Reports phcashier = new Inventory.Reports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            phcashier.MdiParent = this;
            phcashier.lblCatName.Visible = true;
            phcashier.ddlcatname.Visible = true;
            phcashier.label2.Visible = false;
            phcashier.textBox1.Visible = false;
            phcashier.ddlFromDate.Visible = false;
            phcashier.ddlToDate.Visible = false;
            phcashier.label13.Visible = false;
            phcashier.label4.Visible = false;
            phcashier.label1.Visible = false;
            phcashier.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.coderobotics.com");
        }

        private void PicHome_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            pnlAdmin.Visible = false;
            pnlLogo.Visible = false;
            panel2.Visible = true;
            LoadWeeklyChart();
            LoadBestProChart();
            loadStockGraph();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReturnSupp_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            pnlAdmin.Visible = false;
            pnlAccounts.Visible = false;
            pnlLogo.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel6.Location = new System.Drawing.Point(3, 119);
            pnlLogo.Location = new System.Drawing.Point(3, 120);
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            pnlAccounts.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            PhoneOrder1 form = new PhoneOrder1
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            form.Show();

            //foreach (Form frm in this.MdiChildren)
            //{
            //    frm.Close();
            //}
            //pnlAdmin.Visible = false;
            //pnlAccounts.Visible = false;
            //pnlLogo.Visible = false;
            //panel2.Visible = false;
            //panel3.Visible = true;
            //pnlLogo.Location = new System.Drawing.Point(3, 120);
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            try
            {
                Inventory.FRM_Services frm = new Inventory.FRM_Services
                {
                    MdiParent = this,
                    Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right))),
                    Dock = DockStyle.Fill
                };
                frm.Show();
            }
            catch (Exception ex)
            {
            }

        }

        private void btnSrvCash_Click(object sender, EventArgs e)
        {
            FRM_SERVICEACCOUNT form = new FRM_SERVICEACCOUNT
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            form.Show();
        }

        private void btnSrvRpt_Click(object sender, EventArgs e)
        {
            Frm_ServicesRpt form = new Frm_ServicesRpt
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            pnlAccounts.Visible = false;
            panel3.Visible = true;

            PhoneOrders form = new PhoneOrders
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            form.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            pnlAccounts.Visible = false;
            panel3.Visible = true;

            PhoneOrder1 form = new PhoneOrder1
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            pnlAccounts.Visible = false;
            panel3.Visible = true;

            PhoneOrder1 form = new PhoneOrder1
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = true;
            panel2.Visible = false;
            Inventory.Racks rack = new Inventory.Racks 
            
           
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            rack.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            pnlAdmin.Visible = false;
            pnlAccounts.Visible = false;
            pnlLogo.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
           
            //pnlLogo.Location = new System.Drawing.Point(3, 120);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                Inventory.PCard PCard = new Inventory.PCard 
                {
                    MdiParent = this,
                    Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right))),
                    Dock = DockStyle.Fill
                };
                PCard.Show();
            }
            catch (Exception ex)
            {
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                Inventory.PCardPointSetting PCardPointSetting = new Inventory.PCardPointSetting
                {
                    MdiParent = this,
                    Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right))),
                    Dock = DockStyle.Fill
                };
                PCardPointSetting.Show();
            }
            catch (Exception ex)
            {
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                Inventory.PAssignCards PAssignCards = new Inventory.PAssignCards
                {
                    MdiParent = this,
                    Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right))),
                    Dock = DockStyle.Fill
                };
                PAssignCards.Show();
            }
            catch (Exception ex)
            {
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "BillDetailReport";
            panel2.Visible = false;
            Inventory.Reports phcashier = new Inventory.Reports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            phcashier.lblCatName.Visible = false;
            phcashier.ddlcatname.Visible = false;
            phcashier.label2.Visible = true;
            phcashier.textBox1.Visible = true;
            phcashier.label4.Visible = false;
            phcashier.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            GlobalData.ReportName = "MemberCardReport";
            Inventory.Reports phcashier = new Inventory.Reports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
       
            phcashier.lblCatName.Visible = false;
            phcashier.ddlcatname.Visible = false;
            phcashier.label2.Visible = false;
            phcashier.textBox1.Visible = true;
            phcashier.label3.Visible = true;

            phcashier.ddlFromDate.Visible = false;
            phcashier.ddlToDate.Visible = false;
            phcashier.label13.Visible = false;
            phcashier.label1.Visible = false;
            phcashier.label4.Visible = false;
            phcashier.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "POINTSUSEDREPORT";
            Inventory.Reports phcashier = new Inventory.Reports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            phcashier.lblCatName.Visible = false;
            phcashier.ddlcatname.Visible = false;
            phcashier.label2.Visible = false;
            phcashier.textBox1.Visible = true;
            phcashier.label3.Visible = true;

            phcashier.ddlFromDate.Visible = true;
            phcashier.ddlToDate.Visible = true;
            phcashier.label13.Visible = true;
            phcashier.label1.Visible = true;
            phcashier.label4.Visible = false;
            phcashier.Show();
        }

        private void lblShopName_Click(object sender, EventArgs e)
        {
            //pnlReports.Visible = false;
            pnlAdmin.Visible = false;
            //pnlGraph.Visible = false;
            panel2.Visible = false;
            //btnAdministrator.ForeColor = System.Drawing.Color.White;
            ////btnAppoinments.ForeColor = System.Drawing.Color.White;
            //btnReturnSupp.ForeColor = System.Drawing.Color.White;
            //btnphnOrder.ForeColor = System.Drawing.Color.White;
            //btnReturns.ForeColor = System.Drawing.Color.White;
            //btnReports.ForeColor = System.Drawing.Color.White;
            Frm_Shop frm = new Frm_Shop
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            frm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = true;
            panel2.Visible = false;
            Inventory.Tax Tax = new Inventory.Tax
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            Tax.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "VATReport";
            panel2.Visible = false;
            Inventory.Reports phcashier = new Inventory.Reports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            phcashier.lblCatName.Visible = false;
            phcashier.ddlcatname.Visible = false;
            phcashier.label2.Visible = true;
            phcashier.textBox1.Visible = true;
            phcashier.lblCatName.Visible = false;
            phcashier.label3.Visible = false;
            phcashier.label4.Visible = false;
           
            phcashier.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "BestProduct";
            Inventory.Reports phcashier = new Inventory.Reports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            phcashier.lblCatName.Visible = false;
            phcashier.ddlcatname.Visible = false;
            phcashier.label2.Visible = false;
            phcashier.textBox1.Visible = false;
            phcashier.label3.Visible = false;

            phcashier.ddlFromDate.Visible = true;
            phcashier.ddlToDate.Visible = true;
            phcashier.label13.Visible = true;
            phcashier.label1.Visible = true;
            phcashier.label4.Visible = false;
            phcashier.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                Inventory.DealerDetails DealerDetails = new Inventory.DealerDetails
                {
                    MdiParent = this,
                    Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right))),
                    Dock = DockStyle.Fill
                };
                DealerDetails.Show();
            }
            catch (Exception ex)
            {
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "DueReport";
            panel2.Visible = false;
            Inventory.Reports phcashier = new Inventory.Reports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            phcashier.lblCatName.Visible = false;
            phcashier.ddlcatname.Visible = false;
            phcashier.label2.Visible = false;
            phcashier.textBox1.Visible = true;
            phcashier.lblCatName.Visible = false;
            phcashier.label3.Visible = false;
            phcashier.ddlToDate.Visible = false;
            phcashier.ddlFromDate.Visible = false;
            phcashier.label4.Visible = true;
            phcashier.label1.Visible = false;
            phcashier.label13.Visible = false;

            phcashier.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = true;
            panel2.Visible = false;
            Inventory.Racks Racks = new Inventory.Racks
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            Racks.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = true;
            panel2.Visible = false;
            Inventory.Units Units = new Inventory.Units
            // stock.MdiParent = this;
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            Units.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            pnlAdmin.Visible = false;
            pnlAccounts.Visible = false;
            pnlLogo.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
          
        }

        private void button25_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            //pnlAdmin.Visible = true;
            panel2.Visible = false;
            Inventory.AgentDetails AgentDetails = new Inventory.AgentDetails
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            AgentDetails.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            //pnlAdmin.Visible = true;
            panel2.Visible = false;
            Inventory.AgentComission AgentComission = new Inventory.AgentComission
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            AgentComission.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            //pnlAdmin.Visible = true;
            panel2.Visible = false;
            Inventory.AgentReports AgentReports = new Inventory.AgentReports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            AgentReports.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            //pnlAdmin.Visible = true;
            panel2.Visible = false;
            Inventory.PayAgentComission PayAgentComission = new Inventory.PayAgentComission
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            PayAgentComission.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            Inventory.Stock stock = new Inventory.Stock
            // stock.MdiParent = this;
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            stock.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            pnlAccounts.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            ReturnToSupplier rtnStock = new ReturnToSupplier
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            rtnStock.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            pnlAccounts.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            PurchaseOrder rtnStock = new PurchaseOrder
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            rtnStock.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            pnlAccounts.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            PurchasePayment rtnStock = new PurchasePayment
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            rtnStock.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            pnlAccounts.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            PurchaseStockAdjist rtnStock = new PurchaseStockAdjist
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            rtnStock.Show();

        }

        private void button32_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "StockPurchase1";
            panel2.Visible = false;
            Inventory.SupplierReport phcashier = new Inventory.SupplierReport
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
           

            phcashier.Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "SupplierReturn";
            panel2.Visible = false;
            Inventory.SupplierReport phcashier = new Inventory.SupplierReport
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };


            phcashier.Show();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            GlobalData.ReportName = "SupplierPayment";
            panel2.Visible = false;
            Inventory.SupplierReport phcashier = new Inventory.SupplierReport
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };


            phcashier.Show();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = true;
            panel2.Visible = false;
            Inventory.Company Units = new Inventory.Company
            // stock.MdiParent = this;
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            Units.Show();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            Inventory.BarcodeReport phcashier = new Inventory.BarcodeReport
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            phcashier.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            Inventory.SubReports phcashier = new Inventory.SubReports
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };
            //phcashier.lblCatName.Visible = false;
            phcashier.ddlcatname.Visible = false;
            phcashier.label2.Visible = true;
            phcashier.textBox1.Visible = true;
            phcashier.label4.Visible = false;
            phcashier.Show();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            pnlLogo.Visible = false;
            pnlAdmin.Visible = false;
            panel2.Visible = false;
            pnlAccounts.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            Frm_POS form = new Frm_POS
            {
                MdiParent = this,
                Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right))),
                Dock = DockStyle.Fill
            };

            form.Show();
        }

       

      
      

 
    }
}
