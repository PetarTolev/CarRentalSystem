namespace CarRentalSystem.Domain.Common
{
    using CarRentalSystem.Domain.Models.CarAds;
    using FluentAssertions;
    using Xunit;

    public class EntitySpecs
    {
        [Fact]
        public void EntitiesWithSameIdsShouldBeEqual()
        {
            var first = new Manufacturer("First").SetId(1);
            var second = new Manufacturer("second").SetId(1);

            var result = first == second;

            result.Should().BeTrue();
        }

        [Fact]
        public void EntitiesWithDifferentIdsShouldNotBeEqual()
        {
            var first = new Manufacturer("First").SetId(1);
            var second = new Manufacturer("second").SetId(2);

            var result = first == second;

            result.Should().BeFalse();
        }

        [Fact]
        public void EntityAndNullShouldNotBeEqual()
        {
            var first = new Manufacturer("First");
            var second = (Manufacturer?)null!;

            var result = first == second;

            result.Should().BeFalse();
        }
    }

    internal static class EntityExtensions
    {
        public static Entity<T> SetId<T>(this Entity<T> entity, int id)
            where T : struct
        {
            entity
                .GetType()
                .BaseType!
                .GetProperty(nameof(Entity<T>.Id))!
                .GetSetMethod(true)!
                .Invoke(entity, new object[] { id });

            return entity;
        }
    }
}
