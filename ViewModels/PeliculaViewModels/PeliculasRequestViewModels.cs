using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.ViewModels
{
    public class PeliculasRequestViewModels
    {
        public int Id { get; set; }
       
        public string Imagen { get; set; }
        [MaxLength(10, ErrorMessage = "El campo imagen solo admite 10 caracteres")]
        [Required (ErrorMessage = "El titulo es requerido")]
        public string Titulo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int Calificacion { get; set; }

        public int GeneroId { get; set; }

        public int? PersonajeId { get; set; }
    }
}
