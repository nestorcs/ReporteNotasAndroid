using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNotas.Areas.Api.Models
{
    public class DocenteAsignatura
    {
        public int DocenteAsignaturaId { get; set; }
        public int DocenteId { get; set; }
        public int AsignaturaId { get; set; }
        public Docente Docentes { get; set; }
        public Asignatura Asignaturas { get; set; }
    }
}