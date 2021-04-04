namespace TaskerAI.Infrastructure.Dto.Enrichers
{
    using System.Threading.Tasks;

    public class TaskGeolocationEnricher : GeolocationEnricher, IEnricher<TaskDto>
    {
        public TaskGeolocationEnricher(IGeolocationProvider geolocationProvider)
            : base(geolocationProvider)
        {
        }

        public Task EnrichAsync(TaskDto dto) => base.EnrichAsync(dto.Location);
    }
}
