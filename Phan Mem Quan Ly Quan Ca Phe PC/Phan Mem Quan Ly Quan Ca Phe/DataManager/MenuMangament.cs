using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager
{
    public class MenuMangament
    {
        private static MenuMangament instance;
        public static MenuMangament Instance
        {
            get { if (instance == null) instance = new MenuMangament(); return MenuMangament.instance; }
            private set { MenuMangament.instance = value; }
        }

        private MenuMangament() { }

        public List<Menu> GetListMenuTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();
            string query = " select f.name, bi.count, bi.noteOrder, f.price, f.price * bi.count as totalPrice " +
                           " from dbo.ThongTinHD as bi, dbo.HoaDon as b, dbo.ThucAn as f " +
                           " where bi.idBill = b.id and bi.idFood = f.id and b.status = 0 and b.idTable = " + id;
            DataTable data = Provider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
