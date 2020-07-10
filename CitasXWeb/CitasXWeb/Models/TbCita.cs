using System;
using System.Collections.Generic;

namespace CitasXWeb.Models
{
    public partial class TbCita
    {
        public int CitId { get; set; }
        public string CitCurp { get; set; }
        public string CitNombrePaciente { get; set; }
        public DateTime? CitFecha { get; set; }
        public string CitHora { get; set; }
        public int? CitNumeroPersonalMedico { get; set; }
        public int? CitEstado { get; set; }

        public TbPaciente CitCurpNavigation { get; set; }
        public TbEstado CitEstadoNavigation { get; set; }
        public TbPersonalHospital CitNumeroPersonalMedicoNavigation { get; set; }
    }
}
