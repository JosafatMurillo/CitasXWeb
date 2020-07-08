using System;
using System.Collections.Generic;

namespace CitasXWeb.Models
{
    public partial class TbPersonalHospital
    {
        public int PerNumeroPersonal { get; set; }
        public string PerNombre { get; set; }
        public string PerSexo { get; set; }
        public string PerCiudad { get; set; }
        public string PerEstado { get; set; }
        public int? PerUsuario { get; set; }
        public int? PerEspecialidad { get; set; }

        public TbPersonalHospital PerNumeroPersonalNavigation { get; set; }
        public TbPersonalHospital InversePerNumeroPersonalNavigation { get; set; }
    }
}
