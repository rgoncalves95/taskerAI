namespace TaskerAI.Infrastructure
{
    using System.Threading.Tasks;
    using TaskerAI.Infrastructure.Dto;

    public interface IMatrixRouteProvider
    {
        Task<MatrixRouteDto> GetMatrixRoutes(float[][] coordinates);
    }
}
