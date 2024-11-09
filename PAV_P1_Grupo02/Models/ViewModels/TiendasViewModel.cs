using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PAV_P1_Grupo02.Models.ViewModels
{
    public class TiendasViewModel
    {
        [Display(Name = "ID")]
        public int Id_Tienda{ get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [StringLength(8)]
        public string Telefono { get; set; }
    }
}