using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Models.Dtos
{
    public class SearchParameters
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get;  set; }

        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;


        public string SearchKeyWord { get; set; }
        public float PriceFrom { get; set; }
        public float PriceTo { get; set; }

        public int YearFrom { get; set; }
        public int YearTo { get; set; }

        //public Dictionary<string, string> filters { get; set; }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
