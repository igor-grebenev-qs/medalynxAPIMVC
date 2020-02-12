using MedalynxAPI.Models.User;
using MedalynxAPI.Models.Enums;
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
        public DbSet<User> Users { get; set; }
    }

    public class MedialynxDbAnalyticalApplicationsContext : BaseDbContext {
        public DbSet<AnalyticalApplicationItem> AnalyticalApplications { get; set; }
    }

    public class MedialynxDbEnviromentsContext : BaseDbContext {
        public DbSet<Models.Enviroment> Enviroments { get; set; }
    }

    public class MedialynxDbCohortEnumLinkContext : BaseDbContext {
        public DbSet<Models.CohortEnumLink> CohortEnumLink { get; set; }
    }
    public class MedialynxDbCohortContext : BaseDbContext {
        public DbSet<Models.Cohort.Cohort> Cohorts { get; set; }
    }

    public class MedialynxDbCohortEnumsContext : BaseDbContext {
        public DbSet<Models.CohortEnums> CohortEnums { get; set; }
    }

    public class MedialynxDbDeseaseStatesContext : BaseDbContext {
        public DbSet<Models.Cohort.CohortEnums.DeseaseStates> DeseaseStates { get; set; }
    }
        
    public class MedialynxDbGeneticMatchesContext : BaseDbContext {
        public DbSet<Models.Cohort.CohortEnums.GeneticMatches> GeneticMatches { get; set; }
    }
    public class MedialynxDbBiomarkersContext : BaseDbContext {
        public DbSet<Models.Cohort.CohortEnums.Biomarkers> Biomarkers { get; set; }
    }
    public class MedialynxDbDemographicsContext : BaseDbContext {
        public DbSet<Models.Cohort.CohortEnums.Demographics> Demographics { get; set; }
    }
    public class MedialynxDbEthnicitysContext : BaseDbContext {
        public DbSet<Models.Cohort.CohortEnums.Ethnicitys> Ethnicitys { get; set; }
    }
    public class MedialynxDbStageOfDeseasesContext : BaseDbContext {
        public DbSet<Models.Cohort.CohortEnums.StageOfDeseases> StageOfDeseases { get; set; }
    }
    public class MedialynxDbPrognosisContext : BaseDbContext {
        public DbSet<Models.Cohort.CohortEnums.Prognosis> Prognosis { get; set; }
    }
    public class MedialynxDbPreviousTreatmentsContext : BaseDbContext {
        public DbSet<Models.Cohort.CohortEnums.PreviousTreatments> PreviousTreatments { get; set; }
    }
    public class MedialynxDbNotificationsContext : BaseDbContext {
        public DbSet<Models.Notification> Notifications { get; set; }
    }
    public class MedialynxDbMessagesContext : BaseDbContext {
        public DbSet<Models.User.Message> Messages { get; set; }
    }
    public class MedialynxDbSessionContext : BaseDbContext {
        public DbSet<Models.Session> Sessions { get; set; }
    }
    public class MedialynxDbHistoryContext : BaseDbContext {
        public DbSet<Models.HistoryItem> HistoryItems { get; set; }
    }

    public class MedialynxDbMetadataContext : BaseDbContext {
        public DbSet<Models.Metadata> Metadata { get; set; }
    }
}