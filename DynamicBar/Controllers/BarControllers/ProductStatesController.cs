﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DynamicBar.Models;
using DynamicBar.Models.DBEntities;

namespace DynamicBar.Controllers.BarControllers
{
    public class ProductStatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductStates
        public ActionResult Index()
        {
            var productStates = db.ProductStates.Include(p => p.CreatedBy);
            return View(productStates.ToList());
        }

        // GET: ProductStates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductState productState = db.ProductStates.Find(id);
            if (productState == null)
            {
                return HttpNotFound();
            }
            return View(productState);
        }

        // GET: ProductStates/Create
        public ActionResult Create()
        {
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: ProductStates/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductStateId,Title,Description,DateCreated,CreatedById")] ProductState productState)
        {
            if (ModelState.IsValid)
            {
                db.ProductStates.Add(productState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Email", productState.CreatedById);
            return View(productState);
        }

        // GET: ProductStates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductState productState = db.ProductStates.Find(id);
            if (productState == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Email", productState.CreatedById);
            return View(productState);
        }

        // POST: ProductStates/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductStateId,Title,Description,DateCreated,CreatedById")] ProductState productState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatedById = new SelectList(db.Users, "Id", "Email", productState.CreatedById);
            return View(productState);
        }

        // GET: ProductStates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductState productState = db.ProductStates.Find(id);
            if (productState == null)
            {
                return HttpNotFound();
            }
            return View(productState);
        }

        // POST: ProductStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductState productState = db.ProductStates.Find(id);
            db.ProductStates.Remove(productState);
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
