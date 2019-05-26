using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.Model
{
    /// <summary>
    /// This is the command handler class.
    /// </summary>
    public class CommandHandler : ICommand
    {
        private Action _action;
        public CommandHandler(Action action)
        {
            _action = action;
        } 
/// <summary>
/// is the parameter given can execute.
/// </summary>
/// <param name="parameter"></param>
/// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
/// <summary>
/// perform an action.
/// </summary>
/// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _action();
        }
    }
}
