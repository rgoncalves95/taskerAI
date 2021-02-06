namespace TaskerAI.Common
{
    using System.Collections.Generic;

    public interface IMapper<Tin, Tout>
    {
        void Map(Tin from, Tout to);
        Tout Map(Tin from);
        void Map(IEnumerable<Tin> from, IEnumerable<Tout> to);
        IEnumerable<Tout> Map(IEnumerable<Tin> from);
    }
}
