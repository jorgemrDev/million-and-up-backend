using Microsoft.Extensions.Logging;
using MilionAndUp.Models;
using MillionAndUp.Api.Gateway.Services.Interfaces;
using MillionAndUp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MillionAndUp.Api.Gateway.MessageHandlers
{
    public class PropertyImageHandler : DelegatingHandler
    {
        private readonly ILogger<PropertyImageHandler> _logger;
        private readonly IImagePropertyRemote _propertyImageRemote;

        public PropertyImageHandler(ILogger<PropertyImageHandler> logger,
            IImagePropertyRemote propertyImageRemote)
        {
            _logger = logger;
            _propertyImageRemote = propertyImageRemote;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var time = Stopwatch.StartNew();
            _logger.LogInformation("Process Starts");
            var response = await base.SendAsync(request, cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<SearchResult>(content, options);
                var list = new List<Property>();
                foreach (var item in result.Properties)
                {
                    var responsePropertyImages = await _propertyImageRemote.GetPropertyImages(item.PropertyId);
                    if (responsePropertyImages.result)
                    {
                        var images = responsePropertyImages.listPropertyImages;
                        item.PropertyImageList = images;
                        list.Add(item);
                    }
                }
                result.Properties = list;
                var stringResult = JsonSerializer.Serialize(result);
                response.Content = new StringContent(stringResult, System.Text.Encoding.UTF8, "application/json");

            }
            _logger.LogInformation($"This process tooks {time.ElapsedMilliseconds} ms");
            return response;
        }
    }
}
