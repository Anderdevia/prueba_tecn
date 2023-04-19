using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prueva_anderson_devia_art.Models;

namespace prueva_anderson_devia_art.Controllers
{
    public class pacientesController : Controller
    {
        private prueba_andersonEntities db = new prueba_andersonEntities();

        // GET: pacientes
        public ActionResult Index()
        {
            return View(db.pacientes.ToList());
        }

        // GET: pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pacientes pacientes = db.pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }
        // GET: pacientes/Details/5
        public ActionResult Error_pk(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pacientes pacientes = db.pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // GET: pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pacientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipo_documento,numero_documento,nombres,apellidos,correo,telefono,fecha_nacimiento,estado_afiliacion")] pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.pacientes.Add(pacientes);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return RedirectToAction("Error_pk/"+pacientes.numero_documento);
                }
                   
                return RedirectToAction("Index");
            }

            return View(pacientes);
        }

        // GET: pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pacientes pacientes = db.pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // POST: pacientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tipo_documento,numero_documento,nombres,apellidos,correo,telefono,fecha_nacimiento,estado_afiliacion")] pacientes pacientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pacientes);
        }

        // GET: pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pacientes pacientes = db.pacientes.Find(id);
            if (pacientes == null)
            {
                return HttpNotFound();
            }
            return View(pacientes);
        }

        // POST: pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pacientes pacientes = db.pacientes.Find(id);
            db.pacientes.Remove(pacientes);
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
