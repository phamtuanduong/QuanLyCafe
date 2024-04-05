using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager
{
    class BillMangament
    {
        private static BillMangament instance;

        public static BillMangament Instance
        {
            get { if (instance == null) instance = new BillMangament(); return BillMangament.instance; }
            private set { BillMangament.instance = value; }
        }

        private BillMangament() { }


        public int GetUnCheckBillIDByTableID(int id)
        {
            DataTable data = Provider.Instance.ExecuteQuery(" select * from dbo.HoaDon where idTable = " + id + " and status = 0 ");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;

            }
            return -1;
        }


        public void InsertBill(int id)
        {
            Provider.Instance.ExecuteNonQuery(" exec USP_InsertBill @idTable ", new object[] { id });
        }

        public void CheckOut(int id, int discount, float totalPrice)
        {
            string query = " update dbo.HoaDon set DateCheckOut = GETDATE(), status = 1," + "discount = " + discount + ", totalPrice = " + totalPrice + " where id =  " + id;
            Provider.Instance.ExecuteNonQuery(query);
        }

        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return Provider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }

        public DataTable GetBillListByDateAndPage(DateTime checkIn, DateTime checkOut, int pageNum)
        {
            return Provider.Instance.ExecuteQuery("exec USP_GetListBillByDateAndPage @checkIn , @checkOut , @page", new object[] { checkIn, checkOut, pageNum });
        }

        public int GetNumBillByDate(DateTime checkIn, DateTime checkOut)
        {
            return (int)Provider.Instance.ExecuteScalar("exec USP_GetNumBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }

        public DataTable GetMaxMinFoodByDate(DateTime checkIn, DateTime checkOut)
        {
            return Provider.Instance.ExecuteQuery("exec USP_GetMaxMinFoodByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }

        public DataTable GetTotalPriceIDBill(DateTime checkIn, DateTime checkOut)
        {
            return Provider.Instance.ExecuteQuery("exec USP_GetTotalPriceIDBill @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }

        public DataTable MaxItemSoldOut()
        {
            return Provider.Instance.ExecuteQuery("select t.name as [Tên Sản Phẩm], t.count as [Số Lượng Bán Ra] from ThongKeMaxMin t,(select MAX(count) MAX from ThongKeMaxMin) m where m.MAX = t.count");
        }

        public DataTable MinItemSoldOut()
        {
            return Provider.Instance.ExecuteQuery("select t.name as [Tên Sản Phẩm], t.count as [Số Lượng Bán Ra] from ThongKeMaxMin t,(select MIN(count) MIN from ThongKeMaxMin) m where m.MIN = t.count");
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)Provider.Instance.ExecuteScalar("select max(id) from dbo.HoaDon");

            }
            catch
            {
                return -1;
            }
        }
    }
}
