//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace America_Virtual.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Localidad
    {
        public System.Guid ORID { get; set; }
        public string CODE { get; set; }
        public string Descripcion { get; set; }
        public string CodigoPostal { get; set; }
        public Nullable<bool> EsLomas { get; set; }
        public Nullable<System.Guid> IdLocalidades { get; set; }
    
        public virtual Localidades Localidades { get; set; }
    }
}
