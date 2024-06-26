﻿namespace CarRentalPlatform.Domain.Common
{
    // Base abstract class for domain entities, providing a common structure for entities with a generic identifier.
    // The generic type parameter TId specifies the type of the entity's unique identifier.
    public abstract class Entity<TId> where TId : struct
    {
        // An unique identifier of the entity
        public TId Id { get; private set; } = default;

        // Override the Equals method to provide custom equality comparison logic for instances of the Entity<TId> class
        public override bool Equals(object? obj)
        {
            // Check if obj is of type Entity<TId>
            if (obj is not Entity<TId> other)
            {
                return false;
            }

            // Check if obj and this refer to the same object in memory
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            // Check if runtime types of this and obj are the same
            if (this.GetType() != other.GetType())
            {
                return false;
            }

            // Check if either this or obj has a default Id value
            if (this.Id.Equals(default) || other.Id.Equals(default))
            {
                return false;
            }

            // Compare Id values of this and obj
            return this.Id.Equals(other.Id);
        }

        // Overloads the equality operator (==) to provide custom equality comparison logic for instances of the Entity<TId> class 
        public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
        {
            // Check if both instances are null
            if (first is null && second is null)
            {
                return true;
            }

            // Check if one of the instances is null
            if (first is null || second is null)
            {
                return false;
            }

            // Delegate the comparison to the Equals method of the Entity<TId> class
            return first.Equals(second);
        }

        // Overloads the inequality operator (!=) to provide custom inequality comparison logic for instances of the Entity<TId> class.
        // Allows comparing two instances of Entity<TId> for inequality.
        // Returns true if the instances are not equal according to the equality operator (==).
        // Otherwise, returns false.
        public static bool operator !=(Entity<TId>? first, Entity<TId>? second) => !(first == second);

        // Overrides the GetHashCode method to provide a custom hash code calculation for instances of the Entity<TId> class.
        // Computes the hash code based on the combination of the runtime type of the object and its unique identifier (Id).
        // The hash code is generated by concatenating the type name with the string representation of the Id
        // and then computing the hash code of the resulting string.
        // Returns the computed hash code as an integer.
        public override int GetHashCode() => (this.GetType().ToString() + this.Id).GetHashCode();
    }
}
