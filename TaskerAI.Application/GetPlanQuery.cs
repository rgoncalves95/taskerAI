using MediatR;
using TaskerAI.Domain;

namespace TaskerAI.Application
{
    public class GetPlanQuery : IRequest<Plan>
    {
        public int Id { get; }

        public GetPlanQuery(int id)
        {
            this.Id = id;
        }
    }
}
