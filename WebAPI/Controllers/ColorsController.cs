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
    public class ColorsController : ControllerBase
    {
        IColorService _service;

        public ColorsController(IColorService colorService)
        {
            _service = colorService;
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
        public IActionResult Add(Color color)
        {
            var result = _service.Add(color);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")] 
        public IActionResult Update(Color color)
        {
            var result = _service.Update(color);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")] 
        public IActionResult Delete(Color color)
        {
            var result = _service.Delete(color);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
