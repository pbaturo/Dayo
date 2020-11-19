using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Dayo.Commands
{
    public class CloseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public CloseCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            StoreMemoryList((string)parameter);
            System.Windows.Application.Current.Shutdown();
        }

        private void StoreMemoryList(string content)
        {
            System.IO.File.WriteAllText("DayoStore.txt", content);
        }
    }
}
