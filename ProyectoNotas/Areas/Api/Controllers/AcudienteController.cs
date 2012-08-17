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
    public class AcudienteController : Controller
    {
        private Context3 db = new Context3();

        //
        // GET: /Api/Acudiente/
        public List<Acudiente> ObtenerAcudientes()
        {
            return db.Acudiente.ToList();

        }
        public bool EliminarAcudientes(int id)
        {
            Acudiente Acudiente = db.Acudiente.Find(id);
            db.Acudiente.Remove(Acudiente);
            db.SaveChanges();
            return true;

        }
        public Acudiente ObtenerAcudiente(int id)
        {

            Acudiente Acudiente = db.Acudiente.Find(id);

            return Acudiente;
        }
        public bool InsertarAcudientes(Acudiente Acudiente)
        {
            if (ModelState.IsValid)
            {
                db.Acudiente.Add(Acudiente);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpGet]
        public JsonResult Acudientes()
        {
            return Json(ObtenerAcudientes(),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult Acudiente(int? id, Acudiente item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(InsertarAcudientes(item));
                case "PUT":
                //  return Json(ActualizarAsignaturas(item));
                case "GET":
                    return Json(ObtenerAcudiente(id.GetValueOrDefault()),
                                JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(EliminarAcudientes(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }





        public ViewResult Index()
        {
            var acudiente = db.Acudiente.Include(a => a.Colegios);
            return View(acudiente.ToList());
        }

        //
        // GET: /Api/Acudiente/Details/5

        public ViewResult Details(int id)
        {
            Acudiente acudiente = db.Acudiente.Find(id);
            return View(acudiente);
        }

        //
        // GET: /Api/Acudiente/Create

        public ActionResult Create()
        {
            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio");
            return View();
        } 

        //
        // POST: /Api/Acudiente/Create

        [HttpPost]
        public ActionResult Create(Acudiente acudiente)
        {
            if (ModelState.IsValid)
            {
                db.Acudiente.Add(acudiente);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio", acudiente.ColegioId);
            return View(acudiente);
        }
        
        //
        // GET: /Api/Acudiente/Edit/5
 
        public ActionResult Edit(int id)
        {
            Acudiente acudiente = db.Acudiente.Find(id);
            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio", acudiente.ColegioId);
            return View(acudiente);
        }

        //
        // POST: /Api/Acudiente/Edit/5

        [HttpPost]
        public ActionResult Edit(Acudiente acudiente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acudiente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio", acudiente.ColegioId);
            return View(acudiente);
        }

        //
        // GET: /Api/Acudiente/Delete/5
 
        public ActionResult Delete(int id)
        {
            Acudiente acudiente = db.Acudiente.Find(id);
            return View(acudiente);
        }

        //
        // POST: /Api/Acudiente/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Acudiente acudiente = db.Acudiente.Find(id);
            db.Acudiente.Remove(acudiente);
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