using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rzeczuchyTasks.Model
{
    public class ToDo : INotifyPropertyChanged
    {
        public const int MaxNameLength = 50;
        
        private string label;
        private bool isChecked;

        public ToDo(int id, string label, bool isChecked)
        {
            Id = id;
            this.label = label.Length > MaxNameLength ? label.Substring(0, MaxNameLength) : label;
            this.isChecked = isChecked;
        }

        public int Id { get; }
        
        public string Label
        {
            get { return label; }
            set {
                label = value;
                OnPropertyChanged("Label");
            }
        }

        public bool IsChecked
        {
            get { return isChecked; }
            set {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
