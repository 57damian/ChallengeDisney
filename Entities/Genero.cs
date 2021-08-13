using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.Entities
{
    public class Genero
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Imagen { get; set; }

        //TODO: PELICULA

        public ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
    }
}
