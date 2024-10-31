namespace App_Tutorias_Turing.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;

    internal sealed class Configuration : DbMigrationsConfiguration<App_Tutorias_Turing.Services.Service>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
          
        }

        protected override void Seed(App_Tutorias_Turing.Services.Service context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
