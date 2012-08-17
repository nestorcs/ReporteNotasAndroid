using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNotas.Areas.Api.Models;

namespace ProyectoNotas.Areas.Api.Controllers
{ 
    public class EstudianteController : Controller
    {
        private Context3 db = new Context3();

        //
        // GET: /Api/Estudiante/
        public List<Estudiante> ObtenerEstudiantes()
        {
            return db.Estudiante.ToList();

        }
        public bool EliminarEstudiantes(int id)
        {
            Estudiante Estudiante = db.Estudiante.Find(id);
            db.Estudiante.Remove(Estudiante);
            db.SaveChanges();
            return true;

        }
        public Estudiante ObtenerEstudiante(int id)
        {

            Estudiante Estudiante = db.Estudiante.Find(id);

            return Estudiante;
        }
        public bool InsertarEstudiantes(Estudiante Estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Estudiante.Add(Estudiante);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpGet]
        public JsonResult Estudiantes()
        {
            return Json(ObtenerEstudiantes(),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult Estudiante(int? id, Estudiante item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(InsertarEstudiantes(item));
                case "PUT":
                //  return Json(ActualizarEstudiantes(item));
                case "GET":
                    return Json(ObtenerEstudiante(id.GetValueOrDefault()),
                                JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(EliminarEstudiantes(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }
        public ViewResult Index()
        {
            var estudiante = db.Estudiante.Include(e => e.Grupos);
            return View(estudiante.ToList());
        }

        //
        // GET: /Api/Estudiante/Details/5

        public ViewResult Details(int id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            return View(estudiante);
        }

        //
        // GET: /Api/Estudiante/Create

        public ActionResult Create()
        {
            ViewBag.GrupoId = new SelectList(db.Grupo, "GrupoId", "Numero");
            return View();
        } 

        //
        // POST: /Api/Estudiante/Create

        [HttpPost]
        public ActionResult Create(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Estudiante.Add(estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.GrupoId = new SelectList(db.Grupo, "GrupoId", "Numero", estudiante.GrupoId);
            return View(estudiante);
        }
        
        //
        // GET: /Api/Estudiante/Edit/5
 
        public ActionResult Edit(int id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            ViewBag.GrupoId = new SelectList(db.Grupo, "GrupoId", "Numero", estudiante.GrupoId);
            return View(estudiante);
        }

        //
        // POST: /Api/Estudiante/Edit/5

        [HttpPost]
        public ActionResult Edit(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupoId = new SelectList(db.Grupo, "GrupoId", "Numero", estudiante.GrupoId);
            return View(estudiante);
        }

        //
        // GET: /Api/Estudiante/Delete/5
 
        public ActionResult Delete(int id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            return View(estudiante);
        }

        //
        // POST: /Api/Estudiante/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Estudiante estudiante = db.Estudiante.Find(id);
            db.Estudiante.Remove(estudiante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}