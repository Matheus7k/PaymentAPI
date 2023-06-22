using Microsoft.AspNetCore.Mvc;
using Payment.API.Domain.Commands.Payment.v1.Create;
using Payment.API.Domain.Queries.Payment.v1.List;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly CreatePaymentCommandHandler _paymentHandler;
        private readonly ListPaymentQuery _listPayment;

        public PaymentController(CreatePaymentCommandHandler paymentHandler, ListPaymentQuery listPayment)
        {
            _paymentHandler = paymentHandler;
            _listPayment = listPayment;
        }

        [HttpPost(Name = "MakePayment")]
        public Task<ActionResult<Domain.Entities.v1.Payment>> MakePayment([FromBody] CreatePaymentCommand command)
        {
            return _paymentHandler.Insert(command);
        }

        [HttpGet(Name = "GetPayments")]
        public Task<IEnumerable<Domain.Entities.v1.Payment>> GetPayments()
        {
            return _listPayment.List();
        }
    }
}
