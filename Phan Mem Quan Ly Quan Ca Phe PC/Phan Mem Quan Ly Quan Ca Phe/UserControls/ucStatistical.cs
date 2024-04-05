using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager;
using DGVPrinterHelper;
using System.Data.SqlClient;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.UserControls
{
    public partial class ucStatistical : UserControl
    {
        public ucStatistical()
        {
            InitializeComponent();
            this.Load += UcStatistical_Load;
        }

        private void UcStatistical_Load(object sender, EventArgs e)
        {
            loadUCStatiscal();
        }

        public void loadUCStatiscal()
        {
            g2btnPrint.Visible = false;
            g2btnItemMax.Visible = false;
            g2btnItemMin.Visible = false;
            LoadDateTimePickerBill();
            LoadListBillByDate(g2dtpkDateFrom.Value, g2dtpkDateTo.Value);
            UpdateFontDTGVStatistical();
        }

        private void UpdateFontDTGVStatistical()
        {
            foreach (DataGridViewColumn c in g2dtgvStatistical.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 12F, GraphicsUnit.Pixel);
            }
            this.g2dtgvStatistical.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            this.g2dtgvStatistical.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F);
            this.g2dtgvStatistical.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F);
            this.g2dtgvStatistical.ColumnHeadersHeight = 25;
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            g2dtgvStatistical.DataSource = BillMangament.Instance.GetBillListByDate(checkIn, checkOut);

            InsertMaxMinFoodSQL(checkIn, checkOut);

        }

        void InsertMaxMinFoodSQL(DateTime checkIn, DateTime checkOut)
        {
            string query = "delete from dbo.ThongKe";
            string query1 = "delete from dbo.ThongKeMaxMin";
            string query2 = "delete from dbo.TongThongKeTheoIDBill";
            string query3 = "select sum(TotalPrice) from dbo.TongThongKeTheoIDBill";
            using (SqlConnection connection = new SqlConnection(Provider.Instance.getConnectionSTR()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                SqlCommand command1 = new SqlCommand(query1, connection);
                command1.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand(query2, connection);
                command2.ExecuteNonQuery();

                connection.Close();
            }

            BillMangament.Instance.GetTotalPriceIDBill(checkIn, checkOut);
            BillMangament.Instance.GetMaxMinFoodByDate(checkIn, checkOut);

            using (SqlConnection connection = new SqlConnection(Provider.Instance.getConnectionSTR()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query3, connection);
                Double total;
                try
                {
                    total = Convert.ToDouble(command.ExecuteScalar());
                }
                catch { total = 0; }
                lbTotal.Text = total.ToString() + " VND";
                connection.Close();
            }
        }

        


        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            g2dtpkDateFrom.Value = new DateTime(today.Year, today.Month, 1);
            g2dtpkDateTo.Value = g2dtpkDateFrom.Value.AddMonths(1).AddDays(-1);
        }

        private void g2btnStatistical_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            g2btnPrint.Visible = true;
            g2btnItemMax.Visible = true;
            g2btnItemMin.Visible = true;
            LoadListBillByDate(g2dtpkDateFrom.Value, g2dtpkDateTo.Value);
        }

        private void g2btnPrint_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(g2dtpkDateFrom.Value, g2dtpkDateTo.Value);

            string dateFrom = g2dtpkDateFrom.Value.ToString();
            string dateTo = g2dtpkDateTo.Value.ToString();
            string manager = StaticControl.fTableManager.getDisplayName();
            string datePrint = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Cà Phê BiliBili - Thống Kê";
            printer.SubTitle = string.Format
                (
                    "Nhân Viên: {0}" + " - "+ "Ngày In: {1}"+
                    "\n\nThống Kê Doanh Thu"+
                    "\nTừ Ngày: {2} \nĐến Ngày: {3}", manager, datePrint, dateTo,dateFrom
                );

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Tổng Thu: " + lbTotal.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(g2dtgvStatistical);

            g2btnPrint.Visible = false;
        }

        private void g2btnFirst_Click(object sender, EventArgs e)
        {
            g2txtPageNumber.Text = "1";
        }

        private void g2btnPrevious_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(g2txtPageNumber.Text);
            if (page > 1)
            {
                page--;
            }
            g2txtPageNumber.Text = page.ToString();
        }

        private void g2btnNext_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(g2txtPageNumber.Text);
            int sumRecord = BillMangament.Instance.GetNumBillByDate(g2dtpkDateFrom.Value, g2dtpkDateTo.Value);

            if (page < sumRecord)
            {
                page++;
            }
            g2txtPageNumber.Text = page.ToString();
        }

        private void g2btnLast_Click(object sender, EventArgs e)
        {
            int sumRecord = BillMangament.Instance.GetNumBillByDate(g2dtpkDateFrom.Value, g2dtpkDateTo.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            g2txtPageNumber.Text = lastPage.ToString();
        }

        private void g2txtPageNumber_TextChanged(object sender, EventArgs e)
        {
            g2dtgvStatistical.DataSource = BillMangament.Instance.GetBillListByDateAndPage(g2dtpkDateFrom.Value, g2dtpkDateTo.Value, Convert.ToInt32(g2txtPageNumber.Text));
        }

        private void g2btnItemMax_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            g2btnPrint.Visible = true;
            g2dtgvStatistical.DataSource = BillMangament.Instance.MaxItemSoldOut();
        }

        private void g2btnItemMin_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            g2btnPrint.Visible = true;
            g2dtgvStatistical.DataSource = BillMangament.Instance.MinItemSoldOut();
        }
    }
}
