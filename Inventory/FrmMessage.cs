using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Inventory
{
    public partial class FrmMessage : Form
    {
        public FrmMessage()
        {
            InitializeComponent();
        }

        
        #region constant defiend in form of enumration which is used in showMessage class.

        public enum enumMessageIcon
        {
            Error,
            Warning,
            Information,
            Question,
        }

        public enum enumMessageButton
        {
            OK,
            YesNo,
            YesNoCancel,
            OKCancel
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.WhiteSmoke, Color.AliceBlue, 60);
            e.Graphics.FillRectangle(brush, rect);
            base.OnPaint(e);
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
        private void setMessage(string messageText)
        {
            int number = Math.Abs(messageText.Length / 30);
            if (number != 0)
                this.lbltxtmessage.Height = number * 25;
            this.lbltxtmessage.Text = messageText;
            lbltxtmessage.MaximumSize = new Size(350, 0);
            lbltxtmessage.AutoSize = true;
        }

        private void addButton(enumMessageButton MessageButton)
        {
            switch (MessageButton)
            {
                case enumMessageButton.OK:
                    {
                        //If type of enumButton is OK then we add OK button only.
                        Button btnOk = new Button();  //Create object of Button.
                        btnOk.Text = "OK";  //Here we set text of Button.
                        btnOk.DialogResult = DialogResult.OK;  //Set DialogResult property of button.
                        btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                        btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        btnOk.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        btnOk.Image = global::Inventory.Properties.Resources.btn_login1;
                        btnOk.SetBounds(pnlbottom.ClientSize.Width - 80, 5, 75, 25);  // Set bounds of button.
                        pnlbottom.Controls.Add(btnOk);  //Finally Add button control on panel.
                    }
                    break;
                case enumMessageButton.OKCancel:
                    {
                        Button btnOk = new Button();
                        btnOk.Text = "OK";
                        btnOk.DialogResult = DialogResult.OK;
                        btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                        btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        btnOk.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        btnOk.Image = global::Inventory.Properties.Resources.btn_login1;
                        btnOk.SetBounds((pnlbottom.ClientSize.Width - 70), 5, 65, 25);
                        pnlbottom.Controls.Add(btnOk);

                        Button btnCancel = new Button();
                        btnCancel.Text = "Cancel";
                        btnCancel.DialogResult = DialogResult.Cancel;
                        btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                        btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        btnCancel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        btnCancel.Image = global::Inventory.Properties.Resources.btn_login1;
                        btnCancel.SetBounds((pnlbottom.ClientSize.Width - (btnOk.ClientSize.Width + 5 + 80)), 5, 75, 25);
                        pnlbottom.Controls.Add(btnCancel);

                    }
                    break;
                case enumMessageButton.YesNo:
                    {
                        Button btnNo = new Button();
                        btnNo.Text = "No";
                        btnNo.DialogResult = DialogResult.No;
                        btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                        btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        btnNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        btnNo.Image = global::Inventory.Properties.Resources.btn_login1;
                        btnNo.SetBounds((pnlbottom.ClientSize.Width - 70), 5, 65, 25);
                        pnlbottom.Controls.Add(btnNo);

                        Button btnYes = new Button();
                        btnYes.Text = "Yes";
                        btnYes.DialogResult = DialogResult.Yes;                        
                        btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                        btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        btnYes.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        btnYes.Image = global::Inventory.Properties.Resources.btn_login1;
                        btnYes.SetBounds((pnlbottom.ClientSize.Width - (btnNo.ClientSize.Width + 5 + 80)), 5, 75, 25);
                        pnlbottom.Controls.Add(btnYes);
                    }
                    break;
                case enumMessageButton.YesNoCancel:
                    {
                        Button btnCancel = new Button();
                        btnCancel.Text = "Cancel";
                        btnCancel.DialogResult = DialogResult.Cancel;
                        btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                        btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        btnCancel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        btnCancel.Image = global::Inventory.Properties.Resources.btn_login1;
                        btnCancel.SetBounds((pnlbottom.ClientSize.Width - 70), 5, 65, 25);
                        pnlbottom.Controls.Add(btnCancel);

                        Button btnNo = new Button();
                        btnNo.Text = "No";
                        btnNo.DialogResult = DialogResult.No;
                        btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                        btnNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        btnNo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        btnNo.Image = global::Inventory.Properties.Resources.btn_login1;
                        btnNo.SetBounds((pnlbottom.ClientSize.Width - (btnCancel.ClientSize.Width + 5 + 80)), 5, 75, 25);
                        pnlbottom.Controls.Add(btnNo);

                        Button btnYes = new Button();
                        btnYes.Text = "Yes";
                        btnYes.DialogResult = DialogResult.No;
                        btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                        btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
                        btnYes.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
                        btnYes.Image = global::Inventory.Properties.Resources.btn_login1;
                        btnYes.SetBounds((pnlbottom.ClientSize.Width - (btnCancel.ClientSize.Width + btnNo.ClientSize.Width + 10 + 80)), 5, 75, 25);
                        pnlbottom.Controls.Add(btnYes);
                    }
                    break;
            }
        }

        private void addIconImage(enumMessageIcon MessageIcon)
        {
            switch (MessageIcon)
            {
                case enumMessageIcon.Error:
                    pictureBox1.Image = imageList1.Images["Error"];  //Error is key name in imagelist control which uniqly identified images in ImageList control.
                    break;
                case enumMessageIcon.Information:
                    pictureBox1.Image = imageList1.Images["Information"];
                    break;
                case enumMessageIcon.Question:
                    pictureBox1.Image = imageList1.Images["Question"];
                    break;
                case enumMessageIcon.Warning:
                    pictureBox1.Image = imageList1.Images["Warning"];
                    break;
            }
        }

        #region Overloaded Show message to display message box.

        /// <summary>
        /// Show method is overloaded which is used to display message
        /// and this is static method so that we don't need to create 
        /// object of this class to call this method.
        /// </summary>
        /// <param name="messageText"></param>
        public static DialogResult Show(string messageText)
        {
            FrmMessage frmMessage = new FrmMessage();
            frmMessage.setMessage(messageText);
            frmMessage.addIconImage(enumMessageIcon.Information);
            frmMessage.addButton(enumMessageButton.OK);
            return frmMessage.ShowDialog();
        }

        public static DialogResult Show(string messageText, string messageTitle)
        {
            FrmMessage frmMessage = new FrmMessage();
            frmMessage.Text = messageTitle;
            frmMessage.setMessage(messageText);
            frmMessage.addIconImage(enumMessageIcon.Information);
            frmMessage.addButton(enumMessageButton.OK);
            return frmMessage.ShowDialog();
            
        }

        public static DialogResult Show(string messageText, string messageTitle, enumMessageButton messageButton,enumMessageIcon messageIcons)
        {
            FrmMessage frmMessage = new FrmMessage();
            frmMessage.setMessage(messageText);
            frmMessage.Text = messageTitle;            
            frmMessage.addButton(messageButton);
            frmMessage.addIconImage(messageIcons);
            return frmMessage.ShowDialog();
        }
               
        #endregion

        public void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
