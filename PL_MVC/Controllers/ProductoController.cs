using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
           
            ML.Producto producto = new ML.Producto();
            producto.Proveedor = new ML.Proveedor();
            producto.Departamento = new ML.Departamento();
            ML.Result result = BL.Producto.GetALlP();
            producto.Productos = result.Objects;

            return View(producto);  
        }

        [HttpGet]       
        public ActionResult Form(int? IdProducto)
        {

            ML.Producto producto = new ML.Producto();
            
            producto.Departamento = new ML.Departamento();
            producto.Departamento.Area = new ML.Area();
            ML.Result resultArea = BL.Area.AreaGetAll();
            producto.Departamento.Area.Areas = resultArea.Objects;

           
            producto.Proveedor = new ML.Proveedor();
           
           
            
            ML.Result resultProveedor = BL.Proveedor.ProveedorGetAll();
           
            
            ML.Departamento departamento = new ML.Departamento();
            ML.Result resultDepartamento = BL.Departamento.GetAllEF(departamento);
           

            if(IdProducto != null)
            {
                ML.Result result = BL.Producto.GetById(IdProducto.Value);
                if (result.Correct)
                {
                    producto = (ML.Producto) result.Object;
                    producto.Proveedor.Proveedores = resultProveedor.Objects;
                    producto.Departamento.Departamentos = resultDepartamento.Objects;
              

                    
                    
                }
            }
            else
            {
                producto.Proveedor.Proveedores = resultProveedor.Objects;
                //producto.Departamento.Departamentos = resultDepartamento.Objects;
            }
          

            return View(producto);  
        }

        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            return View();
        }




        public ActionResult Delete(int IdProducto)
        {
            ML.Result result = BL.Producto.DeleteEF(IdProducto);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Producto eliminado correctamente";
            }

            else
            {
                ViewBag.Mensaje = "Error al eliminar producto" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
    }
}