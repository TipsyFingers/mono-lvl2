using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mono_lvl2.Service.ViewModels
{
    public class VehicleMakeViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter maker name!")]
        [Display(Name = "Maker name")]
        public string Name { get; set; }

        [Display(Name = "Maker abbreviation")]
        public string Abrv { get; set; }

        public virtual ICollection<VehicleModelViewModel> Models { get; set; }
    }
}