using ChallengeDisney.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.Context
{
    public class ChallengeContext :DbContext
    {
        public ChallengeContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Personaje> Personajes { get; set; } = null!;
        public DbSet<Pelicula> Peliculas { get; set; } = null!;
        public DbSet<Genero> Generos { get; set; } = null!;
    }
}
