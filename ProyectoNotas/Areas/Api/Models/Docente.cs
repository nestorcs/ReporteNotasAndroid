﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNotas.Areas.Api.Models
{
    public class Docente
    {
        public int DocenteId { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public int ColegioId { get; set; }
        public Colegio Colegios { get; set; }

    }
}