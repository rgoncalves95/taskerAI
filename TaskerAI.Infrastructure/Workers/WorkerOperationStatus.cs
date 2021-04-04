namespace TaskerAI.Infrastructure.Workers
{
    using System.Collections.Generic;

    public class WorkerOperationStatus
    {
        public string OperationId { get; set; }
        public int Status { get; set; }
        public List<string> FailureReasons { get; set; }
    }
}
