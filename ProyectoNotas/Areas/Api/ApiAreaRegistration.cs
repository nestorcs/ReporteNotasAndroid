using System.Web.Mvc;

namespace ProyectoNotas.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration
    
    {
        public override string AreaName
        {
            get
            {
                return "Api";
            }
        }
   
        public override void RegisterArea(AreaRegistrationContext Context3)
        {
            Context3.MapRoute(
"AccesoColegios",
"Api/Colegios",
new
{
    controller = "Colegio",
    action = "Colegios"
}
);
            Context3.MapRoute(
    "AccesoColegio",
    "Api/Colegios/Colegio/{id}",
    new
    {
        controller = "Colegio",
        action = "Colegio",
        id = UrlParameter.Optional
    }
);








            Context3.MapRoute(
"AccesoDocentes",
"Api/Docentes",
new
{
    controller = "Docente",
    action = "Docentes"
}
);
            Context3.MapRoute(
    "AccesoDocente",
    "Api/Docentes/Docente/{id}",
    new
    {
        controller = "Docente",
        action = "Docente",
        id = UrlParameter.Optional
    }
);








            Context3.MapRoute(
"AccesoAcudientes",
"Api/Acudientes",
new
{
    controller = "Acudiente",
    action = "Acudientes"
}
);
            Context3.MapRoute(
    "AccesoAcudiente",
    "Api/Acudientes/Acudiente/{id}",
    new
    {
        controller = "Acudiente",
        action = "Acudiente",
        id = UrlParameter.Optional
    }
);








            Context3.MapRoute(
"AccesoAsignaturas",
"Api/Asignaturas",
new
{
    controller = "Asignatura",
    action = "Asignaturas"
}
);
            Context3.MapRoute(
    "AccesoAsignatura",
    "Api/Asignaturas/Asignatura/{id}",
    new
    {
        controller = "Asignatura",
        action = "Asignatura",
        id = UrlParameter.Optional
    }
);







            Context3.MapRoute(
"AccesoGrupos",
"Api/Grupos",
new
{
    controller = "Grupo",
    action = "Grupos"
}
);
            Context3.MapRoute(
    "AccesoGrupo",
    "Api/Grupos/Grupo/{id}",
    new
    {
        controller = "Grupo",
        action = "Grupo",
        id = UrlParameter.Optional
    }
);






            Context3.MapRoute(
"AccesoEstudiantes",
"Api/Estudiantes",
new
{
    controller = "Estudiante",
    action = "Estudiantes"
}
);
            Context3.MapRoute(
    "AccesoEstudiante",
    "Api/Estudiantes/Estudiante/{id}",
    new
    {
        controller = "Estudiante",
        action = "Estudiante",
        id = UrlParameter.Optional
    }
);





            Context3.MapRoute(
"AccesoAcudienteEstudiantes",
"Api/AcudienteEstudiantes",
new
{
    controller = "AcudienteEstudiante",
    action = "AcudienteEstudiantes"
}
);
            Context3.MapRoute(
    "AccesoAcudienteEstudiante",
    "Api/AcudienteEstudiantes/AcudienteEstudiante/{id}",
    new
    {
        controller = "AcudienteEstudiante",
        action = "AcudienteEstudiante",
        id = UrlParameter.Optional
    }
);







            Context3.MapRoute(
"AccesoDocenteAsignaturas",
"Api/DocenteAsignaturas",
new
{
    controller = "DocenteAsignatura",
    action = "DocenteAsignaturas"
}
);
            Context3.MapRoute(
    "AccesoDocenteAsignatura",
    "Api/DocenteAsignaturas/DocenteAsignatura/{id}",
    new
    {
        controller = "DocenteAsignatura",
        action = "DocenteAsignatura",
        id = UrlParameter.Optional
    }
);

            
            
            Context3.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }

    }
}
