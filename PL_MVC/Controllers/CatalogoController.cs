using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        public ActionResult Catalogo()
        {

            ML.Area area = new ML.Area();
            ML.Result result = BL.Area.AreaGetAll();
            
            area.Areas = result.Objects;
            return View(area);
        }

        [HttpGet]
        public ActionResult GetProductos(int? idArea)
        {
            ML.Result result = BL.Producto.GetALL(idArea.Value);
            if (result.Correct)
            {
                ML.Producto producto = new ML.Producto();
                producto.Productos = result.Objects;
                return View(producto);
            }
            else
            {
                ViewBag.Mensaje = "Error en la consulta";
                return PartialView("Modal");
            }
        }

        [HttpPost]
        public ActionResult GetProductos()
        {
            return View();

        }
    }

   
}