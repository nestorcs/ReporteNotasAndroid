using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNotas.Areas.Api.Models
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupos{ get; set; }
        
    }
}