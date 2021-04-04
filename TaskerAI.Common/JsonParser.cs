namespace TaskerAI.Common
{
    using System.Text.Json;

    public class JsonParser : IJsonParser
    {
        public string Serialize<T>(T obj) => JsonSerializer.Serialize(obj);

        public T Deserialize<T>(string obj) => JsonSerializer.Deserialize<T>(obj);
    }
}
