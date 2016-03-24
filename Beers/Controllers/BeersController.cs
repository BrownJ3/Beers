using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Beers.Controllers
{
    public class BeersController : Controller
    {
        BeersContext db = new BeersContext();
        // GET: Beers
        public ActionResult Index()
        {
            return View(db.Beers.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Beer beer = db.Beers.Find(id) ;
            if (beer == null)
                return HttpNotFound();
            return View(beer);
        }
      
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Beer beers)
        {
            if (ModelState.IsValid)
            {
                db.Beers.Add(beers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beers);
          
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Beer beer = db.Beers.Find(id);
            if (beer == null)
                return HttpNotFound();
            return View(beer);
            
        }

        [HttpPost]
        public ActionResult Edit(Beer beers)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(beers).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(beers);
            }
               
            catch
            {

                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Beer beer = db.Beers.Find(id);
            if (beer == null)
                return HttpNotFound();
             return View(beer);
        }

        [HttpPost]
        public ActionResult Delete(int? id, Beer be)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    Beer beer = db.Beers.Find(id);
                    db.Beers.Remove(beer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View("Index");
                
            }
            catch 
            {

                return View();
            }
        }
    }
}