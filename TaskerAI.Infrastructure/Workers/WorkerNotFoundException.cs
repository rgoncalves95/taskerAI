namespace TaskerAI.Infrastructure.Workers
{
    using System;

    public class WorkerNotFoundException : Exception
    {
        public WorkerNotFoundException(string message) : base(message)
        {

        }
    }
}
