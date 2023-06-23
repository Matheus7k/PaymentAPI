using MediatR;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Domain.Commands.Order.v1.Create;
using Payment.API.Domain.Queries.Order.v1.List;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateOrder")]
        public Task<Domain.Entities.v1.Order> InsertOrder([FromBody] CreateOrderCommand command, CancellationToken cancellation)
        {
            return _mediator.Send(command, cancellation);
        }

        [HttpGet(Name = "ListOrders")]
        public Task<IEnumerable<ListOrderQueryResponse>> GetOrders(CancellationToken cancellation)
        {
            var query = new ListOrderQuery();
            return _mediator.Send(query, cancellation);
        }
    }
}
