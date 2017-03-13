using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonalCalendar.Startup))]
namespace PersonalCalendar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
