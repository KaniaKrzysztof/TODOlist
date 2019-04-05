using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOlist
{
    public class TaskListManager
    {
        public ObservableCollection<Task> TaskList { get; set; }

        public TaskListManager()
        {
            TaskList = new ObservableCollection<Task>();
        }

        public bool AddTask(string content)
        {
            if(content != "")
            {
                TaskList.Add(new Task(content));
                return true;
            } else
            {
                return false;
            }
        }

        public bool RemoveTask()
        {
            
            while (TaskList.SelectedItems.Count > 0)
            {
                Task selectedTask = (Task)TaskList.SelectedItems[0];
                TaskList.Remove(selectedTask);
                return true;
            }
            return false;
        }
    }
}
