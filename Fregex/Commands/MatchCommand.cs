using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fregex.Commands
{
    class MatchCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = (sender, o) => { };

        #region Actions

        Action MatchAction;

        #endregion

        public MatchCommand(Action action)
        {
            MatchAction = action;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            MatchAction();
        }
    }
}
