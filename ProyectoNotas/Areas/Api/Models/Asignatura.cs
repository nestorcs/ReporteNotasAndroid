using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNotas.Areas.Api.Models
{
    public class Asignatura
    {
        public int AsignaturaId { get; set; }
        public String Nombre { get; set; }
        public int Grado { get;set; }
        public int ColegioId { get; set; }
        public Colegio Colegios { get; set; }


    }
}