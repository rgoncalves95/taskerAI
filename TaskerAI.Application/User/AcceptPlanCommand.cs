namespace TaskerAI.Application.User
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using TaskerAI.Domain;


    public class AcceptPlanCommand : IRequest<Domain.Plan>
    {


        public AcceptPlanCommand(int userId, int planId)
        {
            UserId = userId;
            PlanId = planId;

        }

        public int UserId { get; }
        public int PlanId { get; }
    }

    public class AcceptPlanCommandHandler : IRequestHandler<AcceptPlanCommand, Domain.Plan>
    {
        private readonly IPlanRepository _planRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserFactory _userFactory;

        public AcceptPlanCommandHandler(IPlanRepository planRepository, IUserRepository userRepository, IUserFactory userFactory)
        {
            _planRepository = planRepository;
            _userRepository = userRepository;
            _userFactory = userFactory;
        }

        public async Task<Domain.Plan> Handle(AcceptPlanCommand request, CancellationToken cancellationToken)
        {

            var plan = _planRepository.GetPlan(request.PlanId);
            var user = _userRepository.GetUser(request.UserId);

            plan.Assign(_userFactory.CreateAssignee(user));
            return plan;

        }
    }
}