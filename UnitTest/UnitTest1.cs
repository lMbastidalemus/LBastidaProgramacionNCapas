using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGetById()
        {
            DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1();
            DLEF.UsuarioGetById_Result usuario = context.UsuarioGetById(34).First();
            Assert.IsNotNull(usuario);
            //ML.Result result = BL.Usuario.GetByIdEF(34);
            //ML.Usuario usuarioEsperado = new ML.Usuario();
            //usuarioEsperado.Nombre = "Mauricio";
            Assert.AreEqual(usuario.Nombre, "Mauricio", "Error");
        }


        //[TestMethod]
        //public void TestMethodDelete()
        //{
        //    ML.Result result = BL.Usuario.DeleteEF(73);
        //    Assert.IsTrue(result.Correct);
        //}

        [TestMethod]
        public void TestMethodAdd()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = 1;
            usuario.UserName = "Testing";
            usuario.Nombre = "Gerado";
            usuario.ApellidoPaterno = "Torres";
            usuario.ApellidoMaterno = "Mendez";
            usuario.Email = "vaca@gmail.com";
            usuario.Password = "12345";
            usuario.Sexo = "H";
            usuario.Telefono = "5544960912";
            usuario.Celular = "5522113324";
            usuario.CURP = "BALL000917HMCSMSA7";
           
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Calle = "SurT";
            usuario.Direccion.NumeroInterior = "345";
            usuario.Direccion.NumeroExterior = "254";
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.IdColonia = 1;
            usuario.Imagen = "null";
            ML.Result result = BL.Usuario.AddEF(usuario);
            Assert.AreEqual(usuario, result.Correct, result.ErrorMessage);
        }

        [TestMethod]
        public void TestGetAll()
        {
            ML.Usuario usuario =  new ML.Usuario();
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            usuario.Usuarios = result.Objects;
            Assert.AreEqual(usuario, result.ErrorMessage);

        }

    }
}
