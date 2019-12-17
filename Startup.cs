using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SetifyFinal.Startup))]
namespace SetifyFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
