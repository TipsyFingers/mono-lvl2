using System;
using System.ComponentModel.DataAnnotations;

namespace mono_lvl2.Service.ViewModels
{
    public class VehicleMakeViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter maker name!")]
        public string Name { get; set; }

        public string Abrv { get; set; }
    }
}