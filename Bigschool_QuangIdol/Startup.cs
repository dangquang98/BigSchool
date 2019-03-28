using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bigschool_QuangIdol.Startup))]
namespace Bigschool_QuangIdol
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
