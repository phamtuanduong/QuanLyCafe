using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();

            Load += FTableManager_Load;
        }

        private void FTableManager_Load(object sender, EventArgs e)
        {
            StaticControl.fTableManager = this;
            displayName = lbDisplayName.Text;
            
        }

        string displayName = "";

        #region Method

        private Account loginAcc;

        public Account LoginAcc
        {
            get { return loginAcc; }
            set { loginAcc = value; ChangeAcc(loginAcc.Type); }
        }

        public fTableManager(Account acc) : this()
        {
            this.LoginAcc = acc;
        }

        void ChangeAcc(int type)
        {
            if (type == 1)
            {
                g2btnItemManager.Enabled = true;
                g2btnAccountManager.Enabled = true;
                g2btnStatistical.Enabled = true;
                lbDisplayName.Text = LoginAcc.DisplayName;
                
            }
            else
            {
                lbDisplayName.Text = LoginAcc.DisplayName;
            }
        }

        public string getDisplayName()
        {
            return displayName;
        }

        public string getUserName()
        {
            return loginAcc.UserName;
        }
        #endregion

        #region Event

        private void g2btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {
            timer.Start();
            ucCafeManager1.Visible = false;
            ucMenuManager1.Visible = false;
            ucAccountManager1.Visible = false;
            ucStatistical1.Visible = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        }

        private void g2btnCafeManager_Click(object sender, EventArgs e)
        {
            ucWelcome1.Visible = false;
            ucMenuManager1.Visible = false;
            ucAccountManager1.Visible = false;
            ucStatistical1.Visible = false;
            ucCafeManager1.Visible = true;
            ucCafeManager1.BringToFront();
        }

        #endregion

        private void g2btnItemManager_Click(object sender, EventArgs e)
        {
            ucWelcome1.Visible = false;
            ucAccountManager1.Visible = false;
            ucCafeManager1.Visible = false;
            ucStatistical1.Visible = false;
            ucMenuManager1.Visible = true;
            ucMenuManager1.BringToFront();
        }

        private void g2btnAccountManager_Click(object sender, EventArgs e)
        {
            ucWelcome1.Visible = false;
            ucMenuManager1.Visible = false;
            ucCafeManager1.Visible = false;
            ucStatistical1.Visible = false;
            ucAccountManager1.Visible = true;
            ucAccountManager1.BringToFront();
        }

        private void g2btnStatistical_Click(object sender, EventArgs e)
        {
            ucWelcome1.Visible = false;
            ucMenuManager1.Visible = false;
            ucCafeManager1.Visible = false;
            ucAccountManager1.Visible = false;
            ucStatistical1.Visible = true;
            ucStatistical1.BringToFront();
        }
    }
}
