namespace TaskerAI.Application
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using TaskerAI.Domain;

    public class GetPlansQuery : IRequest<Plan>
    {
    }

    public class GetPlansQueryHandler : IRequestHandler<GetPlansQuery, Plan>
    {
        private readonly IPlanRepository repo;

        public GetPlansQueryHandler(IPlanRepository repo) => this.repo = repo;

        public async Task<Plan> Handle(GetPlansQuery request, CancellationToken cancellationToken)
        {
            Plan plan = this.repo.GetPlan(0);

            return plan;
        }
    }
}
