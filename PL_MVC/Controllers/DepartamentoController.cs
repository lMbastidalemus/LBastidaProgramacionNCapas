using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net.Http;
using System.Configuration;

namespace PL_MVC.Controllers
{
    //Pasos para el DDL 
    //Crear SP de la tabla que desplegara lista y actualizar el modelo, crear en ML su propiedad LIst
    //Crear su metodo en BL y ese mandarlo a llamar en el controlador con las respectivas instancias
    //Cuando sean mas de un DDL se ocupa ajax
    public class DepartamentoController : Controller
    {
        //[HttpGet]
        //public ActionResult DepartamentoGetAll()
        //{
        //    ML.Departamento departamento = new ML.Departamento();
        //    departamento.Area = new ML.Area();
        //    departamento.Nombre = "";

        //    ML.Result result = new ML.Result();
        //    result = BL.Departamento.GetAllEF(departamento);

        //    ML.Result resultArea = new ML.Result();
        //    resultArea = BL.Area.AreaGetAll();


        //    if (result.Correct)
        //    {
        //        departamento.Departamentos = result.Objects;
        //        departamento.Area.Areas = resultArea.Objects;
        //        return View(departamento); //Se imprime todos los datos traidos de la bD
        //    }
        //    else
        //    {
        //        departamento.Area.Areas = resultArea.Objects;
        //        return View();
        //    }


        //}

        ///Con web Api
        [HttpGet]
        public ActionResult DepartamentoGetAll()
        {
            ML.Departamento departamento = new ML.Departamento();
            departamento.Departamentos = new List<object>();
            departamento.Area = new ML.Area();
            departamento.Nombre = "";

            ML.Result result = BL.Departamento.GetAllEF(departamento);
            ML.Result resultArea = BL.Area.AreaGetAll();
            using (var client = new HttpClient())
            {
                
                departamento.Area.Areas = resultArea.Objects;
                departamento.Departamentos = result.Objects;

                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var resultServicio = responseTask.Result;

                if (resultServicio.IsSuccessStatusCode)
                {
                    var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Departamento resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Departamento>(resultItem.ToString());
                        departamento.Departamentos.Add(resultItemList);
                    }
                }
            }
            return View(departamento);

        }

        [HttpPost]
        public ActionResult DepartamentoGetAll(ML.Departamento departamento)
        {
            if (departamento.Nombre == null)
            {
                departamento.Nombre = "";
            }

            ML.Result result = new ML.Result();
            result = BL.Departamento.GetAllEF(departamento);

            ML.Result resultArea = new ML.Result();
            resultArea = BL.Area.AreaGetAll();

            departamento.Departamentos = result.Objects;
            departamento.Area.Areas = resultArea.Objects;

            return View(departamento);
        }
        ////con wfc
        //[HttpGet]
        //public ActionResult FormDepto(int? IdDepartamento)
        //{
        //    //Instancias
        //    ML.Departamento departamento = new ML.Departamento();
        //    departamento.Area = new ML.Area();
        //    ML.Result resultArea = BL.Area.AreaGetAll();



        //    //Para el update de precargar solo el formulario
        //    if (IdDepartamento != null)
        //    {
        //        ServiceReferenceDepartamento.ServiceDepartamentoClient departamentoWcf = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
        //        var result = departamentoWcf.GetById(IdDepartamento.Value);
        //        if (result.Correct)
        //        {
        //            //Unboxing de extraer el objeto para convertirlo en un tipo de dato
        //            departamento = (ML.Departamento)result.Object;
        //            //Pasarle la lista a la propiedad que es la lista Areas
        //            departamento.Area.Areas = resultArea.Objects;



        //        }

        //    }
        //    else
        //    {
        //        //Sino trae nada pues entonces solo se llenaran las listas y los demas campos estaran
        //        //en blanco y esto es en cierta parte para que se muestre  form de agregar

        //        departamento.Area.Areas = resultArea.Objects;


        //    }
        //    return View(departamento);
        //}
        //con wfc
        //[HttpPost]
        //public ActionResult FormDepto(ML.Departamento departamento)
        //{



        //    //Si no tiene un id significa que apenas va agregar
        //    if (departamento.IdDepartamento == 0)
        //    {

        //        ServiceReferenceDepartamento.ServiceDepartamentoClient departamentoWcf = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
        //        var result = departamentoWcf.Add(departamento);
        //        if (result.Correct)
        //        {
        //            ViewBag.Mensaje = "Departamento agregado correctamente";
        //        }
        //        else
        //        {
        //            ViewBag.Mensaje = "Error al agregar el usuario";
        //        }
        //    }
        //    else
        //    {
        //        //Aqui va el metodo de actualizar
        //        ServiceReferenceDepartamento.ServiceDepartamentoClient departamentoWcf = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
        //        var result = departamentoWcf.Update(departamento);
        //        if (result.Correct)
        //        {
        //            ViewBag.Mensaje = "Usuario actualizado correctamente";
        //        }
        //        else
        //        {
        //            ViewBag.Mensaje = "Error al actualizar el usuario";
        //        }

        //    }
        //    return PartialView("Modal");


        //}

        //Configuration wcf
        //public ActionResult Eliminar(int IdDepartamento)
        //{
        //    ServiceReferenceDepartamento.ServiceDepartamentoClient departamentoWcf = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
        //    var result = departamentoWcf.Delete(IdDepartamento);
        //    if (result.Correct)
        //    {
        //        ViewBag.Mensaje = "Departamento eliminado correctamente";
        //    }
        //    else
        //    {
        //        ViewBag.Mensaje = "Error al eliminar el departamento";
        //    }
        //    return PartialView("Modal");

        //}



        //Con webAPi
        public ActionResult Eliminar(ML.Departamento departamento)
        {
            int IdDepartamento = departamento.IdDepartamento;
            departamento.Area = new ML.Area();
            ML.Result resultArea = BL.Area.AreaGetAll();
            departamento.Area.Areas = resultArea.Objects;
            using (var client = new HttpClient())
            {
                departamento.Area.Areas = resultArea.Objects;
           
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                var task = client.DeleteAsync("departamento/" + IdDepartamento);
                task.Wait();
                var result = task.Result;
                if (result.IsSuccessStatusCode)
                {

                    ViewBag.Mensaje = "Departamento eliminado correctamente";
                    return View("Modal");
                }
            }
            departamento.Area.Areas = resultArea.Objects;
            ViewBag.Mensaje = "Error al agregar departamento";
            return View("Modal");

        }

        //Con webapi
        [HttpPost]
        public ActionResult FormDepto(ML.Departamento departamento)
        {

            departamento.Departamentos = new List<object>();
       


            //Si no tiene un id significa que apenas va agregar
            if (departamento.IdDepartamento == 0)
            {
                using (var client = new HttpClient())
                {
                   
            
                    
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Departamento>("departamento/" , departamento);
                    postTask.Wait();
                    //h
                 
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Departamento agregado correctamente";
                        return View("Modal");
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al agregar departamento";
                        return View("Modal");
                    }
                }


            }
            else
            {
                using (var client = new HttpClient())
                {

                    

                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApi"]);
                    //HTTP POST
                    var postTask = client.PutAsJsonAsync<ML.Departamento>("departamento/" + departamento.IdDepartamento, departamento);
                    postTask.Wait();
                    //h

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Departamento actualizado correctamente";
                        return View("Modal");
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al actualizar departamento";
                        return View("Modal");
                    }
                }



            }
          


        }

        //con web api
        [HttpGet]
        public ActionResult FormDepto(int? IdDepartamento)
        {
            //Instancias
            ML.Departamento departamento = new ML.Departamento();
            ML.Result result = new ML.Result();
            departamento.Area = new ML.Area();
            ML.Result resultArea = BL.Area.AreaGetAll();
            


            //Para el update de precargar solo el formulario
            if (IdDepartamento != null)
            {
                try
                {
                    string urlAPI = System.Configuration.ConfigurationManager.AppSettings["WebApi"];
                    using (var client = new HttpClient())
                    {
                        
                        client.BaseAddress = new Uri(urlAPI);
                        var responseTask = client.GetAsync("departamento/" + IdDepartamento);
                        responseTask.Wait();
                        var resultAPI = responseTask.Result;

                        if (resultAPI.IsSuccessStatusCode)
                        {
                           
                            departamento.Area.Areas = resultArea.Objects;

                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Departamento resultItemList = new ML.Departamento();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Departamento>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Departamento";

                        }

                    }
                    return View(departamento);
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;

                }
               

            }
            
            else
            {
                //Sino trae nada pues entonces solo se llenaran las listas y los demas campos estaran
                //en blanco y esto es en cierta parte para que se muestre  form de agregar

                departamento.Area.Areas = resultArea.Objects;


            }
            return View(departamento);
        }

    }



}