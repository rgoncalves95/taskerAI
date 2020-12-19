namespace TaskerAI.Infrastructure
{
    public interface IMapper<Tin, Tout>
    {
        void Map<Tin, Tout>(Tin from, Tout to);
    }
}
