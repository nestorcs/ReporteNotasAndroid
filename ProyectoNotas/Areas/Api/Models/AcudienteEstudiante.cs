using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNotas.Areas.Api.Models
{
    public class AcudienteEstudiante
    {
        public int AcudienteEstudianteId { get; set; }
        public int EstudianteId { get; set; }
        public int AcudienteId { get; set; }
        public Estudiante Estudiantes { get; set; }
        public Acudiente Acudientes { get; set; }

    }
}