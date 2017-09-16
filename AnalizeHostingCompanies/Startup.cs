using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnalizeHostingCompanies.Startup))]
namespace AnalizeHostingCompanies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
