using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        IPaymentService _paymentManager;

        public PaymentController(IPaymentService paymentManager)
        {
            _paymentManager = paymentManager;
        }


        [HttpGet("list")]
     
        public IActionResult Get()
        {
            var result = _paymentManager.GetAll();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        
        [HttpPost("addpayment")]     
        public IActionResult AddPayment(Payment payment)
        {
            var result = _paymentManager.Add(payment);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

    }
}

