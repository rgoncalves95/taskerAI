namespace TaskerAI.Application
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using TaskerAI.Domain;

    public class GetTaskByIdQuery : IRequest<Domain.Task>
    {
        public int Id { get; }

        public GetTaskByIdQuery(int id) => this.Id = id;
    }

    public class GetTaskByIdQueryHandler : IRequestHandler<GetPlansQuery, Plan>
    {
        private readonly IPlanRepository repo;

        public GetTaskByIdQueryHandler(IPlanRepository repo) => this.repo = repo;

        public async Task<Plan> Handle(GetPlansQuery request, CancellationToken cancellationToken)
        {
            Plan plan = this.repo.GetPlan(0);

            return plan;
        }
    }
}
