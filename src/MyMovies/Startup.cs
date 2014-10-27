using Microsoft.AspNet.Builder;

namespace MyMovies
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseWelcomePage();
        }
    }
}
