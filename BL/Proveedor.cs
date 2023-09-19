using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proveedor
    {
        public static ML.Result ProveedorGetAll()
        {
            //Este metodo se llamara en el controlador con su respectiva instancia para que pueda mostrarse el form
            //en el decorador get del metodo form
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.ProveedorGetAll();
                    result.Objects = new List<object>().ToList();
                    if(query != null)
                    {
                        foreach(var registro in query)
                        {
                            ML.Proveedor proveedor = new ML.Proveedor();
                            proveedor.IdProveedor = registro.IdProveedor;
                            proveedor.Telefono = registro.Telefono;
                            proveedor.Nombre = registro.Nombre;
                            result.Objects.Add(proveedor);
                        }
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
    }
}
