using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int foodID, int count)
        {
            this.ID = id;
            this.BillID = billID;
            this.FoodID = foodID;
            this.Count = count;
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idbill"];
            this.FoodID = (int)row["idfood"];
            this.Count = (int)row["count"];
        }

        private int iD;
        public int ID { get => iD; set => iD = value; }

        private int billID;
        public int BillID { get => billID; set => billID = value; }

        private int foodID;
        public int FoodID { get => foodID; set => foodID = value; }

        private int count;
        public int Count { get => count; set => count = value; }
    }
}
