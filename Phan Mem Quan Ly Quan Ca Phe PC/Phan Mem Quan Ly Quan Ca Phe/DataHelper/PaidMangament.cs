using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataHelper
{
    public class PaidMangament
    {
        public PaidMangament(int id, string name, string describe, int count, int price)
        {
            this.ID = id;
            this.Name = name;
            this.Describe = describe;
            this.Count = count;
            this.Price = price;
        }

        private int iD;
        public int ID { get => iD; set => iD = value; }

        private string name;
        public string Name { get => name; set => name = value; }

        private string describe;
        public string Describe { get => describe; set => describe = value; }

        private int count;
        public int Count { get => count; set => count = value; }

        private string total;
        public string Total
        {
            get { total = GetTotal(); return total; }
            private set => total = value;
        }

        private int price;
        public int Price { get => price; set => price = value; }

        private string infoCount;
        public string InfoCount
        {
            get { infoCount = GetInfo(); return infoCount; }
            private set => infoCount = value;
        }


        private string GetTotal() => (Count * Price * 1000).ToString("c", System.Globalization.CultureInfo.CreateSpecificCulture("vi"));


        private string GetInfo() => $"{Count} x {(Price * 1000).ToString("c", System.Globalization.CultureInfo.CreateSpecificCulture("vi"))}";

        
    }
}
