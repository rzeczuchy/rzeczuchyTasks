using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rzeczuchyTasks.Model
{
    class ToDo
    {
        public const int MaxNameLength = 50;

        public ToDo(string name, bool isChecked)
        {
            Label = name.Length > MaxNameLength ? name.Substring(0, MaxNameLength) : name;
            IsChecked = isChecked;
        }

        public string Label { get; set; }
        public bool IsChecked { get; set; }
    }
}
