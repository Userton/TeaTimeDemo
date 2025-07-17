using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDomo.DataAccess.Repository.IRepository;
using TeaTimeDomo.Models;

namespace TeaTimeDomo.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Add(Category obj)
        {
            _db.Categories.Add(obj);
        }
        
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
