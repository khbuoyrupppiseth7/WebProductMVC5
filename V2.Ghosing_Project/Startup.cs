using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(V2.Ghosing_Project.Startup))]
namespace V2.Ghosing_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
