using System.Reflection;

namespace CarRentalPlatform.Domain.Common
{
   
    // In Domain-Driven Design(DDD), a value object is equal to another if it has the same properties as the other object, and their values are equal.
    // Provides common functionality for value objects, such as equality comparison and hash code generation.
    public abstract class ValueObject
    {
        // Flags used for accessing private, non-public, and public instance fields via reflection
        private readonly BindingFlags privateBindingFlags =
           BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;

        // this method passes through the objects, gets their fields and compare them
        // if there are equar returns true, otherwise - false 
        public override bool Equals(object? other)
        {
            if (other == null)
            {
                return false;
            }

            var type = this.GetType();
            var otherType = other.GetType();

            if (type != otherType)
            {
                return false;
            }

            var fields = type.GetFields(this.privateBindingFlags);

            foreach (var field in fields)
            {
                var firstValue = field.GetValue(other);
                var secondValue = field.GetValue(this);

                if (firstValue == null)
                {
                    if (secondValue != null)
                    {
                        return false;
                    }
                }
                else if (!firstValue.Equals(secondValue))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Overrides the hash code generation method to compute a hash code based on the properties and values of the value object.
        /// </summary>
        /// <returns>The computed hash code as an integer.</returns>
        public override int GetHashCode()
        {
            var fields = this.GetFields();

            const int startValue = 17;
            const int multiplier = 59;

            return fields
                .Select(field => field.GetValue(this))
                .Where(value => value != null)
                .Aggregate(startValue, (current, value) => current * multiplier + value!.GetHashCode());
        }

        /// <summary>
        /// Retrieves all fields of the value object using reflection
        /// </summary>
        /// <returns>A collection of FieldInfo objects representing the fields.</returns>
        private IEnumerable<FieldInfo> GetFields()
        {
            var type = this.GetType();

            var fields = new List<FieldInfo>();

            while (type != typeof(object) && type != null)
            {
                fields.AddRange(type.GetFields(this.privateBindingFlags));

                type = type.BaseType!;
            }

            return fields;
        }

        /// <summary>
        /// Overrides the inequality operator (!=) to provide custom inequality comparison logic for instances of ValueObject.
        /// </summary>
        /// <param name="first">The first ValueObject instance to compare</param>
        /// <param name="second">The second ValueObject instance to compare</param>
        /// <returns>Returns true if the instances are not equal according to the equality operator (==), otherwise returns false.</returns>
        public static bool operator ==(ValueObject first, ValueObject second) => first.Equals(second);

        /// <summary>
        /// Overrides the inequality operator (!=) to provide custom inequality comparison logic for instances of ValueObject.
        /// </summary>
        /// <param name="first">The first ValueObject instance to compare.</param>
        /// <param name="second">The second ValueObject instance to compare.</param>
        /// <returns>Returns true if the instances are not equal according to the equality operator (==), otherwise returns false.</returns>
        
        public static bool operator !=(ValueObject first, ValueObject second) => !(first == second);

    }
}

