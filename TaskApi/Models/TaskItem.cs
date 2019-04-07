using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.Models
{
    public class TaskItem
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; protected set; }
        public bool IsComplete { get; set; }

        public TaskItem()
        {
            DateCreated = DateTime.Now;
        }
    }
}
