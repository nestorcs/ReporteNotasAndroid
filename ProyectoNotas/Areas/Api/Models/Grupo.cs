using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNotas.Areas.Api.Models
{
    public class Grupo
    {
        public int GrupoId { get; set; }
        public int Grado { get; set; }
        public String Numero { get; set; }
        public int ColegioId { get; set; }
        public Colegio Colegios { get; set; }
       // public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}