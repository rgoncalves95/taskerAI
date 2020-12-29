namespace TaskerAI.Application.Tests.Plan
{
    using NSubstitute;
    using Xunit;
    using Domain;
    using System.Threading;
    using FluentAssertions;
    using Common.Tests;

    public class GetPlanByIdQueryHandlerTests
    {
        [Theory]
        [AutoDomainData]
        public async void ShouldReturnPlanWhenIsRequested(GetPlanByIdQueryHandlerTestsFixture fixture)
        {
            ////Arrange
            //var plan = Plan.Create(1, "new plan");
            //fixture.PlanRepository.GetPlan(Arg.Any<int>()).Returns(plan);
            //var sut = new GetPlanByIdQueryHandler(fixture.PlanRepository);

            ////Act
            //var result = await sut.Handle(new GetPlansQuery(), CancellationToken.None);

            ////Assert
            //result.Should().NotBeNull();
            //result.Id.Should().Be(1);
            //result.Name.Should().Be("new plan");
        }
    }
}