using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
        [Display(Name = "Nombre Producto")]
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }

        public int Stock { get; set; }
        public string Descripcion { get; set; }

        public ML.Proveedor Proveedor { get; set; }
        //Para las vistas de las areas y productos
        public ML.Departamento Departamento { get; set; }
     

        public List<object> Productos { get; set; } 

        public string Imagen { get; set; }
    }
}
