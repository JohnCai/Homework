using NUnit.Framework;
using System;
using SalesTaxes.Core;

namespace SalesTaxes.UnitTest.Core
{
    [TestFixture]
    public class UnitTester
    {
        [Test]
        public void Creating_Unit_Without_Name_Is_Forbidden()
        {
            Assert.Throws(typeof (ArgumentNullException), () => new Unit(string.Empty));
        }

        [Test]
        public void Units_With_Same_Names_Are_Equal()
        {
            var unit1 = new Unit("a");
            var unit2 = new Unit("a");

            Assert.AreEqual(unit1, unit2);
        }

        [Test]
        public void Units_With_Different_Names_Are_Not_Equal()
        {
            var unit1 = new Unit("a");
            var unit2 = new Unit("b");

            Assert.AreNotEqual(unit1, unit2);
        }
    }
}