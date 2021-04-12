﻿using MilionAndUp.Models;
using MillionAndUp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillionAndUp.Api.PropertyImages.Services.Interfaces
{
    public interface IPropertyImageService
    {
        Task<List<PropertyImage>> GetPropertyImages(Guid propertyId);
        Task<PropertyImage> SaveImage(PropertyImageDto propertyImageDto);
    }
}