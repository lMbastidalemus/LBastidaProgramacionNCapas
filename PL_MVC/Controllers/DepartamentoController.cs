using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace PL_MVC.Controllers
{
    //Pasos para el DDL 
    //Crear SP de la tabla que desplegara lista y actualizar el modelo, crear en ML su propiedad LIst
    //Crear su metodo en BL y ese mandarlo a llamar en el controlador con las respectivas instancias
    //Cuando sean mas de un DDL se ocupa ajax
    public class DepartamentoController : Controller
    {
        [HttpGet]
        public ActionResult DepartamentoGetAll()
        {
            ML.Departamento departamento = new ML.Departamento();
            departamento.Area = new ML.Area();
            departamento.Nombre = "";

            ML.Result result = new ML.Result();
            result = BL.Departamento.DepartamentoGetAllEF(departamento);

            ML.Result resultArea = new ML.Result();
            resultArea = BL.Area.AreaGetAll();


            if (result.Correct)
            {
                departamento.Departamentos = result.Objects;
                departamento.Area.Areas = resultArea.Objects;
                return View(departamento); //Se imprime todos los datos traidos de la bD
            }
            else
            {
                departamento.Area.Areas = resultArea.Objects;
                return View();
            }
            
          
        }

        [HttpPost]
        public ActionResult DepartamentoGetAll(ML.Departamento departamento)
        {
            if (departamento.Nombre == null)
            {
                departamento.Nombre = "";
            }

            ML.Result result = new ML.Result();
            result = BL.Departamento.DepartamentoGetAllEF(departamento);

            ML.Result resultArea = new ML.Result();
            resultArea = BL.Area.AreaGetAll();

            departamento.Departamentos = result.Objects;
            departamento.Area.Areas = resultArea.Objects;
               
            return View(departamento);
        }
        [HttpGet]
        public ActionResult FormDepto(int? IdDepartamento)
        {
            //Instancias
            ML.Departamento departamento = new ML.Departamento();
            departamento.Area = new ML.Area();
            departamento.Producto = new ML.Producto();
            departamento.Producto.Proveedor = new ML.Proveedor();
            
           
            ML.Result resultArea = BL.Area.AreaGetAll();
            ML.Result resultProveedor = BL.Proveedor.ProveedorGetAll();


            //Para el update de precargar solo el formulario
            if (IdDepartamento != null)
            {
                ML.Result result = BL.Departamento.DepartamentoGetByIdEF(IdDepartamento.Value);
                if (result.Correct)
                {
                    //Unboxing de extraer el objeto para convertirlo en un tipo de dato
                    departamento = (ML.Departamento)result.Object;
                    //Pasarle la lista a la propiedad que es la lista Areas
                    departamento.Area.Areas = resultArea.Objects;
                   
                    departamento.Producto.Proveedor.Proveedores = resultProveedor.Objects;
                    
                }

            }
            else
            {
                //Sino trae nada pues entonces solo se llenaran las listas y los demas campos estaran
                //en blanco y esto es en cierta parte para que se muestre  form de agregar
              
                departamento.Area.Areas = resultArea.Objects;
                departamento.Producto.Proveedor.Proveedores = resultProveedor.Objects;

            }
            return View(departamento);
        }
        // GET: Departamento
        [HttpPost]
        public ActionResult FormDepto(ML.Departamento departamento)
        {
            
                HttpPostedFileBase file = Request.Files["Imagen"];
                if (file.ContentLength > 0)
                {
                    departamento.Producto.Imagen = ConvertirABase64(file);
                }
                //Si no tiene un id significa que apenas va agregar
                if (departamento.IdDepartamento == 0)
                {
                    ML.Result result = BL.Departamento.DepartamentoAddEF(departamento);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Departamento agregado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al agregar el usuario";
                    }
                }
                else
                {
                    //Aqui va el metodo de actualizar
                    ML.Result result = BL.Departamento.DepartamentoUpdateEF(departamento);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Usuario actualizado correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al actualizar el usuario";
                    }

                }
                return PartialView("Modal");
            
           
        }

        public ActionResult Eliminar(int IdDepartamento)
        {
            ML.Result result = BL.Departamento.DepartamentoDeleteEF(IdDepartamento);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Departamento eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar el departamento";
            }
            return PartialView("Modal");

        }

        public string ConvertirABase64(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }

      
    }

    
}