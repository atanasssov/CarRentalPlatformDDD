using System.Collections.Concurrent;
using System.Reflection;

namespace CarRentalPlatform.Domain.Common
{

    // Provides common functionality for working with enumerations, such as retrieving all values, parsing values from their names or values

    public abstract class Enumeration : IComparable
    {
        // Cache to store enumeration values for each enumeration type to improve performance
        private static readonly ConcurrentDictionary<Type, IEnumerable<object>> EnumCache
            = new ConcurrentDictionary<Type, IEnumerable<object>>();

        // The unique value of the enumeration
        public int Value { get; }

        // The name of the enumeration
        public string Name { get; }

        // Constructor to initialize the enumeration constant with its value and name
        protected Enumeration(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }

        // Returns the name of the enumeration constant.
        public override string ToString() => this.Name;

        // Retrieves all enumeration constants of the specified type
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            // Retrieves or adds enumeration values for the specified type to the cache
            var type = typeof(T);

            var values = EnumCache.GetOrAdd(type, _ => type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null)!));

            return values.Cast<T>();
        }

        // Parses the enumeration constant from its value
        public static T FromValue<T>(int value) where T : Enumeration
            => Parse<T, int>(value, "value", item => item.Value == value);

        // Parses the enumeration constant from its name.
        public static T FromName<T>(string name) where T : Enumeration
            => Parse<T, string>(name, "name", item => item.Name == name);

        // Retrieves the name of the enumeration constant from its value
        public static string NameFromValue<T>(int value) where T : Enumeration
            => FromValue<T>(value).Name;

        // Checks if the specified value is a valid value for the enumeration
        public static bool HasValue<T>(int value) where T : Enumeration
        {
            try
            {
                FromValue<T>(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Parses the enumeration constant based on the specified predicate
        private static T Parse<T, TValue>(TValue value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
            }

            return matchingItem;
        }

        // Overrides the equality comparison method to compare two enumeration constants
        public override bool Equals(object? obj)
        {
            if (!(obj is Enumeration otherValue))
            {
                return false;
            }

            var typeMatches = this.GetType() == obj.GetType();
            var valueMatches = this.Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        // Overrides the hash code generation method based on the type and value of the enumeration constant
        public override int GetHashCode() => (this.GetType().ToString() + this.Value).GetHashCode();

        // Implements the IComparable interface to compare two enumeration constants
        public int CompareTo(object? other) => this.Value.CompareTo(((Enumeration)other!).Value);
    }
}

