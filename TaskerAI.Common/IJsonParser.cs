namespace TaskerAI.Common
{
    public interface IJsonParser
    {
        T Deserialize<T>(string obj);
        string Serialize<T>(T obj);
    }
}