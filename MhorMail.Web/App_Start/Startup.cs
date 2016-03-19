using System.Data.Entity;
using System.Reflection;
using System.Security.Claims;
using System.Web.Helpers;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MhorMail.Data;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace MhorMail.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (Startup).Assembly);
            DependencyConfig.RegisterDependencies(builder);
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
            Database.SetInitializer(new MhorMailInitializer());
            using (var ctx = new MhorMailContext())
            {
                ctx.Database.Initialize(false);
            }
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}