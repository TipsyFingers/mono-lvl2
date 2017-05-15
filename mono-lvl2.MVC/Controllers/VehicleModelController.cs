using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mono_lvl2.Service;
using mono_lvl2.Service.ViewModels;

namespace mono_lvl2.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        // GET: VehicleModel
        public ActionResult Index()
        {
            return View(VehicleService.GetModelsList());
        }

        // GET: VehicleModel/Create
        public ActionResult Create()
        {
            var makes = VehicleService.GetMakesList().ToList();
            SelectList list = new SelectList(makes, "Id", "Name");
            ViewBag.makelist = list;
            return View();
        }

        // Jos ne radi

        // POST: VehicleModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv,MakeID")] VehicleModelViewModel vehicleModelViewModel)
        {
            if (ModelState.IsValid)
            {
                VehicleService.AddModel(vehicleModelViewModel);
                return RedirectToAction("Index");
            }

            return View(vehicleModelViewModel);
        }

        //// GET: VehicleModel/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    VehicleModelViewModel vehicleModelViewModel = VehicleService.GetModel(id);

        //    if (vehicleModelViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicleModelViewModel);
        //}

        //// GET: VehicleModel/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    VehicleModelViewModel vehicleModelViewModel = VehicleService.GetModel(id);
        //    if (vehicleModelViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicleModelViewModel);
        //}

        //// POST: VehicleModel/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    VehicleService.RemoveModel(id);
        //    return RedirectToAction("Index");
        //}

        //// GET: VehicleModel/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    VehicleModelViewModel vehicleModelViewModel = db.VehicleModelViewModels.Find(id);
        //    if (vehicleModelViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicleModelViewModel);
        //}

        //// POST: VehicleModel/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Abrv,MakerID")] VehicleModelViewModel vehicleModelViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(vehicleModelViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(vehicleModelViewModel);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
