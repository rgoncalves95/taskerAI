namespace TaskerAI.Domain.Exceptions
{
    using System.Collections.Generic;

    public class EntityIntegrityException : DomainException
    {
        public IEnumerable<string> IntegrityFaults { get; private set; }

        public EntityIntegrityException(string entityName, IEnumerable<string> messages) : base($"{entityName} Integrity Fault") => this.IntegrityFaults = messages;
    }
}
