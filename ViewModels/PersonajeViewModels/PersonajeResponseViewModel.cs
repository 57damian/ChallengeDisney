using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.ViewModels.PersonajeViewModels
{
    public class PersonajeResponseViewModel
    {
        public int Id { get; set; }

        public string Imagen { get; set; }
        public string Nombre { get; set; }

        public int Edad { get; set; }
        public double Peso { get; set; }

        public string Historia { get; set; }
        public int PeliculaId { get; set; }
    }
}
