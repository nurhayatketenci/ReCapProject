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
    public class CreditCardsController : ControllerBase
    {
         ICreditCartService _cardService;
        public CreditCardsController(ICreditCartService cardService)
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
        [HttpPost("registercreditcard")]
        public IActionResult RegisterCreditCard(CreditCart creditCart)
        {
            var result = _cardService.Add(creditCart);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _cardService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
