using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaTimeDomo.DataAccess.Repository.IRpository;
using TeaTimeDomo.Models;

namespace TeaTimeDomo.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>  
    {
        void Update(Product obj);
        //void Save();
    }
}