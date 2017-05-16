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
        [Display(Name = "Model name")]
        public string Name { get; set; }

        [Display(Name = "Model abbreviation")]
        public string Abrv { get; set; }

        [Required(ErrorMessage = "Please select maker!")]
        public Guid Make_Id { get; set; }

        [ForeignKey("Make_Id")]
        [Display(Name = "Maker name")]
        public VehicleMakeViewModel Make { get; set; }
    }
}