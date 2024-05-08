using Blogger.Domain.Common;
using FluentAssertions;

namespace Blogger.UnitTests.BuldingBlocks.Domain;
public class ValueObjectTests
{
    [Fact]
    public void value_objects_of_diffrent_type_should_not_be_equal()
    {
        // arrange
        var valueObjectA = new Address
        {
            City = "Saqqez",
            PostalCode = "66123812",
            State = "Kurdestan"
        };

        var valueObjectB = new Price
        {
            Corrency = "Dollars",
            Value = 12
        };

        // act & assert

        (valueObjectA == valueObjectB).Should().BeFalse();
        (valueObjectA != valueObjectB).Should().BeTrue();

        valueObjectA.Equals(valueObjectB).Should().BeFalse();
        valueObjectB.Equals(valueObjectA).Should().BeFalse();

        (valueObjectB.GetHashCode() == valueObjectA.GetHashCode()).Should().BeFalse();
    }

    [Fact]
    public void value_objects_of_same_type_should_be_equal_when_values_match()
    {
        // arrange
        var valueObjectA = new Address
        {
            City = "Saqqez",
            PostalCode = "66123812",
            State = "Kurdestan"
        };

        var valueObjectB = new Address
        {
            City = "Saqqez",
            PostalCode = "66123812",
            State = "Kurdestan"
        };

        // act & assert
        (valueObjectA == valueObjectB).Should().BeTrue();
        (valueObjectA != valueObjectB).Should().BeFalse();

        valueObjectA.Equals(valueObjectB).Should().BeTrue();
        valueObjectB.Equals(valueObjectA).Should().BeTrue();

        (valueObjectB.GetHashCode() == valueObjectA.GetHashCode()).Should().BeTrue();
    }

    [Fact]
    public void value_objects_of_same_type_should_not_be_equal_when_values_are_different()
    {
        // arrange
        var valueObjectA = new Address
        {
            City = "Tehran",
            PostalCode = "66123812",
            State = "Kurdestan"
        };

        var valueObjectB = new Address
        {
            City = "Saqqez",
            PostalCode = "66123812",
            State = "Kurdestan"
        };

        // act & assert
        (valueObjectA == valueObjectB).Should().BeFalse();
        (valueObjectA != valueObjectB).Should().BeTrue();

        valueObjectA.Equals(valueObjectB).Should().BeFalse();
        valueObjectB.Equals(valueObjectA).Should().BeFalse();

        (valueObjectB.GetHashCode() == valueObjectA.GetHashCode()).Should().BeFalse();
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
