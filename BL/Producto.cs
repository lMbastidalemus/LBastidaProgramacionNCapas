using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetALL(int idArea)
        {
            ML.Result result = new ML.Result();
            try{
                using(DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var tablaArea = context.ProductoGetByIdArea(idArea);
                    result.Objects = new List<object>();
                    if(tablaArea != null)
                    {
                        foreach(var obj in tablaArea)
                        {
                            ML.Producto productoDatos = new ML.Producto();
                            productoDatos.IdProducto = obj.IdProducto;
                            productoDatos.Nombre = obj.Nombre;
                            productoDatos.PrecioUnitario = obj.PrecioUnitario;
                            productoDatos.Stock = obj.Stock;
                            productoDatos.Descripcion = obj.Descripcion;
                            productoDatos.Imagen = obj.Imagen;
                            productoDatos.Departamento = new ML.Departamento();

                            productoDatos.Departamento.Area = new ML.Area();
                            productoDatos.Departamento.Nombre = obj.NombreDepartamento;
                            productoDatos.Departamento.Area.Nombre = obj.NombreArea;
                            result.Objects.Add(productoDatos);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct=false;
                        result.ErrorMessage = "Error al traer los productos";
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }

        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.AddProducto(producto.Nombre, producto.PrecioUnitario,
                        producto.Stock, producto.Descripcion, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Imagen);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar el producto";
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

        public static ML.Result UpdateEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.UpdateProducto(producto.IdProducto, producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Descripcion,
                        producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Imagen);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar el producto";
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
        public static ML.Result GetALlP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.GetAllProducto();
                    result.Objects = new List<object>().ToList();
                    if(query != null)
                    {
                        ML.Producto producto = new ML.Producto();
                        foreach (var registro in query)
                        {
                            producto.Departamento = new ML.Departamento();
                            producto.Proveedor = new ML.Proveedor();
                            producto.IdProducto = registro.IdProducto;
                            producto.Nombre = registro.NombreProducto;
                            producto.PrecioUnitario = registro.PrecioUnitario;
                            producto.Stock = registro.Stock;
                            producto.Descripcion = registro.Descripcion;
                            producto.Proveedor.IdProveedor = registro.IdProveedor;
                            producto.Proveedor.Telefono = registro.Telefono;
                            producto.Proveedor.Nombre = registro.NombreProveedor;
                            producto.Departamento.IdDepartamento = registro.IdDepartamento;
                            producto.Departamento.Nombre = registro.Nombre;


                            result.Objects.Add(producto);
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


        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.GetByIdProducto(IdProducto).SingleOrDefault();
                  
                    if (query != null)
                    {
                            ML.Producto producto = new ML.Producto();
                            producto.Proveedor = new ML.Proveedor();
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.Area = new ML.Area();
                            producto.IdProducto = query.IdProducto;
                            producto.Nombre = query.NombreProducto;
                            producto.PrecioUnitario = query.PrecioUnitario;
                            producto.Stock = query.Stock;
                            producto.Descripcion = query.Descripcion;
                            producto.Proveedor.IdProveedor = query.IdProveedor;
                            producto.Proveedor.Nombre = query.NombreProveedor;
                            producto.Departamento.IdDepartamento = query.IdDepartamento;
                            producto.Departamento.Nombre = query.Nombre;


                            result.Object = producto;
                        
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
        public static ML.Result DeleteEF(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.DeleteProducto(IdProducto);
                    if (query > 0)
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


      


    }
}
