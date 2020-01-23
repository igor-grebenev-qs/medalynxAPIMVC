using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace MedalynxAPI
{
    public class MedialynxData {

        private MedialynxDbContext dbContext;

        public UserDBAPI userDBAPI;

        public MedialynxData () {
            dbContext = new MedialynxDbContext();
            userDBAPI = new UserDBAPI(dbContext);
        }

        ~MedialynxData () {
            dbContext.Dispose();
        }

        public DbSet<Models.User> Users {
            get { return dbContext.Users; }
        }
    }
}