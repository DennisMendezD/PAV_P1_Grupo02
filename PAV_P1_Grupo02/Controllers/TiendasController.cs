using PAV_P1_Grupo02.Models.ViewModels;
using PAV_P1_Grupo02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAV_P1_Grupo02.Controllers
{
    public class TiendasController : Controller
    {
        // GET: Tiendas
        public ActionResult Index()
        {
            List<TiendasViewModel> lista;
            using (PAV_PARCIAL_IEntities dTienda = new PAV_PARCIAL_IEntities())
            {
                lista = (from datos in dTienda.TIENDAS
                         select new TiendasViewModel
                         {
                             Id_Tienda = datos.ID_TIENDA,
                             Nombre = datos.NOMBRE,
                             Direccion = datos.DIRECCION,
                             Telefono = datos.TELEFONO
                         }).ToList();
            }
            return View(lista);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TiendasViewModel TModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (PAV_PARCIAL_IEntities dTienda = new PAV_PARCIAL_IEntities())
                    {
                        var Objeto = new TIENDAS();

                        Objeto.ID_TIENDA = TModel.Id_Tienda;
                        Objeto.NOMBRE = TModel.Nombre;
                        Objeto.DIRECCION = TModel.Direccion;
                        Objeto.TELEFONO = TModel.Telefono;

                        dTienda.TIENDAS.Add(Objeto);
                        dTienda.SaveChanges();
                    }
                    return Redirect("/");
                }
                return View(TModel);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            TiendasViewModel TModel = new TiendasViewModel();
            using (PAV_PARCIAL_IEntities dTienda = new PAV_PARCIAL_IEntities())
            {
                var Objeto = dTienda.TIENDAS.Find(id);

                TModel.Id_Tienda = Objeto.ID_TIENDA;
                TModel.Nombre = Objeto.NOMBRE;
                TModel.Direccion = Objeto.DIRECCION;
                TModel.Telefono = Objeto.TELEFONO;
            }
            return View(TModel);
        }

        [HttpPost]
        public ActionResult Editar(TiendasViewModel TModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (PAV_PARCIAL_IEntities dTienda = new PAV_PARCIAL_IEntities())
                    {
                        var Objeto = dTienda.TIENDAS.Find(TModel.Id_Tienda);

                        Objeto.ID_TIENDA = TModel.Id_Tienda;
                        Objeto.NOMBRE = TModel.Nombre;
                        Objeto.DIRECCION = TModel.Direccion;
                        Objeto.TELEFONO = TModel.Telefono;

                        dTienda.Entry(Objeto).State = System.Data.Entity.EntityState.Modified;
                        dTienda.SaveChanges();
                    }
                    return Redirect("/");
                }
                return View(TModel);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (PAV_PARCIAL_IEntities dTienda = new PAV_PARCIAL_IEntities())
            {
                var Objeto = dTienda.TIENDAS.Find(id);
                dTienda.TIENDAS.Remove(Objeto);
                dTienda.SaveChanges();
            }
            return Redirect("/");
        }
    }
}