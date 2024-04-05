using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager
{
    public class CategoryMangament
    {
        private static CategoryMangament instance;

        public static CategoryMangament Instance
        {
            get { if (instance == null) instance = new CategoryMangament(); return CategoryMangament.instance; }
            private set { CategoryMangament.instance = value; }
        }

        private CategoryMangament() { }

        public List<Category> GetListCategory()
        {
            List<Category> listCategory = new List<Category>();
            string query = " select * from dbo.DanhMucTA ";
            DataTable data = Provider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                listCategory.Add(category);
            }
            return listCategory;
        }

        public Category GetCategoryByID(int id)
        {
            Category category = null;

            string query = " select * from dbo.DanhMucTA where id = " + id;
            DataTable data = Provider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }

            return category;
        }
    }
}
