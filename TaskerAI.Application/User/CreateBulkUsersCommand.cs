namespace TaskerAI.Application.User
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class CreateBulkUsersCommand : IRequest<IEnumerable<Domain.User>>
    {

    }

    public class CreateBulkUsersCommandHandler : IRequestHandler<CreateBulkUsersCommand, IEnumerable<Domain.User>>
    {
        public Task<IEnumerable<Domain.User>> Handle(CreateBulkUsersCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
