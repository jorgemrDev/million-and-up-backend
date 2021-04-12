using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Models.Dtos
{
    public class PropertyDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public float Price { get; set; }
        public int CodeInternal { get; set; }
        public int Year { get; set; }
        public Guid PropertyId { get; set; }
    }
}
