using System.Linq;
using MhorMail.Data;
using MhorMail.Model;
using MhorMail.Services.Abstract;

namespace MhorMail.Services
{
    public class AdminService:IAdminService
    {
        public ServerConfiguration GetCurrentServerConfiguration()
        {
            using (var ctx = new MhorMailContext())
            {
                return ctx.ServerConfigurations.First();
            }
        }
    }
}