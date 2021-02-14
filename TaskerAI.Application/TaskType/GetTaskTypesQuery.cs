namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Common;
    using TaskerAI.Domain;
    using TaskerAI.Domain.Entities;

    public class GetTaskTypesQuery : IRequest<Paged<TaskType>>
    {
        public GetTaskTypesQuery(string name, double? cost, int? duration, int? pageSize, int? pageIndex, string sortBy, string sortAs)
        {
            this.Name = name;
            this.Cost = cost;
            this.Duration = duration;
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.SortBy = sortBy;
            this.SortAs = sortAs;
        }

        public string Name { get; }
        public double? Cost { get; }
        public int? Duration { get; }
        public int? PageSize { get; }
        public int? PageIndex { get; }
        public string SortBy { get; }
        public string SortAs { get; }
    }

    public class GetTaskTypesQueryHandler : IRequestHandler<GetTaskTypesQuery, Paged<TaskType>>
    {
        private readonly ITaskTypeRepository repository;

        public GetTaskTypesQueryHandler(ITaskTypeRepository repository) => this.repository = repository;

        public Task<Paged<TaskType>> Handle(GetTaskTypesQuery request, CancellationToken cancellationToken)
        {
            return this.repository.GetAsync
            (
                request.Name,
                request.Cost,
                request.Duration,
                request.PageSize,
                request.PageIndex,
                request.SortBy,
                request.SortAs
            );
        }
    }
}