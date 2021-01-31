namespace TaskerAI.Application
{
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TaskerAI.Domain;

    public class GetTasksQuery : IRequest<IEnumerable<Domain.Task>>
    {
    }

    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<Domain.Task>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTasksQueryHandler(ITaskRepository taskRepository) => _taskRepository = taskRepository;
    
        public Task<IEnumerable<Domain.Task>> Handle(GetTasksQuery request, CancellationToken cancellationToken) => _taskRepository.GetAsync();
    }
}
