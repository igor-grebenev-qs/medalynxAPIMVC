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

        public AnalyticalApplicationsDBAPI analyticalApplicationsDBAPI;
        public DeseaseStatesDBAPI deseaseStatesDBAPI;
        public UserDBAPI userDBAPI;
        public EnviromentDBAPI enviromentDBAPI;

        public MedialynxData () {
            dbContext = new MedialynxDbContext();

            // enums
            analyticalApplicationsDBAPI = new AnalyticalApplicationsDBAPI(dbContext);
            deseaseStatesDBAPI = new DeseaseStatesDBAPI(dbContext);

            //user
            userDBAPI = new UserDBAPI(dbContext);
            enviromentDBAPI = new EnviromentDBAPI(dbContext);

            //cohort
        }

        ~MedialynxData () {
            dbContext.Dispose();
        }

        public DbSet<Models.User> Users {
            get { return dbContext.Users; }
        }
    }
}