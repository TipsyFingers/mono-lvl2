using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using mono_lvl2.Service.ViewModels;
using AutoMapper;

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

            VehicleModel vehicleModel = _db.VehicleModel.Where(m => m.Id == id).FirstOrDefault();

            if (vehicleModel == null)
            {
                throw new ArgumentNullException("Model is null");
            }

            return Mapper.Map(vehicleModel, new VehicleModelViewModel());
        }

        public IEnumerable<VehicleModelViewModel> GetAll()
        {
            List<VehicleModelViewModel> modelList = new List<VehicleModelViewModel>();
            IEnumerable<VehicleModel> data = _db.VehicleModel.ToList();

            Mapper.Map(data, modelList);

            return modelList;
        }

        public void Add(VehicleModelViewModel modelVM)
        {
            VehicleModel model = new VehicleModel();

            Mapper.Map(modelVM, model);
            model.Id = Guid.NewGuid();

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
    }
}
