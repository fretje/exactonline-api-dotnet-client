using System.Data.Entity.Migrations;

namespace ExactOnline.Client.Sdk.Sync.EntityFramework.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}
	}
}
