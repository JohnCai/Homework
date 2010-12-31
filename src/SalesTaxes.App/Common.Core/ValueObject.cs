using System;

namespace Common.Core
{
    /// <summary>
    /// quick and simple implementation of value object
    /// </summary>
    public class ValueObject
    {
        public string Name { get; protected set; }

        public ValueObject(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name", "the name can't be empty");
            Name = name;
        }

        #region Equality

        public bool Equals(ValueObject another)
        {
            if (another == null)
                return false;

            if (ReferenceEquals(this, another))
                return true;

            return string.Compare(this.Name, another.Name, StringComparison.CurrentCulture) == 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return Equals(obj as ValueObject);
        }

        public override int GetHashCode()
        {
            int hashCode = GetType().GetHashCode();
            return (hashCode * HASH_MULTIPLIER) ^ Name.GetHashCode();
        }

        private const int HASH_MULTIPLIER = 31;

        #endregion

    }
}