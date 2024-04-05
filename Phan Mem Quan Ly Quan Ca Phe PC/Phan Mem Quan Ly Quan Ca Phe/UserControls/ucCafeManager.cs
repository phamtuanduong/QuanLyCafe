using DGVPrinterHelper;
using Guna.UI2.WinForms;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Menu = Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction.Menu;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.UserControls
{
    public partial class ucCafeManager : UserControl
    {
        #region Variable

        private Function fn = new Function();
        private String query;
        protected int n;

        #endregion Variable

        #region Method

        public ucCafeManager()
        {
            InitializeComponent();
            this.Load += UcCafeManager_Load;
        }

        private void UcCafeManager_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadCategory();
            UpdateFontDTGVBill();
        }

        private void UpdateFontDTGVBill()
        {
            foreach (DataGridViewColumn c in g2dtgvBill.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 12F, GraphicsUnit.Pixel);
            }
            this.g2dtgvBill.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            this.g2dtgvBill.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F);
            this.g2dtgvBill.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F);
            this.g2dtgvBill.ColumnHeadersHeight = 25;
        }

        private void LoadTable()
        {
            flpTable.Controls.Clear();

            List<Table> tableList = TableMangament.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Guna2Button g2btn = new Guna2Button() { Width = TableMangament.TableWidth, Height = TableMangament.TableHeight, BorderRadius = TableMangament.TableRadius, Font = new Font("Segoe UI", 11.64f) };

                g2btn.Text = item.Name + Environment.NewLine + item.Status;

                g2btn.Click += G2btn_Click;

                g2btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        g2btn.BackColor = Color.White;
                        g2btn.ForeColor = Color.White;
                        g2btn.FillColor = Color.FromArgb(94, 148, 255);
                        break;

                    default:
                        g2btn.BackColor = Color.White;
                        g2btn.ForeColor = Color.White;
                        g2btn.FillColor = Color.Orange;
                        break;
                }

                flpTable.Controls.Add(g2btn);
            }
        }

        private void showBill(int id)
        {
            g2dtgvBill.Rows.Clear();

            List<Menu> listBillInfo = MenuMangament.Instance.GetListMenuTable(id);

            float totalPrice = 0;

            foreach (Menu item in listBillInfo)
            {
                n = g2dtgvBill.Rows.Add();
                g2dtgvBill.Rows[n].Cells[0].Value = item.FoodName.ToString();
                g2dtgvBill.Rows[n].Cells[1].Value = item.Count.ToString();
                g2dtgvBill.Rows[n].Cells[2].Value = item.NoteOrder.ToString();
                g2dtgvBill.Rows[n].Cells[3].Value = item.Price.ToString();
                g2dtgvBill.Rows[n].Cells[4].Value = item.TotalPrice.ToString();
                totalPrice += item.TotalPrice;
            }

            CultureInfo culture = new CultureInfo("vi-VN");

            Thread.CurrentThread.CurrentCulture = culture;

            g2txtFinalTotal.Text = totalPrice.ToString("c");
        }

        private void LoadCategory()
        {
            List<Category> listCategory = CategoryMangament.Instance.GetListCategory();

            g2cbItemList.DataSource = listCategory;

            g2cbItemList.DisplayMember = "Name";
        }

        private void LoadFoodListByCategoryID(int id)
        {
            List<Food> listFood = FoodMangament.Instance.GetFoodByCategoryID(id);

            lbxItemList.DataSource = listFood;

            lbxItemList.DisplayMember = "Name";
        }

        private void addOrder()
        {
            Table table = g2dtgvBill.Tag as Table;

            if (table == null)
            {
                setMess("Hãy Chọn Bàn!!!", 1);
                return;
            }

            int idBill = BillMangament.Instance.GetUnCheckBillIDByTableID(table.ID);
            int foodID = (lbxItemList.SelectedItem as Food).ID;
            int count = (int)g2nuAmount.Value;
            if (idBill == -1)
            {
                if (count != 0)
                {
                    BillMangament.Instance.InsertBill(table.ID);
                    BillInfoMangament.Instance.InsertBillInfo(BillMangament.Instance.GetMaxIDBill(), foodID, count, g2txtNoteOrder.Text);
                }
                else
                {
                    setMess("Số Lượng >0", 1);
                }
            }
            else
            {
                BillInfoMangament.Instance.InsertBillInfo(idBill, foodID, count, g2txtNoteOrder.Text);
            }

            showBill(table.ID);
            LoadTable();
            g2nuAmount.Value = default;
            g2txtNoteOrder.Text = default;
        }

        public string getTableName()
        {
            Table table = g2dtgvBill.Tag as Table;
            string tableName = table.Name;
            return tableName;
        }

        public string getToltalPrice()
        {
            double finalTotalPrice = Convert.ToDouble(g2txtFinalTotal.Text.Split(',')[0]);
            string toltalPrice = finalTotalPrice.ToString();
            return toltalPrice;
        }

        public void setEnable()
        {
            g2btnAdd.Enabled = true;
            g2btnPay.Enabled = true;
        }

        private void setMess(string text, int i)
        {
            ucMessageBoxCafeManager1.setUCCafeManager(this);
            ucMessageBoxCafeManager1.Visible = true;
            ucMessageBoxCafeManager1.BringToFront();
            ucMessageBoxCafeManager1.setDisable(g2btnAdd, g2btnPay);
            ucMessageBoxCafeManager1.setMessage(text, i);
        }

        public void paid()
        {
            Table table = g2dtgvBill.Tag as Table;

            if (table == null)
            {
                setMess("Hãy Chọn Bàn!!!", 1);
                return;
            }

            double finalTotalPrice = Convert.ToDouble(g2txtFinalTotal.Text.Split(',')[0]);

            int idBill = BillMangament.Instance.GetUnCheckBillIDByTableID(table.ID);

            if (idBill != -1)
            {
                string temp = string.Format("Bạn Có Muốn Thanh Toán Bàn {0}\n Tổng Tiền = {1}", this.getTableName(), this.getToltalPrice());
                setMess(temp, 2);
            }
        }

        public void printBill(int i)
        {
            Table table = g2dtgvBill.Tag as Table;

            double finalTotalPrice = Convert.ToDouble(g2txtFinalTotal.Text.Split(',')[0]);

            int discount = 0;

            int idBill = BillMangament.Instance.GetUnCheckBillIDByTableID(table.ID);

            if (i == 1)
            {
                string dt = "";
                string displayName = StaticControl.fTableManager.getDisplayName();

                dt = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss ");

                DGVPrinter printer = new DGVPrinter();
                printer.Title = "Cà Phê BiliBili - Hóa Đơn";
                printer.SubTitle = string.Format
                    (
                        "Số Hóa Đơn: {0} \nNgày: {1} \nNhân Viên: {2}", idBill, dt, displayName
                    );

                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Tổng Tiền: " + g2txtFinalTotal.Text;
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(g2dtgvBill);

                BillMangament.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);

                showBill(table.ID);

                LoadTable();
            }
            else
            {
                BillMangament.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);

                showBill(table.ID);

                LoadTable();
            }
        }

        #endregion Method

        #region Event

        private void G2btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Guna2Button).Tag as Table).ID;

            g2dtgvBill.Tag = (sender as Guna2Button).Tag;

            showBill(tableID);
        }

        private void g2cbItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            Guna2ComboBox cb = sender as Guna2ComboBox;

            if (cb.SelectedItem == null) return;

            Category selected = cb.SelectedItem as Category;

            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }

        private void lbxItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            g2nuAmount.Value = default;

            g2txtNoteOrder.Text = default;

            string text = lbxItemList.GetItemText(lbxItemList.SelectedItem);

            g2txtItemName.Text = text;
        }

        private void g2txtItemName_TextChanged(object sender, EventArgs e)
        {
            string temp = g2txtItemName.Text;

            query = "select price from dbo.ThucAn where name = N'" + temp + "'";

            using (SqlConnection connection = new SqlConnection(Provider.Instance.getConnectionSTR()))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@temp", (string)(g2txtItemName.Text));

                SqlDataReader da = command.ExecuteReader();

                while (da.Read())
                {
                    g2txtPrice.Text = da.GetValue(0).ToString();
                }
                connection.Close();
            }
        }

        private void g2nuAmount_ValueChanged(object sender, EventArgs e)
        {
            int discount = (int)g2nuAmount.Value;

            double totalPrice = Convert.ToDouble(g2txtPrice.Text);

            double finalTotalPrice = totalPrice * discount;

            g2txtTotal.Text = finalTotalPrice.ToString();
        }

        private void g2btnAdd_Click(object sender, EventArgs e)
        {
            addOrder();
        }

        private void g2btnPay_Click(object sender, EventArgs e)
        {
            paid();
        }

        #endregion Event
    }
}