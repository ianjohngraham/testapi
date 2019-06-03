using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FulfilmentOrderApi.Domain.Models;
using FulfilmentOrderApi.Models;

namespace FulfilmentOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FulfilmentOrderController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IColourMatch _colourMatch;

        public FulfilmentOrderController(ILogger<FulfilmentOrderController> logger, IColourMatch colourMatch)
        {
            _logger = logger;
            _colourMatch = colourMatch;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] OrderRequest request)
        {
            try
            {
                var order = new Order(request.OrderId);
                foreach (var item in request.Items)
                {
                    order.AddOrderItem(item.Sku,item.Url, item.Copies);
                }
               
                order.Submit(_colourMatch);
                return Ok( new SubmissionResponse(order.result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error for request: {nameof(FulfilmentOrderController)}:Submit -- {ex}");
                return StatusCode(500);
            }
        }
    }
}