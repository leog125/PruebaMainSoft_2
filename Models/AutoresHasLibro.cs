using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaMainSoft_2.Models
{
    public partial class AutoresHasLibro
    {
        public int AutoresId { get; set; }
        public int LibrosIs8n { get; set; }

        public virtual Autore Autores { get; set; }
        public virtual Libro LibrosIs8nNavigation { get; set; }
    }
}
