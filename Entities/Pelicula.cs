using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.Entities
{
    public class Pelicula
    {
        public int Id { get; set; }

        public string Imagen { get; set; }

        public string Titulo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int Calificacion { get; set; }

        public Genero Genero { get; set; }

        public ICollection<Personaje> personajes { get; set; } = new List<Personaje>();
    }
}
