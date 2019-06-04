using System.Linq;
using FulfilmentOrderApi.Domain.Models;
using FulfilmentOrderApi.Infrastructure;
using FulfilmentOrderApi.Infrastructure.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FulfilmentOrderApi.Tests
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void SubmitReturnsMatchedColour()
        {
            var order = new Order("MyId");
            order.AddOrderItem("1234", "https://pwintyimages.blob.core.windows.net/samples/stars/test-sample-black.png", 1);

            var mappings = new ColourMatchMappings();
            var colourMapping = new ColourMapping
            {
                Blue = 69,
                Green = 69,
                Red =69,
                Key = "black"
            };

            mappings.Mappings = new ColourMapping[] {colourMapping};

            order.Submit( new ConfigurationBasedColourMatch(mappings));

            Assert.IsTrue(order.result.ColourMatches.Any());
        }

        [TestMethod]
        public void SubmitDoesNotReturnMatchedColour()
        {
            var order = new Order("MyId");
            order.AddOrderItem("1234", "https://pwintyimages.blob.core.windows.net/samples/stars/test-sample-grey.png", 1);

            var mappings = new ColourMatchMappings();
            var colourMapping = new ColourMapping
            {
                Blue = 7,
                Green = -3,
                Red = 13,
                Key = "Black",
                Keywords = new string[] { "Black" }
            };

            mappings.Mappings = new ColourMapping[] { colourMapping };

            order.Submit(new ConfigurationBasedColourMatch(mappings));

            Assert.IsFalse(order.result.ColourMatches.Any());
        }
    }
}
