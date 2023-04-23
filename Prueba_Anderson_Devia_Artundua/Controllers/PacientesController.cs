using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WcfServPaci;

namespace Prueba_Anderson_Devia_Artundua.Controllers
{
    public class PacientesController : Controller
    {
        private prueba_andersonEntities db = new prueba_andersonEntities();  //conexion al servicio

        // GET: Pacientes
        public ActionResult Index()
        {
            return View(db.pacientes.ToList());
        }
       
        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Pacientes/Error_pk/5
        public ActionResult Error_pk(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipo_documento,numero_documento,nombres,apellidos,correo,telefono,fecha_nacimiento,estado_afiliacion")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        db.pacientes.Add(paciente);
                        db.SaveChanges();
                        return RedirectToAction("Index");

                    }
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Error_pk/" + paciente.numero_documento);
                }

            }
                return View(paciente);
            
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipo_documento,numero_documento,nombres,apellidos,correo,telefono,fecha_nacimiento,estado_afiliacion")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            paciente paciente = db.pacientes.Find(id);
            db.pacientes.Remove(paciente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
