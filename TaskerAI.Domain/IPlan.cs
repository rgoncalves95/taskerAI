namespace TaskerAI.Domain
{
    using System;
    using System.Collections.Generic;

    internal interface IPlan
    {
        int Id { get; }
        string Name { get; }
        List<Task> Tasks { get; }
        User Accountable { get; }
        User Responsible { get; }
        DateTimeOffset Date { get; }
        int Status { get; }
    }
}
