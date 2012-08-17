using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
namespace ProyectoNotas.Areas.Api.Models
{
    public class Context3 : DbContext
    {

       
        public DbSet<Colegio> Colegio { get; set; }

        public DbSet<Docente> Docente { get; set; }

        public DbSet<Acudiente> Acudiente { get; set; }

        public DbSet<Grupo> Grupo { get; set; }

        public DbSet<Asignatura> Asignatura { get; set; }

        public DbSet<Estudiante> Estudiante { get; set; }

        public DbSet<AcudienteEstudiante> AcudienteEstudiante { get; set; }

        public DbSet<DocenteAsignatura> DocenteAsignatura { get; set; }



    }


}