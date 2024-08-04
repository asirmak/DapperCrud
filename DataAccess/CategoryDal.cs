using Dapper;
using Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccess
{
    public class CategoryDal : DapperEntityRepositoryBase<Category>, ICategoryDal
    {
    }
}
