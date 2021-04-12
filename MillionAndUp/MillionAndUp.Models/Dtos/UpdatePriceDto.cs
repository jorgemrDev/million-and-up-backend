using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Models.Dtos
{
   public class UpdatePriceDto
    {
        public Guid PropertyId { get; set; }
        public float Price { get; set; }
    }
}
