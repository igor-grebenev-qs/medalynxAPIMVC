using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace MedalynxAPI
{
    public abstract class BaseDbContext : DbContext {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=35.188.34.140;UserId=root;Password=m1llions;database=medalynx_db;");
        }
    }

    public abstract class MedialynxDbBaseContext : BaseDbContext {

        public MedialynxDbBaseContext()
        {
            Database.EnsureCreated();
        }
    }

    public class MedialynxDbUserContext : BaseDbContext {
        public DbSet<Models.User> Users { get; set; }
    }

    public class MedialynxDbAnalyticalApplicationsContext : BaseDbContext {
        public DbSet<Models.Enums.AnalyticalApplicationItem> AnalyticalApplications { get; set; }
    }

    public class MedialynxDbEnvironmentsContext : BaseDbContext {
        public DbSet<Models.Enviroment> Environments { get; set; }
    }
}