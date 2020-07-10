using System;
using System.Collections.Generic;

namespace CitasXWeb.Models
{
    public partial class TbSeguroSocial
    {
        public TbSeguroSocial()
        {
            TbPaciente = new HashSet<TbPaciente>();
        }

        public int SegId { get; set; }
        public string SegNombre { get; set; }

        public ICollection<TbPaciente> TbPaciente { get; set; }
    }
}
