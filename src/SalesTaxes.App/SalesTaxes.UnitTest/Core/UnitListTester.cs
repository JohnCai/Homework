using NUnit.Framework;
using SalesTaxes.Core;

namespace SalesTaxes.UnitTest.Core
{
    [TestFixture]
    public class UnitListTester
    {
        [Test]
        public void Should_Be_Able_To_Add_Unit()
        {
            var unitList = new UnitList();
            var stubUnit = new Unit("a");

            unitList.AddUnit(stubUnit);

            Assert.AreEqual(1, unitList.Count());
        }

    }
}