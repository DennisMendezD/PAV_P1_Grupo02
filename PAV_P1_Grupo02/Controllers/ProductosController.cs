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
            return View();
        }

        public ActionResult Nuevo(ProductosViewModel PModel)
        {
            return View();
        }

        public ActionResult Editar(ProductosViewModel PModel)
        {
            return View();
        }
    }
}