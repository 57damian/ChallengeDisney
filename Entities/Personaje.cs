using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.Entities
{
    public class Personaje
    {
        public int Id { get; set; }

        public string Imagen { get; set; }
        public string Nombre { get; set; }

        public int Edad { get; set; }
        public double Peso { get; set; }
        
        public string Historia { get; set; }


        public ICollection<Pelicula> peliculas { get; set; } = new List<Pelicula>();

    }
}
