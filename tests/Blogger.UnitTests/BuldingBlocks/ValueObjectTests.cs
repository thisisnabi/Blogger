using Blogger.BuildingBlocks.Domain;

using FluentAssertions;

namespace Blogger.UnitTests.BuldingBlocks;
public class ValueObjectTests
{
    [Fact]
    public void value_objects_of_different_type_should_not_be_equal()
    {
        // Arrange
        var valueObjectA = new Address
        {
            City = "Saqqez",
            PostalCode = "12345",
            State = "Kurdestan"
        };

        var valueObjectB = new Price
        {
            Corrency = "IRR",
            Value = decimal.Zero,
        };

        // Act & Assert
        (valueObjectA == valueObjectB).Should().BeFalse();
        (valueObjectA != valueObjectB).Should().BeTrue();

        valueObjectB.Equals(valueObjectA).Should().BeFalse();
        valueObjectA.Equals(valueObjectB).Should().BeFalse();

        (valueObjectA.GetHashCode() == valueObjectB.GetHashCode()).Should().BeFalse();
    }

    [Fact]
    public void value_objects_of_same_types_should_be_equal_when_values_match()
    {
        // Arrange
        var valueObjectA = new Address
        {
            City = "Saqqez",
            PostalCode = "12345",
            State = "Kurdestan"
        };

        var valueObjectB = new Address
        {
            City = "Saqqez",
            PostalCode = "12345",
            State = "Kurdestan"
        };

        // Act & Assert
        (valueObjectA == valueObjectB).Should().BeTrue();
        (valueObjectA != valueObjectB).Should().BeFalse();

        valueObjectA.Equals(valueObjectB).Should().BeTrue();
        valueObjectB.Equals(valueObjectA).Should().BeTrue();

        (valueObjectA.GetHashCode() == valueObjectB.GetHashCode()).Should().BeTrue();
    }

    [Fact]
    public void value_objects_of_same_type_should_be_not_equal_when_values_diffrent()
    {
        // Arrange
        var valueObjectA = new Address
        {
            City = "Tehran",
            PostalCode = "12345",
            State = "Tehran"
        };

        var valueObjectB = new Address
        {
            City = "Saqqez",
            PostalCode = "12345",
            State = "Kurdestan"
        };

        // Act & Assert
        (valueObjectA == valueObjectB).Should().BeFalse();
        (valueObjectA != valueObjectB).Should().BeTrue();

        valueObjectA.Equals(valueObjectB).Should().BeFalse();
        valueObjectB.Equals(valueObjectA).Should().BeFalse();

        (valueObjectA.GetHashCode() == valueObjectB.GetHashCode()).Should().BeFalse();
    }

    private class Address : ValueObject<Address>
    {
        public required string City { get; init; }
        public required string State { get; init; }
        public required string PostalCode { get; init; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return State;
            yield return PostalCode;
        }
    }

    private class Price : ValueObject<Address>
    {
        public required string Corrency { get; init; }
        public required decimal Value { get; init; }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Corrency;
            yield return Value;
        }
    }
}
