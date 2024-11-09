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
                         select new TiendaViewModel
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

                        Objeto.Id_Tienda = TModel.ID_TIENDA;
                        Objeto.Nombre = TModel.NOMBRE;
                        Objeto.Direccion = TModel.DIRECCION;
                        Objeto.Telefono = TModel.TELEFONO;

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
            ProductoViewModel TModel = new TiendasViewModel();
            using (PAV_PARCIAL_IEntities dTienda = new PAV_PARCIAL_IEntities())
            {
                var Objeto = dTienda.TIENDAS.Find(id);

                TModel.ID_TIENDA = Objeto.Id_Tienda;
                TModel.NOMBRE = Objeto.Nombre;
                TModel.DIRECCION = Objeto.Direccion;
                TModel.TELEFONO = Objeto.Telefono;
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

                        dProducto.Entry(Objeto).State = System.Data.Entity.EntityState.Modified;
                        dProducto.SaveChanges();
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
                dProducto.producto.Remove(Objeto);
                dProducto.SaveChanges();
            }
            return Redirect("/");
        }
    }
}