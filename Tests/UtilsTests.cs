using System;
using Xunit;
using MedalynxAPI;

namespace medalynxAPI.Tests
{
    internal class ReflectionTestClass
    {
        public int iProp1;
        public int iProp2;
        public string sProp1;
        public string sProp2;
    }

    internal class ModelValidationTestClass{
        public int TestProp { get; set; }
    }

    public class UtilsTests
    {
        //[Theory]
        //[InlineData(...)]
        //[InlineData(...)]
        //public void MyTheory(...) {Assert ...}

        [Fact]
        public void PassingToGuidTest() {
            Assert.Equal(Guid.Parse("26bf435f-8651-45e3-93cd-74eab5849104"), Utils.ToGuid("26bf435f-8651-45e3-93cd-74eab5849104", false));
        }
        
        [Fact]
        public void PassingToGuidTestNonGuid() {
            Assert.Equal(Guid.Empty, Utils.ToGuid("26bf435f-8651-45e3-93cd-74eab5849---", false));
        }

        [Fact]
        public void PassingToGuidTestCreate() {
            Assert.NotEqual(Guid.Empty, Utils.ToGuid("26bf435f-8651-45e3-93cd-74eab5849---", true));
        }

        [Fact]
        public void CopyPropertyValuesTest() {
            ReflectionTestClass object1 = new ReflectionTestClass();
            object1.iProp2 = 2;
            object1.sProp2 = "prop2 value";

            ReflectionTestClass object2 = new ReflectionTestClass();
            object2.iProp1 = 1;
            object2.iProp2 = 5;
            object2.sProp1 = "sp1 val";
            object2.sProp2 = "sp2 val";

            Assert.False(Utils.CopyPropertyValues<ReflectionTestClass>(object1, object2));

            Assert.NotStrictEqual(object1.iProp2, object2.iProp2);

            Assert.NotStrictEqual(object1.sProp2, object2.sProp2);

        }

        [Fact]
        public void PassingHasPropertyTest() {
            Assert.True(Utils.HasProperty<ModelValidationTestClass>("TestProp", typeof(int)));
        }
    }
}