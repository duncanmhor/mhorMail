using Autofac;
using MhorMail.Services;
using MhorMail.Services.Abstract;

namespace MhorMail.Web
{
    public class DependencyConfig
    {
        public static void RegisterDependencies(ContainerBuilder container)
        {
            container.Register(c => new AccountService()).As<IAccountService>();
            container.Register(c => new MailService()).As<IMailService>();
        }
    }
}