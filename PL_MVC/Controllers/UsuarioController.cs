using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Nombre = "";
            usuario.ApellidoPaterno = "";
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            usuario.Usuarios = result.Objects;
           
           
            return View(usuario);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {

            if (usuario.Nombre == null)
            {
                usuario.Nombre = "";
            }
            if (usuario.ApellidoPaterno == null)
            {
                usuario.ApellidoPaterno = "";
            }
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            usuario = new ML.Usuario();
            usuario.Usuarios = result.Objects;
            return View(usuario);
        }
        [HttpGet] //Mostrar
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            //INSTANCIAS
            usuario.Rol = new ML.Rol();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            


            ML.Result resultRol = BL.Rol.RolGetAll();
            ML.Result resultPais = BL.Pais.PaisGetAll();
            
            
            
       
            if(IdUsuario != null) //Update
            {
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    usuario.Rol.Roles = resultRol.Objects; //Mandamos a llamar la lista 
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.EstadoGetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais).Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.MunicipioGetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Objects;
                    usuario.Direccion.Colonia.Colonias = BL.Colonia.ColoniaGetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio).Objects;
                    

                } 
            }
            else
            {
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects; //Pasar lista de paises  
                usuario.Rol.Roles = resultRol.Objects;
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
           
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["Imagen"];
                if (file.ContentLength > 0)
                {
                    usuario.Imagen = ConvertirABase64(file);
                }
                if (usuario.IdUsuario == 0)
                {
                    ML.Result result = BL.Usuario.AddEF(usuario);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Usuario agregado correctamente";

                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al agregar usuario" + result.ErrorMessage;

                    }
                }
                else
                {
                    ML.Result result = BL.Usuario.ActualizarEF(usuario);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Usuario actualizado correctamente";

                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al actualizar usuario" + result.ErrorMessage;

                    }
                }
                return PartialView("Modal");
            }
            else
            {
                ML.Result resultRol = BL.Rol.RolGetAll();
                ML.Result resultPais = BL.Pais.PaisGetAll();

           
                usuario.Rol.Roles = resultRol.Objects; //Mandamos a llamar la lista 
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Estados = BL.Estado.EstadoGetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais).Objects;
                usuario.Direccion.Colonia.Municipio.Municipios = BL.Municipio.MunicipioGetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Objects;
                usuario.Direccion.Colonia.Colonias = BL.Colonia.ColoniaGetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio).Objects;




                return View(usuario);
            }
        }

       
        public ActionResult Eliminar(int IdUsuario)
        {
            ML.Result result = BL.Usuario.DeleteEF(IdUsuario);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Usuario eliminado correctamente";
            }
            
            else
            {
                ViewBag.Mensaje = "Error al eliminar usuario" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }

        public JsonResult EstadoGetByIdPais(int IdPais)
        {
            ML.Result result = BL.Estado.EstadoGetByIdPais(IdPais);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult MunicipioGetByIdEstado(int IdEstado)
        {
            ML.Result result = BL.Municipio.MunicipioGetByIdEstado(IdEstado);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = BL.Colonia.ColoniaGetByIdMunicipio(IdMunicipio);
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public string ConvertirABase64(HttpPostedFileBase Foto)
        {
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            byte[] data = reader.ReadBytes((int)Foto.ContentLength);
            string imagen = Convert.ToBase64String(data);
            return imagen;
        }

        public JsonResult UsuarioChangeStatus(int IdUsuario, bool Status)
        {
            ML.Result result = BL.Usuario.UsuarioChangeStatus(IdUsuario, Status);
            return Json(null);
        }


        //Metodo para el login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            ML.Result result = BL.Usuario.ValidarGetById(email, password);
            if (result.Correct)
            {
                //Umboxing
                ML.Usuario usuario = (ML.Usuario)result.Object;
                if(usuario.Password == password)
                {
                    
                    return RedirectToAction("GetAll", "Usuario");
                    
                }
                else
                {
                    ViewBag.Login = true;
                    ViewBag.Mensaje = "La contraseña es incorrecta";
                    return PartialView("Modal");
                }
               
            }
            else
            {
                ViewBag.Login = true; //Esta mal el usuario o contraseña
                ViewBag.Mensaje = "Usuario no encontrado";
                return PartialView("Modal");
               
            }
         

        }

       


    }
}