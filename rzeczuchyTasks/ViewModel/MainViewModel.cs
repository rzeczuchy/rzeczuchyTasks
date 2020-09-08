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
using rzeczuchyTasks.Model;
using rzeczuchyTasks.ViewModel.Commands;

namespace rzeczuchyTasks.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DataReaderWriter data;
        private string newLabel;

        public MainViewModel()
        {
            data = new DataReaderWriter(this);
            ToDoList = new ObservableCollection<ToDo>(data.LoadToDos());
            AddToDoCommand = new AddToDoCommand(this);
            DeleteToDoCommand = new DeleteToDoCommand(this);
        }

        public ObservableCollection<ToDo> ToDoList { get; }
        public AddToDoCommand AddToDoCommand { get; set; }
        public DeleteToDoCommand DeleteToDoCommand { get; set; }

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
            ToDoList.Add(new ToDo(DataReaderWriter.NewToDoId(ToDoList.ToList()), NewLabel, false, this));
            SaveToDos();
            NewLabel = string.Empty;
        }

        public void DeleteToDo(object parameter)
        {
            if (parameter is ToDo todo)
            {
                ToDoList.Remove(todo);
                SaveToDos();
            }
        }

        public void SaveToDos()
        {
            data.SaveToDos(ToDoList.ToList());
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
