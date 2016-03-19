using System.Data.Entity;
using MhorMail.Model;

namespace MhorMail.Data
{
    public class MhorMailInitializer:DropCreateDatabaseIfModelChanges<MhorMailContext>
    {
        protected override void Seed(MhorMailContext context)
        {
            
            var serverConfiguration = new ServerConfiguration { ServerName = "mail.duncanlundie.co.uk", CreatedBy = "Seed", ServerPort = 143 };
            context.ServerConfigurations.Add(serverConfiguration);
            context.SaveChanges();
            base.Seed(context);
        }


    }
}