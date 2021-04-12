using MilionAndUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MillionAndUp.Api.Gateway.Services.Interfaces
{
    public interface IImagePropertyRemote
    {
        Task<(bool result, List<PropertyImage> listPropertyImages, string errorMessage)> GetPropertyImages(Guid propertyId);
    }
}
