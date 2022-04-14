using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Models
{
    public class AuditableEntity
    {
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
