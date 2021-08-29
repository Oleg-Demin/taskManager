using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
    }
}
