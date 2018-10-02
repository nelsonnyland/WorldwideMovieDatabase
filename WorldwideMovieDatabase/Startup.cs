using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorldwideMovieDatabase.Startup))]
namespace WorldwideMovieDatabase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
