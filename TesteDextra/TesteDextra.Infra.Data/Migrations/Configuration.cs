namespace TesteDextra.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TesteDextra.Infra.Data.Context.TesteDextraContext>
    {
        /// <summary>
        /// Arquivo de configuração do migration para programação com code first
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TesteDextra.Infra.Data.Context.TesteDextraContext context)
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
        }
    }
}
