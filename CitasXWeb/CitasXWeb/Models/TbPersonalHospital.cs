using System;
using System.Collections.Generic;

namespace CitasXWeb.Models
{
    public partial class TbPersonalHospital
    {
        public TbPersonalHospital()
        {
            TbCita = new HashSet<TbCita>();
            TbHistorialMedico = new HashSet<TbHistorialMedico>();
        }

        public int PerNumeroPersonal { get; set; }
        public string PerNombre { get; set; }
        public string PerSexo { get; set; }
        public string PerCiudad { get; set; }
        public string PerEstado { get; set; }
        public int? PerUsuario { get; set; }
        public int? PerEspecialidad { get; set; }

        public TbEspecialidad PerEspecialidadNavigation { get; set; }
        public TbUsuario PerUsuarioNavigation { get; set; }
        public ICollection<TbCita> TbCita { get; set; }
        public ICollection<TbHistorialMedico> TbHistorialMedico { get; set; }
    }
}
