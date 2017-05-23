using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using mono_lvl2.Service.ViewModels;
using AutoMapper;
using PagedList;

namespace mono_lvl2.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private MakeModelContext _db;

        public VehicleMakeService()
        {
            _db = new MakeModelContext();
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

        public IEnumerable<VehicleMakeViewModel> GetAll(string sortOrder = "", string searchStr = "") // IQueryable
        {

            IQueryable<VehicleMake> data;

            if (!String.IsNullOrEmpty(searchStr))
            {
                data = _db.VehicleMake.Where(m => m.Name.Contains(searchStr));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    data = _db.VehicleMake.OrderByDescending(m => m.Name);
                    break;
                case "abrv":
                    data = _db.VehicleMake.OrderBy(m => m.Abrv);
                    break;
                case "abrv_desc":
                    data = _db.VehicleMake.OrderByDescending(m => m.Abrv);
                    break;
                default:
                    data = _db.VehicleMake.OrderBy(m => m.Name);
                    break;                    
            }            

            return Mapper.Map<List<VehicleMake>, IEnumerable<VehicleMakeViewModel>>(data.ToList());
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

            VehicleMake vehicleMake = _db.VehicleMake.Where(m => m.Id == id).FirstOrDefault();

            if (vehicleMake == null)
            {
                throw new ArgumentNullException("Model is null");
            }


            _db.VehicleMake.Remove(vehicleMake);
            _db.SaveChanges();
        }

        public IPagedList<VehicleMakeViewModel> PageList(int? page, string searchStr, string currentFilter, string sortOrder)
        {
            int pageSize = 3;

            int pageNumber = (page ?? 1);
            var makes = GetAll(sortOrder, searchStr);

            return makes.ToPagedList(pageNumber, pageSize);
        }
    }
}