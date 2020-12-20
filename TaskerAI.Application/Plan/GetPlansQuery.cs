namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
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
            var plan = repo.GetPlan(0);

            return plan;
        }
    }
}
