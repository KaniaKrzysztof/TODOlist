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
        public ObservableCollection<Task> _TaskList { get; private set; }

        public TaskListManager(ListView taskListView)
        {
            _taskListView = taskListView;
            _TaskList = new ObservableCollection<Task>();
        }

        public bool AddTask(string content)
        {
            if (content.Trim() != "")
            {
                _TaskList.Add(new Task(content.Trim()));
                JsonTaskFileManager jtfm = new JsonTaskFileManager();
                jtfm.MakeJsonFile(_TaskList);
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
                _TaskList.Remove(selectedTask);
            }
            return true;
        }
    }
}
