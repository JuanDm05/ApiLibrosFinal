using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


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
        [JsonIgnore]

        public int? FkIdAutor { get; set; }
        [JsonIgnore]

        public virtual Autor? FkIdAutorNavigation { get; set; }
        [JsonIgnore]

        public virtual ICollection<LibroAutor> LibroAutors { get; set; }
        [JsonIgnore]

        public virtual ICollection<LibroPrestamo> LibroPrestamos { get; set; }



    }
}
