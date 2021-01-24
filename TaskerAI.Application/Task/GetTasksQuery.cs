namespace TaskerAI.Application
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TaskerAI.Domain;

    public class GetTasksQuery : IRequest<IEnumerable<Domain.Task>>
    {
        public GetTasksQuery(string name, int? type, DateTimeOffset? intervalStart, DateTimeOffset? intervalEnd, int? status)
        {
            this.Name = name;
            this.Type = type;
            this.IntervalStart = intervalStart;
            this.IntervalEnd = intervalEnd;
            this.Status = status;
        }

        public string Name { get; }
        public int? Type { get; }
        public DateTimeOffset? IntervalStart { get; }
        public DateTimeOffset? IntervalEnd { get; }
        public int? Status { get; }
    }

    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, IEnumerable<Domain.Task>>
    {
        private readonly ITaskRepository repo;

        public GetTasksQueryHandler(ITaskRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Domain.Task>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            return await this.repo.GetAsync(request.Name, request.Type, request.IntervalStart, request.IntervalEnd, request.Status);
        }
    }
}
