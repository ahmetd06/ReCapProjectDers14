using System;
using Business.Abstract;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _service;

        public CarsController(ICarService carService)
        {
            _service = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();

            if (result.Success)
            {
                return Ok(result.Data); //response kodu olarak 200 ve datayı verdik. resultu da döndürebiliriz
            }
            return BadRequest(result.Message);//response kodu 400 ve hata mesajını verdik
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

        // sektörde silme ve güncelleme içinde post kullanılıyor 

        [HttpPost("add")] //alias veriyoruz
        public IActionResult Add(Car car)
        {
            var result = _service.Add(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")] 
        public IActionResult Update(Car car)
        {
            var result = _service.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")] 
        public IActionResult Delete(Car car)
        {
            var result = _service.Delete(car);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getcarsbybrandid")] 
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _service.GetCarsByBrandId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int id)
        {
            var result = _service.GetCarsByColorId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _service.GetCarDetails();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
