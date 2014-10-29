using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using MovieFileImport;
using MovieImportService;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Security.Cookies;
using MyMovies.Models;
using MyMovies.Database;

namespace MyMovies
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseServices(services =>
            {
                services.AddEntityFramework()
                    .AddInMemoryStore();

                services.AddIdentitySqlServer<ApplicationDbContext, ApplicationUser>()
                    .AddAuthentication();

                services.AddMvc().AddScoped<IMovieImporter, MovieFileImporter>();
            });
            app.UseStaticFiles();
            app.UseErrorPage();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = ClaimsIdentityOptions.DefaultAuthenticationType,
                LoginPath = new PathString("/Account/Login"),
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "api", 
                    template: "{controller}/{id?}");
            });
        }
    }
}
