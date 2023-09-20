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




      
    }
}
