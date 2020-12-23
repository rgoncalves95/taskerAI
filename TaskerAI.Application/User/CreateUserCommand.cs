namespace TaskerAI.Application.User
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class CreateUserCommand : IRequest<Domain.User>
    {
        public CreateUserCommand(string email, string lastName, string firstName, string phone)
        {
            Email = email;
            LastName = lastName;
            FirstName = firstName;
            Phone = phone;
        }

        public string Email { get; }
        public string LastName { get; }
        public string FirstName { get; }
        public string Phone { get; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Domain.User>
    {
        public Task<Domain.User> Handle(CreateUserCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
