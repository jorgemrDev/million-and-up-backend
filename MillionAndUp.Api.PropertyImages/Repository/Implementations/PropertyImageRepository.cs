using Microsoft.EntityFrameworkCore;
using MilionAndUp.Models;
using MillionAndUp.Api.PropertyImages.Context;
using MillionAndUp.Api.PropertyImages.Repository.Interfaces;
using MillionAndUp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillionAndUp.Api.PropertyImages.Repository.Implementations
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly PropertyContext _propertyContext;
        public PropertyImageRepository(PropertyContext propertyContext)
        {
            _propertyContext = propertyContext;
        }
        public async Task<List<PropertyImage>> GetPropertyImages(Guid propertyId)
        {
            return await _propertyContext.PropertyImage.Where(e => e.PropertyId == propertyId && e.Enabled).ToListAsync();
        }

        public async Task<PropertyImage> SaveImage(PropertyImageDto propertyImageDto)
        {
            var image = new PropertyImage
            {
                Photo = propertyImageDto.Photo,
                PropertyId = propertyImageDto.PropertyId,
                Enabled = true
            };

            _propertyContext.PropertyImage.Add(image);
            var rows = await _propertyContext.SaveChangesAsync();

            if (rows > 0)
                return image;

            throw new Exception("There was an error inseting PropertyImage");
        }
    }
}
