using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result ColoniaGetByIdMunicipio(int IdMunicipio)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.ColoniaGetByIdMunicipio(IdMunicipio);
                    result.Objects = new List<object>().ToList();
                    if (query != null)
                    {
                        
                        foreach(var registro in query)
                        {
                            ML.Colonia colonia = new ML.Colonia(registro.IdColonia, registro.Nombre, registro.CodigoPostal);  
                            result.Objects.Add(colonia);    
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al mostrar las colonias";
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
