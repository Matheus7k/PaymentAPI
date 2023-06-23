using AutoMapper;
using MediatR;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Queries.Payment.v1.List
{
    public class ListPaymentQueryHandler : BaseHandler, IRequestHandler<ListPaymentQuery, IEnumerable<ListPaymentQueryResponse>>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public ListPaymentQueryHandler(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListPaymentQueryResponse>> Handle(ListPaymentQuery query, CancellationToken cancellation)
        {
            var payments = await _paymentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ListPaymentQueryResponse>>(payments);
        }
    }
}
