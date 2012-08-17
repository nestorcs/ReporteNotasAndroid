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
    public class AsignaturaController : Controller
    {
        private Context3 db = new Context3();

        //
        // GET: /Api/Asignatura/
        public List<Asignatura> ObtenerAsignaturas()
        {
            return db.Asignatura.ToList();

        }
        public bool EliminarAsignaturas(int id)
        {
            Asignatura Asignatura = db.Asignatura.Find(id);
            db.Asignatura.Remove(Asignatura);
            db.SaveChanges();
            return true;

        }
        public Asignatura ObtenerAsignatura(int id)
        {

            Asignatura Asignatura = db.Asignatura.Find(id);

            return Asignatura;
        }
        public bool InsertarAsignaturas(Asignatura Asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Asignatura.Add(Asignatura);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpGet]
        public JsonResult Asignaturas()
        {
            return Json(ObtenerAsignaturas(),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult Asignatura(int? id, Asignatura item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(InsertarAsignaturas(item));
                case "PUT":
                //  return Json(ActualizarAsignaturas(item));
                case "GET":
                    return Json(ObtenerAsignatura(id.GetValueOrDefault()),
                                JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(EliminarAsignaturas(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }





        public ViewResult Index()
        {
            var asignatura = db.Asignatura.Include(a => a.Colegios);
            return View(asignatura.ToList());
        }

        //
        // GET: /Api/Asignatura/Details/5

        public ViewResult Details(int id)
        {
            Asignatura asignatura = db.Asignatura.Find(id);
            return View(asignatura);
        }

        //
        // GET: /Api/Asignatura/Create

        public ActionResult Create()
        {
            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio");
            return View();
        } 

        //
        // POST: /Api/Asignatura/Create

        [HttpPost]
        public ActionResult Create(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Asignatura.Add(asignatura);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio", asignatura.ColegioId);
            return View(asignatura);
        }
        
        //
        // GET: /Api/Asignatura/Edit/5
 
        public ActionResult Edit(int id)
        {
            Asignatura asignatura = db.Asignatura.Find(id);
            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio", asignatura.ColegioId);
            return View(asignatura);
        }

        //
        // POST: /Api/Asignatura/Edit/5

        [HttpPost]
        public ActionResult Edit(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio", asignatura.ColegioId);
            return View(asignatura);
        }

        //
        // GET: /Api/Asignatura/Delete/5
 
        public ActionResult Delete(int id)
        {
            Asignatura asignatura = db.Asignatura.Find(id);
            return View(asignatura);
        }

        //
        // POST: /Api/Asignatura/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Asignatura asignatura = db.Asignatura.Find(id);
            db.Asignatura.Remove(asignatura);
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