using MhorMail.Model;

namespace MhorMail.Services.Abstract
{
    public interface IAdminService
    {
        ServerConfiguration GetCurrentServerConfiguration();
    }
}