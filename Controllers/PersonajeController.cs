using ChallengeDisney.Context;
using ChallengeDisney.Entities;
using ChallengeDisney.ViewModels;
using ChallengeDisney.ViewModels.PersonajeViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PersonajeController : ControllerBase
    {
        private readonly ChallengeContext _challengecontext;
        public PersonajeController(ChallengeContext ctx)
        {
            _challengecontext = ctx;
        }

        [HttpGet]
        [Route ("Characters")]
        [Authorize]

        public async Task<IActionResult> GetPersonaje()
        {
            return Ok(_challengecontext.Personajes.Select(x => new { Nombre = x.Nombre, Imagen = x.Imagen }).ToList());
        }
        
        [HttpGet]
        [Route ("MostrarPersonaje")]
        public async Task<IActionResult> Get(string? nombre, int edad, int peso, string pelicula)
        {
            
            if (nombre != null)
            {
               Personaje personaje = _challengecontext.Personajes.Include(x => x.peliculas).FirstOrDefault(x => x.Nombre == nombre);
               return Ok(personaje);
            }
            else if (edad != 0)
            {
                Personaje personaje = _challengecontext.Personajes.Include(x => x.peliculas).FirstOrDefault(x => x.Edad == edad);
                return Ok(personaje);
            }
            else if (peso != 0)
            {
                Personaje personaje = _challengecontext.Personajes.Include(x => x.peliculas).FirstOrDefault(x => x.Peso == peso);
                return Ok(personaje);
            }
            else if (pelicula != null)
            {
                Pelicula personaje = _challengecontext.Peliculas.Include(x => x.personajes).FirstOrDefault(x => x.Titulo == pelicula);
                return Ok(personaje);
            }




            return Ok("El personaje no existe");
            
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonajeRequestViewModel perso)
        {
            var newPersonaje = new Personaje
            {
                Imagen = perso.Imagen,
                Nombre = perso.Nombre,
                Edad = perso.Edad,
                Peso = perso.Peso,
                Historia = perso.Historia,
            };
            if(perso.PeliculaId.GetValueOrDefault() != 0)
            {
                var peli = _challengecontext.Peliculas.FirstOrDefault(x => x.Id == perso.PeliculaId);

                if( peli != null)
                {
                    newPersonaje.peliculas.Add(peli);
                }
            }
            _challengecontext.Personajes.Add(newPersonaje);
            await _challengecontext.SaveChangesAsync();
            return Ok(new PersonajeResponseViewModel 
            {
                Id = perso.Id,
                Imagen = perso.Imagen,
                Nombre = perso.Nombre,
                Edad = perso.Edad,
                Peso = perso.Peso,
                Historia = perso.Historia,
                PeliculaId = (int)perso.PeliculaId
            });
        }

        [HttpPut]
        public async Task<IActionResult> Put( int id, PersonajeRequestViewModel perso)
        {

            if(id != perso.Id)
            {
                return BadRequest();
            };
            var newPersonaje = new Personaje
            {
                Imagen = perso.Imagen,
                Nombre = perso.Nombre,
                Edad = perso.Edad,
                Peso = perso.Peso,
                Historia = perso.Historia,
            };

            _challengecontext.Entry(perso).State = EntityState.Modified;
            await _challengecontext.SaveChangesAsync();
            return NoContent();
    
        }

        [HttpDelete]
        public async Task<IActionResult> Delete( int id)
        {
            var perso = await _challengecontext.Personajes.FindAsync(id);

            if(perso == null)
            {
                return NotFound();
            }

            _challengecontext.Personajes.Remove(perso);
            await _challengecontext.SaveChangesAsync();

            return NoContent();

        }
    }
}
