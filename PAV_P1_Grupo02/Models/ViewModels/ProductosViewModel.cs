using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PAV_P1_Grupo02.Models.ViewModels
{
    public class ProductosViewModel
    {
        [Display(Name = "ID")]
        public int Id_Producto { get; set; }

        [Required]
        [StringLength(100)]
        public string Descrpcion { get; set; }

        [Required]
        public int Cantidad { get; set; }

    }
}