using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.UserControls;
using Guna.UI2.WinForms;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            txtPassword.KeyDown += TxtPassword_KeyDown;
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                g2btnLogin_Click(null, null);
            }
        }



        #region Method

        public string connectionSTR = @"Data Source=.\sqlexpress;Initial Catalog=DB_CafeManagement;Integrated Security=True";


        private void fLogin_Load(object sender, EventArgs e)
        {
            ucMessageBoxLogin1.Visible = false;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        bool Login(string userName, string passWord)
        {
            return AccountMangament.Instance.Login(userName, passWord);
        }

        #endregion

        #region Event

        // Close Form
        private void g2btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Clear Textbox
        private void g2btnCancel_Click(object sender, EventArgs e)
        {
            txtAccount.Text = "";
            txtPassword.Text = "";
        }

        // Control Textbox Login
        private void txtAccount_Click(object sender, EventArgs e)
        {
            txtAccount.BackColor = Color.White;
            pnAccount.BackColor = Color.White;
            pnPassword.BackColor = SystemColors.Control;
            txtPassword.BackColor = SystemColors.Control;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            pnPassword.BackColor = Color.White;
            pnAccount.BackColor = SystemColors.Control;
            txtAccount.BackColor = SystemColors.Control;
        }

        //Login
        private void g2btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtAccount.Text;
            string passWord = txtPassword.Text;

            if (Login(userName, passWord))
            {
                Account loginAcc = AccountMangament.Instance.GetAccByUserName(userName);

                fTableManager fTableM = new fTableManager(loginAcc);
                this.Hide();
                fTableM.ShowDialog();
                this.Show();
                   
            }
            else
            {
                ucMessageBoxLogin1.setLogin(this);
                ucMessageBoxLogin1.Visible = true;
                ucMessageBoxLogin1.BringToFront();
                ucMessageBoxLogin1.setMessage();
                ucMessageBoxLogin1.setDisable(g2btnLogin, g2btnCancel);
            }
        }

        public void setEnable(int i)
        {
            if (i == 1)
            {
                g2btnLogin.Enabled = true;
                g2btnCancel.Enabled = true;
            }
        }
        #endregion
    }
}
