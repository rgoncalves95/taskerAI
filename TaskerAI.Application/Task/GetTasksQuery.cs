namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetTasksQuery : IRequest<Domain.Task>
    {
    }

    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, Domain.Task>
    {
        public Task<Domain.Task> Handle(GetTasksQuery request, CancellationToken cancellationToken) => throw new System.NotImplementedException();
    }
}
