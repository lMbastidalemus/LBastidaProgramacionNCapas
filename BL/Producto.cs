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
                    var tablaArea = context.ProductoGetByIdArea(idArea).ToList();
                    result.Objects = new List<object>();
                    if(tablaArea != null)
                    {
                        foreach(var obj in tablaArea)
                        {
                            ML.Producto producto = new ML.Producto();   
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.PrecioUnitario = obj.PrecioUnitario;
                            producto.Stock = obj.Stock;
                            producto.Descripcion = obj.Descripcion;
                            producto.Imagen = obj.Imagen;
                            producto.Departamento = new ML.Departamento();
                            
                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Nombre = obj.NombreDepartamento;
                            producto.Departamento.Area.Nombre = obj.NombreArea;
                            result.Objects.Add(producto);

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
    }
}
