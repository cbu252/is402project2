using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(is402project2.Startup))]
namespace is402project2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
