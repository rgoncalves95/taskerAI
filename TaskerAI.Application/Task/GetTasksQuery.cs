namespace TaskerAI.Application
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Common;
    using TaskerAI.Domain;

    public class GetTasksQuery : IRequest<Paged<Domain.Entities.Task>>
    {
        public GetTasksQuery
        (
            string name,
            int? type,
            DateTimeOffset? intervalStart,
            DateTimeOffset? intervalEnd,
            int? status,
            int? pageSize,
            int? pageIndex,
            string sortBy,
            string sortAs
        )
        {
            this.Name = name;
            this.Type = type;
            this.IntervalStart = intervalStart;
            this.IntervalEnd = intervalEnd;
            this.Status = status;
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.SortBy = sortBy;
            this.SortAs = sortAs;
        }

        public string Name { get; }
        public int? Type { get; }
        public DateTimeOffset? IntervalStart { get; }
        public DateTimeOffset? IntervalEnd { get; }
        public int? Status { get; }
        public int? PageSize { get; }
        public int? PageIndex { get; }
        public string SortBy { get; }
        public string SortAs { get; }
    }

    public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, Paged<Domain.Entities.Task>>
    {
        private readonly ITaskRepository repository;

        public GetTasksQueryHandler(ITaskRepository respository) => this.repository = respository;

        public async Task<Paged<Domain.Entities.Task>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
        {
            return await this.repository.GetAsync
            (
                request.Name,
                request.Type,
                request.IntervalStart,
                request.IntervalEnd,
                request.Status,
                request.PageSize,
                request.PageIndex,
                request.SortBy,
                request.SortAs
            );
        }
    }
}
