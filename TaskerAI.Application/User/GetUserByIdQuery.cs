namespace TaskerAI.Application
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TaskerAI.Domain;

    public class GetUserByIdQuery : IRequest<User>
    {
        public GetUserByIdQuery(int id) => this.Id = id;

        public int Id { get; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Domain.User>
    {
        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
