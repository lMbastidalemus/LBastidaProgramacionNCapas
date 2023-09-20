using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        [HttpGet]
        public ActionResult Cargar()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            return View(result);
        }

        [HttpPost]
        public ActionResult Cargar(ML.Result result) 
        {
            //Almacenar el archivo con el id excel en el objeto file
            HttpPostedFileBase file = Request.Files["Excel"];

            //condicion si la session es nulla significa que hara por primera vez el proceso
            //para buscar el archivo excel y hacer el proceso que sigue
            if (Session["pathExcel"] == null)
            {
                //Si el archivo trae algo/fue seleccionado
                if (file != null)
                {
                    //Se obtiene solamente la extension del archivo seleccionado
                    string extensionArchivo = Path.GetExtension(file.FileName).ToLower();
                    //SE llama el appsetting creado en webconfig para verificar que la extension sea .xlsx
                    string extesionValida = ConfigurationManager.AppSettings["TipoExcel"];

                    //si la extension dle archivo seleccionado y la del appsetting son iguales
                    if (extensionArchivo == extesionValida)
                    {
                        //SE obtiene la ruta(relativa) del proyecto donde se guardara la copia
                        string rutaproyecto = Server.MapPath("~/CargaMasiva/");
                        //Para la copia que se guardara se le pasara la ruta dle proyecto + el nombre del proyecto sin extension + la fecha con ss para que no se 
                        //tenga problema en que los archivos tengas hasta la misma hora y por eso se pone segundos y se agrega la extension .xlsx
                        string filePath = rutaproyecto + Path.GetFileNameWithoutExtension(file.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                        //Si el archivo realmente existe
                        if (!System.IO.File.Exists(filePath))
                        {
                            //Se guardar el archivo
                            file.SaveAs(filePath);

                            //SE hace la conexion con oldb mas la copia dle archivo con toda la ruta y la extension
                            string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + filePath;
                            //SE iguala el metodo de BL pasandole la conexion para pasarselo al objeto resultUsuarios
                            ML.Result resultUsuarios = BL.Usuario.LeerExcel(connectionString);

                            //Si es correcto, es decir, que el metodo leerExcel se haya completado correctamente antes(no significa que es correcto los datos, solo se trajo
                            ////lo que se tenia en la consulta de la hoja del excel)
                            if (resultUsuarios.Correct)
                            {
                                //Si es que se leyo el excel correctamente se mandara a llamar el metodo para validar que sea correcto o no
                                ML.Result resultValidacion = BL.Usuario.ValidarExcel(resultUsuarios.Objects);

                                //Si es verdadero entra al if, sino retornar lo que traiga resultvlidation que son los errores o sino trae errores pues no muestra nada
                                if (resultValidacion.Objects.Count == 0)
                                {
                                    resultValidacion.Correct = true;
                                    Session["pathExcel"] = filePath;
                                }

                                //retornar los errores o no, depende el caso
                                return View(resultValidacion);

                            }
                            else
                            {
                                ViewBag.Message = "El excel no contiene registros";
                            }
                            return PartialView("Modal");

                        }

                    }
                    else
                    {

                        //Si el archivo no tiene la extension .xlsx manda el siguiente mensaje
                        ViewBag.Message = "Favor de seleccionar un archivo .xlsx, Verifique su archivo";
                       
                    }
                    return PartialView("Modal");
                }
                else
                {
                    ViewBag.Message = "No selecciono ningun archivo, Seleccione uno correctamente";
                }
                return View(result);
            }
            else
            {
                //Si la validacion fue correcta estos pasos son para ya poder insertar (significa que es la segunda vez que hara el proceso ya para insertar)
                string filepath = Session["pathExcel"].ToString();
                //Si el archivo si trae datos
                if (filepath != null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnection"] + filepath;
                    //Vuelve a leer el excel para verificar que el archivo que subio de nuevo el usuario sea correcto nuevamente
                    ML.Result resultUsuarios = BL.Usuario.LeerExcel(connectionString);

                    if (resultUsuarios.Correct)
                    {
                        ML.Result resultErrores = new ML.Result();
                        resultErrores.Objects = new List<object>();
                        //sE itera en cada fila del excel, trayendo los datos
                        foreach (ML.Usuario usuario in resultUsuarios.Objects)
                        {
                            //Txt para errores
                            ML.Result result1 = BL.Usuario.AddEF(usuario);
                            if (!result1.Correct)
                            {
                                string error = "Ocurrio un error al insertar el usuario con correo: " + usuario.Email + "el error fue" + result1.ErrorMessage;
                                resultErrores.Objects.Add(error);
                            }
                            //Se limpia la session porque si es que ya existe la sesion querra hacer el mismo proceso de antes
                            Session["pathExcel"] = null;

                        }
                        if(resultErrores.Objects.Count > 0)
                        {
                             string pathTxt = Server.MapPath(@"~\Files\logErrores.txt");
                            
                            using (StreamWriter writter = new StreamWriter(pathTxt))

                            {
                                foreach(string linea in resultErrores.Objects)
                                {
                                    writter.WriteLine(linea);
                                }
                            }
                        }
                    }

                }
                else
                {
                  

                }


            }
            return View(result);
        }
    }
}