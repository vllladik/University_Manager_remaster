using Microsoft.Owin;
using Owin;
using University_Manager.Models.Roles;

[assembly: OwinStartupAttribute(typeof(University_Manager.Startup))]
namespace University_Manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AppDbInitializer.SeedUsers();
        }
    }
}
