using MilionAndUp.Models;
using MillionAndUp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<Property> CreateProperty(PropertyDto property);
        Task<bool> UpdatePrice(UpdatePriceDto priceDto);
        Task<Property> UpdateProperty(PropertyDto propertyDto);
        Task<SearchResult> SearchProperties(SearchParameters parameters);
    }
}
