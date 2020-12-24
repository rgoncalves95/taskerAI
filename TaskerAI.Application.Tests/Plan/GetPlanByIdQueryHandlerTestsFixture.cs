namespace TaskerAI.Application.Tests.Plan
{
    using NSubstitute;
    using TaskerAI.Persistence;

    public class GetPlanByIdQueryHandlerTestsFixture 
    {
        public IPlanRepository PlanRepository { get; private set; }

        public GetPlanByIdQueryHandlerTestsFixture()
        {
            PlanRepository = Substitute.For<IPlanRepository>();
        }
    }
}
