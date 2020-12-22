namespace TaskerAI.Infrastructure
{
    public interface IMapper<Tin, Tout>
    {
        void Map(Tin from, Tout to);
        Tout Map(Tin from);
    }
}
