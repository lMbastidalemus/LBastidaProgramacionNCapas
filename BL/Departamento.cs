using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
       public static ML.Result DepartamentoAddEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.departamentoAdd(departamento.Nombre, departamento.Area.IdArea,
                        departamento.Producto.Nombre, departamento.Producto.PrecioUnitario,
                        departamento.Producto.Stock,departamento.Producto.Descripcion, departamento.Producto.Proveedor.IdProveedor,
                        departamento.Producto.Imagen);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar el usuario";
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

        public static ML.Result DepartamentoUpdateEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.departamentoUpdate(departamento.IdDepartamento, departamento.Nombre, departamento.Area.IdArea, departamento.Producto.Nombre, departamento.Producto.PrecioUnitario, 
                        departamento.Producto.Stock, departamento.Producto.Descripcion, departamento.Producto.Proveedor.IdProveedor, departamento.Producto.Imagen);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar el usuario";
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

        public static ML.Result DepartamentoGetAllEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.DepartamentoGetAll(departamento.Area.IdArea,  departamento.Nombre);
                    result.Objects = new List<object>().ToList();
                    if(query != null)
                    {
                        
                        foreach (var registro in query)
                        {
                           
                            ML.Departamento departamentoResult = new ML.Departamento();
                            departamentoResult.IdDepartamento = registro.IdDepartamento;
                            departamentoResult.Nombre = registro.Nombre;
                            departamentoResult.Area = new ML.Area();
                            departamentoResult.Area.IdArea = registro.IdArea;
                            departamentoResult.Area.Nombre = registro.NombreArea;
                            departamentoResult.Producto = new ML.Producto();
                            departamentoResult.Producto.IdProducto = registro.IdProducto;
                            departamentoResult.Producto.Nombre = registro.NombreProducto;
                            departamentoResult.Producto.PrecioUnitario = registro.PrecioUnitario;
                            departamentoResult.Producto.Stock = registro.Stock;
                            departamentoResult.Producto.Descripcion = registro.Descripcion;
                            departamentoResult.Producto.Imagen = registro.Imagen;
                            departamentoResult.Producto.Proveedor = new ML.Proveedor();
                            departamentoResult.Producto.Proveedor.IdProveedor = registro.IdProveedor;
                            departamentoResult.Producto.Proveedor.Telefono = registro.Telefono;
                            departamentoResult.Producto.Proveedor.Nombre = registro.NombreProveedor;
                            result.Objects.Add(departamentoResult);   
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

        public static ML.Result DepartamentoGetByIdEF(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.DepartamentoGetById(IdDepartamento).SingleOrDefault();
                    if(query != null)
                    {
                        ML.Departamento departamentoResult = new ML.Departamento();
                        departamentoResult.IdDepartamento = query.IdDepartamento;
                        departamentoResult.Nombre = query.Nombre;
                        departamentoResult.Area = new ML.Area();
                        departamentoResult.Producto = new ML.Producto();
                        departamentoResult.Producto.Proveedor = new ML.Proveedor();
                        departamentoResult.Area.IdArea = query.IdArea;
                        departamentoResult.Area.Nombre = query.NombreArea;
                        departamentoResult.Producto.Nombre = query.NombreProducto;
                        departamentoResult.Producto.PrecioUnitario = query.PrecioUnitario;
                        departamentoResult.Producto.Stock = query.Stock;
                        departamentoResult.Producto.Descripcion = query.Descripcion;
                        departamentoResult.Producto.Proveedor.IdProveedor = query.IdProveedor;
                        departamentoResult.Producto.Imagen = query.Imagen;
                        result.Object = departamentoResult;
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

        public static ML.Result DepartamentoDeleteEF(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.departamentoDelete(IdDepartamento);
                    if(query >0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar el departamento";
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
    }
}
