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
    public class PlayersController : ControllerBase
    {
        private ApplicationDbContext applicationDbContext;
        public PlayersController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [HttpGet]
        public IActionResult GetPlayers()
        {
            List<Player> players = applicationDbContext.Players.ToList();
            return Ok(players);
        }
        [HttpPost]
        public IActionResult PostPlayer(Player player)
        {
            Uri uri = new Uri(Url.Link("GetPlayeryID", new { Id = player.ID }));
            applicationDbContext.Players.Add(player);
            applicationDbContext.SaveChanges();
            return Created(uri, player);
        }

        [HttpGet("{id}", Name = "GetPlayerByID")]
        public IActionResult GetByID(int id)
        {
            Player player = applicationDbContext.Players.Find(id);
            return Ok(player);
        }

        [HttpPut]
        public IActionResult PutPlayer(int id, Player player)
        {
            applicationDbContext.Players.Update(player);
            applicationDbContext.SaveChanges();
            return Ok(player);
        }

        [HttpDelete]
        public IActionResult DeletePlayer(int id)
        {
            Player player = applicationDbContext.Players.Find(id);
            applicationDbContext.Players.Remove(player);
            applicationDbContext.SaveChanges();
            return Ok(player);
        }
    }
}

