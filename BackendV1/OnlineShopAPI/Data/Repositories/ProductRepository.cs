using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {

    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(OnlineShopDbContext dbContext) : base(dbContext)
        {

        }
    }
}
