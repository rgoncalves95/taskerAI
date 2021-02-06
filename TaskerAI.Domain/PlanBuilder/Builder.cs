namespace TaskerAI.Domain.PlanBuilder
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Builder
    {
        private readonly int MaxCount = 5;
        private readonly Task[] _path;

        public void Build(List<Task> tasks, List<Route> routes)
        {
            int count = tasks.Count > this.MaxCount ? this.MaxCount : tasks.Count;

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
            foreach (Task nextTask in tasks.Except(this._path))
            {
                depth++;
                this._path[depth] = nextTask;

            }

        }
    }
}
