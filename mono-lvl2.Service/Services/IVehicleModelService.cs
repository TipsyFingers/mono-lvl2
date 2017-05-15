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
        IEnumerable<VehicleModelViewModel> GetAll();
        void Add(VehicleModelViewModel modelVM);
        VehicleModelViewModel Edit(Guid? id, VehicleModelViewModel makeVM);
        void Remove(Guid? id);
    }
}