using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Departamento
    {
        public  int IdDepartamento { get; set; }

        [Display(Name = "Nombre Departamento")]

        public string Nombre { get; set; }

        public ML.Area Area { get; set; }
        public ML.Producto Producto { get; set; }
        public List<object> Departamentos { get; set; }
    }
}
