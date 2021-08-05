using ChallengeDisney.Context;
using ChallengeDisney.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonajeController : ControllerBase
    {
        private readonly ChallengeContext _challengecontext;
        public PersonajeController( ChallengeContext ctx)
        {
            _challengecontext = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string Id)
        {
            var personaje = await _challengecontext.Personajes.FirstOrDefaultAsync();
            return Ok(); 
        }

        [HttpPost]
        public async Task<IActionResult> Post( Personaje personaje)
        {
            _challengecontext.Personajes.Add(personaje);
            await _challengecontext.SaveChangesAsync();
            return Ok(_challengecontext.Personajes.ToList());
        }

        [HttpPut]
        public void Put()
        {

        }

        [HttpDelete]
        public void Delete()
        {

        }
    }
}
