using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace America_Virtual.Models
{

    public class UsuarioModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Debes ingresar el Usuario")]
        [Display(Name = "Usuario")]
        public string Usuario1 { get; set; }
        [Required(ErrorMessage = "Debes ingresar la Contraseña")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}