[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("TaskerAI")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("TaskerAI.Application")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("TaskerAI.Infrastructure")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("TaskerAI.Database")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("TaskerAI.MockRepository")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("TaskerAI.Application.Tests")]
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("TaskerAI.Api.Tests")]
namespace TaskerAI.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int? Id { get; protected set; }
        protected abstract void IntegrityCheck();
    }
}
