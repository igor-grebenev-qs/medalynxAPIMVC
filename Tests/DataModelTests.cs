using System;
using Xunit;
using MedalynxAPI;
using MedalynxAPI.Models;
using MedalynxAPI.Models.Cohort;
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
    }
}