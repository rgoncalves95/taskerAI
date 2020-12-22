namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;
    using TaskerAI.Persistence;

    public class GetPlanByIdQuery : IRequest<Plan>
    {
        public int Id { get; }

        public GetPlanByIdQuery(int id) => Id = id;
    }

    public class GetPlanByIdQueryHandler : IRequestHandler<GetPlansQuery, Plan>
    {
        private readonly IPlanRepository repo;

        public GetPlanByIdQueryHandler(IPlanRepository repo) => this.repo = repo;

        public async Task<Plan> Handle(GetPlansQuery request, CancellationToken cancellationToken)
        {
            var plan = repo.GetPlan(0);

            return plan;
        }
    }
}
