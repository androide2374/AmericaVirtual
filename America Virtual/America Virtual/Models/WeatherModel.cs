using America_Virtual.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace America_Virtual.Models
{
    public class HomeModel
    {
        public Buscador Buscador { get; set; }
        public ResultViewModel ResultViewModel { get; set; }
    }
    public class Buscador
    {
        public Guid IdProvincia { get; set; }
        public string NombreLocalidad { get; set; }
        public string NombreProvincia { get; set; }
        public Localidades Localidad { get; set; }
        public List<Provincia> Provincias { get; set; }
        public List<Localidades> Localidades { get; set; }
    }
}