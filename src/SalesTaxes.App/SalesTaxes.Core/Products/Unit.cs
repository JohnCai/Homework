using System;
using Common.Core;

namespace SalesTaxes.Core
{
    /// <summary>
    /// unit of a product,implemented as value object.
    /// </summary>
    public class Unit: ValueObject
    {
        public static Unit Null = new NullUnit();

        private class NullUnit:Unit
        {
            public NullUnit(): base("default")
            {
            }
        }

        public Unit(string name) : base(name)
        {
        }

        public bool IsNull()
        {
            return this is NullUnit;
        }
    }
}