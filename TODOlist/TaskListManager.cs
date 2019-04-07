using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TODOlist
{
    public class TaskListManager
    {
        protected ListView _taskListView;
        public ObservableCollection<TaskItem> TaskList { get; private set; }

        public TaskListManager(ListView taskListView)
        {
            _taskListView = taskListView;
            TaskList = new ObservableCollection<TaskItem>();
        }

        public bool AddTask(string content)
        {
            if (content.Trim() != "")
            {
                TaskList.Add(new TaskItem(content.Trim()));
                
                return true;
            } else
            {
                return false;
            }
        }

        public bool RemoveTask()
        {
            while (_taskListView.SelectedItems.Count > 0)
            {
                TaskItem selectedTask = (TaskItem)_taskListView.SelectedItems[0];
                TaskList.Remove(selectedTask);
            }
            return true;
        }

        public async void LoadTasks()
        {
            GetApiHandler taskLoader = new GetApiHandler();

            List<TaskItem> loadedList = await taskLoader.GetTaskList();
            foreach (TaskItem task in loadedList)
            {
                TaskList.Add(task);
            }
        }
    }
}
