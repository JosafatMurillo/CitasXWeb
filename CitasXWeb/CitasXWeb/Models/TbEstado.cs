using System;
using System.Collections.Generic;

namespace CitasXWeb.Models
{
    public partial class TbEstado
    {
        public TbEstado()
        {
            TbCita = new HashSet<TbCita>();
        }

        public int EstId { get; set; }
        public string EstNombre { get; set; }

        public ICollection<TbCita> TbCita { get; set; }
    }
}
