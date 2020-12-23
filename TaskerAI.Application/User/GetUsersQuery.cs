namespace TaskerAI.Application.User
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;

    public class GetUsersQuery : IRequest<IEnumerable<Domain.User>>
    {
        public DateTimeOffset? AvailabilityStartDate { get; }
        public DateTimeOffset? AvailabilityEndDate { get; }
        public string Latitude { get; }
        public string Longitude { get; }
        public string Name { get; }

        public GetUsersQuery(DateTimeOffset? availabilityStartDate, DateTimeOffset? availabilityEndDate, string latitude, string longitude, string name)
        {
            AvailabilityStartDate = availabilityStartDate;
            AvailabilityEndDate = availabilityEndDate;
            Latitude = latitude;
            Longitude = longitude;
            Name = name;
        }
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<Domain.User>>
    {
        Task<IEnumerable<User>> IRequestHandler<GetUsersQuery, IEnumerable<User>>.Handle(GetUsersQuery request, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
