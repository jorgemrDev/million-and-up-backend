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
        Task<Property> CreateProduct(PropertyDto property);

    }
}
