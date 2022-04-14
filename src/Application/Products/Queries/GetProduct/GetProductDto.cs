using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries.GetProduct
{
    public class GetProductDto
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public string? StatusName { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public decimal FinalPrice { get; set; }

    }
}
