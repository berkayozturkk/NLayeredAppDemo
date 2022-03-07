using Northwind.DataAcces.Abstract;
using Northwind.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAcces.Concrate.EntityFramework
{
    public class EfProductDal: EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal
    {
        
    }
}
