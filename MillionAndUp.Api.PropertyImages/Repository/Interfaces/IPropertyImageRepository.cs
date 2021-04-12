using MilionAndUp.Models;
using MillionAndUp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillionAndUp.Api.PropertyImages.Repository.Interfaces
{
    public interface IPropertyImageRepository
    {
        /// <summary>
        /// Get Images from a Property
        /// </summary>
        /// <param name="propertyId">Id of the property</param>
        /// <returns>List of images from a Property</returns>
        Task<List<PropertyImage>> GetPropertyImages(Guid propertyId);
        /// <summary>
        /// Save Image from a Property
        /// </summary>
        /// <param name="propertyImageDto">property image object</param>
        /// <returns>the property image created</returns>
        Task<PropertyImage> SaveImage(PropertyImageDto propertyImageDto);
    }
}
