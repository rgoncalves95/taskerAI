namespace TaskerAI.Application
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetTasksQuery : IRequest<Domain.Task>
    {
    }

    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, Domain.Task>
    {
        public Task<Domain.Task> Handle(GetTasksQuery request, CancellationToken cancellationToken) => throw new System.NotImplementedException();
    }
}
