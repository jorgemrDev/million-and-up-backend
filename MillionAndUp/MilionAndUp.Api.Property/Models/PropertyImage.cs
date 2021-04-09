using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionAndUp.Api.Property.Models
{
    public class PropertyImage
    {
        public Guid PropertyImageId { get; set; }
        public Guid PropertyId { get; set; }
        public string Photo { get; set; }
        public bool Enabled { get; set; }
        public Property Property { get; set; }
    }
}
