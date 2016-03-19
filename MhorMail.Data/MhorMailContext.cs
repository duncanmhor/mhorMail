using System.Data.Entity;
using MhorMail.Model;

namespace MhorMail.Data
{
    public class MhorMailContext:DbContext
    {
        public MhorMailContext() : base("MhorMailContext")
        {
            Database.SetInitializer(new MhorMailInitializer());
        }

        public DbSet<ServerConfiguration> ServerConfigurations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            var assembly = typeof(MhorMailContext).Assembly;
            modelBuilder.Conventions.AddFromAssembly(assembly);
            modelBuilder.Configurations.AddFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}