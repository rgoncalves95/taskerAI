namespace TaskerAI.Infrastructure
{
    public interface IEnricher<T>
    {
        void Enrich(T dto);
    }
}
