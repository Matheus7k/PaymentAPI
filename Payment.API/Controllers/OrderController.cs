using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Domain.Commands.Order.v1.Create;
using Payment.API.Domain.Commands.Payment.v1.Create;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly CreateOrderCommandHandler _orderHandler;

        public OrderController(CreateOrderCommandHandler orderhandler)
        {
            _orderHandler = orderhandler;
        }

        [HttpPost(Name = "CreateOrder")]
        public Task<Domain.Entities.v1.Order> InsertOrder([FromBody] CreateOrderCommand command)
        {
            return _orderHandler.Insert(command);
        }
    }
}
