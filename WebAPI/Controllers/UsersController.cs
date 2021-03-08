using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        IUserService _service;

        public UsersController(IUserService userService)
        {
            _service = userService;
        }

        //[HttpGet("getall")]
        //public IActionResult GetAll()
        //{
        //    var result = _service.GetAll();

        //    if (result.Success)
        //    {
        //        return Ok(result.Data);
        //    }
        //    return BadRequest(result.Message);
        //}

        //[HttpGet("getbyid")]
        //public IActionResult GetById(int id)
        //{
        //    var result = _service.GetById(id);

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}



        //[HttpPost("add")]
        //public IActionResult Add(User user)
        //{
        //    var result = _service.Add(user);

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpPost("update")]
        //public IActionResult Update(User user)
        //{
        //    var result = _service.Update(user);

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}

        //[HttpPost("delete")]
        //public IActionResult Delete(User user)
        //{
        //    var result = _service.Delete(user);

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}
