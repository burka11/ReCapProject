using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalsController : ControllerBase
    {
        ICarRentalService _carRentalService;
        public CarRentalsController(ICarRentalService carRentalService)
        {
            _carRentalService = carRentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _carRentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("add")]
        public IActionResult Add(CarRental carRental)
        {
            var result = _carRentalService.Add(carRental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarRental carRental)
        {
            var result = _carRentalService.Delete(carRental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(CarRental carRental)
        {
            var result = _carRentalService.Update(carRental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}