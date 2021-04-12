using MilionAndUp.Models;
using MillionAndUp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Repository.Interfaces
{
    public interface IPropertyRepository
    {
        /// <summary>
        /// Create a Property on million And Up Database
        /// </summary>
        /// <param name="property">Property Object</param>
        /// <returns>Created Entity</returns>
        Task<Property> CreateProperty(PropertyDto property);
        /// <summary>
        /// Update the price of a Property
        /// </summary>
        /// <param name="priceDto">Pricer Object</param>
        /// <returns>true if update succesfully, false if not</returns>
        Task<bool> UpdatePrice(UpdatePriceDto priceDto);
        /// <summary>
        /// Update a property Entity
        /// </summary>
        /// <param name="propertyDto">Property Object</param>
        /// <returns>Updated Entity</returns>
        Task<Property> UpdateProperty(PropertyDto propertyDto);
        /// <summary>
        /// Search properties with requested filters
        /// </summary>
        /// <param name="parameters">parameters object to filter properties</param>
        /// <returns>Lits of properties filtered</returns>
        Task<SearchResult> SearchProperties(SearchParameters parameters);

    }
}
