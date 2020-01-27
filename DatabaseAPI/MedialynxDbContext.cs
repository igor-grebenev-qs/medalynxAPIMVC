using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace MedalynxAPI
{
    public class MedialynxDbContext : DbContext {
        public DbSet<Models.Enums.AnalyticalApplicationItem> AnalyticalApplications { get; set; }
        public DbSet<Models.Enums.DeseaseStateItem> DeseaseStates { get; set; }
 
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Enviroment> Enviroments { get; set; }
 
        public MedialynxDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=35.188.34.140;UserId=root;Password=m1llions;database=medalynx_db;");
        }
    }
    }