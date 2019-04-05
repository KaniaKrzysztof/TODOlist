﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class MainWindow : Window
    {

        public ObservableCollection<Task> myTaskList1 { get; set; }
        public TaskListManager myTaskList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            myTaskList = new TaskListManager();
            this.DataContext = this;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            myTaskList.AddTask(textBox.Text);
        }

        private void textBox_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                myTaskList.AddTask(textBox.Text);
            }

        }

        private void textBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            //tb.GotMouseCapture -= textBox_GotMouseCapture;
        }

        private void textBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            //tb.GotKeyboardFocus -= textBox_GotKeyboardFocus;
        }

        

        private void textBox_Del(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Delete)
            {
                while (myTaskList1.SelectedItems.Count > 0)
                {
                    Task selectedTask = (Task)myTaskList1.SelectedItems[0];
                    myTaskList1.Remove(selectedTask);
                    
                }
            }
        }
    }
}
