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
    public class ColegioController : Controller
    {
        private Context3 db = new Context3();

        //
        // GET: /Api/Colegio/
        public List<Colegio> ObtenerColegios()
        {
            return db.Colegio.ToList();

        }
        public bool EliminarColegios(int id)
        {
            Colegio colegio = db.Colegio.Find(id);
            db.Colegio.Remove(colegio);
            db.SaveChanges();
            return true;

        }
        public Colegio ObtenerColegio(int id)
        {

           Colegio colegio = db.Colegio.Find(id);

            return colegio;
        }
        public bool InsertarColegios(Colegio colegio)
        {
            if (ModelState.IsValid)
            {
                db.Colegio.Add(colegio);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpGet]
        public JsonResult Colegios()
        {
            return Json(ObtenerColegios(),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult Colegio(int? id, Colegio item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(InsertarColegios(item));
                case "PUT":
                  //  return Json(ActualizarColegios(item));
                case "GET":
                   return Json(ObtenerColegio(id.GetValueOrDefault()),
                               JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(EliminarColegios(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }
        public ViewResult Index()
        {
            return View(db.Colegio.ToList());
        }

        //
        // GET: /Api/Colegio/Details/5

        public ViewResult Details(int id)
        {
            Colegio colegio = db.Colegio.Find(id);
            return View(colegio);
        }

        //
        // GET: /Api/Colegio/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Api/Colegio/Create

        [HttpPost]
        public ActionResult Create(Colegio colegio)
        {
            if (ModelState.IsValid)
            {
                db.Colegio.Add(colegio);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(colegio);
        }
        
        //
        // GET: /Api/Colegio/Edit/5
 
        public ActionResult Edit(int id)
        {
            Colegio colegio = db.Colegio.Find(id);
            return View(colegio);
        }

        //
        // POST: /Api/Colegio/Edit/5

        [HttpPost]
        public ActionResult Edit(Colegio colegio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colegio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colegio);
        }

        //
        // GET: /Api/Colegio/Delete/5
 
        public ActionResult Delete(int id)
        {
            Colegio colegio = db.Colegio.Find(id);
            return View(colegio);
        }

        //
        // POST: /Api/Colegio/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Colegio colegio = db.Colegio.Find(id);
            db.Colegio.Remove(colegio);
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