using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNotas.Areas.Api.Models;
//http://localhost:7699/Api/AcudienteEstudiantes
namespace ProyectoNotas.Areas.Api.Controllers
{ 
    public class GrupoController : Controller
    {
        private Context3 db = new Context3();

        //
        // GET: /Api/Grupo/



        public List<Grupo> ObtenerGrupos()
        {
            return db.Grupo.ToList();

        }
        public bool EliminarGrupos(int id)
        {
            Grupo Grupo = db.Grupo.Find(id);
            db.Grupo.Remove(Grupo);
            db.SaveChanges();
            return true;

        }
        public Grupo ObtenerGrupo(int id)
        {

            Grupo Grupo = db.Grupo.Find(id);

            return Grupo;
        }
        public bool InsertarGrupos(Grupo Grupo)
        {
            if (ModelState.IsValid)
            {
                db.Grupo.Add(Grupo);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        [HttpGet]
        public JsonResult Grupos()
        {
            return Json(ObtenerGrupos(),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult Grupo(int? id, Grupo item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(InsertarGrupos(item));
                case "PUT":
                //  return Json(ActualizarGrupos(item));
                case "GET":
                    return Json(ObtenerGrupo(id.GetValueOrDefault()),
                                JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(EliminarGrupos(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }

        public ViewResult Index()
        {
            var grupo = db.Grupo.Include(g => g.Colegios);
            return View(grupo.ToList());
        }

        //
        // GET: /Api/Grupo/Details/5

        public ViewResult Details(int id)
        {
            Grupo grupo = db.Grupo.Find(id);
            return View(grupo);
        }

        //
        // GET: /Api/Grupo/Create

        public ActionResult Create()
        {
            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio");
            return View();
        } 

        //
        // POST: /Api/Grupo/Create

        [HttpPost]
        public ActionResult Create(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Grupo.Add(grupo);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio", grupo.ColegioId);
            return View(grupo);
        }
        
        //
        // GET: /Api/Grupo/Edit/5
 
        public ActionResult Edit(int id)
        {
            Grupo grupo = db.Grupo.Find(id);
            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio", grupo.ColegioId);
            return View(grupo);
        }

        //
        // POST: /Api/Grupo/Edit/5

        [HttpPost]
        public ActionResult Edit(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColegioId = new SelectList(db.Colegio, "ColegioId", "NombreColegio", grupo.ColegioId);
            return View(grupo);
        }

        //
        // GET: /Api/Grupo/Delete/5
 
        public ActionResult Delete(int id)
        {
            Grupo grupo = db.Grupo.Find(id);
            return View(grupo);
        }

        //
        // POST: /Api/Grupo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Grupo grupo = db.Grupo.Find(id);
            db.Grupo.Remove(grupo);
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