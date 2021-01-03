namespace TaskerAI.Application
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateBulkUsersCommand : IRequest<IEnumerable<Domain.User>>
    {

    }

    public class CreateBulkUsersCommandHandler : IRequestHandler<CreateBulkUsersCommand, IEnumerable<Domain.User>>
    {
        public Task<IEnumerable<Domain.User>> Handle(CreateBulkUsersCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}
