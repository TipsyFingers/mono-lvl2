﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mono_lvl2.Service.ViewModels
{
    public class VehicleModelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        
        public int MakerID { get; set; }
    }
}