using Domain.Common;
using Domain.Common.Enums;
using Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : AuditableEntity
    {
        
        [Key]
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public StatusId StatusId { get; set; }
        public Status Status { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }


    }
}
