using System;
using System.Web.Mvc;
using mono_lvl2.Service;
using mono_lvl2.Service.ViewModels;
using PagedList;

namespace mono_lvl2.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        private VehicleMakeService _service = new VehicleMakeService();

        // GET: VehicleMake
        public ActionResult Index(string sortOrder, string currentFilter, string searchStr, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbrvSortParm = sortOrder == "abrv" ? "abrv_desc" : "abrv";
            var makes = _service.GetAll(sortOrder, searchStr);

            if(searchStr != null)
            {
                page = 1;
            }
            else
            {
                searchStr = currentFilter;
            }

            ViewBag.CurrentFilter = searchStr;

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(makes.ToPagedList(pageNumber, pageSize));
        }

        // GET: VehicleMake/Details/5
        public ActionResult Details(Guid? id)
        {

            return View(_service.Get(id));
        }

        // GET: VehicleMake/Create
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
                _service.Add(vehicleMakeViewModel);
                return RedirectToAction("Index");
            }

            return View(vehicleMakeViewModel);
        }

        // GET: VehicleMake/Edit/5
        public ActionResult Edit(Guid? id)
        {
            return View(_service.Get(id));
        }

        // POST: VehicleMake/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Abrv")] VehicleMakeViewModel vehicleMakeViewModel)  
        {
            if (ModelState.IsValid)
            {
                _service.Edit(vehicleMakeViewModel);
                return RedirectToAction("Index");
            }
            return View(vehicleMakeViewModel);
        }

        // GET: VehicleMake/Delete/5
        public ActionResult Delete(Guid? id)
        {
            return View(_service.Get(id));
        }

        // POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _service.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
