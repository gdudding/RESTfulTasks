namespace RESTfulTasks.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RESTfulTasks.Models.RESTfulTasksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RESTfulTasks.Models.RESTfulTasksContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Tasks.AddOrUpdate(new Models.Task[]{
                new Models.Task() { TaskId = 1, TaskDescription="Sample Task 1" },
                new Models.Task() { TaskId = 2, TaskDescription="Sample Task 2" }
            });
        }
    }
}
