using System;
using System.Web.Mvc;
using mono_lvl2.Service.Services;
using mono_lvl2.Service.ViewModels;
using mono_lvl2.Service;
using System.Linq;
using System.Data.Entity;

namespace mono_lvl2.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        private VehicleModelService _serviceModel = new VehicleModelService();
        private VehicleMakeService _serviceMake = new VehicleMakeService();

        // GET: VehicleModel
        public ActionResult Index(string sortOrder, string searchStr)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbrvSortParm = sortOrder == "abrv" ? "abrv_desc" : "abrv";
            var models = from m in _serviceModel.GetAll() select m;

            if (!String.IsNullOrEmpty(searchStr))                                          
            {
                models = models.Where(m => m.Name.Contains(searchStr));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    models = models.OrderByDescending(m => m.Name);
                    break;
                case "abrv":
                    models = models.OrderBy(m => m.Abrv);
                    break;
                case "abrv_desc":
                    models = models.OrderByDescending(m => m.Abrv);
                    break;
                case "maker_desc":
                    models = models.OrderByDescending(m => m.MakeName);
                    break;
                case "maker":
                    models = models.OrderBy(m => m.MakeName);
                    break;
                default:
                    models = models.OrderBy(m => m.Name);
                    break;
            }

            return View(models);
        }

        // GET: VehicleModel/Details/5
        public ActionResult Details(Guid? id)
        {
            return View(_serviceModel.Get(id));
        }

        // GET: VehicleModel/Create
        public ActionResult Create()
        {
            ViewBag.List = new SelectList(_serviceMake.GetAll(), "Id", "Name");

            return View();
        }

        // POST: VehicleModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Abrv,MakeID")] VehicleModelViewModel vehicleModelViewModel)
        {
            if (ModelState.IsValid)
            {
                vehicleModelViewModel.Id = Guid.NewGuid();
                _serviceModel.Add(vehicleModelViewModel);
                return RedirectToAction("Index");
            }

            return View(vehicleModelViewModel);
        }

        // GET: VehicleModel/Edit/5
        public ActionResult Edit(Guid? id)
        {
            var _service2 = new VehicleMakeService();
            var makes = _service2.GetAll();

            ViewBag.List = new SelectList(makes, "Id", "Name");
            return View(_serviceModel.Get(id));
        }

        // POST: VehicleModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv,MakeID")] VehicleModelViewModel vehicleModelViewModel)
        {
            if (ModelState.IsValid)
            {
                _serviceModel.Edit(vehicleModelViewModel);
                return RedirectToAction("Index");
            }
            return View(vehicleModelViewModel);
        }

        // GET: VehicleModel/Delete/5
        public ActionResult Delete(Guid? id)
        {
            return View(_serviceModel.Get(id));
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _serviceModel.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
