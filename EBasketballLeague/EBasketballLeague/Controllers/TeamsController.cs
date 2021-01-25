using DataAccess;
using DataStructure;
using Microsoft.AspNetCore.Authorization;
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
    public class TeamsController : ControllerBase
    {
        private ApplicationDbContext applicationDbContext;
        public TeamsController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetTeam()
        {
            List<Team> teams = applicationDbContext.Teams.ToList();
            return Ok(teams);
        }
        [HttpPost]
        public IActionResult PostTeam(Team team)
        {
            Uri uri = new Uri(Url.Link("GetTeamByID", new { Id = team.ID }));
            applicationDbContext.Teams.Add(team);
            applicationDbContext.SaveChanges();
            return Created(uri, team);
        }

        [HttpGet("{id}", Name = "GetTeamByID")]
        public IActionResult GetByID(int id)
        {
            Team team = applicationDbContext.Teams.Find(id);
            return Ok(team);
        }

        [HttpPut]
        public IActionResult PutTeam(int id, Team team)
        {
            applicationDbContext.Teams.Update(team);
            applicationDbContext.SaveChanges();
            return Ok(team);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            Team team = applicationDbContext.Teams.Find(id);
            applicationDbContext.Teams.Remove(team);
            applicationDbContext.SaveChanges();
            return Ok(team);
        }
    }
}
