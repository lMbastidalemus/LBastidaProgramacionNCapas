﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceProducto" in both code and config file together.
    [ServiceContract]
    public interface IServiceProducto
    {
        [OperationContract]
        SLWCF.Result Delete(int IdProducto);
    }
}
