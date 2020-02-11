using System;
using Xunit;
using MedalynxAPI;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort;
using MedalynxAPI.Models.Cohort.CohortEnums;
using MedalynxAPI.Models.Enums;
using MedalynxAPI.Models.User;

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
            // Fields constraints. All necessary filds listed below
            Assert.True(typeof(User).GetProperties().Length == 10);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<User>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<User>("Email", typeof(string)));
            Assert.True(Utils.HasProperty<User>("FirstName", typeof(string)));
            Assert.True(Utils.HasProperty<User>("LastName", typeof(string)));
            Assert.True(Utils.HasProperty<User>("CompanyName", typeof(string)));
            Assert.True(Utils.HasProperty<User>("Request", typeof(RequestType)));
            Assert.True(Utils.HasProperty<User>("Password", typeof(string)));
            Assert.True(Utils.HasProperty<User>("Role", typeof(string)));
            Assert.True(Utils.HasProperty<User>("CreationDate", typeof(DateTime)));
            Assert.True(Utils.HasProperty<User>("LastUpdate", typeof(DateTime)));
        }

        /// <summary>
        /// User messages entity validation.
        /// </summary>
        [Fact]
        public void PassingModelMessageTest() {
            // Fields constraints. All necessary filds listed below
            Assert.True(typeof(Message).GetProperties().Length == 4);

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
            // Fields constraints. All necessary filds listed below
            Assert.True(typeof(AnalyticalApplicationItem).GetProperties().Length == 3);

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
            // Fields constraints. All necessary filds listed below
            Assert.True(typeof(Cohort).GetProperties().Length == 7);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<Cohort>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<Cohort>("UserId", typeof(string)));
            Assert.True(Utils.HasProperty<Cohort>("NumberOfSubjectsRequired", typeof(int)));
            Assert.True(Utils.HasProperty<Cohort>("CohortType", typeof(string)));
            Assert.True(Utils.HasProperty<Cohort>("Request", typeof(RequestType)));
            Assert.True(Utils.HasProperty<Cohort>("CreationDate", typeof(DateTime)));
            Assert.True(Utils.HasProperty<Cohort>("LastUpdate", typeof(DateTime)));
        }

        /// <summary>
        /// CohortEnumLink entity validation.
        /// </summary>
        [Fact]
        public void PassingModelCohortEnumLinkTest() {
            // Fields constraints. All necessary filds listed below
            Assert.True(typeof(CohortEnumLink).GetProperties().Length == 8);

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
            // Fields constraints. All necessary filds listed below
            Assert.True(typeof(Biomarkers).GetProperties().Length == 2);

            // Enumerate all exists fields
            Assert.True(Utils.HasProperty<Biomarkers>("Id", typeof(string)));
            Assert.True(Utils.HasProperty<Biomarkers>("DeseaseState", typeof(string)));
        }

        #endregion
    }
}