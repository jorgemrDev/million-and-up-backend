using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionAndUp.Models
{
    public class Property
    {
        public Guid PropertyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Price { get; set; }
        public int CodeInternal { get; set; }
        public int Year { get; set; }
        public ICollection<Owner> OwnerList { get; set; }
        public ICollection<PropertyImage> PropertyImageList { get; set; }
        public ICollection<PropertyTrace> PropertyTraceList { get; set; }
    }
}
