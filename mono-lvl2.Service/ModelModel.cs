namespace mono_lvl2.Service
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelModel : DbContext
    {
        // Your context has been configured to use a 'ModelModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'mono_lvl2.Service.ModelModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelModel' 
        // connection string in the application configuration file.
        public ModelModel()
            : base("name=ModelModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<VehicleModel> ModelSet { get; set; }
    }

    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string MakeID { get; set; }

        public virtual VehicleMake Maker { get; set; }
    }
}