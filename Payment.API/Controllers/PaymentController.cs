using Microsoft.AspNetCore.Mvc;
using Payment.API.Domain.Commands.Payment.v1;
using Payment.API.Domain.Queries.Payment.v1.List;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentCommandHandler _paymentHandler;
        private readonly ListPaymentQuery _listPayment;

        public PaymentController(PaymentCommandHandler paymentHandler, ListPaymentQuery listPayment)
        {
            _paymentHandler = paymentHandler;
            _listPayment = listPayment;
        }

        [HttpPost(Name = "MakePayment")]
        public Task<Domain.Entities.v1.Payment> MakePayment([FromBody] Domain.Entities.v1.Payment payment)
        {
            return _paymentHandler.Insert(payment);
        }

        [HttpGet(Name = "GetPayments")]
        public Task<IEnumerable<Domain.Entities.v1.Payment>> GetPayments()
        {
            return _listPayment.List();
        }
    }
}
