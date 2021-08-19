using System;
using EFCore.Entitis;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var contextFactory = new MyDbContextFactory();

            using (var context = contextFactory.CreateDbContext(args))
            {
                CreateFiveStatusesAndTasks(context);

                var statuses = context.Statuses;
                var tasks = context.Tasks;

                Print(statuses);
                Print(tasks);
            }
        }

        static void Print(DbSet<Status> statuses)
        {
            foreach (Status status in statuses)
            {
                int id = status.StatusId;
                string name = status.StatusName;
                Console.WriteLine($"ID: {id}, NAME: {name}");
            }
        }

        static void Print(DbSet<Task> tasks)
        {
            foreach (Task task in tasks)
            {
                int id = task.Id;
                string name = task.Name;
                string description = task.Description;
                int statusId = task.StatusId;
                Console.WriteLine(
                    $"ID: {id}, NAME: {name}, DESCRIPTION: {description}, STATUSID: {statusId}"
                );
            }
        }

        static void CreateFiveStatusesAndTasks(MyDbContext context)
        {
            for (int i = 0; i < 5; i++)
            {
                var status = new Status()
                {
                    StatusName = $"Статус {i}"
                };

                context.Statuses.Add(status);
            }

            for (int i = 0; i < 5; i++)
            {
                var task = new Task()
                {
                    Name = $"Статус {i}",
                    Description = $"Описание {i}",
                    StatusId = i + 1
                };

                context.Tasks.Add(task);
            }

            context.SaveChanges();
        }
    }
}
