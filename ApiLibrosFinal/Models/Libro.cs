using System;
using System.Collections.Generic;

namespace ApiLibrosFinal.Models
{
    public partial class Libro
    {
        public Libro()
        {
            LibroAutors = new HashSet<LibroAutor>();
            LibroPrestamos = new HashSet<LibroPrestamo>();
        }

        public int IdLibro { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public string? Categoria { get; set; }
        public int? FkIdAutor { get; set; }

        public virtual Autor? FkIdAutorNavigation { get; set; }
        public virtual ICollection<LibroAutor> LibroAutors { get; set; }
        public virtual ICollection<LibroPrestamo> LibroPrestamos { get; set; }
    }
}
