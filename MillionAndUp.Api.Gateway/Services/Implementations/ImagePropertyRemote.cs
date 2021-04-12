using Microsoft.Extensions.Logging;
using MilionAndUp.Models;
using MillionAndUp.Api.Gateway.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MillionAndUp.Api.Gateway.Services.Implementations
{
    public class ImagePropertyRemote : IImagePropertyRemote
    {
        public readonly IHttpClientFactory _httpClient;
        public readonly ILogger<ImagePropertyRemote> _logger;

        public ImagePropertyRemote(IHttpClientFactory httpClient,
            ILogger<ImagePropertyRemote> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool result, List<PropertyImage> listPropertyImages, string errorMessage)> GetPropertyImages(Guid propertyId)
        {
            try
            {
                var client = _httpClient.CreateClient("PropertyImageService");
                var response = await client.GetAsync($"PropertyImage/{propertyId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var propertyImagesList = JsonSerializer.Deserialize<List<PropertyImage>>(content, options);
                    return (true, propertyImagesList, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
