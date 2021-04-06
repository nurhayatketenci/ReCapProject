using Business.Abstract;
using Entities.Concrete;
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
    public class CreditCartController : ControllerBase
    {
         ICreditCartService _cardService;
        public CreditCartController(ICreditCartService cardService)
        {
            _cardService = cardService;
        }
        [HttpPost("check")]
        public IActionResult Get(CreditCart creditCart)
        {
            var result = _cardService.CardVerification(creditCart);

            if (result.Success) {
                return Ok(result);
            }
           
            return BadRequest(result);
        }

    }
}
