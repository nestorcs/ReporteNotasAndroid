using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNotas.Areas.Api.Models
{
    public class Colegio
    {
        public int ColegioId { get; set; }
        public String NombreColegio { get; set; }
      // public virtual ICollection<Docente> Docentes { get; set; }
        //public virtual ICollection<Grupo> Grupos { get; set; }
        //public virtual ICollection<Acudiente> Acudientes { get; set; }
    }
}