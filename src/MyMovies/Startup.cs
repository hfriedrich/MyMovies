using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using MovieFileImport;
using MovieImportService;

namespace MyMovies
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseServices(service => service.AddMvc().AddScoped<IMovieImporter, MovieFileImporter>());
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
