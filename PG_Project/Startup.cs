using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PG_Project.Startup))]
namespace PG_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);
        }
    }
}
