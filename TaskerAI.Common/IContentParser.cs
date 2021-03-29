namespace TaskerAI.Common
{
    public interface IContentParser<T>
    {
        string ContentType { get; }
        T Parse(byte[] content);
    }
}