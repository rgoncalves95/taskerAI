using TaskerAI.Domain;

namespace TaskerAI.Application
{
    class Algoritmo : IAlgoritmo
    {
        private readonly ITimeDistance timeDistance;

        public Algoritmo(ITimeDistance timeDistance)
        {
            this.timeDistance = timeDistance;
        }

        public Domain.Plan CreatePlan()
        {
            return new Domain.Plan();
        }
    }
}
