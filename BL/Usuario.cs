using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.Entity.Core.Objects;
using System.Data.OleDb;
using System.IO; //Para usar File y StreamReader

namespace BL
{
    public class Usuario
    {
        //public static ML.Result Add(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        //todo lo que ejecute dentro de un using se libera al final
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "INSERT INTO Usuario VALUES(@Nombre, @ApellidoPaterno, @ApellidoMaterno, @Sexo, @Correo, @FechaNacimiento)";

        //            SqlCommand cmd = new SqlCommand(query, context);

        //            SqlParameter[] collection = new SqlParameter[6];

        //            collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
        //            collection[0].Value = usuario.Nombre;

        //            collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
        //            collection[1].Value = usuario.ApellidoPaterno;

        //            collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
        //            collection[2].Value = usuario.ApellidoMaterno;

        //            collection[3] = new SqlParameter("@Sexo", SqlDbType.Char);
        //            collection[3].Value = usuario.Sexo;



        //            collection[5] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
        //            collection[5].Value = usuario.FechaNacimiento;


        //            cmd.Parameters.AddRange(collection);
        //            cmd.Connection.Open();

        //            int filasAfectadas = cmd.ExecuteNonQuery();
        //            if (filasAfectadas > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Error al insertar el usuario";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;


        //    }
        //    return result;

        //}


        //public static ML.Result Eliminar(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = $"DELETE FROM  Usuario Where IdUsuario = {usuario.IdUsuario} ";

        //            SqlCommand cmd = new SqlCommand(query, context);

        //            SqlParameter[] collection = new SqlParameter[1];



        //            collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            collection[0].Value = usuario.IdUsuario;


        //            cmd.Parameters.AddRange(collection);
        //            cmd.Connection.Open();

        //            int filasAfectadas = cmd.ExecuteNonQuery();
        //            if (filasAfectadas > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Error al eliminar el usuario";
        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;

        //}

        //public static ML.Result Actualizar(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = $"Update Usuario set Nombre = '{usuario.Nombre}', ApellidoPaterno = '{usuario.ApellidoPaterno}', ApellidoMaterno = '{usuario.ApellidoMaterno}', Correo = '{usuario.Correo}' WHERE IdUsuario = {usuario.IdUsuario}";

        //            SqlCommand cmd = new SqlCommand(query, context);

        //            SqlParameter[] collection = new SqlParameter[5];
        //            collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            collection[0].Value = usuario.IdUsuario;

        //            collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
        //            collection[1].Value = usuario.Nombre;

        //            collection[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
        //            collection[2].Value = usuario.ApellidoPaterno;

        //            collection[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
        //            collection[3].Value = usuario.ApellidoMaterno;

        //            collection[4] = new SqlParameter("@Correo", SqlDbType.VarChar);
        //            collection[4].Value = usuario.Correo;



        //            cmd.Parameters.AddRange(collection);
        //            cmd.Connection.Open();

        //            int filasAfectadas = cmd.ExecuteNonQuery();
        //            if (filasAfectadas > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Error al eliminar el usuario";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}


        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();


        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "SELECT IdUsuario, Nombre, ApellidoPaterno, ApellidoMaterno, Sexo, Correo, FechaNacimiento FROM Usuario";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            DataTable tablaUsuario = new DataTable();
        //            adapter.Fill(tablaUsuario);

        //            if (tablaUsuario.Rows.Count > 0)
        //            {
        //                result.Objects = new List<object>();
        //                foreach (DataRow row in tablaUsuario.Rows)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.IdUsuario = int.Parse(row[0].ToString());
        //                    usuario.Nombre = row[1].ToString();
        //                    usuario.ApellidoPaterno = row[2].ToString();
        //                    usuario.ApellidoMaterno = row[3].ToString();
        //                    usuario.Sexo = char.Parse(row[4].ToString());
        //                    usuario.Correo = row[5].ToString();
        //                    usuario.FechaNacimiento = DateTime.Parse(row[6].ToString());

        //                    result.Objects.Add(usuario);
        //                }
        //                result.Correct = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result GetById(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "SELECT IdUsuario, Nombre, ApellidoPaterno, ApellidoMaterno, Sexo, Correo, FechaNacimiento FROM Usuario Where IdUsuario = @IdUsuario";
        //            SqlCommand cmd = new SqlCommand(query, context);

        //            SqlParameter[] collection = new SqlParameter[1];
        //            collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            collection[0].Value = usuario.IdUsuario;

        //            cmd.Parameters.AddRange(collection);

        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //            DataTable tablaUsuario = new DataTable();

        //            adapter.Fill(tablaUsuario);

        //            if (tablaUsuario.Rows.Count > 0)
        //            {
        //                DataRow row = tablaUsuario.Rows[0];
        //                ML.Usuario usuarioResult = new ML.Usuario();
        //                usuarioResult.IdUsuario = int.Parse(row[0].ToString());
        //                usuarioResult.Nombre = row[1].ToString();
        //                usuarioResult.ApellidoPaterno = row[2].ToString();
        //                usuarioResult.ApellidoMaterno = row[3].ToString();
        //                usuarioResult.Sexo = char.Parse(row[4].ToString());
        //                usuarioResult.Correo = row[5].ToString();
        //                usuarioResult.FechaNacimiento = DateTime.Parse(row[6].ToString());

        //                result.Object = usuarioResult;

        //                result.Correct = true;

        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result AddSP(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioAdd";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            SqlParameter[] collection = new SqlParameter[7];
        //            collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
        //            collection[0].Value = usuario.Nombre;

        //            collection[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
        //            collection[1].Value = usuario.ApellidoPaterno;

        //            collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
        //            collection[2].Value = usuario.ApellidoMaterno;

        //            collection[3] = new SqlParameter("@Sexo", SqlDbType.Char);
        //            collection[3].Value = usuario.Sexo;

        //            collection[4] = new SqlParameter("@Correo", SqlDbType.VarChar);
        //            collection[4].Value = usuario.Correo;

        //            collection[5] = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
        //            collection[5].Value = usuario.FechaNacimiento;

        //            collection[6] = new SqlParameter("@IdRol", SqlDbType.VarChar);
        //            collection[6].Value = usuario.Rol.IdRol;

        //            cmd.Parameters.AddRange(collection);
        //            cmd.Connection.Open();

        //            int filasAfectadas = cmd.ExecuteNonQuery();
        //            if (filasAfectadas > 0)
        //            {
        //                result.Correct = true;

        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Error al insertar el usuario";

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;

        //    }

        //    return result;
        //}

        //public static ML.Result EliminarSP(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioDelete";

        //            SqlCommand cmd = new SqlCommand(query, context);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            SqlParameter[] collection = new SqlParameter[1];
        //            collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            collection[0].Value = usuario.IdUsuario;

        //            cmd.Parameters.AddRange(collection);
        //            cmd.Connection.Open();

        //            int filasAfectadas = cmd.ExecuteNonQuery();
        //            if (filasAfectadas > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Error al eliminar el usuario";
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result ActualizarSP(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioUpdate";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            cmd.CommandType = CommandType.StoredProcedure;


        //            SqlParameter[] collection = new SqlParameter[6];
        //            collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            collection[0].Value = usuario.IdUsuario;

        //            collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
        //            collection[1].Value = usuario.Nombre;

        //            collection[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
        //            collection[2].Value = usuario.ApellidoPaterno;

        //            collection[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
        //            collection[3].Value = usuario.ApellidoMaterno;

        //            collection[4] = new SqlParameter("@Correo", SqlDbType.VarChar);
        //            collection[4].Value = usuario.Correo;

        //            collection[5] = new SqlParameter("IdRol", SqlDbType.Int);
        //            collection[5].Value = usuario.Rol.IdRol;

        //            cmd.Parameters.AddRange(collection);
        //            cmd.Connection.Open();

        //            int filasAfectadas = cmd.ExecuteNonQuery();
        //            if (filasAfectadas > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "Error al actualizar el usuario";
        //            }


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result GetAllSP()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioGetAll";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            DataTable tablaUsuario = new DataTable();
        //            adapter.Fill(tablaUsuario);


        //            if (tablaUsuario.Rows.Count > 0)
        //            {
        //                result.Objects = new List<object>();
        //                foreach (DataRow row in tablaUsuario.Rows)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.IdUsuario = int.Parse(row[0].ToString());
        //                    usuario.Nombre = row[1].ToString();
        //                    usuario.ApellidoPaterno = row[2].ToString();
        //                    usuario.ApellidoMaterno = row[3].ToString();
        //                    usuario.Sexo = char.Parse(row[4].ToString());
        //                    usuario.Correo = row[5].ToString();
        //                    usuario.FechaNacimiento = DateTime.Parse(row[6].ToString());
        //                    usuario.Rol = new ML.Rol();
        //                    usuario.Rol.IdRol = int.Parse(row[7].ToString());

        //                    result.Objects.Add(usuario);
        //                }
        //                result.Correct = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result GetByIdSP(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            string query = "UsuarioGetById";
        //            SqlCommand cmd = new SqlCommand(query, context);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            SqlParameter[] collection = new SqlParameter[1];
        //            collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
        //            collection[0].Value = usuario.IdUsuario;

        //            cmd.Parameters.AddRange(collection);

        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //            DataTable tablaUsuario = new DataTable();

        //            adapter.Fill(tablaUsuario);

        //            if (tablaUsuario.Rows.Count > 0)
        //            {
        //                DataRow row = tablaUsuario.Rows[0];
        //                ML.Usuario usuarioResult = new ML.Usuario();
        //                usuarioResult.IdUsuario = int.Parse(row[0].ToString());
        //                usuarioResult.Nombre = row[1].ToString();
        //                usuarioResult.ApellidoPaterno = row[2].ToString();
        //                usuarioResult.ApellidoMaterno = row[3].ToString();
        //                usuarioResult.Sexo = char.Parse(row[4].ToString());
        //                usuarioResult.Correo = row[5].ToString();
        //                usuarioResult.FechaNacimiento = DateTime.Parse(row[6].ToString());
        //                usuarioResult.Rol = new ML.Rol();
        //                usuarioResult.Rol.IdRol = int.Parse(row[7].ToString());



        //                result.Object = usuarioResult;

        //                result.Correct = true;

        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}


        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new
                      DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    ObjectParameter filasAfectadas = new ObjectParameter("FilasAfectadas", typeof(int));
                   
                    var query = context.UsuarioAdd(usuario.Rol.IdRol, usuario.UserName, usuario.Nombre,
                        usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, 
                        usuario.Password, usuario.Sexo.ToString(), usuario.Telefono,
                        usuario.Celular, usuario.FechaNacimiento, usuario.CURP, usuario.Direccion.Calle, 
                        usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, 
                        usuario.Direccion.Colonia.IdColonia, filasAfectadas, usuario.Imagen);
                    if (query == 2)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result DeleteEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new
                    DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    ObjectParameter filasAfectadas = new ObjectParameter("FilasAfectadas", typeof(int));
                    var query = context.usuarioDelete(IdUsuario, filasAfectadas);
                    if (query == 2)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result ActualizarEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new
                    DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    ObjectParameter filasAfectadas = new ObjectParameter("FilasAfectadas", typeof(int));
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Rol.IdRol, 
                        usuario.UserName, usuario.Nombre, usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Telefono, 
                        usuario.Celular, usuario.CURP, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior,
                        usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia, filasAfectadas,
                        usuario.Imagen);
                    if (query == 2)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new
                    DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.UsuarioGetAll(usuario.Nombre, usuario.ApellidoPaterno);   
                    
                    if (query != null)
                    {
                        result.Objects = new List<object>().ToList();
                        foreach (var registro in query)
                        {
                            ML.Usuario usuarioResult = new ML.Usuario();

                            usuarioResult.IdUsuario = registro.IdUsuario;
                            usuarioResult.Rol = new ML.Rol();
                            usuarioResult.Rol.IdRol = registro.IdRol;
                            usuarioResult.UserName = registro.UserName;
                            usuarioResult.Nombre = registro.Nombre;
                            usuarioResult.ApellidoPaterno = registro.ApellidoPaterno;
                            usuarioResult.ApellidoMaterno = registro.ApellidoMaterno;
                            usuarioResult.Email = registro.Email;
                            usuarioResult.Password = registro.Password;
                            usuarioResult.Sexo = registro.Sexo;
                            usuarioResult.Telefono = registro.Telefono;
                            usuarioResult.Celular = registro.Celular;
                            usuarioResult.FechaNacimiento = registro.FechaNacimiento;
                            usuarioResult.CURP = registro.CURP;
                            usuarioResult.Rol.Nombre = registro.NombreRol;
                            usuarioResult.Direccion = new ML.Direccion();
                            usuarioResult.Direccion.IdDireccion = registro.IdDireccion;
                            usuarioResult.Direccion.Calle = registro.Calle;
                            usuarioResult.Direccion.NumeroInterior = registro.NumeroInterior;
                            usuarioResult.Direccion.NumeroExterior = registro.NumeroExterior;
                            usuarioResult.Direccion.Colonia = new ML.Colonia();

                            usuarioResult.Direccion.Colonia.IdColonia = registro.IdColonia;
                            usuarioResult.Direccion.Colonia.Nombre = registro.NombreColonia;

                            usuarioResult.Imagen = registro.Imagen;
                            usuarioResult.Status = registro.Status;




                            result.Objects.Add(usuarioResult);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result UsuarioChangeStatus(int IdUsuario, bool Status)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var rowsAffetted = context.UsuarioChangeStatus(IdUsuario, Status);  

                    if (rowsAffetted > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context =
                    new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.UsuarioGetById(IdUsuario).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Usuario usuarioResult = new ML.Usuario();
                        usuarioResult.IdUsuario = query.IdUsuario;
                        usuarioResult.Rol = new ML.Rol();
                        usuarioResult.Rol.IdRol = query.IdRol;
                        usuarioResult.UserName = query.UserName;
                        usuarioResult.Nombre = query.Nombre;
                        usuarioResult.ApellidoPaterno = query.ApellidoPaterno;
                        usuarioResult.ApellidoMaterno = query.ApellidoMaterno;
                        usuarioResult.Email = query.Email;
                        usuarioResult.Password = query.Password;
                        usuarioResult.Sexo = query.Sexo;
                        usuarioResult.Telefono = query.Telefono;
                        usuarioResult.Celular = query.Celular;
                        usuarioResult.FechaNacimiento = query.FechaNacimiento;
                        usuarioResult.CURP = query.CURP;
                        usuarioResult.Rol.Nombre = query.NombreRol;
                        usuarioResult.Direccion = new ML.Direccion();
                        usuarioResult.Direccion.Colonia = new ML.Colonia();
                        usuarioResult.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuarioResult.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuarioResult.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuarioResult.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais;
                        usuarioResult.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.NombrePais;

                        usuarioResult.Direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado;
                        usuarioResult.Direccion.Colonia.Municipio.Estado.Nombre = query.NombreEstado;

                        usuarioResult.Direccion.Colonia.Municipio.IdMunicipio= query.IdMunicipio;
                        usuarioResult.Direccion.Colonia.Municipio.Nombre = query.NombreMunicipio;

                        usuarioResult.Direccion.Colonia.IdColonia = query.IdColonia;
                        usuarioResult.Direccion.Colonia.Nombre = query.NombreColonia;

                        usuarioResult.Direccion.Calle = query.Calle;
                        usuarioResult.Direccion.NumeroInterior = query.NumeroInterior;

                        usuarioResult.Direccion.NumeroExterior = query.NumeroExterior;
                        usuarioResult.Imagen = query.Imagen;
                       

                      
                        result.Object = usuarioResult;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = true;
                        result.ErrorMessage = "Error al mostrar los datos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        //Validar con getByid
        public static ML.Result ValidarGetById(string email, string password)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.Validar(email).SingleOrDefault();
                    if(query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.Email = query.Email;
                        usuario.Password = query.Password;
                        result.Object = usuario;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static void CargaMasivaTxt()
        {
            string file = @"C:\Users\digis\Documents\Luis Manuel Bastida Lemus\LBastidaProgramacionNCapas - Copy\PL_MVC\files\CargaMasivaTxt.txt";
            if (File.Exists(file))
            {
                StreamReader streamReader = new StreamReader(file);
                string line = streamReader.ReadLine(); //SALTAR HEDEARS

                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] row = line.Split('|');
                    ML.Usuario usuario = new ML.Usuario();
                    usuario.Rol = new ML.Rol();
                    usuario.Direccion = new ML.Direccion();
                    usuario.Direccion.Colonia = new ML.Colonia();

                    usuario.Rol.IdRol = int.Parse(row[0]);
                    usuario.UserName = row[1];
                    usuario.Nombre = row[2];
                    usuario.ApellidoPaterno = row[3];
                    usuario.ApellidoMaterno = row[4];
                    usuario.Email = row[5];
                    usuario.Password = row[6];
                    usuario.Sexo = row[7];
                    usuario.Telefono = row[8];
                    usuario.Celular = row[9];
                    usuario.FechaNacimiento = DateTime.Parse(row[10]);
                    usuario.CURP = row[11];
                    usuario.Direccion.Calle = row[12];
                    usuario.Direccion.NumeroInterior = row[13];
                    usuario.Direccion.NumeroExterior = row[14];
                    usuario.Direccion.Colonia.IdColonia = int.Parse(row[15]);
                    usuario.Imagen = row[16];

                    BL.Usuario.AddEF(usuario);
                }
                Console.WriteLine("Usuario agregado");
            }
        }


        public static ML.Result LeerExcel(string connectionString)
        {
            ML.Result result = new  ML.Result();
            try
            {
                //Se hace la conexion   
                using (OleDbConnection context = new OleDbConnection(connectionString))
                {
                    //SE le pasa la primera hoja del excel
                    string query = "SELECT * FROM [Sheet1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;

                        //SE crea una tabla
                        DataTable tableUsuario = new DataTable();

                        //sE llena el objeto da con la tabla usuario
                        da.Fill(tableUsuario);
                        //El numero de registros de las filas
                        if(tableUsuario.Rows.Count> 0)
                        {
                            result.Objects = new List<object>();

                            //itero en cada fila de la tabla usuario y se lo paso a row
                            foreach(DataRow row in tableUsuario.Rows)
                            {
                                //APesar de algunos ser string como vienen de un formato diferente(excel)
                                //entonces se tiene que convertir a string
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.Rol = new ML.Rol();
                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Colonia = new ML.Colonia();
                                usuario.Rol.IdRol = int.Parse(row[0].ToString());
                                usuario.UserName = row[1].ToString();
                                usuario.Nombre = row[2].ToString();
                                usuario.ApellidoPaterno = row[3].ToString();
                                usuario.ApellidoMaterno = row[4].ToString();
                                usuario.Email = row[5].ToString();
                                usuario.Password = row[6].ToString();
                                usuario.Sexo = row[7].ToString();
                                usuario.Telefono = row[8].ToString();
                                usuario.Celular = row[9].ToString();
                                usuario.FechaNacimiento = DateTime.Parse(row[10].ToString());
                                usuario.CURP = row[11].ToString();
                                usuario.Direccion.Calle = row[12].ToString();
                                usuario.Direccion.NumeroInterior = row[13].ToString();
                                usuario.Direccion.NumeroExterior = row[14].ToString();
                                usuario.Direccion.Colonia.IdColonia = int.Parse(row[15].ToString());
                                usuario.Imagen = row[16].ToString();
                                result.Objects.Add(usuario);
                            }
                            result.Correct = true;
                        }
                        result.Object = tableUsuario;

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en el excel";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }

        public static ML.Result ValidarExcel(List<object> usuarios)
        {
            ML.Result result = new ML.Result();
            try
            {
                result.Objects = new List<object>(); //ALmacenar objetos incompletos
                int i = 1;  //guarda el numero de la fila

                //Aqui se va a iterar en cada registro buscar si faltan campos por llenar(los que sean not nul)
                foreach(ML.Usuario usuario in usuarios)
                {
                    ML.ErrorExcel error = new ML.ErrorExcel();
                    error.IdRegistro = i++;
                    //Si un campo not null esta lleno se le mandara un mensaje
                    usuario.Rol = new ML.Rol();
                    if(usuario.Rol.IdRol.ToString() == "")
                    {
                        error.Mensaje += "Ingrese el id del Rol";
                    }
                    if (usuario.UserName == "")
                    {
                        error.Mensaje += "Ingrese el username";
                    }

                    if (usuario.Nombre == "")
                    {
                        error.Mensaje += "Ingrese el nombre";
                    }

                    if(usuario.ApellidoPaterno == "")
                    {
                        error.Mensaje += "Ingrese el apellido paterno";
                    }
                    if (usuario.ApellidoMaterno == "")
                    {
                        error.Mensaje += "Ingrese el apellido materno";
                    }
                    if (usuario.Email == "")
                    {
                        error.Mensaje += "Ingrese el  email";
                    }
                    if (usuario.Password == "")
                    {
                        error.Mensaje += "Ingrese el password";
                    }
                    if (usuario.Sexo == "")
                    {
                        error.Mensaje += "Ingrese el sexo";
                    }
                    if (usuario.Telefono == "")
                    {
                        error.Mensaje += "Ingrese el telefono";
                    }
                    if (usuario.Celular == "")
                    {
                        error.Mensaje += "Ingrese el celular";
                    }
                    if (usuario.FechaNacimiento.ToString() == "")
                    {
                        error.Mensaje += "Ingrese la fecha de nacimiento";
                    }
                    if (usuario.CURP == "")
                    {
                        error.Mensaje += "Ingrese el curp";
                    }
                    usuario.Direccion = new ML.Direccion();
                    usuario.Direccion.Colonia = new ML.Colonia();
             
                    
                    if(usuario.Direccion.Calle == "")
                    {
                        error.Mensaje += "Ingrese la calle";
                    }
                  
                    if (usuario.Direccion.NumeroExterior == "")
                    {
                        error.Mensaje += "Ingrese el numero exterior";
                    }
                    if (usuario.Direccion.Colonia.IdColonia.ToString()== "")
                    {
                        error.Mensaje += "Ingrese el id de la colonia";
                    }

                    //Si el mensaje si trae algo(errores) entonces se agrega el error a los objetos de result
                    if (error.Mensaje != null)
                    {
                        result.Objects.Add(error);
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        //public static ML.Result AddLINQ(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
        //        {
        //            DLEF.Usuario usuarioResult = new DLEF.Usuario();

        //            usuarioResult.Nombre = usuario.Nombre;
        //            usuarioResult.ApellidoPaterno = usuario.ApellidoPaterno;
        //            usuarioResult.ApellidoMaterno = usuario.ApellidoMaterno;
        //            usuarioResult.Sexo = usuario.Sexo.ToString();

        //            usuarioResult.FechaNacimiento = usuario.FechaNacimiento;

        //            usuarioResult.IdRol = usuario.Rol.IdRol;
        //            context.Usuarios.Add(usuarioResult);
        //            int filasAfectadas = context.SaveChanges();

        //            if (filasAfectadas > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se agrego el usuario";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;

        //    }
        //    return result;

        //}
        //public static ML.Result DeleteLINQ(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
        //        {

        //            var query = (from Usuario in context.Usuarios
        //                         where Usuario.IdUsuario == usuario.IdUsuario
        //                         select Usuario).Single();
        //            context.Usuarios.Remove(query);
        //            int filasAfectadas = context.SaveChanges();

        //            if (filasAfectadas > 0)
        //            {
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //            }


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;

        //    }
        //    return result;
        //}

        //public static ML.Result UpdateLINQ(ML.Usuario usuario)
        //{

        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
        //        {
        //            var query = (from Usuario in context.Usuarios
        //                         where Usuario.IdUsuario == usuario.IdUsuario
        //                         select Usuario).Single();

        //            if (query != null)
        //            {
        //                query.Nombre = usuario.Nombre;
        //                query.ApellidoPaterno = usuario.ApellidoPaterno;
        //                query.ApellidoMaterno = usuario.ApellidoMaterno;
        //                query.Correo = usuario.Correo;
        //                query.Rol.IdRol = usuario.Rol.IdRol;

        //                context.SaveChanges();
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se actualizo el usuario";
        //            }
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;

        //    }
        //    return result;



        //}

        //public static ML.Result GetAllLINQ()
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
        //        {

        //            var query = (from Usuario in context.Usuarios
        //                         join Rol in context.Usuarios on Usuario.IdRol equals Rol.IdRol
        //                         select new
        //                         {
        //                             IdUsuario = Usuario.IdUsuario,
        //                             Nombre = Usuario.Nombre,
        //                             ApellidoPaterno = Usuario.ApellidoPaterno,
        //                             ApellidoMaterno = Usuario.ApellidoMaterno,
        //                             Sexo = Usuario.Sexo,
        //                             Correo = Usuario.Correo,
        //                             FechaNacimiento = Usuario.FechaNacimiento,
        //                             IdRol = Usuario.IdRol,
        //                             Nombrerol = Usuario.Rol.Nombre
        //                         });
        //            result.Objects = new List<object>();

        //            if (query != null && query.ToList().Count > 0)
        //            {
        //                foreach (var obj in query)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.IdUsuario = obj.IdUsuario;
        //                    usuario.Nombre = obj.Nombre;
        //                    usuario.ApellidoPaterno = obj.ApellidoPaterno;
        //                    usuario.ApellidoMaterno = obj.ApellidoMaterno;
        //                    usuario.Sexo = char.Parse(obj.Sexo);
        //                    usuario.Correo = obj.Correo;
        //                    usuario.FechaNacimiento = obj.FechaNacimiento;
        //                    usuario.Rol = new ML.Rol();
        //                    usuario.Rol.IdRol = obj.IdRol;
        //                    usuario.Rol.Nombre = obj.Nombrerol;


        //                    result.Objects.Add(usuario);
        //                }
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = false;
        //                result.ErrorMessage = "No se encontraron registros";
        //            }


        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }
        //    return result;
        //}

        //public static ML.Result GetByIdLINQ(ML.Usuario usuario)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
        //        {

        //            var query = (from Usuario in context.Usuarios
        //                         join Rol in context.Usuarios on Usuario.IdRol equals Rol.IdRol
        //                         where Usuario.IdUsuario == usuario.IdUsuario
        //                         select new
        //                         {
        //                             IdUsuario = Usuario.IdUsuario,
        //                             Nombre = Usuario.Nombre,
        //                             ApellidoPaterno = Usuario.ApellidoPaterno,
        //                             ApellidoMaterno = Usuario.ApellidoMaterno,
        //                             Sexo = Usuario.Sexo,
        //                             Correo = Usuario.Correo,
        //                             FechaNacimiento = Usuario.FechaNacimiento,
        //                             IdRol = Usuario.IdRol,
        //                             Nombrerol = Usuario.Rol.Nombre
        //                         }).SingleOrDefault();


        //            if (query != null)
        //            {
        //                ML.Usuario usuarioResult = new ML.Usuario();
        //                usuarioResult.IdUsuario = query.IdUsuario;
        //                usuarioResult.Nombre = query.Nombre;
        //                usuarioResult.ApellidoPaterno = query.ApellidoPaterno;
        //                usuarioResult.ApellidoMaterno = query.ApellidoPaterno;
        //                usuarioResult.Sexo = char.Parse(query.Sexo.ToString());
        //                usuarioResult.Correo = query.Correo;
        //                usuarioResult.FechaNacimiento = query.FechaNacimiento;
        //                usuarioResult.Rol = new ML.Rol();
        //                usuarioResult.Rol.IdRol = query.IdRol;
        //                usuarioResult.Rol.Nombre = query.Nombrerol;

        //                result.Object = usuarioResult;
        //                result.Correct = true;
        //            }
        //            else
        //            {
        //                result.Correct = true;
        //                result.ErrorMessage = "Error al mostrar los datos";
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}
    }
}