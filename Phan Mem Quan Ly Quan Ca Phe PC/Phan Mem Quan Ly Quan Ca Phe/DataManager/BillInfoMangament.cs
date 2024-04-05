using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager
{
    class BillInfoMangament
    {
        private static BillInfoMangament instance;

        public static BillInfoMangament Instance
        {
            get { if (instance == null) instance = new BillInfoMangament(); return BillInfoMangament.instance; }
            private set { BillInfoMangament.instance = value; }
        }

        public BillInfoMangament() { }

        public void DeleteBillInforByFood(int id)
        {
            Provider.Instance.ExecuteQuery(" delete dbo.ThongTinHD where idFood = " + id);
        }

        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = Provider.Instance.ExecuteQuery(" select * from dbo.ThongTinHD where idBill = " + id);
            foreach (DataRow item in data.Rows)
            {
                BillInfo infor = new BillInfo(item);
                listBillInfo.Add(infor);
            }

            return listBillInfo;
        }

        //public void InsertBillInfo(int idBill, int idFood, int count)
        //{
        //    Provider.Instance.ExecuteNonQuery(" exec USP_InsertBillInfo @idBill , @idFood , @count ", new object[] { idBill, idFood, count });
        //}
        public void InsertBillInfo(int idBill, int idFood, int count, string note)
        {
            Provider.Instance.ExecuteNonQuery(" exec USP_InsertBillInfo @idBill , @idFood , @count , @noteOrder ", new object[] { idBill, idFood, count, note });
        }
    }
}
