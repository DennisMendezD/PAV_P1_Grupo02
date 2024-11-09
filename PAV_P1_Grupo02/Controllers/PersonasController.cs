using PAV_P1_Grupo02.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PAV_P1_Grupo02.Models;
using System.Web.Mvc;

namespace PAV_P1_Grupo02.Controllers
{
    public class PersonasController : Controller
    {
        // GET: Personas
        public ActionResult Index()
        {
            List<PersonasViewModel> list = new List<PersonasViewModel>();

            using (PAV_PARCIAL_IEntities db = new PAV_PARCIAL_IEntities())
            {
                list = (from d in db.PERSONAS select new PersonasViewModel { 
                    Id = d.ID_PERSONA,
                    Identificacion = d.IDENTIFICACION,
                    NombreCompleto = d.NOMBRE_COMPLETO,
                    Edad = d.EDAD,
                    Estado = d.ESTADO
                }).ToList();
            }

            return View(list);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(PersonasViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PAV_PARCIAL_IEntities db = new PAV_PARCIAL_IEntities())
                    {
                        var oPersona = new PERSONAS();
                        oPersona.ID_PERSONA = model.Id;
                        oPersona.IDENTIFICACION = model.Identificacion;
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editar(PersonasViewModel model)
        {
            return View();
        }
    }
}