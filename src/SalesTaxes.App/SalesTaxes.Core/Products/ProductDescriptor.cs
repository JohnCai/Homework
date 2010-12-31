using System;

namespace SalesTaxes.Core
{
    /// <summary>
    /// encapsulates name, applicable units, productCategory etc.
    /// </summary>
    public class ProductDescriptor
    {
        public ProductDescriptor(string name)
        {
            Units = new UnitList();
            Name = name;

            InitNullUnit();
            InitDefaultCategory();
        }

        public string Name { get; private set; }
        public UnitList Units { get; private set; }

        public ProductCategory Category { get; set; }

        private void InitNullUnit()
        {
            AddUnit(Unit.Null);
        }

        private void InitDefaultCategory()
        {
            Category = ProductCategory.UnCategorized;
        }

        public void AddUnit(Unit unit)
        {
            Units.AddUnit(unit);
        }

        public int UnitsCount()
        {
            return Units.Count();
        }
    }
}