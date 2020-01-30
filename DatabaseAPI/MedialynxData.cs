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
        public CohortEnumsDBAPI cohortEnumsDBAPI;
        public UserDBAPI userDBAPI;
        public EnviromentDBAPI enviromentDBAPI;
        public CohortDBAPI cohortDBAPI;
        public CohortEnumLinkDBAPI cohortEnumLinkDBAPI;

        public MedialynxData () {
            // enums
            analyticalApplicationsDBAPI = new AnalyticalApplicationsDBAPI();
            cohortEnumsDBAPI = new CohortEnumsDBAPI();

            //user
            userDBAPI = new UserDBAPI();
            enviromentDBAPI = new EnviromentDBAPI();

            //cohort
            cohortDBAPI = new CohortDBAPI();
            cohortEnumLinkDBAPI = new CohortEnumLinkDBAPI();
        }
    }
}