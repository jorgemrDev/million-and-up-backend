using MilionAndUp.Models;
using MillionAndUp.Api.PropertyImages.Repository.Interfaces;
using MillionAndUp.Api.PropertyImages.Services.Interfaces;
using MillionAndUp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillionAndUp.Api.PropertyImages.Services.Implementations
{
    public class PropertyImageService : IPropertyImageService
    {
        private readonly IPropertyImageRepository _propertyImagesRepository;

        public PropertyImageService(IPropertyImageRepository propertyImagesRepository)
        {
            _propertyImagesRepository = propertyImagesRepository;
        }
        public async Task<List<PropertyImage>> GetPropertyImages(Guid propertyId)
        {
            return await _propertyImagesRepository.GetPropertyImages(propertyId);
        }

        public async Task<PropertyImage> SaveImage(PropertyImageDto propertyImageDto)
        {
            return await _propertyImagesRepository.SaveImage(propertyImageDto);
        }
    }
}
