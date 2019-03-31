using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TODOlist
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    class Task
    {
        string content { get; set; }
        DateTime dateTimeCreated { get; set; }

        public Task(string content)
        {
            this.content = content;
            dateTimeCreated = DateTime.Now;
        }

        public override string ToString()
        {
            return content.ToString();
        }
    }

    class TaskList
    {
        public List<Task> allTasks { get; private set; }

        public TaskList()
        {
            allTasks = new List<Task>();
        }

        public void AddNewTask(Task newTask)
        {
            allTasks.Add(newTask);
        }
    }


    public partial class MainWindow : Window
    {
        TaskList myTaskList = new TaskList();
        ICollectionView view;
        public MainWindow()
        {
            InitializeComponent();
            lvDataBinding.ItemsSource = myTaskList.allTasks;
            view = CollectionViewSource.GetDefaultView(myTaskList.allTasks);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            TextBox tb = textBox;
            myTaskList.AddNewTask(new Task(tb.Text));
            view.Refresh();
        }

        private void textBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.GotMouseCapture -= textBox_GotMouseCapture;
        }

        private void textBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.GotKeyboardFocus -= textBox_GotKeyboardFocus;
        }

        private void textBox_Enter(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                TextBox tb = textBox;
                myTaskList.AddNewTask(new Task(tb.Text));
                view.Refresh();
            }
            
        }

        private void textBox_Del(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                foreach (Task eachItem in lvDataBinding.SelectedItems)
                {
                    // do dokonczenia
                }
            }
        }
    }
}
