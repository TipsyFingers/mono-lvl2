using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mono_lvl2.Service
{
    public class MakeModelContext : DbContext
    {
        public MakeModelContext() : base("name=db.lvl2") { }

        public virtual DbSet<VehicleModel> VehicleModel { get; set; }
        public virtual DbSet<VehicleMake> VehicleMake { get; set; }
    }
}