//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prueva_anderson_devia_art.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pacientes
    {
        public int tipo_documento { get; set; }
        public Nullable<int> numero_documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public Nullable<int> telefono { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public string estado_afiliacion { get; set; }
    }
}
