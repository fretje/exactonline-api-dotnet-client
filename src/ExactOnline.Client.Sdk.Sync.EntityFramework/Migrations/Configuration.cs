using System.Data.Entity.Migrations;

namespace ExactOnline.Client.Sdk.Sync.EntityFramework.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ExactOnline.Client.Sdk.Sync.EntityFramework.EntityFrameworkDbContext";
        }

        protected override void Seed(EntityFrameworkDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
