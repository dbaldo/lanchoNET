using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteDextra.Infra.Data.EntityConfig;
using TesteDextra.Domain.Entities;

namespace TesteDextra.Infra.Data.Context
{
    /// <summary>
    /// Contexto para acesso ao banco com entityframework
    /// </summary>
    public class TesteDextraContext : DbContext
    {
        public TesteDextraContext()
            : base("TesteDextra")
        {

        }

        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<IngredienteLanche> IngredientesLanche { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new IngredienteConfig());
            modelBuilder.Configurations.Add(new LancheConfig());
            modelBuilder.Configurations.Add(new IngredienteLancheConfig());
        }

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("DataCadastro").CurrentValue = DateTime.Now;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("DataCadastro").IsModified = false;
        //        }
        //    }
        //    return base.SaveChanges();
        //}
    }
}
