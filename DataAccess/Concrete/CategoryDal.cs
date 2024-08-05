using Dapper;
using DataAccess.Abstract;
using Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccess.Concrete
{
    public class CategoryDal : DapperEntityRepositoryBase<Category>, ICategoryDal
    {
    }
}
