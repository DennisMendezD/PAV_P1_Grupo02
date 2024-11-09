using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PAV_P1_Grupo02.Models.ViewModels
{
    public class Personas
    {
        [Required]
        [StringLength(30)]
        public string Identificacion { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        [StringLength(10)]
        public string Estado { get; set; }

    }
}