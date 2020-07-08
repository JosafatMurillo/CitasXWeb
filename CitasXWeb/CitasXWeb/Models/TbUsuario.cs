using System;
using System.Collections.Generic;

namespace CitasXWeb.Models
{
    public partial class TbUsuario
    {
        public int UsuId { get; set; }
        public string UsuContrasenia { get; set; }
        public string UsuIdentificador { get; set; }
        public int? UsuRol { get; set; }

        public TbRol UsuRolNavigation { get; set; }
    }
}
