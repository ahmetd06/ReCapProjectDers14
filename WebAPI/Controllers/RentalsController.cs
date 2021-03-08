using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        IRentalService _service;

        public RentalsController(IRentalService rentalService)
        {
            _service = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _service.Add(rental);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _service.Update(rental);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _service.Delete(rental);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("checkreturndate")]
        public IActionResult CheckReturnDate(int carId)
        {
            var result = _service.CheckReturnDate(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("rentacar")]
        public IActionResult RentACar(Car car, Customer customer)
        {
            var result = _service.RentACar(car, customer);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getrentdetaillist")]
        public IActionResult GetRentDetailList()
        {
            var result = _service.GetRentDetailList();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("updatereturndate")]
        public IActionResult UpdateReturnDate(int rentId, DateTime returnDate)
        {
            var result = _service.UpdateReturnDate(rentId, returnDate);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
