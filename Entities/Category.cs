using Core;
using Core.Entities;

namespace Entities
{
    [Table("Categories")]
    public class Category : IEntity
    {
        [PrimaryKey]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
