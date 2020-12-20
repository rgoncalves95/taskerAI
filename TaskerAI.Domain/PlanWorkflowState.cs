namespace TaskerAI.Domain
{
    public enum PlanWorkflowState
    {
        Draft,
        Created,
        PendingApproval,
        Approved,
        Started,
        Completed,
        Cancelled,
        Deleted
    }
}
