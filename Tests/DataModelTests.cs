using System;
using Xunit;
using MedalynxAPI;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort;
using MedalynxAPI.Models.Cohort.CohortEnums;
using MedalynxAPI.Models.Enums;
using MedalynxAPI.Models.User;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace medalynxAPI.Tests
{
    /// <summary>
    /// Validation data model.
    /// </summary>
    public class DataModelTests
    {
        /// <summary>
        /// User entity validation.
        /// </summary>
        [Fact]
        public void PassingModelUserTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(11, typeof(User).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<User>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<User>("Email", typeof(string)));
            Assert.True(Utils.HasProperty<User>("FirstName", typeof(string)));
            Assert.True(Utils.HasProperty<User>("LastName", typeof(string)));
            Assert.True(Utils.HasProperty<User>("CompanyName", typeof(string)));
            Assert.True(Utils.HasProperty<User>("Request", typeof(RequestType)));
            Assert.True(Utils.HasProperty<User>("Password", typeof(string)));
            Assert.True(Utils.HasProperty<User>("Role", typeof(string)));
            Assert.True(Utils.HasProperty<User>("Status", typeof(int)));
            Assert.True(Utils.HasProperty<User>("CreationDate", typeof(DateTime)));
            Assert.True(Utils.HasProperty<User>("LastUpdate", typeof(DateTime)));
        }

        /// <summary>
        /// User messages entity validation.
        /// </summary>
        [Fact]
        public void PassingModelMessageTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(4, typeof(Message).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<Message>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<Message>("UserId", typeof(string)));
            Assert.True(Utils.HasProperty<Message>("MessageBody", typeof(string)));
            Assert.True(Utils.HasProperty<Message>("CreationDate", typeof(DateTime)));
        }

        /// <summary>
        /// AnalyticalApplicationItem entity validation. (Environment analytical applications options)
        /// </summary>
        [Fact]
        public void PassingModelAnalyticalApplicationItemTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(3, typeof(AnalyticalApplicationItem).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<AnalyticalApplicationItem>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<AnalyticalApplicationItem>("Pos", typeof(int)));
            Assert.True(Utils.HasProperty<AnalyticalApplicationItem>("Name", typeof(string)));
        }

        /// <summary>
        /// Cohort entity validation.
        /// </summary>
        [Fact]
        public void PassingModelCohortTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(10, typeof(Cohort).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<Cohort>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<Cohort>("UserId", typeof(string)));
            Assert.True(Utils.HasProperty<Cohort>("NumberOfSubjectsRequired", typeof(int)));
            Assert.True(Utils.HasProperty<Cohort>("CohortType", typeof(string)));
            Assert.True(Utils.HasProperty<Cohort>("RequestAdmin", typeof(RequestType)));
            Assert.True(Utils.HasProperty<Cohort>("RequestUser", typeof(RequestType)));
            Assert.True(Utils.HasProperty<Cohort>("Status", typeof(ObjectStatus)));
            Assert.True(Utils.HasProperty<Cohort>("RequestType", typeof(ObjectStatus)));
            Assert.True(Utils.HasProperty<Cohort>("CreationDate", typeof(DateTime)));
            Assert.True(Utils.HasProperty<Cohort>("LastUpdate", typeof(DateTime)));
        }

        /// <summary>
        /// CohortEnumLink entity validation.
        /// </summary>
        [Fact]
        public void PassingModelCohortEnumLinkTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(8, typeof(CohortEnumLink).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<CohortEnumLink>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<CohortEnumLink>("CohortId", typeof(string)));
            Assert.True(Utils.HasProperty<CohortEnumLink>("CohortEnumId", typeof(string)));
            Assert.True(Utils.HasProperty<CohortEnumLink>("EnumItemId", typeof(string)));
            Assert.True(Utils.HasProperty<CohortEnumLink>("Include", typeof(int)));
            Assert.True(Utils.HasProperty<CohortEnumLink>("Percentage", typeof(float)));
            Assert.True(Utils.HasProperty<CohortEnumLink>("CreationDate", typeof(DateTime)));
            Assert.True(Utils.HasProperty<CohortEnumLink>("LastUpdate", typeof(DateTime)));
        }

        #region Cohort enums

        /// <summary>
        /// Biomarkers entity validation.
        /// </summary>
        [Fact]
        public void PassingModelBiomarkersTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(2, typeof(Biomarkers).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<Biomarkers>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<Biomarkers>("DiseaseState", typeof(string)));
        }

        /// <summary>
        /// Demographics entity validation.
        /// </summary>
        [Fact]
        public void PassingModelDemographicsTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(4, typeof(Demographics).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<Demographics>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<Demographics>("AgeFrom", typeof(float)));
            Assert.True(Utils.HasProperty<Demographics>("AgeTo", typeof(float)));
            Assert.True(Utils.HasProperty<Demographics>("Gender", typeof(string)));
        }

        /// <summary>
        /// DiseaseStates entity validation.
        /// </summary>
        [Fact]
        public void PassingModelDiseaseStatesTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(2, typeof(DiseaseStates).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<DiseaseStates>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<DiseaseStates>("DiseaseState", typeof(string)));
        }

        /// <summary>
        /// Ethnicitys entity validation.
        /// </summary>
        [Fact]
        public void PassingModelEthnicitysTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(2, typeof(Ethnicitys).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<Ethnicitys>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<Ethnicitys>("Nationality", typeof(string)));
        }

        /// <summary>
        /// GeneticMatches entity validation.
        /// </summary>
        [Fact]
        public void PassingModelGeneticMatchesTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(6, typeof(GeneticMatches).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<GeneticMatches>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<GeneticMatches>("Chromosome", typeof(string)));
            Assert.True(Utils.HasProperty<GeneticMatches>("Position", typeof(int)));
            Assert.True(Utils.HasProperty<GeneticMatches>("Ref", typeof(string)));
            Assert.True(Utils.HasProperty<GeneticMatches>("Alt", typeof(string)));
            Assert.True(Utils.HasProperty<GeneticMatches>("dbSNP", typeof(string)));
        }

        /// <summary>
        /// PreviousTreatments entity validation.
        /// </summary>
        [Fact]
        public void PassingModelPreviousTreatmentsTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(2, typeof(PreviousTreatments).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<PreviousTreatments>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<PreviousTreatments>("Keyword", typeof(string)));
        }

        /// <summary>
        /// Prognosis entity validation.
        /// </summary>
        [Fact]
        public void PassingModelPrognosisTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(2, typeof(Prognosis).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<Prognosis>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<Prognosis>("Keyword", typeof(string)));
        }

        /// <summary>
        /// StageOfDiseases entity validation.
        /// </summary>
        [Fact]
        public void PassingModelStageOfDiseasesTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(4, typeof(StageOfDiseases).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<StageOfDiseases>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<StageOfDiseases>("StageOfTumour", typeof(int)));
            Assert.True(Utils.HasProperty<StageOfDiseases>("NumberOfNodesAffected", typeof(int)));
            Assert.True(Utils.HasProperty<StageOfDiseases>("NumberOfMetastasis", typeof(int)));
        }

        #endregion

        /// <summary>
        /// CohortEnums entity validation.
        /// </summary>
        [Fact]
        public void PassingModelCohortEnumsTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(4, typeof(CohortEnums).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<CohortEnums>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<CohortEnums>("Name", typeof(string)));
            Assert.True(Utils.HasProperty<CohortEnums>("CreationDate", typeof(DateTime)));
            Assert.True(Utils.HasProperty<CohortEnums>("LastUpdate", typeof(DateTime)));
        }

        /// <summary>
        /// Environment entity validation.
        /// </summary>
        [Fact]
        public void PassingModelEnvironmentTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(11, typeof(MedalynxAPI.Models.Environment).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<MedalynxAPI.Models.Environment>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<MedalynxAPI.Models.Environment>("UserId", typeof(string)));
            Assert.True(Utils.HasProperty<MedalynxAPI.Models.Environment>("NumberOfUsers", typeof(int)));
            Assert.True(Utils.HasProperty<MedalynxAPI.Models.Environment>("DataStorage", typeof(float)));
            Assert.True(Utils.HasProperty<MedalynxAPI.Models.Environment>("AnalyticalApplication", typeof(string)));
            Assert.True(Utils.HasProperty<MedalynxAPI.Models.Environment>("TypeOfConnectivity", typeof(string)));
            Assert.True(Utils.HasProperty<MedalynxAPI.Models.Environment>("Request", typeof(RequestType)));
            Assert.True(Utils.HasProperty<MedalynxAPI.Models.Environment>("RequestType", typeof(ObjectStatus)));
            Assert.True(Utils.HasProperty<MedalynxAPI.Models.Environment>("Status", typeof(ObjectStatus)));
            Assert.True(Utils.HasProperty<MedalynxAPI.Models.Environment>("CreationDate", typeof(DateTime)));
            Assert.True(Utils.HasProperty<MedalynxAPI.Models.Environment>("LastUpdate", typeof(DateTime)));
        }

        /// <summary>
        /// Notification entity validation.
        /// </summary>
        [Fact]
        public void PassingModelNotificationTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(7, typeof(Notification).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<Notification>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<Notification>("UserId", typeof(string)));
            Assert.True(Utils.HasProperty<Notification>("Message", typeof(string)));
            Assert.True(Utils.HasProperty<Notification>("NotificationType", typeof(int)));
            Assert.True(Utils.HasProperty<Notification>("Status", typeof(NotificationStatus)));
            Assert.True(Utils.HasProperty<Notification>("CreationDate", typeof(DateTime)));
            Assert.True(Utils.HasProperty<Notification>("LastUpdate", typeof(DateTime)));
        }

        /// <summary>
        /// Session entity validation.
        /// </summary>
        [Fact]
        public void PassingModelSessionTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(4, typeof(Session).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<Notification>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<Notification>("UserId", typeof(string)));
            Assert.True(Utils.HasProperty<Notification>("CreationDate", typeof(DateTime)));
            Assert.True(Utils.HasProperty<Notification>("LastUpdate", typeof(DateTime)));
       }

        /// <summary>
        /// HistoryItem entity validation.
        /// </summary>
        [Fact]
        public void PassingModelHistoryItemTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(6, typeof(HistoryItem).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<HistoryItem>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<HistoryItem>("UserId", typeof(string)));
            Assert.True(Utils.HasProperty<HistoryItem>("ObjectId", typeof(string)));
            Assert.True(Utils.HasProperty<HistoryItem>("ObjectType", typeof(string)));
            Assert.True(Utils.HasProperty<HistoryItem>("Message", typeof(string)));
            Assert.True(Utils.HasProperty<HistoryItem>("CreationDate", typeof(DateTime)));
       }

        /// <summary>
        /// TypeOfConnectivity entity validation.
        /// </summary>
        [Fact]
        public void PassingModelTypeOfConnectivityTest() {
            // Fields constraints. All necessary fields listed below
            Assert.Equal(3, typeof(TypeOfConnectivity).GetProperties().Length);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<TypeOfConnectivity>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<TypeOfConnectivity>("Pos", typeof(int)));
            Assert.True(Utils.HasProperty<TypeOfConnectivity>("Name", typeof(string)));
       }

        [Fact]
        public void ValidateInformationSchema() {
            Console.WriteLine("VALIDATE INFORMATION SCHEMA");
            Type parent = typeof(BaseDbContext);
            Type[] types = Assembly.GetExecutingAssembly().GetTypes(); // Maybe select some other assembly here, depending on what you need
            var inheritingTypes = types.Where(t => parent.IsAssignableFrom(t)).ToList();
            List<string> dbSetNames = new List<string>();
            foreach( var t in inheritingTypes) {
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo pi in props) {
                    dbSetNames.Add(pi.Name);
                }
            }

            string query = String.Concat("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA=\"", BaseDbContext.SchemaName,"\"");
            using (MySqlConnection connection = new MySqlConnection(BaseDbContext.ConnectionString)){
                connection.Open();
                using (var cmd = connection.CreateCommand()) {
                    cmd.CommandText = query;
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var tableName = reader["TABLE_NAME"];
                        bool modelHasDbTable = dbSetNames.Contains(tableName);
                        if (!modelHasDbTable) {
                            Console.WriteLine(tableName + " DbSet not exists!");
                        }
                        Assert.True(modelHasDbTable);
                        Console.WriteLine(tableName + " passed");
                    }
                }
            }
        }
    }
}