using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using mono_lvl2.Service.ViewModels;
using AutoMapper;
using System.Data.Entity;
using PagedList;

namespace mono_lvl2.Service.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private DbCont _db;

        public VehicleModelService()
        {
            _db = new DbCont();
        }

        public VehicleModelViewModel Get(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id is null");
            }

            VehicleModel vehicleModel = _db.VehicleModel.Where(m => m.Id == id).Include(m => m.Make).FirstOrDefault();

            if (vehicleModel == null)
            {
                throw new ArgumentNullException("Model is null");
            }

            return Mapper.Map(vehicleModel, new VehicleModelViewModel());
        }

        public IEnumerable<VehicleModelViewModel> GetAll(string sortOrder = "", string searchStr = "")
        {
            List<VehicleModel> data = _db.VehicleModel.ToList();
            List<VehicleModelViewModel> output = Mapper.Map<List<VehicleModel>, List<VehicleModelViewModel>>(data);

            if (!String.IsNullOrEmpty(searchStr))
            {
                output = output.Where(m => m.Make.Name.Contains(searchStr)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    output = output.OrderByDescending(m => m.Name).ToList();
                    break;
                case "abrv":
                    output = output.OrderBy(m => m.Abrv).ToList();
                    break;
                case "abrv_desc":
                    output = output.OrderByDescending(m => m.Abrv).ToList();
                    break;
                case "make":
                    output = output.OrderBy(m => m.Make.Name).ToList();
                    break;
                case "make_desc":
                    output = output.OrderByDescending(m => m.Make.Name).ToList();
                    break;
                default:
                    output = output.OrderBy(m => m.Name).ToList();
                    break;
            }

            return output;
        }

        public void Add(VehicleModelViewModel modelVM)
        {
            VehicleModel model = new VehicleModel();

            Mapper.Map(modelVM, model);

            _db.VehicleModel.Add(model);
            _db.SaveChanges();
        }

        public VehicleModelViewModel Edit(VehicleModelViewModel modelVM)
        {
            if (modelVM.Id == null)
            {
                throw new ArgumentNullException("Id is null");
            }

            VehicleModel model = _db.VehicleModel.Where(m => m.Id == modelVM.Id).FirstOrDefault();

            if (model == null)
            {
                throw new ArgumentNullException("Model is null");
            }

            model.Name = modelVM.Name;
            model.Abrv = modelVM.Abrv;
            model.Make_Id = modelVM.Make_Id;

            _db.VehicleModel.AddOrUpdate(model);
            _db.SaveChanges();

            return Mapper.Map(model, modelVM);
        }

        public void Remove(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id is null");
            }

            _db.VehicleModel.Remove(_db.VehicleModel.Where(m => m.Id == id).FirstOrDefault());
            _db.SaveChanges();
        }

        public IPagedList<VehicleModelViewModel> PageList(int? page, string searchStr, string currentFilter, string sortOrder)
        {
            int pageSize = 3;

            int pageNumber = (page ?? 1);
            var models = GetAll(sortOrder, searchStr);

            return models.ToPagedList(pageNumber, pageSize);
        }
    }
}
