namespace TaskerAI.Application.PlanBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Builder
    {
        private readonly List<RouteResult> _routeResults = new List<RouteResult>();
        private readonly int MaxCount = 6;
        private int _count;
        private Domain.Entities.Task[] _path;
        private Dictionary<(int, int), Route> _routes;

        public List<RouteResult> Build(List<Domain.Entities.Task> tasks, Dictionary<(int, int), Route> routes)
        {

            Console.WriteLine(DateTime.Now);
            this._routes = routes;
            this._count = tasks.Count > this.MaxCount ? this.MaxCount : tasks.Count;
            this._path = new Domain.Entities.Task[tasks.Count];
            for (int i = 0; i < tasks.Count; i++)
            {
                this._path[i] = tasks[i];
                Recursive(this._path[i], tasks, new List<Domain.Entities.Task> { this._path[i] });
            }




            var result = new List<RouteResult>();

            //Como exemplo retorna um que so tenha falhado uma tarefa, podia por tb p.TaskFailed == 1)  e que tenha a menor distancia percorrida
            RouteResult route = this._routeResults.Where(p => p.TaskFailed < 2 && p.TaskFailed > 0).OrderBy(p => p.TotalDistance).FirstOrDefault();
            if (route != null)
            {
                result.Add(route);
            }
            

            //2 melhores resultados com tarefas a tempo
            result.AddRange(this._routeResults.Where(p => p.TaskFailed == 0).OrderBy(p => p.TotalDistance).Take(result.Count == 0 ? 3 : 2));

            /*
            Console.WriteLine("Total routes : " + _routeResults.Count);
            Console.WriteLine("Failed routes : " + _routeResults.Where(p => p.TaskFailed > 0).Count());
            foreach (var routeResult in _routeResults.Where(p => p.TaskFailed == 0))
            {
                foreach (var routeTask in routeResult.TaskResults)
                {
                    Console.WriteLine($"{routeTask.From} - {routeTask.To} ARRIVAL : {routeTask.EstimatedArrival}");
                }
                Console.WriteLine(routeResult.TotalDistance);
            }
            foreach (var routeTask in route.TaskResults)
            {
                Console.WriteLine($"{routeTask.From} - {routeTask.To} ARRIVAL : {routeTask.EstimatedArrival}");
            }
            Console.WriteLine(route.TotalDistance);

            */
            Console.WriteLine(DateTime.Now);

            return result;
        }



        private void Recursive(Domain.Entities.Task task, List<Domain.Entities.Task> tasks, List<Domain.Entities.Task> chainedTasks)
        {
            if (chainedTasks.Count == this._count)
            {
                DoLogic(chainedTasks);
                return;
            }

            IEnumerable<Domain.Entities.Task> filteredTasks = tasks.Except(chainedTasks);
            foreach (Domain.Entities.Task nextTask in filteredTasks)
            {
                Recursive(nextTask, tasks, new List<Domain.Entities.Task>(chainedTasks) { nextTask });
            }
        }

        private void DoLogic(List<Domain.Entities.Task> chainedTasks)
        {
            var routeResult = new RouteResult();
            if (chainedTasks.Count < 2) { return; }

            //maneira de definir a hora de comeco
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0);
            float distance = 0;
            for (int i = 0; i < chainedTasks.Count - 1; i++)
            {
                Domain.Entities.Task start = chainedTasks[i];
                Domain.Entities.Task end = chainedTasks[i + 1];
                if (i == 0)
                {
                    routeResult.StartTask = start.Id.Value;
                }

                distance += this._routes[(start.Id.Value, end.Id.Value)].Distance;
                //exacto
                startTime = startTime.AddSeconds(start.DurationInSeconds).AddSeconds(this._routes[(start.Id.Value, end.Id.Value)].TimeInSeconds);


                //duedate
                //var time = start.DueDate.AddSeconds(_routes[(start.Id, end.Id)].TimeInSeconds).AddSeconds(end.Duration);
                var taskResult = new TaskResult
                {
                    Id = end.Id.Value
                };
                if (end.DueDate < startTime)
                {
                    taskResult.SecondsLost = (startTime - end.DueDate).Seconds;
                }
                taskResult.EstimatedArrival = startTime;
                taskResult.From = start.DueDate;
                taskResult.To = end.DueDate;
                routeResult.TaskResults.Add(taskResult);
            }

            routeResult.TotalDistance = distance;
            this._routeResults.Add(routeResult);
        }


        /*
        private void DoLogicExact(List<Task> chainedTasks)
        {
            var routeResult = new RouteResult();
            if (chainedTasks.Count < 2) { return; }

            var distance = 0;
            for (int i = 0; i < chainedTasks.Count - 1; i++)
            {
                var start = chainedTasks[i];
                var end = chainedTasks[i + 1];

                distance += _routes[(start.Id, end.Id)].Distance;
                //exacto
                var time = start.DueDate.AddSeconds(start.Duration).AddSeconds(_routes[(start.Id, end.Id)].TimeInSeconds);


                //duedate
                //var time = start.DueDate.AddSeconds(_routes[(start.Id, end.Id)].TimeInSeconds).AddSeconds(end.Duration);
                var taskResult = new TaskResult();
                taskResult.Id = end.Id;
                if (end.DueDate < time)
                {
                    taskResult.SecondsLost = (time - end.DueDate).Seconds;
                }
                taskResult.EstimatedArrival = time;
                taskResult.From = start.DueDate;
                taskResult.To = end.DueDate;
                routeResult.TaskResults.Add(taskResult);
            }

            routeResult.TotalDistance = distance;
            _routeResults.Add(routeResult);
        }*/
    }
}
