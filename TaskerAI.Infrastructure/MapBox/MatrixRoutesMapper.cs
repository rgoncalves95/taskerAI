namespace TaskerAI.Infrastructure.MapBox
{
    using System.Collections.Generic;
    using System.Linq;
    using TaskerAI.Common;
    using TaskerAI.Infrastructure.Dto;

    internal class MatrixRoutesMapper : IMapper<MatrixResponse, MatrixRouteDto>
    {
        public void Map(MatrixResponse from, MatrixRouteDto to)
        {
            to.Distances = from.Distances;
            to.Durations = from.Durations;
        }

        public MatrixRouteDto Map(MatrixResponse from)
        {
            var to = new MatrixRouteDto();
            Map(from, to);
            return to;
        }

        public void Map(IEnumerable<MatrixResponse> from, IEnumerable<MatrixRouteDto> to) => to = from.Select(f => Map(f)).ToArray();

        public IEnumerable<MatrixRouteDto> Map(IEnumerable<MatrixResponse> from) => from.Select(f => Map(f)).ToArray();
    }
}
