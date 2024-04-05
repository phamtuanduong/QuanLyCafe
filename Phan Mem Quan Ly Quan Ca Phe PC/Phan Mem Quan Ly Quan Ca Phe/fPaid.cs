using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager;
using Menu = Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction.Menu;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe
{
    public partial class fPaid : Form
    {
        public fPaid()
        {
            InitializeComponent();
        }

        





        private void fPaid_Load(object sender, EventArgs e)
        {
            List<PaidMangament> _listPayBill = new List<PaidMangament>()
            {
                new PaidMangament(1,"cfe1", "", 1, 30),
                new PaidMangament(2,"cfe2", "", 3, 30),
                new PaidMangament(3,"cfe3", "", 1, 50),
                new PaidMangament(4,"cfe4", "", 1, 30)
            };


            ReportParameter[] rp = new ReportParameter[]
            {
                new ReportParameter("pName", "Huỳnh Cao Thanh Bách"),
                new ReportParameter("pAddress","Cần Thơ - Việt Nam"),
                new ReportParameter("pPhone","0367672138"),
                new ReportParameter("pID", "001"),
                new ReportParameter("pDate", DateTime.Now.ToString("dd/MM/yyyy")),
                new ReportParameter("pTotalCount", 0.ToString("c"))
            };

            ReportDataSource rds = new ReportDataSource("BillInfo", _listPayBill);

            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.SetParameters(rp);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
