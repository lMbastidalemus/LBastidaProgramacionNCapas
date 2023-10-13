using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
       public static ML.Result AddEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.AddDepartamento(departamento.Nombre, departamento.Area.IdArea);
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

        public static ML.Result UpdateEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.UpdateDepartamento(departamento.IdDepartamento, departamento.Nombre, departamento.Area.IdArea );
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

        public static ML.Result GetAllEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.GetAllDepartamento(departamento.Area.IdArea,  departamento.Nombre);
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

        public static ML.Result GetByIdEF(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.GetByIdDepartamento(IdDepartamento).SingleOrDefault();
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

        public static ML.Result DeleteEF(int IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.LBastidaProgramacionNCapasEntities1 context = new DLEF.LBastidaProgramacionNCapasEntities1())
                {
                    var query = context.DeleteDepartamento(IdDepartamento);
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
