using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceDepartamento" in both code and config file together.
    [ServiceContract]
    public interface IServiceDepartamento
    {
        [OperationContract]
        SLWCF.Result Add(ML.Departamento departamento);

        [OperationContract]
        SLWCF.Result Delete(int idDepartamento);

        [OperationContract]
        SLWCF.Result Update(ML.Departamento departamento);
    }
}
