using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction
{
    public class Menu
    {
        public Menu(string foodName, int count, string noteOrder, float price, float totalPrice = 0)
        {
            this.FoodName = foodName;
            this.Count = count;
            this.NoteOrder = noteOrder;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }

        public Menu(DataRow row)
        {
            this.FoodName = row["Name"].ToString();
            this.Count = (int)row["count"];
            this.NoteOrder = row["noteOrder"].ToString();
            this.Price = (float)Convert.ToDouble((row["price"]).ToString());
            this.TotalPrice = (float)Convert.ToDouble((row["totalPrice"]).ToString());
        }

        private string foodName;
        public string FoodName { get => foodName; set => foodName = value; }

        private int count;
        public int Count { get => count; set => count = value; }

        private string noteOrder;
        public string NoteOrder { get => noteOrder; set => noteOrder = value; }

        private float price;
        public float Price { get => price; set => price = value; }

        private float totalPrice;
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }

    }
}
