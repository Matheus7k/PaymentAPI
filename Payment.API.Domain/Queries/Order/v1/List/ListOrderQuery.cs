using MediatR;

namespace Payment.API.Domain.Queries.Order.v1.List
{
    public class ListOrderQuery : IRequest<IEnumerable<ListOrderQueryResponse>>
    {
    }
}
