using MilionAndUp.Models;
using MillionAndUp.Models.Dtos;
using MillionAndUp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Repository.Implementations
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly PropertyContext _propertyContext;
        public PropertyRepository(PropertyContext propertyContext)
        {
            _propertyContext = propertyContext;
        }
        public async Task<Property> CreateProduct(PropertyDto property)
        {
            var propertyObj = new Property
            {
                Name = property.Name
            };

            _propertyContext.Property.Add(propertyObj);
            var rows = await _propertyContext.SaveChangesAsync();

            if (rows > 0)
                return propertyObj;

            throw new Exception("There was an error inseting Author");

        }
    }
}
