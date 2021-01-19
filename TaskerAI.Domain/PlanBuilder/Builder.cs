namespace TaskerAI.Domain.PlanBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Builder
    {
        private int MaxCount = 5;
        private Task[] _path;

        public void Build(List<Task> tasks, List<Route> routes)
        {
            int count = tasks.Count > MaxCount ? MaxCount : tasks.Count;
            
            foreach (Task task in tasks)
            {
                var _path = new Task[count];
                int depth = 0;
                _path[depth] = task;

                Recursive(depth, task, tasks);
                //clone lista
            }
        }

        private void Recursive(int depth, Task task, List<Task> tasks)
        {
            foreach (Task nextTask in tasks.Except(_path))
            {
                depth++;
                _path[depth] = nextTask;

            }
            
        }
    }
}
