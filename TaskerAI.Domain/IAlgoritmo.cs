using System;
using System.Collections.Generic;

namespace TaskerAI.Domain
{
    interface IAlgoritmo
    {
        Plan CreatePlan(List<Task> tasks, int maxTasks, int maxTimeInMinutes, Location location, int radius, DateTime planDateTime);
    }
}