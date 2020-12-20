namespace TaskerAI.Application.Tests.Plan
{
    using AutoFixture;
    using TaskerAI.Domain;

    public class GetPlanByIdQueryHandlerTestsFixture 
    {
        public IPlanRepository PlanRepository { get; private set; }

        public GetPlanByIdQueryHandlerTestsFixture(IFixture fixture)
        {
            PlanRepository = fixture.Create<IPlanRepository>();
        }
    }
}
