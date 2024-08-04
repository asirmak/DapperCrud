using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        void Add(Category category);
        void Delete(int id);

        Category GetById(int id);
        void Update(Category category);
    }
}
