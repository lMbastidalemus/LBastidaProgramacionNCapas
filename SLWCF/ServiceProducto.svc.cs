using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceProducto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceProducto.svc or ServiceProducto.svc.cs at the Solution Explorer and start debugging.
    public class ServiceProducto : IServiceProducto
    {
        public SLWCF.Result Delete(int IDProducto)
        {
            ML.Result result = BL.Producto.DeleteEF(IDProducto);
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
