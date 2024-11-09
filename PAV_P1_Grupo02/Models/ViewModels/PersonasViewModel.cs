using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PAV_P1_Grupo02.Models.ViewModels
{
    public class PersonasViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Identificacion { get; set; }

        [Required]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }

        [Required]
        public int? Edad { get; set; }

        [Required]
        public string Estado { get; set; }

    }
}