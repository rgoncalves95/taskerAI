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
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) => _userRepository.GetAsync(request.Id);
    }
}
