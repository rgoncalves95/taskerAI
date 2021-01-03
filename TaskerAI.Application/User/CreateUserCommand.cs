namespace TaskerAI.Application
{
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUserCommand : IRequest<Domain.User>
    {
        public CreateUserCommand(string email, string lastName, string firstName, string phone)
        {
            this.Email = email;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Phone = phone;
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
