using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace MedalynxAPI
{
    public class MedialynxData {
        public AnalyticalApplicationsDBAPI analyticalApplicationsDBAPI;
        public UserDBAPI userDBAPI;
        public EnviromentDBAPI enviromentDBAPI;

        public MedialynxData () {
            // enums
            analyticalApplicationsDBAPI = new AnalyticalApplicationsDBAPI();

            //user
            userDBAPI = new UserDBAPI();
            enviromentDBAPI = new EnviromentDBAPI();

            //cohort
        }
    }
}