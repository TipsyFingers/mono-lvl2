using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mono_lvl2.Service.ViewModels;
using PagedList;

namespace mono_lvl2.Service
{
    public interface IVehicleMakeService
    {
        VehicleMakeViewModel Get(Guid? id);
        IEnumerable<VehicleMakeViewModel> GetAll(string sortOrder = "", string searchStr = "");
        void Add(VehicleMakeViewModel makeVM);
        VehicleMakeViewModel Edit(VehicleMakeViewModel makeVM);
        void Remove(Guid? id);
        IPagedList<VehicleMakeViewModel> PageList(int? page, string searchStr, string currentFilter, string sortOrder);
        
    }
}
