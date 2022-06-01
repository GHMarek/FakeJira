using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FakeJira.Startup))]
namespace FakeJira
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
