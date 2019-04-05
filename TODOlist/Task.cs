using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOlist
{
    public class Task
    {
        public string Content { get; set; }
        public string DateTimeCreated { get; set; }

        public Task(string content)
        {
            this.Content = content;
            DateTimeCreated = DateTime.Now.ToString();
        }
    }
}
