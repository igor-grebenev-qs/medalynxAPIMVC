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
        public NotificationDBAPI notificationDBAPI;
        public MessageDBAPI messageDBAPI;
        public SessionDBAPI sessionDBAPI;

        // enums
        public DeseaseStatesDBAPI deseaseStatesDBAPI;
        public GeneticMatchesDBAPI geneticMatchesDBAPI;
        public BiomarkersDBAPI biomarkersDBAPI;
        public DemographicsDBAPI demographicsDBAPI;
        public EthnicitysDBAPI ethnicitysDBAPI;
        public StageOfDeseasesDBAPI stageOfDeseasesDBAPI;
        public PrognosisDBAPI prognosisDBAPI;
        public PreviousTreatmentsDBAPI previousTreatmentsDBAPI;

        public HistoryDBAPI historyDBAPI;

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
            
            notificationDBAPI = new NotificationDBAPI();
            messageDBAPI = new MessageDBAPI();
            
            sessionDBAPI = new SessionDBAPI();

            deseaseStatesDBAPI = new DeseaseStatesDBAPI();
            geneticMatchesDBAPI = new GeneticMatchesDBAPI();
            biomarkersDBAPI = new BiomarkersDBAPI();
            demographicsDBAPI = new DemographicsDBAPI();
            ethnicitysDBAPI = new EthnicitysDBAPI();
            stageOfDeseasesDBAPI = new StageOfDeseasesDBAPI();
            prognosisDBAPI = new PrognosisDBAPI();
            previousTreatmentsDBAPI = new PreviousTreatmentsDBAPI();

            historyDBAPI = new HistoryDBAPI();
        }
    }
}