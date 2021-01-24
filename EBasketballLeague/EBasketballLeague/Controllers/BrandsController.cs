using DataAccess;
using DataStructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBasketballLeague.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private ApplicationDbContext applicationDbContext;
        public BrandsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult GetBrands()
        {
            List<Brand> brands = applicationDbContext.Brands.ToList();
            return Ok(brands);
        }
        [HttpPost]
        public IActionResult PostBrand(Brand brand)
        {
            Uri uri = new Uri(Url.Link("GetBrandByID", new { Id = brand.ID }));
            applicationDbContext.Brands.Add(brand);
            applicationDbContext.SaveChanges();
            return Created(uri, brand);
        }

        [HttpGet("{id}", Name = "GetBrandByID")]
        public IActionResult GetByID(int id)
        {
            Brand brand = applicationDbContext.Brands.Find(id);
            return Ok(brand);
        }

        [HttpPut]
        public IActionResult PutBrand(int id, Brand brand)
        {
            applicationDbContext.Brands.Update(brand);
            applicationDbContext.SaveChanges();
            return Ok(brand);
        }

        [HttpDelete]
        public IActionResult DeleteBrand(int id)
        {
            Brand brand = applicationDbContext.Brands.Find(id);
            applicationDbContext.Brands.Remove(brand);
            applicationDbContext.SaveChanges();
            return Ok(brand);
        }
    }
}

