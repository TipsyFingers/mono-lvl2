using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mono_lvl2.Service.ViewModels
{
    public class VehicleModelViewModel
    {


        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter model name!")]
        public string Name { get; set; }

        public string Abrv { get; set; }
        public Guid MakeID { get; set; }

        public IEnumerable<VehicleMakeViewModel> Makes { get; set; }
    }
}