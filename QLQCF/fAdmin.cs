﻿using QLQCF.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQCFTest
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        BindingSource accountList = new BindingSource();

        public fAdmin()
        {
            InitializeComponent();
            Load();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void Load()
        {
            dtgvCategory.DataSource = categoryList;
            dtgvFood.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            LoadListFood();
            LoadListCatagory();
            LoadListAccount();
            AddFoodBinding();
            AddCategoryBinding();
            AddAccountBinding();
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCatagory();
        }

        void LoadListCatagory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }

        void AddCategoryBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbCategoryActive.DataBindings.Add(new Binding("text", dtgvCategory.DataSource, "active", true, DataSourceUpdateMode.Never));
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }
        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "NameFood", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("text", dtgvFood.DataSource, "ID_Food", true, DataSourceUpdateMode.Never));
            cbFoodCategory.DataBindings.Add(new Binding("text", dtgvFood.DataSource, "ID_FoodCategory", true, DataSourceUpdateMode.Never));
            txbFoodPrice.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }

        void LoadListAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            txbType.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }


        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = Convert.ToInt32(cbFoodCategory.Text);
            float price = float.Parse(txbFoodPrice.Text);

            if (FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công!");
                LoadListFood();
            }
            else
            {
                MessageBox.Show("Thêm món thất bại!");
            }

        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = Convert.ToInt32(cbFoodCategory.Text);
            float price = float.Parse(txbFoodPrice.Text);
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(name, categoryID, price, id))
            {
                MessageBox.Show("Sửa món thành công!");
                LoadListFood();
            }
            else
            {
                MessageBox.Show("Sửa món thất bại!");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công!");
                LoadListFood();
            }
            else
            {
                MessageBox.Show("Xóa món thất bại!");
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;

            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công!");
                LoadListCatagory();
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại!");
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.UpdateCategory(name, id))
            {
                MessageBox.Show("Sửa danh mục thành công!");
                LoadListCatagory();
            }
            else
            {
                MessageBox.Show("Sửa danh mục thất bại!");
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbCategoryID.Text);

            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa danh mục thành công!");
                LoadListCatagory();
            }
            else
            {
                MessageBox.Show("Xóa danh mục thất bại!");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

    }
}
