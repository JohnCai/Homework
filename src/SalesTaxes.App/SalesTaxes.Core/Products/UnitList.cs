using System;
using System.Collections.Generic;

namespace SalesTaxes.Core
{
    public class UnitList
    {
        private readonly List<Unit> _units;
        public IList<Unit> Units
        {
            get { return _units; }
        }

        public UnitList()
        {
            _units = new List<Unit>();
        }

        public int Count()
        {
            return _units.Count;
        }

        public void AddUnit(Unit unit)
        {
            _units.Add(unit);
        }

        public Unit this[int index]
        {
            get { return _units[index]; }
        }
    }
}