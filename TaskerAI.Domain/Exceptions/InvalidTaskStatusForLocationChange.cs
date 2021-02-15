namespace TaskerAI.Domain.Exceptions
{
    public class InvalidTaskStatusForLocationChange : DomainException
    {
        public InvalidTaskStatusForLocationChange(TaskStatus status)
            : base($"Invalid attempt to change Task location. Task status is {status}, so location cannot be changed")
        {
        }
    }
}
