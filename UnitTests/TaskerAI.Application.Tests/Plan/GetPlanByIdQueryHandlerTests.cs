namespace TaskerAI.Application.Tests.Plan
{
    using Domain;
    using FluentAssertions;
    using global::Tests.Common;
    using NSubstitute;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Xunit;

    public class GetPlanByIdQueryHandlerTests
    {
        [Theory]
        [AutoDomainData]
        public async void ShouldReturnPlanWhenIsRequested(GetPlanByIdQueryHandlerTestsFixture fixture)
        {
            //Arrange
            var plan = Plan.Create(10, new List<TaskRoute>(), DateTimeOffset.UtcNow);
            fixture.PlanRepository.GetPlan(Arg.Any<int>()).Returns(plan);
            var sut = new GetPlanByIdQueryHandler(fixture.PlanRepository);

            //Act
            Plan result = await sut.Handle(new GetPlansQuery(), CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Name.Should().Be("new plan");
        }
    }
}