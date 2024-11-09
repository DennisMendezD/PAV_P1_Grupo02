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
                        oPersona.NOMBRE_COMPLETO = model.NombreCompleto;
                        oPersona.EDAD = model.Edad;
                        oPersona.ESTADO = model.Estado;

                        db.PERSONAS.Add(oPersona);
                        db.SaveChanges();
                    }

                    return Redirect("/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            PersonasViewModel model = new PersonasViewModel();

            using (PAV_PARCIAL_IEntities db = new PAV_PARCIAL_IEntities())
            {
                var oPersona = db.PERSONAS.Find(id);
                model.Id = oPersona.ID_PERSONA;
                model.Identificacion = oPersona.IDENTIFICACION;
                model.NombreCompleto = oPersona.NOMBRE_COMPLETO;
                model.Edad = oPersona.EDAD;
                model.Estado = oPersona.ESTADO;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(PersonasViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PAV_PARCIAL_IEntities db = new PAV_PARCIAL_IEntities())
                    {
                        var oPersona = db.PERSONAS.Find(model.Id);
                        oPersona.ID_PERSONA = model.Id;
                        oPersona.IDENTIFICACION = model.Identificacion;
                        oPersona.NOMBRE_COMPLETO = model.NombreCompleto;
                        oPersona.EDAD = model.Edad;
                        oPersona.ESTADO = model.Estado;

                        db.PERSONAS.Add(oPersona);
                        db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar (int id)
        {
            using (PAV_PARCIAL_IEntities db = new PAV_PARCIAL_IEntities())
            {
                var oPersona = db.PERSONAS.Find(id);
                db.PERSONAS.Remove(oPersona);
                db.SaveChanges();
            }

            return Redirect("/");
        }
    }}