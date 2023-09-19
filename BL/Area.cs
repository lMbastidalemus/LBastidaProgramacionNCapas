using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Area
    {
        public static ML.Result AreaGetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.AreaGetAll();
                    result.Objects = new List<object>().ToList();
                    if (query != null)
                    {
                       
                        foreach(var registro in query)
                        {
                            ML.Area area = new ML.Area();
                            area.IdArea= registro.IdArea;
                            area.Nombre = registro.Nombre;
                            result.Objects.Add(area);   
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
    }
}
