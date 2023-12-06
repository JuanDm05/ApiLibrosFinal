using System;
using System.Collections.Generic;

namespace ApiLibrosFinal.Models
{
    public partial class LibroAutor
    {
        public int LibroAutorId { get; set; }
        public int? FkIdLibro { get; set; }
        public int? FkIdAutor { get; set; }

        public virtual Autor? FkIdAutorNavigation { get; set; }
        public virtual Libro? FkIdLibroNavigation { get; set; }
    }
}
