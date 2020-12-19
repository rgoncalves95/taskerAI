using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskerAI.Domain;
using TaskerAI.Persistence;

namespace TaskerAI.Application
{
    public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand>
    {
        private readonly IPlanRepository repo;

        public CreatePlanCommandHandler(IPlanRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Unit> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = Plan.Create(request.Name);

            return Unit.Value;
        }
    }
}
