//using Northwind.DataAcces.Concrate;
using Northwind.Bussines.Abstract;
using Northwind.DataAcces.Abstract;
using Northwind.Entities.Concrate;
using System.Collections.Generic;


namespace Northwind.Bussines.Concrate
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
           _productDal.Add(product);
        }

        public void Delete(Product product)
        {
           _productDal.Delete(product);    
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p=>p.CategoryId==categoryId);
        }

        public List<Product> GetProductsByName(string productName)
        {
            return _productDal.GetAll(p => p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        public void Update(Product product)
        {
                _productDal.Update(product); 

        }
    }
}
