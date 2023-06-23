using MediatR;

namespace Payment.API.Domain.Queries.Payment.v1.List
{
    public class ListPaymentQuery : IRequest<IEnumerable<ListPaymentQueryResponse>>
    {
    }
}
