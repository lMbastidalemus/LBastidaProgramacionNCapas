using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceDepartamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceDepartamento.svc or ServiceDepartamento.svc.cs at the Solution Explorer and start debugging.
    public class ServiceDepartamento : IServiceDepartamento
    {
        public SLWCF.Result Add(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.AddEF(departamento);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects,
            };
        }

        public SLWCF.Result Delete(int idDepartamento)
        {
            ML.Result result = BL.Departamento.DeleteEF(idDepartamento);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects,

            };
        }

        public SLWCF.Result Update(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.UpdateEF(departamento);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects,

            };
        }

        public SLWCF.Result GetAll(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.GetAllEF(departamento);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects,

            };
        }

        public SLWCF.Result GetById(int idDepartamento)
        {
            ML.Result result = BL.Departamento.GetByIdEF(idDepartamento);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects,

            };
        }


    }
}
