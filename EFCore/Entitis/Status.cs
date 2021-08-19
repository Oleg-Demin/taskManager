using System;
using System.Collections.Generic;

namespace EFCore.Entitis
{
    public class Status
    {
        public Status()
        {
            Tasks = new HashSet<Task>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
