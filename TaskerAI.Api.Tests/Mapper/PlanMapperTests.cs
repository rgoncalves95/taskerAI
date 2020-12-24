using System;
using FluentAssertions;
using TaskerAI.Api.Mapper;
using TaskerAI.Domain;
using Xunit;

namespace TaskerAI.Api.Tests.Mapper
{
    public class PlanMapperTests
    {
        [Fact]
        public void ShouldMapToNewPlanModelWhenMappingDomainPlan()
        {
            //Arrange
            var sut = new PlanMapper();
            var plan = Plan.Create(10, "new plan name");

            //Act
            var result = sut.Map(plan);

            //Assert
            result.Id.Should().Be(10);
        }
    }
}
