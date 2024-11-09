using PAV_P1_Grupo02.Models;
using PAV_P1_Grupo02.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAV_P1_Grupo02.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            List<ProductosViewModel> lista;
            using (PAV_PARCIAL_IEntities dProducto = new PAV_PARCIAL_IEntities())
            {
                lista = (from datos in dProducto.PRODUCTOS
                         select new ProductosViewModel
                         {
                             Id_Producto = datos.ID_PRODUCTO,
                             Descripcion = datos.DESCRIPCION_PRODUCTO,
                             Cantidad = datos.CANTIDAD_DISPONIBLE
                         }).ToList();
            }

                return View(lista);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ProductosViewModel PModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (PAV_PARCIAL_IEntities dProducto = new PAV_PARCIAL_IEntities())
                    {
                        var Objeto = new PRODUCTOS();

                        Objeto.ID_PRODUCTO = PModel.Id_Producto;
                        Objeto.DESCRIPCION_PRODUCTO = PModel.Descripcion;
                        Objeto.CANTIDAD_DISPONIBLE = PModel.Cantidad;

                        dProducto.PRODUCTOS.Add(Objeto);
                        dProducto.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(PModel);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ActionResult Editar(int id)
        {
            ProductosViewModel PModel = new ProductosViewModel();
            using (PAV_PARCIAL_IEntities dProducto = new PAV_PARCIAL_IEntities())
            {
                var Objeto = dProducto.PRODUCTOS.Find(id);

                PModel.Id_Producto = Objeto.ID_PRODUCTO;
                PModel.Descripcion = Objeto.DESCRIPCION_PRODUCTO;
                PModel.Cantidad = Objeto.CANTIDAD_DISPONIBLE;

            }
            return View(PModel);
        }

        [HttpPost]
        public ActionResult Editar(ProductosViewModel PModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (PAV_PARCIAL_IEntities dProducto = new PAV_PARCIAL_IEntities())
                    {
                        var Objeto = dProducto.PRODUCTOS.Find(PModel.Id_Producto);

                        Objeto.ID_PRODUCTO = PModel.Id_Producto;
                        Objeto.DESCRIPCION_PRODUCTO = PModel.Descripcion;
                        Objeto.CANTIDAD_DISPONIBLE = PModel.Cantidad;

                        dProducto.Entry(Objeto).State = System.Data.Entity.EntityState.Modified;
                        dProducto.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                return View(PModel);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (PAV_PARCIAL_IEntities dProducto = new PAV_PARCIAL_IEntities())
            {
                var Objeto = dProducto.PRODUCTOS.Find(id);
                dProducto.PRODUCTOS.Remove(Objeto);
                dProducto.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}