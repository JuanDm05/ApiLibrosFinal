using System;
using System.Collections.Generic;

namespace ApiLibrosFinal.Models
{
    public partial class TarjetaRfid
    {
        public int IdTarjeta { get; set; }
        public int? FkIdUsuario { get; set; }

        public virtual Usuario? FkIdUsuarioNavigation { get; set; }
    }
}
