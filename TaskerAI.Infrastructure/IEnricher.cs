namespace TaskerAI.Infrastructure
{
    using System.Threading.Tasks;
    public interface IEnricher<T>
    {
        Task EnrichAsync(T dto);
    }
}
