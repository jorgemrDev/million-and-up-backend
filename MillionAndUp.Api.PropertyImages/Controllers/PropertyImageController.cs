using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilionAndUp.Models;
using MillionAndUp.Api.PropertyImages.Services.Interfaces;
using MillionAndUp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MillionAndUp.Api.PropertyImages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly IPropertyImageService _propertyImageService;

        public PropertyImageController(IPropertyImageService propertyImageService)
        {
            _propertyImageService = propertyImageService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PropertyImage>>> Get(Guid id)
        {
            return await _propertyImageService.GetPropertyImages(id);
        }

        [HttpPost]
        public async Task<ActionResult<PropertyImage>> UploadImage(IFormFile file, Guid propertyId)
        {
           var fileName = await WriteFile(file);
           return await _propertyImageService.SaveImage(new PropertyImageDto {
               Photo = fileName,
               PropertyId = propertyId
            });
        }

        
        private async Task<string> WriteFile(IFormFile file)
        {
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension; 
                var path = Path.Combine(Directory.GetCurrentDirectory(), "images", fileName);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return fileName;
        }


    }
}
