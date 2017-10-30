using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Childcare.Startup))]
namespace Childcare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
