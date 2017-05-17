using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using mono_lvl2.Service.ViewModels;
using AutoMapper;

namespace mono_lvl2.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private DbCont _db;

        public VehicleMakeService()
        {
            _db = new DbCont();
        }

        public VehicleMakeViewModel Get(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id is null");
            }

            VehicleMake vehicleMake = _db.VehicleMake.Where(m => m.Id == id).FirstOrDefault();

            if (vehicleMake == null)
            {
                throw new ArgumentNullException("Model is null");
            }

            return Mapper.Map(vehicleMake, new VehicleMakeViewModel());
        }

        public IEnumerable<VehicleMakeViewModel> GetAll(string sortOrder = "", string searchStr = "")
        {
            List<VehicleMake> data = _db.VehicleMake.ToList();
            List<VehicleMakeViewModel> output = Mapper.Map<List<VehicleMake>, List<VehicleMakeViewModel>>(data);

            if (!String.IsNullOrEmpty(searchStr))
            {
                output = output.Where(m => m.Name.Contains(searchStr)).ToList();
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
                default:
                    output = output.OrderBy(m => m.Name).ToList();
                    break;                    
            }

            return output;
        }

        public void Add(VehicleMakeViewModel makeVM)
        {
            VehicleMake make = new VehicleMake();

            Mapper.Map(makeVM, make);
            make.Id = Guid.NewGuid();

            _db.VehicleMake.Add(make);
            _db.SaveChanges();
        }

        public VehicleMakeViewModel Edit(VehicleMakeViewModel makeVM)
        {
            if (makeVM == null)
            {
                throw new ArgumentNullException("Id is null");
            }

            VehicleMake make = _db.VehicleMake.Where(m => m.Id == makeVM.Id).FirstOrDefault();

            if (make == null)
            {
                throw new ArgumentNullException("Model is null");
            }

            make.Name = makeVM.Name;
            make.Abrv = makeVM.Abrv;

            _db.VehicleMake.AddOrUpdate(make);
            _db.SaveChanges();

            return Mapper.Map(make, makeVM);
        }

        public void Remove(Guid? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id is null");
            }

            _db.VehicleMake.Remove(_db.VehicleMake.Where(m => m.Id == id).FirstOrDefault());
            _db.SaveChanges();
        }
    }
}