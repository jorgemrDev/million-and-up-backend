using MilionAndUp.Models;
using MillionAndUp.Models.Dtos;
using MillionAndUp.Repository.Interfaces;
using MillionAndUp.Services.Implementations;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.UnitTests
{
    [TestFixture]
    public class PropertyServicesTests
    {
        private PropertyService _propertyService;

        [SetUp]
        public void SetUp()
        {
            //ARRANGE
            
        }

        [Test]
        public async Task Test_Search_Properties()
        {
            Task<SearchResult> lstProperties = createResponse();
            Mock<IPropertyRepository> mock = new Mock<IPropertyRepository>();
            _propertyService = new PropertyService(mock.Object);
            mock.Setup(c => c.SearchProperties(new SearchParameters() { PageNumber =1 }))
                .Returns(lstProperties);

            //ACT
            SearchResult result = await _propertyService.SearchProperties(new SearchParameters() { PageNumber = 1 });

            //ASSERT
            Assert.AreEqual(result.Properties.Count, 2);
            Assert.AreEqual(result.Properties[0].Name, "Name1");
            Assert.AreEqual(result.Properties[1].Name, "Name2");
            Assert.AreEqual(result.Properties[0].Address, "Address1");
            Assert.AreEqual(result.Properties[1].Address, "Address2");
        }


        private async Task<SearchResult> createResponse()
        {
            List<Property> lstProperties = new List<Property>();
            Property property = new Property()
            {
                Name = "Name1",
                Address = "Address1"
            };
            lstProperties.Add(property);
            property = new Property()
            {
                Name = "Name2",
                Address = "Address2"
            };
            lstProperties.Add(property);
            var result = new SearchResult()
            {
                Properties = lstProperties,
                SearchParameters = new SearchParameters()
            };
            return Task.FromResult(result).Result;
        }
    }
}
