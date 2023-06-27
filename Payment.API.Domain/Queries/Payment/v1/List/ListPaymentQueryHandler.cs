﻿using AutoMapper;
using MediatR;
using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Queries.Payment.v1.List
{
    public class ListPaymentQueryHandler : BaseHandler, IRequestHandler<ListPaymentQuery, IEnumerable<ListPaymentQueryResponse>>
    {
        private readonly IBaseRepository<Entities.v1.Payment> _paymentRepository;
        private readonly IMapper _mapper;

        public ListPaymentQueryHandler(IMapper mapper, IBaseRepository<Entities.v1.Payment> paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;

        }

        public async Task<IEnumerable<ListPaymentQueryResponse>> Handle(ListPaymentQuery query, CancellationToken cancellation)
        {
            var payments = await _paymentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ListPaymentQueryResponse>>(payments);
        }
    }
}
