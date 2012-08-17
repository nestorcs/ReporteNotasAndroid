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
    public class DocenteAsignaturaController : Controller
    {
        private Context3 db = new Context3();

        //
        // GET: /Api/DocenteAsignatura/

        public ViewResult Index()
        {
            var docenteasignatura = db.DocenteAsignatura.Include(d => d.Docentes).Include(d => d.Asignaturas);
            return View(docenteasignatura.ToList());
        }

        //
        // GET: /Api/DocenteAsignatura/Details/5

        public ViewResult Details(int id)
        {
            DocenteAsignatura docenteasignatura = db.DocenteAsignatura.Find(id);
            return View(docenteasignatura);
        }

        //
        // GET: /Api/DocenteAsignatura/Create

        public ActionResult Create()
        {
            ViewBag.DocenteId = new SelectList(db.Docente, "DocenteId", "Nombres");
            ViewBag.AsignaturaId = new SelectList(db.Asignatura, "AsignaturaId", "Nombre");
            return View();
        } 

        //
        // POST: /Api/DocenteAsignatura/Create

        [HttpPost]
        public ActionResult Create(DocenteAsignatura docenteasignatura)
        {
            if (ModelState.IsValid)
            {
                db.DocenteAsignatura.Add(docenteasignatura);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.DocenteId = new SelectList(db.Docente, "DocenteId", "Nombres", docenteasignatura.DocenteId);
            ViewBag.AsignaturaId = new SelectList(db.Asignatura, "AsignaturaId", "Nombre", docenteasignatura.AsignaturaId);
            return View(docenteasignatura);
        }
        
        //
        // GET: /Api/DocenteAsignatura/Edit/5
 
        public ActionResult Edit(int id)
        {
            DocenteAsignatura docenteasignatura = db.DocenteAsignatura.Find(id);
            ViewBag.DocenteId = new SelectList(db.Docente, "DocenteId", "Nombres", docenteasignatura.DocenteId);
            ViewBag.AsignaturaId = new SelectList(db.Asignatura, "AsignaturaId", "Nombre", docenteasignatura.AsignaturaId);
            return View(docenteasignatura);
        }

        //
        // POST: /Api/DocenteAsignatura/Edit/5

        [HttpPost]
        public ActionResult Edit(DocenteAsignatura docenteasignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docenteasignatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocenteId = new SelectList(db.Docente, "DocenteId", "Nombres", docenteasignatura.DocenteId);
            ViewBag.AsignaturaId = new SelectList(db.Asignatura, "AsignaturaId", "Nombre", docenteasignatura.AsignaturaId);
            return View(docenteasignatura);
        }

        //
        // GET: /Api/DocenteAsignatura/Delete/5
 
        public ActionResult Delete(int id)
        {
            DocenteAsignatura docenteasignatura = db.DocenteAsignatura.Find(id);
            return View(docenteasignatura);
        }

        //
        // POST: /Api/DocenteAsignatura/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            DocenteAsignatura docenteasignatura = db.DocenteAsignatura.Find(id);
            db.DocenteAsignatura.Remove(docenteasignatura);
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