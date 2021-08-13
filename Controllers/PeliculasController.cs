using ChallengeDisney.Context;
using ChallengeDisney.Entities;
using ChallengeDisney.ViewModels;
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
    public class PeliculasController : ControllerBase
    {


        private readonly ChallengeContext _challengecontext;
        public PeliculasController(ChallengeContext ctx)
        {
            _challengecontext = ctx;
        }
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            return Ok(_challengecontext.Peliculas.Select(x => new { Nombre = x.Titulo, Imagen = x.Imagen, FechaCreacion = x.FechaCreacion }).ToList());
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesList()
        {
            var peli = await _challengecontext.Peliculas.Include(x => x.personajes).ToListAsync();
            return Ok(peli);
        }

        [HttpPost]
        public IActionResult Post(PeliculasRequestViewModels peli )
        {
            var newPeli = new Pelicula
            {
                Imagen = peli.Imagen,
                Titulo = peli.Titulo,
                FechaCreacion = peli.FechaCreacion,
                Calificacion = peli.Calificacion
            };
            if(peli.PersonajeId.GetValueOrDefault() != 0)
            {
                var per = _challengecontext.Personajes.FirstOrDefault(x => x.Id == peli.PersonajeId);
                if(per != null)
                {
                    newPeli.personajes.Add(per);
                }
            }
           
            _challengecontext.Peliculas.Add(newPeli);
            _challengecontext.SaveChanges();
            return Ok(_challengecontext.Peliculas.ToList());
        }

        [HttpPut]
        public IActionResult Put(Pelicula peli)
        {
            var pelicul = _challengecontext.Peliculas.FirstOrDefault(x => x.Id == peli.Id);

            if (pelicul == null)
            {
                return NotFound("La pelicula no existe");
            }

            pelicul.Id = peli.Id;
            pelicul.Imagen = peli.Imagen;
            pelicul.Titulo = peli.Titulo;
            pelicul.FechaCreacion = peli.FechaCreacion;
            pelicul.Calificacion = peli.Calificacion;


            _challengecontext.Peliculas.Update(pelicul);
            _challengecontext.SaveChanges();
            return Ok(_challengecontext.Peliculas.ToList());

        }
        [HttpDelete]

        public IActionResult Delete(Pelicula peli)
        {
            _challengecontext.Remove(peli);
            _challengecontext.SaveChanges();
            return Ok(_challengecontext.Peliculas.ToList());

        }

    }
}
