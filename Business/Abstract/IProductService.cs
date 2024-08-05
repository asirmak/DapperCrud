using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product category);
        void Delete(int id);
        void Update(Product category);
    }
}
