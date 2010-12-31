using System;
using Common.Core;
using NUnit.Framework;

namespace SalesTaxes.UnitTest.Common
{
    [TestFixture]
    public class ValueObjectTester
    {
        [Test]
        public void Creating_ValueObject_Without_Name_Is_Forbidden()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new ValueObject(string.Empty));
        }

        [Test]
        public void Units_With_Same_Names_Are_Equal()
        {
            var valueObject1 = new ValueObject("a");
            var valueObject2 = new ValueObject("a");

            Assert.AreEqual(valueObject1, valueObject2);
        }

        [Test]
        public void Units_With_Different_Names_Are_Not_Equal()
        {
            var valueObject1 = new ValueObject("a");
            var valueObject2 = new ValueObject("b");

            Assert.AreNotEqual(valueObject1, valueObject2);
        }
    }
}