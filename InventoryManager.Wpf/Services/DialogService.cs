using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InventoryManager.Wpf.Services
{
    public class DialogService : IDialogService
    {
        public bool DisplayConfirmMessage(string message, string title)
        {
            var result = MessageBox.Show(message, title, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK) return true;
            return false;
        }

        public void DisplayMessage(string message, string title)
        {
            MessageBox.Show(message, title);
        }
    }
}
