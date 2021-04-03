namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Common;
    using TaskerAI.Domain;
    using TaskerAI.Domain.Entities;

    public class GetLocationsQuery : IRequest<Paged<Location>>
    {
        public GetLocationsQuery(string alias, string[] tags, int? pageSize, int? pageIndex, string sortBy, string sortAs)
        {
            this.Alias = alias;
            this.Tags = tags;
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.SortBy = sortBy;
            this.SortAs = sortAs;
        }

        public string Alias { get; }
        public string[] Tags { get; }
        public int? PageSize { get; }
        public int? PageIndex { get; }
        public string SortBy { get; }
        public string SortAs { get; }
    }

    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, Paged<Location>>
    {
        private readonly ILocationRepository repository;

        public GetLocationsQueryHandler(ILocationRepository repository) => this.repository = repository;

        public async Task<Paged<Location>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
            => await this.repository.GetAsync(request.Alias, request.Tags, request.PageSize, request.PageIndex, request.SortBy, request.SortAs);
    }
}