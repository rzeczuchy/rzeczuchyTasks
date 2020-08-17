using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace rzeczuchyTasks.ViewModel.Commands
{
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
