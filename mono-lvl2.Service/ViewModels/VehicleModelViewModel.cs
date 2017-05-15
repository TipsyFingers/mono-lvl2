using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mono_lvl2.Service.ViewModels
{
    public class VehicleModelViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter model name!")]
        public string Name { get; set; }

        public string Abrv { get; set; }
        public int MakeID { get; set; }
    }
}