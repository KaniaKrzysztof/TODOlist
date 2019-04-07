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
        protected JsonTaskFileManager _jtfm;
        public ObservableCollection<TaskItem> TaskList { get; private set; }

        public TaskListManager(ListView taskListView)
        {
            _taskListView = taskListView;
            TaskList = new ObservableCollection<TaskItem>();
            _jtfm = new JsonTaskFileManager();
        }

        public bool AddTask(string content)
        {
            if (content.Trim() != "")
            {
                TaskList.Add(new TaskItem(content.Trim()));
                
                _jtfm.MakeJsonFile(TaskList);
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

        public void LoadTasks()
        {
            List<TaskItem> loadedList = _jtfm.ReadJsonFile();
            foreach (TaskItem task in loadedList)
            {
                TaskList.Add(task);
            }
        }
    }
}
