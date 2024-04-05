using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager
{
    class FoodMangament
    {
        private static FoodMangament instance;

        public static FoodMangament Instance
        {
            get { if (instance == null) instance = new FoodMangament(); return FoodMangament.instance; }
            private set { FoodMangament.instance = value; }
        }

        private FoodMangament() { }
        // lay thuc an boi id danh muc mon an
        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();

            string query = "select * from dbo.ThucAn where idCategory = " + id;

            DataTable data = Provider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }


        public List<Food> GetListFood()
        {
            List<Food> listFood = new List<Food>();
            string query = " select * from dbo.ThucAn";
            DataTable data = Provider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }

        public List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = new List<Food>();
            string query = string.Format("select * from dbo.ThucAn where dbo.fuConvertToUnsign1(name) like N'%' +dbo.fuConvertToUnsign1(N'{0}')+ '%'", name);
            DataTable data = Provider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }
        // ham them sua xoa sql
        public bool InsertFood(string name, int id, float price)
        {
            string query = string.Format("insert dbo.ThucAn (name, idCategory, price) values (N'{0}', {1}, {2})", name, id, price);
            int result = Provider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateFood(int idFood, string name, int id, float price)
        {
            string query = string.Format("update dbo.ThucAn set name = N'{0}', idCategory = {1}, price = {2} where id = {3}", name, id, price, idFood);
            int result = Provider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteFood(int idFood)
        {
            BillInfoMangament.Instance.DeleteBillInforByFood(idFood);
            string query = string.Format("delete dbo.ThucAn where id = {0}", idFood);
            int result = Provider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
