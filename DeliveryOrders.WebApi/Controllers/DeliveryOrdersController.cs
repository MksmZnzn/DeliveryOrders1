using DeliveryOrders.Application.CQRS.Queries;
using DeliveryOrders.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryOrders.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryOrdersController : ControllerBase
    {

        private readonly IMediator _mediator;
        public DeliveryOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<DeliveryOrdersController> _logger;

        //public DeliveryOrdersController(ILogger<DeliveryOrdersController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        /// <summary>
        /// Получаем список заказов
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllOrders")]
        [ProducesResponseType(201, Type = typeof(Order))]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllOrdersQuery());

            return Ok(result);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredOrders([FromQuery] string district, [FromQuery] DateTime fromTime, [FromQuery] DateTime toTime)
        {
            var query = new GetFilteredOrdersQuery(district, fromTime, toTime);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

    }
}
