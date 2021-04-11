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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Post(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("RentalDetailDto")]
        public IActionResult GetRentalDetails()
        {
            var result = _rentalService.GetRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
         [HttpGet("list/{id}")]
        
        public IActionResult Get(int id)
        {
            var result = _rentalService.GetRentalDetailById(id);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getbyid")]

        public IActionResult GetById(int rentalId)
        {
            var result = _rentalService.GetById(rentalId);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        
        
        [HttpGet("getrentalbycar")]
        public IActionResult GetRentalByCar(int carId)
        {
            var result = _rentalService.GetByCarId(carId);

            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("iscaravailable")]
        public IActionResult IsCarAvailable(Rental rental)
        {
            var result = _rentalService.CheckRentalAvailable(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }

    }
}
