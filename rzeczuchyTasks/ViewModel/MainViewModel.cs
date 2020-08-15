using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rzeczuchyTasks.Model;

namespace rzeczuchyTasks.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private readonly DataReaderWriter data;
        private List<ToDo> toDoList;

        public MainViewModel()
        {
            data = new DataReaderWriter();
            toDoList = data.LoadToDos();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<ToDo> ToDoList
        {
            get { return toDoList; }
            set
            {
                toDoList = value;
                OnPropertyChanged("ToDoList");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
