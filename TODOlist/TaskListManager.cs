using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TODOlist
{
    public class TaskListManager
    {
        protected ListView _taskListView;
        public ObservableCollection<TaskItem> TaskList { get; private set; }
        protected QueryHandler _taskLoader;
        protected CommandHandler _taskCommander;

        public TaskListManager(ListView taskListView, QueryHandler taskLoader, CommandHandler taskCommander)
        {
            _taskListView = taskListView;
            TaskList = new ObservableCollection<TaskItem>();
            _taskLoader = taskLoader;
            _taskCommander = taskCommander;
        }

        public async void AddTask(string content)
        {
            if (content.Trim() != "")
            {
                TaskItem tempTask = new TaskItem(content.Trim());
                TaskList.Add(tempTask);
                await _taskCommander.CreateTasktAsync(tempTask);
                
            } else
            {
                return;
            }
        }

        public async void RemoveTask()
        {
            while (_taskListView.SelectedItems.Count > 0)
            {
                try
                {
                    TaskItem selectedTask = (TaskItem)_taskListView.SelectedItems[0];
                    HttpStatusCode responseCode = await _taskCommander.DeleteTaskItemAsync(selectedTask.Id);
                    TaskList.Remove(selectedTask);
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message);
                }
            }
        }

        public async void LoadTasks()
        {
            List<TaskItem> loadedList;
            try
            {
                loadedList = await _taskLoader.GetTaskListAsync();
                TaskList.Clear();
                foreach (TaskItem task in loadedList)
                {
                    TaskList.Add(task);
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

        }
    }
}
