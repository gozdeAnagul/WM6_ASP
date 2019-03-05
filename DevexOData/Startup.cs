using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevexOData.Startup))]
namespace DevexOData
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
