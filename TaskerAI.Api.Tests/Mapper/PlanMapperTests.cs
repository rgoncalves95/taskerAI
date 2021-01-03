namespace TaskerAI.Api.Tests.Mapper
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TaskerAI.Api.Mapper;
    using TaskerAI.Domain;
    using Xunit;

    public class PlanMapperTests
    {
        [Fact]
        public void ShouldMapToNewPlanModelWhenMappingDomainPlan()
        {
            //Arrange
            DateTimeOffset now = DateTimeOffset.UtcNow;

            var sut = new PlanMapper();
            var plan = Plan.Create(10, new List<TaskRoute>(), now);

            //Act
            Models.PlanModel result = sut.Map(plan);

            //Assert
            result.Id.Should().Be(10);
            result.Date.Should().Be(now);
        }
    }
}
