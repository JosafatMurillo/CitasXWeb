using System;
using System.Collections.Generic;

namespace CitasXWeb.Models
{
    public partial class TbPaciente
    {
        public TbPaciente()
        {
            TbCita = new HashSet<TbCita>();
            TbHistorialMedico = new HashSet<TbHistorialMedico>();
        }

        public string PacCurp { get; set; }
        public string PacNombre { get; set; }
        public DateTime? PacFechaNacimiento { get; set; }
        public string PacCiudad { get; set; }
        public string PacEstado { get; set; }
        public string PacSexo { get; set; }
        public string PacDomicilio { get; set; }
        public int? PacCodigoPostal { get; set; }
        public int? PacTelefonoFijo { get; set; }
        public int? PacTelefonoPersonal { get; set; }
        public int? PacNumeroSeguroSocial { get; set; }
        public int? PacTipoSeguro { get; set; }
        public int? PacUsuario { get; set; }

        public TbSeguroSocial PacTipoSeguroNavigation { get; set; }
        public TbUsuario PacUsuarioNavigation { get; set; }
        public ICollection<TbCita> TbCita { get; set; }
        public ICollection<TbHistorialMedico> TbHistorialMedico { get; set; }
    }
}
