using MilionAndUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillionAndUp.Api.Gateway.Services.Interfaces
{
    public interface IImagePropertyRemote
    {
        /// <summary>
        /// Get theimages from a Property
        /// </summary>
        /// <param name="propertyId">id of the property</param>
        /// <returns>List of images from a property</returns>
        Task<(bool result, List<PropertyImage> listPropertyImages, string errorMessage)> GetPropertyImages(Guid propertyId);
    }
}
