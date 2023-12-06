using System;
using System.Collections.Generic;

namespace ApiLibrosFinal.Models
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            LibroPrestamos = new HashSet<LibroPrestamo>();
        }

        public int IdPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string? EstadoLibro { get; set; }
        public DateTime? FechaApartado { get; set; }
        public int? FkIdUsuario { get; set; }

        public virtual Usuario? FkIdUsuarioNavigation { get; set; }
        public virtual ICollection<LibroPrestamo> LibroPrestamos { get; set; }
    }
}
