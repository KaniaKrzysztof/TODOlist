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
        public ObservableCollection<Task> TaskList { get; private set; }

        public TaskListManager(ListView taskListView)
        {
            _taskListView = taskListView;
            TaskList = new ObservableCollection<Task>();
            _jtfm = new JsonTaskFileManager();
        }

        public bool AddTask(string content)
        {
            if (content.Trim() != "")
            {
                TaskList.Add(new Task(content.Trim()));
                
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
                Task selectedTask = (Task)_taskListView.SelectedItems[0];
                TaskList.Remove(selectedTask);
            }
            return true;
        }

        public void LoadTasks()
        {
            List<Task> loadedList = _jtfm.ReadJsonFile();
            TaskList = new ObservableCollection<Task>(loadedList);
            _taskListView.ItemsSource = TaskList;
        }
    }
}
