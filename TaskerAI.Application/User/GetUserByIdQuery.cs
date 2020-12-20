namespace TaskerAI.Application.User
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;

    public class GetUserByIdQuery : IRequest<User>
    {
        public GetUserByIdQuery(int id) => Id = id;

        public int Id { get; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Domain.User>
    {
        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
