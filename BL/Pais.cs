using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result PaisGetAll()
        {
          ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.PaisGetAll();
                    result.Objects = new List<object>().ToList();
                    if(query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Pais pais = new ML.Pais(registro.IdPais, registro.Nombre);
                            result.Objects.Add(pais);
                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al mostrar los paises";
                    }

                }
               
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
