using MilionAndUp.Models;
using MillionAndUp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Services.Interfaces
{
    public interface IPropertyService
    {
        Task<Property> CreateProduct(PropertyDto property);
    }
}
