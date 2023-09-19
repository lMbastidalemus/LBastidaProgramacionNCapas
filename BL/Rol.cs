using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {

        public static ML.Result RolGetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.RolGetAll();
                    result.Objects = new List<object>().ToList();
                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                           ML.Rol rol = new ML.Rol();
                            rol.IdRol = registro.IdRol;
                            rol.Nombre = registro.Nombre;

                            result.Objects.Add(rol);    

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al consultar los datos";
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
