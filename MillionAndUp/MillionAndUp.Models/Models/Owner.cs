using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionAndUp.Models
{
    public class Owner
    {
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
