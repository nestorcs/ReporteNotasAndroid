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
    public class DocenteController : Controller
    {
        private Context3 db = new Context3();

        //
        // GET: /Api/Docente/
        public List<Docente> ObtenerDocentes()
        {
            return db.Docente.ToList();

        }
        public bool EliminarDocentes(int id)
        {
            Docente Docente = db.Docente.Find(id);
            db.Docente.Remove(Docente);
            db.SaveChanges();
            return true;

        }
        public Docente ObtenerDocente(int id)
        {

            Docente Docente = db.Docente.Find(id);

            return Docente;
        }
        public bool InsertarDocentes(Docente Docente)
        {
            if (ModelState.IsValid)
            {
                db.Docente.Add(Docente);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpGet]
        public JsonResult Docentes()
        {
            return Json(ObtenerDocentes(),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult Docente(int? id, Docente item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(InsertarDocentes(item));
                case "PUT":
                //  return Json(ActualizarDocentes(item));
                case "GET":
                    return Json(ObtenerDocente(id.GetValueOrDefault()),
                                JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(EliminarDocentes(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }







        public ViewResult Index()
        {
            var docente = db.Docente.Include(d => d.Colegios);
            return View(docente.ToList());
        }

        //
        // GET: /Api/Docente/Details/5

        public ViewResult Details(int id)
        {
            Docente docente = db.Docente.Find(id);
            return View(docente);
        }

        //
        // GET: /Api/Docente/Create

        public ActionResult Create()
        {
            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio");
            return View();
        } 

        //
        // POST: /Api/Docente/Create

        [HttpPost]
        public ActionResult Create(Docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Docente.Add(docente);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio", docente.ColegioId);
            return View(docente);
        }
        
        //
        // GET: /Api/Docente/Edit/5
 
        public ActionResult Edit(int id)
        {
            Docente docente = db.Docente.Find(id);
            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio", docente.ColegioId);
            return View(docente);
        }

        //
        // POST: /Api/Docente/Edit/5

        [HttpPost]
        public ActionResult Edit(Docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio", docente.ColegioId);
            return View(docente);
        }

        //
        // GET: /Api/Docente/Delete/5
 
        public ActionResult Delete(int id)
        {
            Docente docente = db.Docente.Find(id);
            return View(docente);
        }

        //
        // POST: /Api/Docente/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Docente docente = db.Docente.Find(id);
            db.Docente.Remove(docente);
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