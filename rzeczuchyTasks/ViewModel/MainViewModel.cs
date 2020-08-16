using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using rzeczuchyTasks.Model;

namespace rzeczuchyTasks.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DataReaderWriter data;
        private string newLabel;

        public MainViewModel()
        {
            data = new DataReaderWriter();
            ToDoList = new ObservableCollection<ToDo>(data.LoadToDos());
            AddToDoCommand = new AddToDoCommand(this);
        }

        public ObservableCollection<ToDo> ToDoList { get; }
        public AddToDoCommand AddToDoCommand { get; set; }

        public string NewLabel
        {
            get { return newLabel; }
            set
            {
                newLabel = value;
                OnPropertyChanged("NewLabel");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void AddToDo()
        {
            ToDoList.Add(new ToDo(NewLabel, false));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class AddToDoCommand : ICommand
    {
        public AddToDoCommand(MainViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public MainViewModel ViewModel { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is string label && !string.IsNullOrWhiteSpace(label))
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            ViewModel.AddToDo();
        }
    }
}
