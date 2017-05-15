using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mono_lvl2.Service.ViewModels
{
    public class VehicleModelViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter model name!")]
        public string Name { get; set; }

        public string Abrv { get; set; }
        public Guid MakeID { get; set; }
    }
}