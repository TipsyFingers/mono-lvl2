using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace mono_lvl2.Service
{
    public class VehicleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public Guid MakeID { get; set; }

        [ForeignKey("MakeID")]
        public virtual VehicleMakeViewModel Maker { get; set; }
    }
}