namespace TaskerAI.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int? Id { get; protected set; }
        protected abstract void IntegrityCheck();
    }
}
