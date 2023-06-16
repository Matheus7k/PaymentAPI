using Payment.API.Domain.Contracts.v1;

namespace Payment.API.Domain.Queries.Payment.v1.List
{
    public class ListPaymentQuery
    {
        private readonly IPaymentRepository _paymentRepository;

        public ListPaymentQuery(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Entities.v1.Payment>> List()
        {
            return await _paymentRepository.GetAllAsync();
        }
    }
}
