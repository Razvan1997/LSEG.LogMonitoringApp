using System.Windows.Input;

namespace LSEG.LogMonitoring.Core.Modules.Commands
{
    /// <summary>
    /// A basic implementation of ICommand that delegates 
    /// execution and can-execute logic to delegates
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Creates a new command that can always execute
        /// </summary>
        /// <param name="execute">The action to execute</param>
        /// <param name="canExecute">Optional condition for whether the command can execute</param>
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determines whether the command can execute in its current state
        /// </summary>
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute();

        /// <summary>
        /// Executes the command
        /// </summary>
        public void Execute(object parameter) => _execute();

        /// <summary>
        /// Raises the CanExecuteChanged event to signal the UI to requery CanExecute
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
