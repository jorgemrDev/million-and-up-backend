using MilionAndUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Models.Dtos
{
    public class SearchResult
    {
        public List<Property> Properties { get; set; }
        public SearchParameters SearchParameters { get; set; }
        
    }
}
