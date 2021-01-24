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
    public class ArenasController : ControllerBase
    {
        private ApplicationDbContext applicationDbContext;
        public ArenasController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult GetArena()
        {
            List<Arena> arenas = applicationDbContext.Arenas.ToList();
            return Ok(arenas);
        }
        [HttpPost]
        public IActionResult PostArena(Arena arena)
        {
            Uri uri = new Uri(Url.Link("GetArenaByID", new { Id = arena.ID }));
            applicationDbContext.Arenas.Add(arena);
            applicationDbContext.SaveChanges();
            return Created(uri, arena);
        }

        [HttpGet("{id}", Name = "GetArenaByID")]
        public IActionResult GetByID(int id)
        {
            Arena arena = applicationDbContext.Arenas.Find(id);
            return Ok(arena);
        }

        [HttpPut]
        public IActionResult PutArena(int id, Arena arena)
        {
            applicationDbContext.Arenas.Update(arena);
            applicationDbContext.SaveChanges();
            return Ok(arena);
        }

        [HttpDelete]
        public IActionResult DeleteArena(int id)
        {
            Arena arena = applicationDbContext.Arenas.Find(id);
            applicationDbContext.Arenas.Remove(arena);
            applicationDbContext.SaveChanges();
            return Ok(arena);
        }
    }
}

