using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Guna.UI2.WinForms;
using NPOI.HPSF;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.UserControls
{
    public partial class ucMessageBoxLogin : UserControl
    {
        fLogin login;

        public ucMessageBoxLogin()
        {
            InitializeComponent();
            this.Visible = false;
        }

        public void setLogin(fLogin login)
        {
            this.login = login;
        }

        public void setMessage()
        {
            lbContent.Text = "Sai Tài Khoản Hoặc Mật Khẩu!";
        }

        public void setDisable(Guna2Button g2btn1, Guna2Button g2btn2)
        {
            g2btn1.Enabled = false;
            g2btn2.Enabled = false;
        }

        private void g2btnOK_Click(object sender, EventArgs e)
        {
            login.setEnable(1);
            this.Visible = false;
        }
    }
}
