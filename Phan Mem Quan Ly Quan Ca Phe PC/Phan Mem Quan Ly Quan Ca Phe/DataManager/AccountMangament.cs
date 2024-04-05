using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager
{
    class AccountMangament
    {
        private static AccountMangament instance;
        public static AccountMangament Instance
        {
            get { if (instance == null) instance = new AccountMangament(); return instance; }
            private set { instance = value; }
        }

        private AccountMangament() { }

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord ";
            DataTable result = Provider.Instance.ExecuteQuery(query, new object[] { userName, passWord/*list*/ });

            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = Provider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @passWord , @newPassWord", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }

        public Account GetAccByUserName(string userName)
        {
            string query = " select * from dbo.TaiKhoan where UserName ='" + userName + "'";
            DataTable data = Provider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public DataTable GetListAccount()
        {
            string query = "select UserName, DisplayName, Type from dbo.TaiKhoan";
            return Provider.Instance.ExecuteQuery(query);
        }

        public bool InsertAccount(string userName, string displayName, int type)
        {
            string query = string.Format("insert dbo.TaiKhoan (UserName, DisplayName, Type) values (N'{0}', N'{1}', {2})", userName, displayName, type);
            int result = Provider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount(string userName, string displayName, int type)
        {
            string query = string.Format("update dbo.TaiKhoan set DisplayName = N'{1}', Type = {2} where UserName = N'{0}'", userName, displayName, type);
            int result = Provider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string userName)
        {
            string query = string.Format("delete dbo.TaiKhoan where UserName = N'{0}'", userName);
            int result = Provider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPass(string userName, string passWord)
        {
            string query = string.Format("update dbo.TaiKhoan set PassWord = N'{0}' where UserName = N'{1}'", passWord, userName);
            int result = Provider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public List<Account> SearchAccountByUserName(string userName)
        {
            List<Account> listAccount = new List<Account>();
            string query = string.Format("select * from dbo.TaiKhoan where dbo.fuConvertToUnsign1(UserName) like N'%' +dbo.fuConvertToUnsign1(N'{0}')+ '%'", userName);
            DataTable data = Provider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Account account = new Account(item);
                listAccount.Add(account);
            }
            return listAccount;
        }
    }
}
