﻿namespace TaskerAI.Application
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;


    public class AcceptPlanCommand : IRequest<Domain.Plan>
    {


        public AcceptPlanCommand(int userId, int planId)
        {
            this.UserId = userId;
            this.PlanId = planId;

        }

        public int UserId { get; }
        public int PlanId { get; }
    }

    public class AcceptPlanCommandHandler : IRequestHandler<AcceptPlanCommand, Domain.Plan>
    {
        private readonly IPlanRepository _planRepository;
        private readonly IUserRepository _userRepository;

        public AcceptPlanCommandHandler(IPlanRepository planRepository, IUserRepository userRepository)
        {
            this._planRepository = planRepository;
            this._userRepository = userRepository;
        }

        public async Task<Domain.Plan> Handle(AcceptPlanCommand request, CancellationToken cancellationToken)
        {

            Plan plan = this._planRepository.GetPlan(request.PlanId);
            User user = await this._userRepository.GetAsync(request.UserId);

            plan.Assign(UserFactory.CreateAssignee(user));
            return plan;

        }
    }
}