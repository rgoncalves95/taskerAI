namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;

    public class GetPlanByIdQuery : IRequest<Plan>
    {
        public int Id { get; }

        public GetPlanByIdQuery(int id) => this.Id = id;
    }

    public class GetPlanByIdQueryHandler : IRequestHandler<GetPlansQuery, Plan>
    {
        private readonly IPlanRepository repo;

        public GetPlanByIdQueryHandler(IPlanRepository repo) => this.repo = repo;

        public async Task<Plan> Handle(GetPlansQuery request, CancellationToken cancellationToken)
        {
            Plan plan = this.repo.GetPlan(0);

            return plan;
        }
    }
}
