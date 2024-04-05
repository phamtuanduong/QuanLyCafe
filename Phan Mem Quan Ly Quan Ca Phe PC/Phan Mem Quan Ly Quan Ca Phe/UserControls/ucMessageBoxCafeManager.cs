using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.UserControls
{
    public partial class ucMessageBoxCafeManager : UserControl
    {
        #region Variable

        private int temp;
        private ucCafeManager ucCafeManager;
        private ucAccountManager ucAccountManager;

        #endregion Variable

        #region Method

        public void setUCCafeManager(ucCafeManager ucCafeManager)
        {
            this.ucCafeManager = ucCafeManager;
        }

        public void setUCAccountManager(ucAccountManager ucAccountManager)
        {
            this.ucAccountManager = ucAccountManager;
        }

        public ucMessageBoxCafeManager()
        {
            InitializeComponent();
            this.Load += UcMessageBoxCafeManager_Load;
        }

        private void UcMessageBoxCafeManager_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            g2btnCancel.Visible = false;
        }

        public void setMessage(string mess, int i)
        {
            lbContent.Text = mess;
            this.temp = i;
            if (temp == 1)
            {
                changeLocation();
            }
            else
            {
                changeLocation();
                g2btnCancel.Visible = true;
            }
        }

        public void setDisable(Guna2Button g2btn1, Guna2Button g2btn2)
        {
            g2btn1.Enabled = false;
            g2btn2.Enabled = false;
        }

        private void changeLocation()
        {
            if (temp == 1)
            {
                g2btnOK.Location = new Point(126, 157);
                lbContent.Location = new Point(105, 75);
            }
            else
            {
                g2btnOK.Location = new Point(43, 157);
                g2btnCancel.Location = new Point(213, 157);
                lbContent.Location = new Point(38, 74);
            }
        }

        #endregion Method

        #region Event

        private void g2btnOK_Click(object sender, EventArgs e)
        {
            if (temp == 1)
            {
                changeLocation();
                this.Visible = false;
                ucCafeManager.setEnable();
            }
            else if (temp == 2)
            {
                this.Visible = false;
                ucCafeManager.printBill(1);
                ucCafeManager.setEnable();
            }
        }

        private void g2btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ucCafeManager.setEnable();
        }

        #endregion Event
    }
}