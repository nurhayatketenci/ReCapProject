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
    public class CreditCartController : ControllerBase
    {
         ICreditCartService _cardService;
        public CreditCartController(ICreditCartService cardService)
        {
            _cardService = cardService;
        }
        [HttpGet("check")]
        public IActionResult Get( int cardNumber)
        {
            var result = _cardService.GetCardByCardNumber(cardNumber);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

    }
}
