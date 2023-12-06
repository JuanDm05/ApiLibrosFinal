using System;
using System.Collections.Generic;

namespace ApiLibrosFinal.Models
{
    public partial class Autor
    {
        public Autor()
        {
            //LibroAutors = new HashSet<LibroAutor>();
        }

        public int IdAutor { get; set; }
        public string? Nombre { get; set; }
        public string? Pais { get; set; }
        public string? Apellidos { get; set; }

        //public virtual ICollection<LibroAutor> LibroAutors { get; set; }
    }
}
