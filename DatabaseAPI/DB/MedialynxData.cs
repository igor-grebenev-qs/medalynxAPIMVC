namespace MedalynxAPI
{
    public class MedialynxData {
        public AnalyticalApplicationsDBAPI analyticalApplicationsDBAPI;
        public CohortEnumsDBAPI cohortEnumsDBAPI;
        public UserDBAPI userDBAPI;
        public EnvironmentDBAPI environmentDBAPI;
        public CohortDBAPI cohortDBAPI;
        public CohortEnumLinkDBAPI cohortEnumLinkDBAPI;
        public NotificationDBAPI notificationDBAPI;
        public MessageDBAPI messageDBAPI;
        public SessionDBAPI sessionDBAPI;

        // enums
        public DiseaseStatesDBAPI diseaseStatesDBAPI;
        public GeneticMatchesDBAPI geneticMatchesDBAPI;
        public BiomarkersDBAPI biomarkersDBAPI;
        public DemographicsDBAPI demographicsDBAPI;
        public EthnicitysDBAPI ethnicitysDBAPI;
        public StageOfDiseasesDBAPI stageOfDiseasesDBAPI;
        public PrognosisDBAPI prognosisDBAPI;
        public PreviousTreatmentsDBAPI previousTreatmentsDBAPI;

        public HistoryDBAPI historyDBAPI;

        public MedialynxDbMetadataContext medialynxDbMetadataContext;

        public ProjectDBAPI projectDBAPI;

        public MedialynxData () {
            // enums
            analyticalApplicationsDBAPI = new AnalyticalApplicationsDBAPI();
            cohortEnumsDBAPI = new CohortEnumsDBAPI();

            //user
            userDBAPI = new UserDBAPI();
            environmentDBAPI = new EnvironmentDBAPI();

            //cohort
            cohortDBAPI = new CohortDBAPI();
            cohortEnumLinkDBAPI = new CohortEnumLinkDBAPI();
            
            notificationDBAPI = new NotificationDBAPI();
            messageDBAPI = new MessageDBAPI();
            
            sessionDBAPI = new SessionDBAPI();

            diseaseStatesDBAPI = new DiseaseStatesDBAPI();
            geneticMatchesDBAPI = new GeneticMatchesDBAPI();
            biomarkersDBAPI = new BiomarkersDBAPI();
            demographicsDBAPI = new DemographicsDBAPI();
            ethnicitysDBAPI = new EthnicitysDBAPI();
            stageOfDiseasesDBAPI = new StageOfDiseasesDBAPI();
            prognosisDBAPI = new PrognosisDBAPI();
            previousTreatmentsDBAPI = new PreviousTreatmentsDBAPI();

            historyDBAPI = new HistoryDBAPI();

            medialynxDbMetadataContext = new MedialynxDbMetadataContext();

            projectDBAPI = new ProjectDBAPI();
        }
    }
}