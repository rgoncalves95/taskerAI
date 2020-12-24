namespace TaskerAI.Application.Tests.Plan
{
    using NSubstitute;
    using Xunit;
    using Domain;
    using System.Threading;
    using FluentAssertions;

    public class GetPlanByIdQueryHandlerTests : IClassFixture<GetPlanByIdQueryHandlerTestsFixture>
    {
        private readonly GetPlanByIdQueryHandlerTestsFixture _fixture;

        public GetPlanByIdQueryHandlerTests(GetPlanByIdQueryHandlerTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void ShouldReturnPlanWhenIsRequested()
        {
            //Arrange
            var plan = Plan.Create(1, "new plan");
            _fixture.PlanRepository.GetPlan(Arg.Any<int>()).Returns(plan);
            var sut = new GetPlanByIdQueryHandler(_fixture.PlanRepository);

            //Act
            var result = await sut.Handle(new GetPlansQuery(), CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Name.Should().Be("new plan");
        }
    }
}