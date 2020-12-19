using MediatR;

namespace TaskerAI.Application
{
    public class CreatePlanCommand : IRequest
    {
        public string Name { get; }
        public string Description { get; }

        public CreatePlanCommand(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
