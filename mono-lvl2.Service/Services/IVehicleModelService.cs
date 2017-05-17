using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mono_lvl2.Service.ViewModels;

namespace mono_lvl2.Service.Services
{
    public interface IVehicleModelService
    {
        VehicleModelViewModel Get(Guid? id);
        IEnumerable<VehicleModelViewModel> GetAll(string sortOrder = "", string searchStr = "");
        void Add(VehicleModelViewModel modelVM);
        VehicleModelViewModel Edit(VehicleModelViewModel makeVM);
        void Remove(Guid? id);
    }
}