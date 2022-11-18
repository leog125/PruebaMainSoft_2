using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaMainSoft_2.Models
{
    public partial class Libro
    {
        public int Is8n { get; set; }
        public int EditorialesId { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string NPaginas { get; set; }

        public virtual Editoriale Editoriales { get; set; }
    }
}
