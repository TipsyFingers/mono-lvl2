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

// TODO: Edit post and get methods

namespace mono_lvl2.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        // GET: VehicleMake
        public ActionResult Index()
        {
            return View(VehicleService.GetMakesList());
        }

        //// GET: VehicleMake/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMake/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv")] VehicleMakeViewModel vehicleMakeViewModel)
        {
            if (ModelState.IsValid)
            {
                VehicleService.AddMake(vehicleMakeViewModel);
                return RedirectToAction("Index");
            }

            return View(vehicleMakeViewModel);
        }

        // GET: VehicleMake/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMakeViewModel = VehicleService.GetMake(id);

            if (vehicleMakeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMakeViewModel);
        }

        // GET: VehicleMake/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMakeViewModel vehicleMakeViewModel = VehicleService.GetMake(id);
            if (vehicleMakeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMakeViewModel);
        }

        // POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleService.RemoveMake(id);
            return RedirectToAction("Index");
        }

        //// GET: VehicleMake/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    VehicleMakeViewModel vehicleMakeViewModel = db.VehicleMakeViewModels.Find(id);
        //    if (vehicleMakeViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicleMakeViewModel);
        //}

        //// POST: VehicleMake/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Abrv")] VehicleMakeViewModel vehicleMakeViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(vehicleMakeViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(vehicleMakeViewModel);
        //}
    }
}
