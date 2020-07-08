using System;
using System.Collections.Generic;

namespace CitasXWeb.Models
{
    public partial class TbRol
    {
        public TbRol()
        {
            TbUsuario = new HashSet<TbUsuario>();
        }

        public int RolId { get; set; }
        public string RolNombre { get; set; }

        public ICollection<TbUsuario> TbUsuario { get; set; }
    }
}
