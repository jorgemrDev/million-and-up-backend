using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionAndUp.Models
{
    public class PropertyTrace
    {
        public Guid PropertyTraceId { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }
        public float Tax { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
