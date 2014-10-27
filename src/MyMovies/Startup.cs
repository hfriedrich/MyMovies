using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;

namespace MyMovies
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseServices(service => service.AddMvc());
            app.UseMvc();
        }
    }
}
