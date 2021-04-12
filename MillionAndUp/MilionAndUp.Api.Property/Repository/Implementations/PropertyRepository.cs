using Microsoft.EntityFrameworkCore;
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
        public async Task<Property> CreateProperty(PropertyDto property)
        {
            var propertyObj = new Property
            {
                Name = property.Name,
                Address = property.Address,
                CodeInternal = property.CodeInternal,
                Price = property.Price,
                Year = property.Year
            };

            _propertyContext.Property.Add(propertyObj);
            var rows = await _propertyContext.SaveChangesAsync();

            if (rows > 0)
                return propertyObj;

            throw new Exception("There was an error inseting Property");

        }

        public async Task<bool> UpdatePrice(UpdatePriceDto priceDto)
        {
            var propertyToUpdate = _propertyContext.Property.Where(e => e.PropertyId == priceDto.PropertyId).FirstOrDefault();
            if (propertyToUpdate != null)
            {
                propertyToUpdate.Price = priceDto.Price;
                var rows = await _propertyContext.SaveChangesAsync();
                if (rows > 0)
                    return true;
                throw new Exception("There was an error updating Property");
            }
            return false;
        }

        public async Task<Property> UpdateProperty(PropertyDto propertyDto)
        {
            var propertyToUpdate = _propertyContext.Property.Where(e => e.PropertyId == propertyDto.PropertyId).FirstOrDefault();
            if (propertyToUpdate != null)
            {
                propertyToUpdate.Price = propertyDto.Price;
                propertyToUpdate.Name = propertyDto.Name;
                propertyToUpdate.Address = propertyDto.Address;
                propertyToUpdate.CodeInternal = propertyDto.CodeInternal;
                propertyToUpdate.Year = propertyDto.Year;
                var rows = await _propertyContext.SaveChangesAsync();
                if (rows > 0)
                    return propertyToUpdate;
                throw new Exception("There was an error updating Property");
            }
            throw new Exception("There was an error updating Property");
        }


        public async Task<SearchResult> SearchProperties(SearchParameters parameters)
        {
            var query = _propertyContext.Property.AsQueryable<Property>();

            if (!string.IsNullOrEmpty(parameters.SearchKeyWord))
            {
                query = from property in query
                        where property.Name.Contains(parameters.SearchKeyWord) || property.Address.Contains(parameters.SearchKeyWord)
                        select property;
            }

            if (parameters.PriceFrom > 0)
            {
                query = from property in query
                        where property.Price >= parameters.PriceFrom
                        select property;
            }

            if (parameters.PriceTo > 0)
            {
                query = from property in query
                        where property.Price <= parameters.PriceTo
                        select property;
            }

            if (parameters.YearFrom > 0)
            {
                query = from property in query
                        where property.Year >= parameters.YearFrom
                        select property;
            }

            if (parameters.YearTo > 0)
            {
                query = from property in query
                        where property.Year <= parameters.YearTo
                        select property;
            }

            var results = await query.Skip((parameters.PageNumber - 1)
                * parameters.PageSize).Take(parameters.PageSize).ToListAsync();

            parameters.TotalCount = results.Select(e => e.PropertyId).Distinct().Count();
            parameters.TotalPages = (int)Math.Ceiling((decimal)((double)parameters.TotalCount / ((double)parameters.PageSize)));

            var result = new SearchResult()
            {
                Properties = results,
                SearchParameters = parameters
            };
            return result;
        }
    }
}
