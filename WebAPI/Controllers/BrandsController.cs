using Business.Abstract;
using Entities;
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
    public class BrandsController : ControllerBase
    {
        //Doğrudan BrandService somut sınıfını da kullanabilirdik FAKAT;
        //ilerde Manager da gerekecek olası değişikliliklerde varolan manageri if lemeden özelleştirme 
        //yapabilmek için; yani var olan manageri değiştirmeden özelleşmiş yeni bir manager sınıfı yazabilmek 
        //ve kullanabilmek için bağımlılığı bu şekilde soyut tuttuk
        //örnek: hatırlı müşteriler için bazı özelleştirme işlemleri


        IBrandService _brandService;

        public  BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result= _brandService.GetAll();

            if (result.Success) {
                return Ok(result.Data); //response kodu olarak 200 ve datayı verdik. resultu da döndürebiliriz
            }
            return BadRequest(result.Message);//responce kodu 400 ve hata mesajını verdik
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);

            if(result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // sektörde silme ve güncelleme içinde post kullanılıyor 

        [HttpPost("add")] //alias veriyoruz
        public IActionResult Add(Brand brand)
        {
            var result = _brandService.Add(brand);

            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")] //alias veriyoruz
        public IActionResult Update(Brand brand)
        {
            var result = _brandService.Update(brand);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")] //alias veriyoruz
        public IActionResult Delete(Brand brand)
        {
            var result = _brandService.Delete(brand);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
