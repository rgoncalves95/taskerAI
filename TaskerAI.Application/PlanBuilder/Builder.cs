namespace TaskerAI.Application.PlanBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Builder
    {
        private List<RouteResult> _routeResults = new List<RouteResult>();
        private int MaxCount = 6;
        private int _count;
        private Task[] _path;
        Dictionary<(Guid, Guid), Route> _routes;

        public List<RouteResult> Build(List<Task> tasks, Dictionary<(Guid, Guid), Route> routes)
        {

            Console.WriteLine(DateTime.Now);
            _routes = routes;
            _count = tasks.Count > MaxCount ? MaxCount : tasks.Count;
            _path = new Task[tasks.Count];
            for (int i = 0; i < tasks.Count; i++)
            {
                _path[i] = tasks[i];
                Recursive(_path[i], tasks, new List<Task> { _path[i] });
            }




            var result = new List<RouteResult>();

            //Como exemplo retorna um que so tenha falhado uma tarefa, podia por tb p.TaskFailed == 1)  e que tenha a menor distancia percorrida
            var route = _routeResults.Where(p => p.TaskFailed < 2).OrderBy(p => p.TotalDistance).First();
            result.Add(route);

            //2 melhores resultados com tarefas a tempo
            result.AddRange(_routeResults.Where(p => p.TaskFailed == 0).OrderBy(p => p.TotalDistance).Take(2));

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



        private void Recursive(Task task, List<Task> tasks, List<Task> chainedTasks)
        {
            if (chainedTasks.Count == _count)
            {
                DoLogic(chainedTasks);
                return;
            }

            var filteredTasks = tasks.Except(chainedTasks);
            foreach (Task nextTask in filteredTasks)
            {
                Recursive(nextTask, tasks, new List<Task>(chainedTasks) { nextTask });
            }
        }

        private void DoLogic(List<Task> chainedTasks)
        {
            var routeResult = new RouteResult();
            if (chainedTasks.Count < 2) { return; }

            //maneira de definir a hora de comeco
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0);
            var distance = 0;
            for (int i = 0; i < chainedTasks.Count - 1; i++)
            {
                var start = chainedTasks[i];
                var end = chainedTasks[i + 1];
                if (i == 0)
                {
                    routeResult.StartTask = start.Id;
                }

                distance += _routes[(start.Id, end.Id)].Distance;
                //exacto
                startTime = startTime.AddSeconds(start.Duration).AddSeconds(_routes[(start.Id, end.Id)].TimeInSeconds);


                //duedate
                //var time = start.DueDate.AddSeconds(_routes[(start.Id, end.Id)].TimeInSeconds).AddSeconds(end.Duration);
                var taskResult = new TaskResult();
                taskResult.Id = end.Id;
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
            _routeResults.Add(routeResult);
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
