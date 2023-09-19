using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        
        public ML.Rol Rol { get; set; }
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

   
        [EmailAddress]
        public string Email { get; set; }

       
        public string Password { get; set; }

        [MaxLength(1)]
        public string Sexo { get; set; }

        [StringLength(10, ErrorMessage ="El número es demasiado largo")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage ="solo se permiten numeros")]
        public string Telefono { get; set; }

       
        public string Celular { get; set; }

        [Required]
        [Display(Name ="Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        
        public string CURP{ get; set; }

        public List<object> Usuarios { get; set; }
        public ML.Direccion Direccion { get; set; }

        public string Imagen { get; set;}

        public bool Status { get; set; }
    }
    
}


