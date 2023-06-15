using Microsoft.AspNetCore.Mvc;
using Payment.API.Domain.Commands.Payment.v1;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentCommandHandler _paymentHandler;

        public PaymentController()
        {
            _paymentHandler = new PaymentCommandHandler();
        }

        [HttpPost(Name = "MakePayment")]
        public Task<Domain.Entities.v1.Payment> MakePayment([FromBody] Domain.Entities.v1.Payment payment)
        {
            return _paymentHandler.Handler(payment);
        }
    }
}
