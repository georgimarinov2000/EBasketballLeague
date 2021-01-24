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
    public class LocationsController : ControllerBase
    {
        private ApplicationDbContext applicationDbContext;
        public LocationsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult GetLocations()
        {
            List<Location> locations = applicationDbContext.Locations.ToList();
            return Ok(locations);
        }
        [HttpPost]
        public IActionResult PostLocation(Location location)
        {
            Uri uri = new Uri(Url.Link("GetLocationByID", new { Id = location.ID }));
            applicationDbContext.Locations.Add(location);
            applicationDbContext.SaveChanges();
            return Created(uri, location);
        }

        [HttpGet("{id}", Name = "GetLocationByID")]
        public IActionResult GetByID(int id)
        {
            Location location = applicationDbContext.Locations.Find(id);
            return Ok(location);
        }

        [HttpPut]
        public IActionResult PutLocation(int id, Location location)
        {
            applicationDbContext.Locations.Update(location);
            applicationDbContext.SaveChanges();
            return Ok(location);
        }

        [HttpDelete]
        public IActionResult DeleteLocation(int id)
        {
            Location location = applicationDbContext.Locations.Find(id);
            applicationDbContext.Locations.Remove(location);
            applicationDbContext.SaveChanges();
            return Ok(location);
        }
    }
}

