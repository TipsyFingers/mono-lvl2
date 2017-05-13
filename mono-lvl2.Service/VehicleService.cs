using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using mono_lvl2.Service.ViewModels;
using System.Diagnostics.Tracing;

using AutoMapper;

namespace mono_lvl2.Service
{
    public class VehicleService
    {
        public static List<VehicleMakeViewModel> GetMakesList()
        {
            DbCont db = new DbCont();
            List<VehicleMakeViewModel> makes = new List<VehicleMakeViewModel>();

            foreach (var m in db.MakeSet)
            {
                VehicleMakeViewModel listItem = new VehicleMakeViewModel();

                Mapper.Map(m, listItem);

                makes.Add(listItem);
            }

            return makes;
        }

        public static void AddMake(VehicleMakeViewModel makeVM)
        {
            DbCont db = new DbCont();
            VehicleMake make = new VehicleMake();

            Mapper.Map(makeVM, make);

            db.MakeSet.Add(make);
            db.SaveChanges();
        }

        public static VehicleMakeViewModel GetMake(int? id)
        {
            DbCont db = new DbCont();
            VehicleMake make = new VehicleMake();
            VehicleMakeViewModel makeVM = new VehicleMakeViewModel();

            if(db.MakeSet.Any(m => m.Id == id))
            {
                make = db.MakeSet.Find(id);
                Mapper.Map(make, makeVM);

                return makeVM;
            }
            else
                return null;
        }

        public static void RemoveMake(int? id)
        {
            DbCont db = new DbCont();

            if (db.MakeSet.Any(m => m.Id == id))
            {
                db.MakeSet.Remove(db.MakeSet.SingleOrDefault(m => m.Id == id));
                db.SaveChanges();
            }
            else
                throw new Exception("Delete operation failed!!");
        }

        public static List<VehicleModelViewModel> GetModelsList()
        {
            DbCont db = new DbCont();
            List<VehicleModelViewModel> models = new List<VehicleModelViewModel>();

            foreach (var m in db.ModelSet)
            {
                VehicleModelViewModel listItem = new VehicleModelViewModel();

                Mapper.Map(m, listItem);

                models.Add(listItem);
            }

            return models;
        }

        public static void AddModel(VehicleModelViewModel modelVM)
        {
            DbCont db = new DbCont();
            VehicleModel model = new VehicleModel();

            Mapper.Map(modelVM, model);

            db.ModelSet.Add(model);
            db.SaveChanges();
        }

        public static VehicleModelViewModel GetModel(int? id)
        {
            DbCont db = new DbCont();
            VehicleModel model = new VehicleModel();
            VehicleModelViewModel modelVM = new VehicleModelViewModel();

            if (db.MakeSet.Any(m => m.Id == id))
            {
                model = db.ModelSet.Find(id);
                Mapper.Map(model, modelVM);

                return modelVM;
            }
            else
                return null;
        }

        public static void RemoveModel(int? id)
        {
            DbCont db = new DbCont();

            if (db.ModelSet.Any(m => m.Id == id))
            {
                db.ModelSet.Remove(db.ModelSet.SingleOrDefault(m => m.Id == id));
                db.SaveChanges();
            }
            else
                throw new Exception("Delete operation failed!!");
        }
    }
}