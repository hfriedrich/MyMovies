using System;
using Microsoft.AspNet.Identity.SqlServer;
using Microsoft.Data.Entity;
using Microsoft.Framework.OptionsModel;
using MyMovies.Models;

namespace MyMovies.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private static bool _created = false;

        public ApplicationDbContext(IServiceProvider serviceProvider, IOptionsAccessor<DbContextOptions> optionsAccessor)
            : base(serviceProvider, optionsAccessor.Options)
        {
            if (!_created)
            {
                Database.EnsureCreated();
                _created = true;
            }
        }
    }
}