using Microsoft.AspNetCore.Mvc;
using Payment.API.Domain.Commands.Order.v1.Create;
using Payment.API.Domain.Queries.Order.v1.List;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly CreateOrderCommandHandler _orderHandler;
        private readonly ListOrderQuery _listOrder;

        public OrderController(CreateOrderCommandHandler orderhandler, ListOrderQuery listOrder)
        {
            _orderHandler = orderhandler;
            _listOrder = listOrder;
        }

        [HttpPost(Name = "CreateOrder")]
        public Task<Domain.Entities.v1.Order> InsertOrder([FromBody] CreateOrderCommand command)
        {
            return _orderHandler.Insert(command);
        }

        [HttpGet(Name = "ListOrders")]
        public Task<IEnumerable<Domain.Entities.v1.Order>> GetOrders()
        {
            return _listOrder.List();
        }
    }
}
