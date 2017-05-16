using mono_lvl2.Service.ViewModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace mono_lvl2.Service
{
    public class VehicleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid Make_Id { get; set; }

        [ForeignKey("Make_Id")]
        public virtual VehicleMake Make { get; set; }
    }
}