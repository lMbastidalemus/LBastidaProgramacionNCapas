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
            ML.Producto producto1 = new ML.Producto();
            producto1.Departamento = new ML.Departamento();
            producto1.Departamento.Area = new ML.Area();
            ML.Result result = BL.Producto.GetALL(idArea.Value);
            if (idArea == 0)
            {
                ML.Producto producto3 = new ML.Producto();
                producto3.Productos = result.Objects;
                return View(producto3);
            }
            else
            {
                if (result.Correct)
                {
                    ML.Producto producto = new ML.Producto();
                    producto.Productos = result.Objects;
                    return View(producto);
                }
                else
                {
                    return View();
                }
            }
           
        }

        [HttpPost]
        public ActionResult GetProductos(ML.Producto producto)
        {
            return View();

        }
    }

   
}