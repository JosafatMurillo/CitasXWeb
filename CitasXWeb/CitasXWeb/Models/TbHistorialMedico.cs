using System;
using System.Collections.Generic;

namespace CitasXWeb.Models
{
    public partial class TbHistorialMedico
    {
        public int HisId { get; set; }
        public string HisPaciente { get; set; }
        public int? HisMedico { get; set; }
        public double? HisPeso { get; set; }
        public double? HisPresionArterial { get; set; }
        public string HisSintoma { get; set; }
        public string HisEvaluacion { get; set; }
        public string HisMedicamento { get; set; }
        public DateTime? HisFecha { get; set; }

        public TbPersonalHospital HisMedicoNavigation { get; set; }
        public TbPaciente HisPacienteNavigation { get; set; }
    }
}
