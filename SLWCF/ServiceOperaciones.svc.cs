using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceOperaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceOperaciones.svc or ServiceOperaciones.svc.cs at the Solution Explorer and start debugging.
    public class ServiceOperaciones : IServiceOperaciones
    {
        public void DoWork()
        {
        }

        public int Sumar(int a, int b)
        {
            return a + b;
        }

        public int Multiplicacion(int a, int b)
        {
            return (a * b);
        }

        public float Division(float a, float b)
        {
            return a / b;
        }

        public int Resta(int a, int b)
        {
            return a - b;
        }

        public static ML.Result Add(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.DepartamentoAddEF(departamento);
            return result;
        }
    }
}
