using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Products")]
    public class Product : IEntity
    {
        [PrimaryKey]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string? ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
