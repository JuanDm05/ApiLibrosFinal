using System;
using System.Collections.Generic;

namespace ApiLibrosFinal.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Prestamos = new HashSet<Prestamo>();
            TarjetaRfids = new HashSet<TarjetaRfid>();
        }

        public int IdUsuario { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
        public virtual ICollection<TarjetaRfid> TarjetaRfids { get; set; }
    }
}
