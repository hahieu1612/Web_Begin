using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASM.Model;

namespace ASM.Controllers
{
    public class ideasController : Controller
    {
        private blog_wedEntities1 db = new blog_wedEntities1();

        // GET: ideas
        public ActionResult Index()
        {
            var ideas = db.ideas.Include(i => i.account).Include(i => i.topic);
            return View(ideas.ToList());
        }

        // GET: ideas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idea idea = db.ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // GET: ideas/Create
        public ActionResult Create()
        {
            ViewBag.id_account = new SelectList(db.accounts, "id_account", "name");
            ViewBag.id_toppic = new SelectList(db.topics, "id_toppic", "name_topic");
            return View();
        }

        // POST: ideas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_ideas,id_account,thumb_up,thumb_down,views,ideas_date,Content,id_toppic")] idea idea)
        {
            if (ModelState.IsValid)
            {
                db.ideas.Add(idea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_account = new SelectList(db.accounts, "id_account", "name", idea.id_account);
            ViewBag.id_toppic = new SelectList(db.topics, "id_toppic", "name_topic", idea.id_toppic);
            return View(idea);
        }

        // GET: ideas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idea idea = db.ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_account = new SelectList(db.accounts, "id_account", "name", idea.id_account);
            ViewBag.id_toppic = new SelectList(db.topics, "id_toppic", "name_topic", idea.id_toppic);
            return View(idea);
        }

        // POST: ideas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_ideas,id_account,thumb_up,thumb_down,views,ideas_date,Content,id_toppic")] idea idea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_account = new SelectList(db.accounts, "id_account", "name", idea.id_account);
            ViewBag.id_toppic = new SelectList(db.topics, "id_toppic", "name_topic", idea.id_toppic);
            return View(idea);
        }

        // GET: ideas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            idea idea = db.ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // POST: ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            idea idea = db.ideas.Find(id);
            db.ideas.Remove(idea);
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
