namespace TaskerAI.Application.PlanBuilder
{
    using System;
    using System.Collections.Generic;

    internal class DemoData
    {
        public List<Task> GetTasks()
        {
            var task = new List<Task>();
            var spot1 = new Task { Display = "Rua Pedro Hispano", Id = 1, DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0), Duration = 1800, Latitude = 41.16631978314229, Longitude = -8.628359301804583 };
            task.Add(spot1);
            var spot2 = new Task { Display = "Rua 5 Outubro", Id = 2, DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0), Duration = 1800, Latitude = 41.159793151840326, Longitude = -8.630722501804744 };
            task.Add(spot2);
            var spot3 = new Task { Display = "Rua dos Vanzeleres", Id = 3, DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 3, 0), Duration = 1800, Latitude = 41.16036735049578, Longitude = -8.632483544133414 };
            task.Add(spot3);
            var spot4 = new Task { Display = "Rua da Boavista", Id = 4, DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 0, 0), Duration = 1800, Latitude = 41.15568979550674, Longitude = -8.615541315297849 };
            task.Add(spot4);
            var spot5 = new Task { Display = "Rua do Almada", Id = 5, DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0), Duration = 1800, Latitude = 41.15097122271649, Longitude = -8.612106444133595 };
            task.Add(spot5);
            var spot6 = new Task { Display = "Rua de Entreparedes", Id = 6, DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0), Duration = 1800, Latitude = 41.1455248852477, Longitude = -8.605598501805044 };
            task.Add(spot6);

            return task;
        }

        public Dictionary<(int, int), Route> GetRoutes(List<Task> tasks)
        {
            Task spot1 = tasks[0];
            Task spot2 = tasks[1];
            Task spot3 = tasks[2];
            Task spot4 = tasks[3];
            Task spot5 = tasks[4];
            Task spot6 = tasks[5];

            var routes = new Dictionary<(int, int), Route>();
            var route = new Route { From = spot1.Id, To = spot2.Id, Distance = 1000, TimeInSeconds = 120 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot2.Id, To = spot1.Id, Distance = 1700, TimeInSeconds = 300 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot1.Id, To = spot3.Id, Distance = 1600, TimeInSeconds = 180 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot3.Id, To = spot1.Id, Distance = 1200, TimeInSeconds = 180 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot1.Id, To = spot4.Id, Distance = 3400, TimeInSeconds = 420 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot4.Id, To = spot1.Id, Distance = 2100, TimeInSeconds = 300 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot1.Id, To = spot5.Id, Distance = 3500, TimeInSeconds = 480 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot5.Id, To = spot1.Id, Distance = 3700, TimeInSeconds = 540 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot1.Id, To = spot6.Id, Distance = 5200, TimeInSeconds = 600 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot6.Id, To = spot1.Id, Distance = 4300, TimeInSeconds = 660 };
            routes.Add((route.From, route.To), route);

            route = new Route { From = spot2.Id, To = spot3.Id, Distance = 600, TimeInSeconds = 120 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot3.Id, To = spot2.Id, Distance = 500, TimeInSeconds = 60 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot2.Id, To = spot4.Id, Distance = 2600, TimeInSeconds = 360 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot4.Id, To = spot2.Id, Distance = 2300, TimeInSeconds = 420 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot2.Id, To = spot5.Id, Distance = 2500, TimeInSeconds = 360 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot5.Id, To = spot2.Id, Distance = 3800, TimeInSeconds = 540 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot2.Id, To = spot6.Id, Distance = 4900, TimeInSeconds = 600 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot6.Id, To = spot2.Id, Distance = 4400, TimeInSeconds = 660 };
            routes.Add((route.From, route.To), route);

            route = new Route { From = spot3.Id, To = spot4.Id, Distance = 2900, TimeInSeconds = 360 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot4.Id, To = spot3.Id, Distance = 1800, TimeInSeconds = 300 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot3.Id, To = spot5.Id, Distance = 3000, TimeInSeconds = 420 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot5.Id, To = spot3.Id, Distance = 3300, TimeInSeconds = 420 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot3.Id, To = spot6.Id, Distance = 4700, TimeInSeconds = 600 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot6.Id, To = spot3.Id, Distance = 3800, TimeInSeconds = 540 };
            routes.Add((route.From, route.To), route);

            route = new Route { From = spot4.Id, To = spot5.Id, Distance = 1400, TimeInSeconds = 240 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot5.Id, To = spot4.Id, Distance = 1300, TimeInSeconds = 240 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot4.Id, To = spot6.Id, Distance = 2800, TimeInSeconds = 480 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot6.Id, To = spot4.Id, Distance = 2100, TimeInSeconds = 360 };
            routes.Add((route.From, route.To), route);

            route = new Route { From = spot5.Id, To = spot6.Id, Distance = 2400, TimeInSeconds = 540 };
            routes.Add((route.From, route.To), route);
            route = new Route { From = spot6.Id, To = spot5.Id, Distance = 2500, TimeInSeconds = 480 };
            routes.Add((route.From, route.To), route);

            return routes;
        }
    }
}
