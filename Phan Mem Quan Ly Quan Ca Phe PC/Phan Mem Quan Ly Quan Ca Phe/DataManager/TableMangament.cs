using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager
{
    class TableMangament
    {
        private static TableMangament instance;

        public static TableMangament Instance
        {
            get { if (instance == null) instance = new TableMangament(); return TableMangament.instance; }
            private set { TableMangament.instance = value; }
        }

        public static int TableWidth = 73;
        public static int TableHeight = 73;
        public static int TableRadius = 15;
        private TableMangament() { }

        public void SwitchTable(int id1, int id2)
        {
            Provider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2 ", new object[] { id1, id2 });
        }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = Provider.Instance.ExecuteQuery(" USP_GetTableList ");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }

    }
}
