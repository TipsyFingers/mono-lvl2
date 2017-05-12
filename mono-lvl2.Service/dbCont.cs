using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mono_lvl2.Service
{
    public class dbCont : DbContext
    {
        // Your context has been configured to use a 'ModelModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'mono_lvl2.Service.ModelModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelModel' 
        // connection string in the application configuration file.
        public dbCont()
            : base("name=db.lvl2")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<VehicleModel> ModelSet { get; set; }
        public virtual DbSet<VehicleMake> MakeSet { get; set; }
    }
}