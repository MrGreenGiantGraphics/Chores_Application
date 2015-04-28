using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectChore_Application.Startup))]
namespace ProjectChore_Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
