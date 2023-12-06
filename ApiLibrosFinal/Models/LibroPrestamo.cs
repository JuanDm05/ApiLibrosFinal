using System;
using System.Collections.Generic;

namespace ApiLibrosFinal.Models
{
    public partial class LibroPrestamo
    {
        public int DetallePrestamoId { get; set; }
        public DateTime? FechaApartado { get; set; }
        public string? EstadoLibro { get; set; }
        public int? FkIdPrestamo { get; set; }
        public int? FkIdLibro { get; set; }

        public virtual Libro? FkIdLibroNavigation { get; set; }
        public virtual Prestamo? FkIdPrestamoNavigation { get; set; }
    }
}
