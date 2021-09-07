using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class IndexViewModel
    {
        public List<Status> Statuses { get; set; }
        public List<Task> Tasks { get; set; }

        public AddRowViewModel Add { get; set; }
        public EditRowViewModel Edit { get; set; }
        public DeleteRowViewModel Delete { get; set; }

        public bool AlertWrongEntry { get; set; }

        public bool AddFormOpen { get; set; }
        public bool EditFormOpen { get; set; }
        public bool DeleteFormOpen { get; set; }
    }
}