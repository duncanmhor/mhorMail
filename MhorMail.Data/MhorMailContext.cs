using System.Data.Entity;

namespace MhorMail.Data
{
    public class MhorMailContext:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(MhorMailContext).Assembly;
            modelBuilder.Conventions.AddFromAssembly(assembly);
            modelBuilder.Configurations.AddFromAssembly(assembly);
        }

    }
}