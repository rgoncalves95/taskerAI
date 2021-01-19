namespace TaskerAI.Domain
{
    public abstract class BaseEntity
    {
        public int? Id { get; protected set; }
        protected abstract void IntegrityCheck();
    }
}
