using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager;
using System;
using System.Drawing;
using System.Windows.Forms;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction;
using System.Collections.Generic;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.UserControls
{
    public partial class ucAccountManager : UserControl
    {
        private BindingSource accountList = new BindingSource();

        public ucAccountManager()
        {
            InitializeComponent();
            this.Load += UcAccountManager_Load;
        }

        private void UcAccountManager_Load(object sender, EventArgs e)
        {
            LoadACC();
        }

        private void LoadACC()
        {
            g2dtgvAccount.DataSource = accountList;
            UpdateFontDTGVAccount();
            LoadAccount();
            AddAccountBinding();
        }

        List<Account> SearchAccountByUserName(string userName)
        {
            List<Account> listAccount = AccountMangament.Instance.SearchAccountByUserName(userName);

            return listAccount;
        }

        private void UpdateFontDTGVAccount()
        {
            foreach (DataGridViewColumn c in g2dtgvAccount.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 12F, GraphicsUnit.Pixel);
            }
            this.g2dtgvAccount.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            this.g2dtgvAccount.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F);
            this.g2dtgvAccount.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F);
            this.g2dtgvAccount.ColumnHeadersHeight = 25;
        }

        private void LoadAccount()
        {
            accountList.DataSource = AccountMangament.Instance.GetListAccount();
        }

        private void AddAccountBinding()
        {
            g2txtUserName.DataBindings.Add(new Binding("Text", g2dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            g2txtDisplayName.DataBindings.Add(new Binding("Text", g2dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            g2nuType.DataBindings.Add(new Binding("Value", g2dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        private void AddAccount(string userName, string displayName, int type)
        {
            if (AccountMangament.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm Thành Công!\nMật Khẩu Mặt Định Là: 0");
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại!");
            }

            LoadAccount();
        }

        private void EditAccount(string userName, string displayName, int type)
        {
            if (AccountMangament.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập Nhật Thành Công!");
            }
            else
            {
                MessageBox.Show("Cập Nhật Thất Bại!");
            }

            LoadAccount();
        }

        private void DeleteAccount(string userName)
        {
            string loginAccount = StaticControl.fTableManager.getUserName();
            if (loginAccount.Equals(userName))
            {
                MessageBox.Show("Không Thể Xóa Tài Khoản Đang Đăng Nhập!!!");
                return;
            }
            if (AccountMangament.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa Thành Công!");
            }
            else
            {
                MessageBox.Show("Xóa Thất Bại!");
            }

            LoadAccount();
        }

        private void ResetPassWord(string userName, string passWord)
        {
            if (AccountMangament.Instance.ResetPass(userName, passWord))
            {
                MessageBox.Show("Đặt Lại Thành Công!");
            }
            else
            {
                MessageBox.Show("Đặt Lại Thất Bại!");
            }
        }

        private void g2btnAdd_Click(object sender, EventArgs e)
        {
            string userName = g2txtUserName.Text;
            string displayName = g2txtDisplayName.Text;
            int type = (int)g2nuType.Value;

            AddAccount(userName, displayName, type);
        }

        private void g2btnEdit_Click(object sender, EventArgs e)
        {
            string userName = g2txtUserName.Text;
            string displayName = g2txtDisplayName.Text;
            int type = (int)g2nuType.Value;

            EditAccount(userName, displayName, type);
        }

        private void g2btnDelete_Click(object sender, EventArgs e)
        {
            string userName = g2txtUserName.Text;

            DeleteAccount(userName);
        }

        private void g2btnResetPass_Click(object sender, EventArgs e)
        {
            string userName = g2txtUserName.Text;
            string passWord = g2txtResetPass.Text;
            if (passWord != null)
                ResetPassWord(userName, passWord);
        }

        private void g2btnSearch_Click(object sender, EventArgs e)
        {
            accountList.DataSource = SearchAccountByUserName(g2txtSearch.Text);
        }

        private void g2txtSearch_TextChanged(object sender, EventArgs e)
        {
            accountList.DataSource = SearchAccountByUserName(g2txtSearch.Text);
        }
    }
}