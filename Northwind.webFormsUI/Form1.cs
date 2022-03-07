using Northwind.Bussines.Abstract;
using Northwind.Bussines.Concrate;
using Northwind.DataAcces.Concrate.EntityFramework;
using Northwind.DataAcces.Concrate.NHibarnate;
using Northwind.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.webFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IProductService _productService = new ProductManager(new EfProductDal());
        ICategoryService _categoryService = new CategoryManager(new efCategoryDal());


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

            cbxCategory2.DataSource = _categoryService.GetAll();
            cbxCategory2.DisplayMember = "CategoryName";
            cbxCategory2.ValueMember = "CategoryId";



        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch 
            {

            }
            }

        private void tbxProductName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbxProductName.Text))
                LoadProducts();
            else
                dgwProduct.DataSource = _productService.GetProductsByName(tbxProductName.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productService.Add(new Product
            {
                CategoryId = Convert.ToInt32(cbxCategory2.SelectedValue),
                ProductName = tbxProductName2.Text,
                QuantityPerUnit = tbxQuantityPerUnit.Text,
                UnitPrice = Convert.ToInt16(tbxUnitPrice.Text),
                UnitsInStock = Convert.ToInt16(tbxQuantityPerUnit.Text)
            }) ;
            LoadProducts();
            tbxProductName2.Text = string.Empty;
        }

        private void dgwProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                ProductName = tbxProductNameUpdate.Text,
                CategoryId = Convert.ToInt32(cbxCategoryIdUpdate.SelectedValue),
                UnitsInStock = Convert.ToInt16(tbxUnitslnStockUpdate.Text),
                QuantityPerUnit = tbxQuantityPerUnitUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text)
            });
            LoadProducts();
        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProduct.CurrentRow;
            tbxProductNameUpdate.Text = row.Cells[0].Value.ToString();    
            cbxCategoryIdUpdate.Text = row.Cells[1].Value.ToString();    
            tbxUnitPriceUpdate.Text = row.Cells[2].Value.ToString();    
            tbxQuantityPerUnitUpdate.Text = row.Cells[3].Value.ToString();
            tbxUnitslnStockUpdate.Text = row.Cells[4].Value.ToString();

            cbxCategoryIdUpdate.DataSource = _categoryService.GetAll();
            cbxCategoryIdUpdate.DisplayMember = "CategoryName";
            cbxCategoryIdUpdate.ValueMember = "CategoryId";
        }

        private void cbxCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(dgwProduct.CurrentRow != null)
                _productService.Delete(new Product
                {
                    ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)
                });
            LoadProducts();
        }
    }
}
