using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var result = _paymentManager.GetAll();

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

