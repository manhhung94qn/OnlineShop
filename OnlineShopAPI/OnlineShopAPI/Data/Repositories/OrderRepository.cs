using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepositoryBase<Model.Order>
    {

    }
    public class OrderRepository : RepositoryBase<Model.Order>, IOrderRepository
    {
        public OrderRepository(OnlineShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
