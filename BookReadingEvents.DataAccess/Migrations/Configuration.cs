using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BookReadingEvents.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookReadingEvents.DataAccess.BookReadingEventsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookReadingEvents.DataAccess.BookReadingEventsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
