using System.Reflection;

namespace JobMaster.Domain.Common.Models;

public class ValueObject
{
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;
        return GetValues().SequenceEqual(other.GetValues());
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return GetValues()
                .Aggregate(17, (current, value) => current * 23 + value.GetHashCode());
        }
    }

    private IEnumerable<object> GetValues()
    {
        return GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Select(field => field.GetValue(this) ?? 0);
    }
}