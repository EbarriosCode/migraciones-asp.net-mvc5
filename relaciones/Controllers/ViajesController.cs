using relaciones.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace relaciones.Controllers
{
    public class ViajesController : Controller
    {
        Contexto db = new Contexto();

        // GET: Viajes
        public ActionResult Index()
        {
            return View(db.Viaje.ToList());
        }

        // GET: Create
        public ActionResult Create()
        {
            var clientes = db.Clientes.ToList();
            SelectList listado = new SelectList(clientes, "IdCliente", "Nombre");
            ViewBag.Clientes = listado;
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "IdCliente,Vendio,Cobro")]Viaje model)
        {
            if(ModelState.IsValid)
            {
                db.Viaje.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            var clientes = db.Clientes.ToList();
            SelectList listado = new SelectList(clientes, "IdCliente", "Nombre");
            ViewBag.Clientes = listado;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Viaje viaje = db.Viaje.Find(id);
            if(viaje == null)
            {
                HttpNotFound();
            }
            return View(viaje);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="IdViaje,IdCliente,Vendio,Cobro")] Viaje model)
        {
            if(ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viaje model = db.Viaje.Find(id);

            if(model==null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viaje model = db.Viaje.Find(id);
            db.Viaje.Remove(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}