using System;
using System.Collections.Generic;
using System.IO; //Para usar File y StreamReader
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
      
           
        
        //public static void AddEF()

        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    Console.WriteLine("Ingresa el id del nuevo Rol del usuario");
        //    usuario.Rol = new ML.Rol();
        //    usuario.Rol.IdRol = int.Parse(Console.ReadLine());

        //    Console.WriteLine("Ingresa el UserName del nuevo usuario");
        //    usuario.UserName = Console.ReadLine();

        //    Console.WriteLine("Ingresa el Nombre del nuevo usuario");
        //    usuario.Nombre = Console.ReadLine();

        //    Console.WriteLine("Ingresa el Apellido Paterno del nuevo usuario");
        //    usuario.ApellidoPaterno = Console.ReadLine();

        //    Console.WriteLine("Ingresa el Apellido Materno del nuevo usuario");
        //    usuario.ApellidoMaterno = Console.ReadLine();

        //    Console.WriteLine("Ingresa su email");
        //    usuario.Email = Console.ReadLine();

        //    Console.WriteLine("Ingresa su password");
        //    usuario.Password = Console.ReadLine();

        //    Console.WriteLine("Ingresa su sexo");
        //    usuario.Sexo = Console.ReadLine();

        //    Console.WriteLine("Ingresa su telefono");
        //    usuario.Telefono = Console.ReadLine();

        //    Console.WriteLine("Ingresa su celular");
        //    usuario.Celular = Console.ReadLine();

        //    Console.WriteLine("Ingresa la fecha de nacimiento del nuevo usuario");
        //    usuario.FechaNacimiento = DateTime.Parse(Console.ReadLine());

        //    Console.WriteLine("Ingresa su CURP");
        //    usuario.CURP = Console.ReadLine();

           


        //    ML.Result result = BL.Usuario.AddEF(usuario);
        //    if (result.Correct)
        //    {
        //        Console.WriteLine("Usuario agregado correctamente");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Usuario no agregado" + result.ErrorMessage);
        //    }

        //}

        //public static void DeleteEF(int IdUsuario)
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    Console.WriteLine("Ingresa el id del usuario a eliminar \n ");
        //    IdUsuario = int.Parse(Console.ReadLine());

        //    ML.Result result = BL.Usuario.DeleteEF(IdUsuario);
        //    if (result.Correct)
        //    {
        //        Console.WriteLine("Usuario eliminado correctamente");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Usuario no eliminado" + result.ErrorMessage);
        //    }

        //}

        //public static void ActualizarEF()
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    Console.WriteLine("Ingresa el id del Usuario a editar");
        //    usuario.IdUsuario = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Ingresa el id del nuevo Rol del usuario");
        //    usuario.Rol = new ML.Rol();
        //    usuario.Rol.IdRol = int.Parse(Console.ReadLine());

        //    Console.WriteLine("Ingresa el UserName del nuevo usuario");
        //    usuario.UserName = Console.ReadLine();

        //    Console.WriteLine("Ingresa el Nombre del nuevo usuario");
        //    usuario.Nombre = Console.ReadLine();

        //    Console.WriteLine("Ingresa el Apellido Paterno del nuevo usuario");
        //    usuario.ApellidoPaterno = Console.ReadLine();

        //    Console.WriteLine("Ingresa el Apellido Materno del nuevo usuario");
        //    usuario.ApellidoMaterno = Console.ReadLine();

        //    Console.WriteLine("Ingresa su email");
        //    usuario.Email = Console.ReadLine();

        //    Console.WriteLine("Ingresa su password");
        //    usuario.Password = Console.ReadLine();

        //    Console.WriteLine("Ingresa su telefono");
        //    usuario.Telefono = Console.ReadLine();

        //    Console.WriteLine("Ingresa su celular");
        //    usuario.Celular = Console.ReadLine();

        //    Console.WriteLine("Ingresa su CURP");
        //    usuario.CURP = Console.ReadLine();
        //    ML.Result result = BL.Usuario.ActualizarEF(usuario);
        //    if (result.Correct)
        //    {
        //        Console.WriteLine("Usuario actualizado correctamente");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Usuario no agregado" + result.ErrorMessage);
        //    }
        //}

        //public static void GetAllEF()
        //{
        //    ML.Result result = BL.Usuario.GetAllEF();


        //    if (result.Correct)
        //    {
        //        foreach (ML.Usuario usuario in result.Objects)
        //        {

        //            Console.WriteLine("------------  GETALL -------");
        //            Console.WriteLine("ID :" + usuario.IdUsuario);
        //            Console.WriteLine("Id Rol: " + usuario.Rol.IdRol);
        //            Console.WriteLine("UserName :" + usuario.UserName);
        //            Console.WriteLine("Nombre :" + usuario.Nombre);
        //            Console.WriteLine("Apellido Paterno : " + usuario.ApellidoPaterno);
        //            Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
        //            Console.WriteLine("Email: " + usuario.Email);
        //            Console.WriteLine("Password: " + usuario.Password);
        //            Console.WriteLine("Sexo :" + usuario.Sexo);
        //            Console.WriteLine("Telefono :" + usuario.Telefono);
        //            Console.WriteLine("Celular :" + usuario.Celular);
        //            Console.WriteLine("Fecha de Nacimiento: " + usuario.FechaNacimiento);
        //            Console.WriteLine("CURP: " + usuario.CURP);
        //            Console.WriteLine("Rol del Usuario: " + usuario.Rol.Nombre);
                 
        //            Console.WriteLine();
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error al consultar el usuario" + result.ErrorMessage);
        //    }

        //}

        //public static void GetByIdEF(int IdUsuario)
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    Console.WriteLine("Ingrese el id del Usuario a consultar");
        //    IdUsuario = int.Parse(Console.ReadLine());

        //    ML.Result result = BL.Usuario.GetByIdEF(IdUsuario);

        //    if (result.Correct == true)
        //    {
        //        usuario = (ML.Usuario)result.Object;



            
        //        Console.WriteLine("ID :" + usuario.IdUsuario);
        //        Console.WriteLine("Id Rol: " + usuario.Rol.IdRol);
        //        Console.WriteLine("UserName :" + usuario.UserName);
        //        Console.WriteLine("Nombre :" + usuario.Nombre);
        //        Console.WriteLine("Apellido Paterno : " + usuario.ApellidoPaterno);
        //        Console.WriteLine("Apellido Materno: " + usuario.ApellidoMaterno);
        //        Console.WriteLine("Email: " + usuario.Email);
        //        Console.WriteLine("Password: " + usuario.Password);
        //        Console.WriteLine("Sexo :" + usuario.Sexo);
        //        Console.WriteLine("Telefono :" + usuario.Telefono);
        //        Console.WriteLine("Celular :" + usuario.Celular);
        //        Console.WriteLine("Fecha de Nacimiento: " + usuario.FechaNacimiento);
        //        Console.WriteLine("CURP: " + usuario.CURP);
        //        Console.WriteLine("Rol del Usuario: " + usuario.Rol.Nombre);
        //        Console.WriteLine();

        //        Console.WriteLine();



        //    }
        //    else
        //    {
        //        Console.WriteLine("Error al consultar el usuario" + result.ErrorMessage);
        //    }

        //}

       
    }
}
