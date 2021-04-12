using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Models.Dtos;
using MillionAndUp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilionAndUp.Api.Property.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes ="TestKey")]
        public async Task<ActionResult<Models.Property>> Create(PropertyDto property)
        {
            return await _propertyService.CreateProperty(property);

        }

        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<SearchResult>> GetProperties([FromQuery] SearchParameters parameters)
        {
           return await _propertyService.SearchProperties(parameters);            
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "TestKey")]
        public async Task<ActionResult<bool>> UpdatePrice(UpdatePriceDto priceDto)
        {
            return await _propertyService.UpdatePrice(priceDto);
        }

        [HttpPut("update")]
        [Authorize(AuthenticationSchemes = "TestKey")]
        public async Task<ActionResult<Models.Property>> UpdateProperty(PropertyDto propertyDto)
        {
            return await _propertyService.UpdateProperty(propertyDto);
        }        
    }
}
