using System.ComponentModel.DataAnnotations.Schema;

namespace mono_lvl2.Service
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int MakeID { get; set; }

        [ForeignKey("MakeID")]
        public virtual VehicleMake Maker { get; set; }
    }
}