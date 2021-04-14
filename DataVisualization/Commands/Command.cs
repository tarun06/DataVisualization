using System;
using System.Windows.Input;

namespace DataVisualization.Commands
{
    public class Command : ICommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;

        public Command(Action execute) : this(execute, null)
        {
        }

        public Command(Action execute,
        Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, new EventArgs());
        }
    }
}