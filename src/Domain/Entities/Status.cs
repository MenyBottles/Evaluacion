using Domain.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Status
    {
        public StatusId StatusId { get; set; }
        public string? Value { get; set; }
    }
}
