using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOlist
{
    public class TaskItem
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; protected set; }
        public bool IsComplete { get; set; }

        public TaskItem(string content)
        {
            this.Content = content;
            DateCreated = DateTime.Now;
            IsComplete = false;
        }
    }
}
