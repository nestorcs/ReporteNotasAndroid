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
    public class AcudienteEstudianteController : Controller
    {
        private Context3 db = new Context3();

        //
        // GET: /Api/AcudienteEstudiante/
        public List<AcudienteEstudiante> ObtenerAcudienteEstudiantes()
        {
            return db.AcudienteEstudiante.ToList();

        }
        public bool EliminarAcudienteEstudiantes(int id)
        {
            AcudienteEstudiante AcudienteEstudiante = db.AcudienteEstudiante.Find(id);
            db.AcudienteEstudiante.Remove(AcudienteEstudiante);
            db.SaveChanges();
            return true;

        }
        public AcudienteEstudiante ObtenerAcudienteEstudiante(int id)
        {

            AcudienteEstudiante AcudienteEstudiante = db.AcudienteEstudiante.Find(id);

            return AcudienteEstudiante;
        }
        public bool InsertarAcudienteEstudiantes(AcudienteEstudiante AcudienteEstudiante)
        {
            if (ModelState.IsValid)
            {
                db.AcudienteEstudiante.Add(AcudienteEstudiante);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpGet]
        public JsonResult AcudienteEstudiantes()
        {
            return Json(ObtenerAcudienteEstudiantes(),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult AcudienteEstudiante(int? id, AcudienteEstudiante item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(InsertarAcudienteEstudiantes(item));
                case "PUT":
                //  return Json(ActualizarAcudienteEstudiantes(item));
                case "GET":
                    return Json(ObtenerAcudienteEstudiante(id.GetValueOrDefault()),
                                JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(EliminarAcudienteEstudiantes(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }
        public ViewResult Index()
        {
            var acudienteestudiante = db.AcudienteEstudiante.Include(a => a.Estudiantes).Include(a => a.Acudientes);
            return View(acudienteestudiante.ToList());
        }

        //
        // GET: /Api/AcudienteEstudiante/Details/5

        public ViewResult Details(int id)
        {
            AcudienteEstudiante acudienteestudiante = db.AcudienteEstudiante.Find(id);
            return View(acudienteestudiante);
        }

        //
        // GET: /Api/AcudienteEstudiante/Create

        public ActionResult Create()
        {
            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Nombres");
            ViewBag.AcudienteId = new SelectList(db.Acudiente, "AcudienteId", "Nombres");
            return View();
        } 

        //
        // POST: /Api/AcudienteEstudiante/Create

        [HttpPost]
        public ActionResult Create(AcudienteEstudiante acudienteestudiante)
        {
            if (ModelState.IsValid)
            {
                db.AcudienteEstudiante.Add(acudienteestudiante);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Nombres", acudienteestudiante.EstudianteId);
            ViewBag.AcudienteId = new SelectList(db.Acudiente, "AcudienteId", "Nombres", acudienteestudiante.AcudienteId);
            return View(acudienteestudiante);
        }
        
        //
        // GET: /Api/AcudienteEstudiante/Edit/5
 
        public ActionResult Edit(int id)
        {
            AcudienteEstudiante acudienteestudiante = db.AcudienteEstudiante.Find(id);
            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Nombres", acudienteestudiante.EstudianteId);
            ViewBag.AcudienteId = new SelectList(db.Acudiente, "AcudienteId", "Nombres", acudienteestudiante.AcudienteId);
            return View(acudienteestudiante);
        }

        //
        // POST: /Api/AcudienteEstudiante/Edit/5

        [HttpPost]
        public ActionResult Edit(AcudienteEstudiante acudienteestudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acudienteestudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstudianteId = new SelectList(db.Estudiante, "EstudianteId", "Nombres", acudienteestudiante.EstudianteId);
            ViewBag.AcudienteId = new SelectList(db.Acudiente, "AcudienteId", "Nombres", acudienteestudiante.AcudienteId);
            return View(acudienteestudiante);
        }

        //
        // GET: /Api/AcudienteEstudiante/Delete/5
 
        public ActionResult Delete(int id)
        {
            AcudienteEstudiante acudienteestudiante = db.AcudienteEstudiante.Find(id);
            return View(acudienteestudiante);
        }

        //
        // POST: /Api/AcudienteEstudiante/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            AcudienteEstudiante acudienteestudiante = db.AcudienteEstudiante.Find(id);
            db.AcudienteEstudiante.Remove(acudienteestudiante);
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