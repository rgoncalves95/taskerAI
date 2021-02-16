namespace TaskerAI.Infrastructure.Jobs
{
    public class WorkerOperation
    {
        public string Id { get; set; }
        public string JobId { get; set; }
        public string Entity { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
