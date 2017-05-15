using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mono_lvl2.Service.ViewModels;

namespace mono_lvl2.Service
{
    public interface IVehicleMakeService
    {
        VehicleMakeViewModel Get(Guid? id);
        IEnumerable<VehicleMakeViewModel> GetAll();
        void Add(VehicleMakeViewModel makeVM);
        VehicleMakeViewModel Edit(Guid? id, VehicleMakeViewModel makeVM);
        void Remove(Guid? id);
    }
}
