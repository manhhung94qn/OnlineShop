using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Repositories;
using Data.UnitOfWord;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly OnlineShopDbContext _dbcontext;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(
            OnlineShopDbContext dbContext, 
            IUnitOfWork unitOfWork,
            IProductRepository productRepository
            )
        {
            _dbcontext = dbContext;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public User GetAll()
        {
            Console.WriteLine("Conexão: " + _dbcontext.Database);
            return _dbcontext.User.SingleOrDefault(x=>x.Id==2);
        }

    }
}