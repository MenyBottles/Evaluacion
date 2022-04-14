using Domain.Common.Enums;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public StatusId StatusId { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }


    }
}
