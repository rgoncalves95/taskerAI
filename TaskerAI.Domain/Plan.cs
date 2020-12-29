﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TaskerAI.Domain
{
    public class Plan
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IList<Task> Tasks { get; private set; }
        public Assignee Accountable { get; private set; }
        public Admin Responsible { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public PlanWorkflowState Status { get; private set; }

        public int TotalDurationInSecs { get; private set; }

        public Plan(string name, IList<Task> tasks, DateTimeOffset date, int totalDurationInSecs)
        {
            Name = name;
            Tasks = tasks;
            Date = date;
            TotalDurationInSecs = totalDurationInSecs;
            Status = PlanWorkflowState.Draft;
        }

        public Plan(string name) => Name = name;

        public Plan(int id, string name)
        {
            Id = id;
            Name = name;
        }

        internal static Plan Create(string name)
        {
            var plan = new Plan(name);

            return plan;
        }

        internal static Plan Create(int id, string name)
        {
            var plan = new Plan(id, name);

            return plan;
        }

        internal void ReorderTasks(List<Task> tasks) => Tasks = tasks;

        internal void Recalc()
        {

        }


        internal void RemoveTasks()
        {

        }

        internal void Finish()
        {

        }

        internal void Assign(Assignee user)
        {
            this.Accountable = user;
            this.Status = PlanWorkflowState.Approved;
        }

        internal List<Assignee> GetAvailableAssignees()
        {
            var result = new List<Assignee>();

            return result;

        }


        private void generatePlan(List<Task> tasks, int maxTasks, int maxTimeInMinutes, Location location, int radius)
        {

            //calculate distance and time between each task location

            //sort tasks by distance and end time 

            //calculate plan totalTime

            //return the one that meet all the constraints

            




            

        }
    }
}
