using System.Collections.Generic;

namespace mono_lvl2.Service
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MakeModel : DbContext
    {
        // Your context has been configured to use a 'MakeModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'mono_lvl2.Service.MakeModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MakeModel' 
        // connection string in the application configuration file.
        public MakeModel()
            : base("name=MakeModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<VehicleMake> MakeSet { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        public virtual ICollection<VehicleModel> Models { get; set; }
    }
}