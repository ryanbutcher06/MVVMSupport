using System;
using System.Windows.Input;

namespace MVVMSupport.Commands
{
    /// <summary>
    /// Represents a command that is represented by an action delegate.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// Initilizes a new instance of DelegateCommand with the specified executeDelegate.
        /// </summary>
        /// <param name="executeDelegete">The delegate to be executed on Execute.</param>
        public DelegateCommand(Action<object> executeDelegete)
            : this(executeDelegete, null)
        {   }

        /// <summary>
        /// Initializes a new instance of DelegateCommand with the specified
        /// executeDelegate and canExecuteDelegate.
        /// </summary>
        /// <param name="executeDelegate">The action delegate to be executed on Execute.</param>
        /// <param name="canExecuteDelegate">The predicate delegate to be executed on CanExecute.</param>
        public DelegateCommand(Action<object> executeDelegate, Predicate<object> canExecuteDelegate)
        {
            _executeDelegate = executeDelegate;
            _canExecuteDelegate = canExecuteDelegate;
        }

        /// <summary>
        /// Gets a boolean denoting whether the execute action should be executed.
        /// </summary>
        /// <param name="parameter">The parameter to be considered by the canExecute delegate.</param>
        /// <returns>A boolean denoting whether the execute action should be executed.</returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecuteDelegate != null)
                return _canExecuteDelegate(parameter);
            else
                return true;
        }

        /// <summary>
        /// Executes the action delegate.
        /// </summary>
        /// <param name="parameter">The object to be passed to the execute delegate.</param>
        public void Execute(object parameter)
        {
            if (_executeDelegate != null)
                _executeDelegate(parameter);
        }

        /// <summary>
        /// Notifies clients when the CanExecute has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Predicate<object> _canExecuteDelegate;
        private Action<object> _executeDelegate;
    }
}
