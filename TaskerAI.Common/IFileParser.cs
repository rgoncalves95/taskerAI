namespace TaskerAI.Common
{
    using System.IO;

    public interface IFileParser<T>
    {
        public T Parse(Stream stream);
    }
}
