using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SkiServcieWPF.Utility
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<object> _execute = null;
        private Predicate<object> _canExecute = null;

        public bool CanExecute(object parameter)
        {
            return (this._canExecute == null) ? true : this._canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("Der Execute-Parameter darf nicht null sein");
            }
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {

        }
    }
}
