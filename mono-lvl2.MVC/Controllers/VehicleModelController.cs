using System;
using System.Web.Mvc;
using mono_lvl2.Service.Services;
using mono_lvl2.Service.ViewModels;

namespace mono_lvl2.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private VehicleModelService _service = new VehicleModelService();

        // GET: VehicleModel
        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        // GET: VehicleModel/Details/5
        public ActionResult Details(Guid? id)
        {
            return View(_service.Get(id));
        }

        // GET: VehicleModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv,Maker")] VehicleModelViewModel vehicleModelViewModel)
        {
            if (ModelState.IsValid)
            {
                vehicleModelViewModel.Id = Guid.NewGuid();
                _service.Add(vehicleModelViewModel);
                return RedirectToAction("Index");
            }

            return View(vehicleModelViewModel);
        }

        // GET: VehicleModel/Edit/5
        public ActionResult Edit(Guid? id)
        {
            return View(_service.Get(id));
        }

        // POST: VehicleModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv,Maker")] VehicleModelViewModel vehicleModelViewModel)
        {
            if (ModelState.IsValid)
            {
                _service.Edit(vehicleModelViewModel);
                return RedirectToAction("Index");
            }
            return View(vehicleModelViewModel);
        }

        // GET: VehicleModel/Delete/5
        public ActionResult Delete(Guid? id)
        {
            return View(_service.Get(id));
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _service.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
