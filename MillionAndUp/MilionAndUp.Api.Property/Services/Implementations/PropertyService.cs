using MilionAndUp.Models;
using MillionAndUp.Models.Dtos;
using MillionAndUp.Repository.Interfaces;
using MillionAndUp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MillionAndUp.Services.Implementations
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public async Task<MilionAndUp.Models.Property> CreateProperty(PropertyDto property)
        {
            return await _propertyRepository.CreateProperty(property);
        }

        public async Task<bool> UpdatePrice(UpdatePriceDto priceDto)
        {
            return await _propertyRepository.UpdatePrice(priceDto);
        }

        public async Task<Property> UpdateProperty(PropertyDto propertyDto)
        {
            return await _propertyRepository.UpdateProperty(propertyDto);
        }

        public async Task<SearchResult> SearchProperties(SearchParameters parameters)
        {
            return await _propertyRepository.SearchProperties(parameters);
        }
    }
}
