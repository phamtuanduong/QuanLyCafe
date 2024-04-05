using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataManager;
using Phan_Mem_Quan_Ly_Quan_Ca_Phe.DataFunction;

namespace Phan_Mem_Quan_Ly_Quan_Ca_Phe.UserControls
{
    public partial class ucMenuManager : UserControl
    {
        BindingSource foodList = new BindingSource();

        public ucMenuManager()
        {
            InitializeComponent();
            LoadFood();
        }

        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodMangament.Instance.SearchFoodByName(name);

            return listFood;
        }

        void LoadFood()
        {
            UpdateFontDTGVMenu();
            g2dtgvMenu.DataSource = foodList;
            LoadListFood();
            LoadCategoryIntoComBox(g2cbxCategoryItem);
            AddFoodBinding();
        }

        void LoadListFood()
        {
            foodList.DataSource = FoodMangament.Instance.GetListFood();
        }

        void AddFoodBinding()
        {
            g2txtName.DataBindings.Add(new Binding("Text", g2dtgvMenu.DataSource, "Name", true, DataSourceUpdateMode.Never));
            g2txtID.DataBindings.Add(new Binding("Text", g2dtgvMenu.DataSource, "ID", true, DataSourceUpdateMode.Never));
            g2nuAmount.DataBindings.Add(new Binding("Value", g2dtgvMenu.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        void LoadCategoryIntoComBox(Guna2ComboBox g2cb)
        {
            g2cb.DataSource = CategoryMangament.Instance.GetListCategory();
            g2cb.DisplayMember = "Name";
        }

        private void UpdateFontDTGVMenu()
        {
            foreach (DataGridViewColumn c in g2dtgvMenu.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Segoe UI", 12F, GraphicsUnit.Pixel);
            }
            this.g2dtgvMenu.DefaultCellStyle.Font = new Font("Segoe UI", 12F);
            this.g2dtgvMenu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F);
            this.g2dtgvMenu.RowHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F);
            this.g2dtgvMenu.ColumnHeadersHeight = 25;
        }

        

        private void g2btnAdd_Click(object sender, EventArgs e)
        {
            string name = g2txtName.Text;
            int categoryID = (g2cbxCategoryItem.SelectedItem as Category).ID;
            float price = (float)g2nuAmount.Value *1000;

            if (FoodMangament.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm Thành Công!");
                LoadListFood();
                if (insertFood != null)
                {
                    insertFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Lỗi!!!");
            }
        }

        private void g2btnEdit_Click(object sender, EventArgs e)
        {
            string name = g2txtName.Text;
            int categoryID = (g2cbxCategoryItem.SelectedItem as Category).ID;
            float price = (float)g2nuAmount.Value *1000;
            int id = Convert.ToInt32(g2txtID.Text);

            if (FoodMangament.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa Thành Công!");
                LoadListFood();
                if (updateFood != null)
                {
                    updateFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Lỗi!!!");
            }
        }

        private void g2btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(g2txtID.Text);

            if (FoodMangament.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa Thành Công!");
                LoadListFood();
                if (deleteFood != null)
                {
                    deleteFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Lỗi!!!");
            }
        }

        private void g2txtID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (g2dtgvMenu.SelectedCells.Count > 0 && g2dtgvMenu.SelectedCells[0].OwningRow.Cells["CategoryID"].Value != null)
                {
                    int id = (int)g2dtgvMenu.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;
                    Category category = CategoryMangament.Instance.GetCategoryByID(id);
                    g2cbxCategoryItem.SelectedItem = category;

                    int index = -1;
                    int i = 0;
                    foreach (Category item in g2cbxCategoryItem.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    g2cbxCategoryItem.SelectedIndex = index;
                }
            }
            catch { }
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private void g2btnSearch_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(g2txtSearch.Text);
        }

        private void g2txtSearch_TextChanged(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(g2txtSearch.Text);
        }

        private void g2dtgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
