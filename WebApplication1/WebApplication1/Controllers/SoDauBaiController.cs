using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    [Authorize(Roles="admin")]
    public class SoDauBaiController : Controller
    {
        private Entities db = new Entities();

        // GET: /SoDauBai/
        public ActionResult Index()
        {
            return View(db.SoDauBais.ToList());
        }

        // GET: /SoDauBai/Details/5
        [Authorize(Roles="mem")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoDauBai sodaubai = db.SoDauBais.Find(id);
            if (sodaubai == null)
            {
                return HttpNotFound();
            }
            return View(sodaubai);
        }

        // GET: /SoDauBai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SoDauBai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SoDauBai model)
        {
            model.Ngay = DateTime.Now;
            model.GiangVien = User.Identity.Name;
            if(ModelState.IsValid)
            {
                db.SoDauBais.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /SoDauBai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoDauBai sodaubai = db.SoDauBais.Find(id);
            if (sodaubai == null)
            {
                return HttpNotFound();
            }
            return View(sodaubai);
        }

        // POST: /SoDauBai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Ngay,GiangVien,NoiDung,NhanXet,DeXuat")] SoDauBai sodaubai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sodaubai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sodaubai);
        }

        // GET: /SoDauBai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoDauBai sodaubai = db.SoDauBais.Find(id);
            if (sodaubai == null)
            {
                return HttpNotFound();
            }
            return View(sodaubai);
        }

        // POST: /SoDauBai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SoDauBai sodaubai = db.SoDauBais.Find(id);
            db.SoDauBais.Remove(sodaubai);
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
