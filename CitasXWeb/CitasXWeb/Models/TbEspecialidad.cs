using System;
using System.Collections.Generic;

namespace CitasXWeb.Models
{
    public partial class TbEspecialidad
    {
        public TbEspecialidad()
        {
            TbPersonalHospital = new HashSet<TbPersonalHospital>();
        }

        public int EspId { get; set; }
        public string EspNombre { get; set; }

        public ICollection<TbPersonalHospital> TbPersonalHospital { get; set; }
    }
}
