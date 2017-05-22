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
        private MakeModelContext _db;

        public VehicleModelService()
        {
            _db = new MakeModelContext();
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
            IQueryable<VehicleModel> data;

            if (!String.IsNullOrEmpty(searchStr))
            {
                data = _db.VehicleModel.Where(m => m.Make.Name.Contains(searchStr));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    data = _db.VehicleModel.OrderByDescending(m => m.Name);
                    break;
                case "abrv":
                    data = _db.VehicleModel.OrderBy(m => m.Abrv);
                    break;
                case "abrv_desc":
                    data = _db.VehicleModel.OrderByDescending(m => m.Abrv);
                    break;
                case "make":
                    data = _db.VehicleModel.OrderBy(m => m.Make.Name);
                    break;
                case "make_desc":
                    data = _db.VehicleModel.OrderByDescending(m => m.Make.Name);
                    break;
                default:
                    data = _db.VehicleModel.OrderBy(m => m.Name);
                    break;
            }

            data.ToList();

            return Mapper.Map<IQueryable<VehicleModel>, IEnumerable<VehicleModelViewModel>>(data);
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
