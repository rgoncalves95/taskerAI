namespace TaskerAI.Api.Tests.Mapper
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using TaskerAI.Api.Mapper;
    using TaskerAI.Domain;
    using Xunit;

    public class PlanMapperTests
    {
        [Fact]
        public void ShouldMapToNewPlanModelWhenMappingDomainPlan()
        {
            //Arrange
            var now = DateTimeOffset.UtcNow;

            var sut = new PlanMapper();
            var plan = Plan.Create(10, new List<TaskRoute>(), now);

            //Act
            var result = sut.Map(plan);

            //Assert
            result.Id.Should().Be(10);
            result.Date.Should().Be(now);
        }
    }
}
