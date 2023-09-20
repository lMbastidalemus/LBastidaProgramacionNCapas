using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceOperaciones" in both code and config file together.
    [ServiceContract]
    public interface IServiceOperaciones
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        int Sumar(int a, int b);

        [OperationContract]
        int Multiplicacion(int a, int b);

        [OperationContract]
        float Division(float a, float b);

        [OperationContract]
        int Resta(int a, int b);

       
    }
}
