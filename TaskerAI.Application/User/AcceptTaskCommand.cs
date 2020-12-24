using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskerAI.Domain;
using TaskerAI.Persistence;

namespace TaskerAI.Application.User
{


    public class AcceptTaskCommand : IRequest<Domain.Task>
    {


        public AcceptTaskCommand(int userId, int taskId)
        {
            UserId = userId;
            TaskId = taskId;

        }

        public int UserId { get; }
        public int TaskId { get; }
    }

    public class AcceptTaskCommandHandler : IRequestHandler<AcceptTaskCommand, Domain.Task>
    {
        private readonly ITaskRepository repo;

        public AcceptTaskCommandHandler(ITaskRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Domain.Task> Handle(AcceptTaskCommand request, CancellationToken cancellationToken)
        {

            var result = repo.GetTask(1);

            return result;

        }
    }
}