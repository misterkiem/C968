using InventoryManager.Wpf.Messages;
using System.Windows;
using System.Windows.Controls;

namespace InventoryManager.Wpf.Views
{
    public class ErrorNotifyWindow : Window
    {
        public ErrorNotifyWindow()
        {
            Validation.AddErrorHandler(this, HandleError);
        }
        private void HandleError(object? sender, ValidationErrorEventArgs e)
        {
            switch (e.Action)
            {
                case ValidationErrorEventAction.Added:
                    Messenger.Send(new ErrorsChangedMessage(e.OriginalSource));
                    break;
                case ValidationErrorEventAction.Removed:
                    Messenger.Send(new ErrorsChangedMessage(e.OriginalSource, true));
                    break;
            }

        }

        protected override void OnClosed(EventArgs e)
        {
            Validation.RemoveErrorHandler(this, HandleError);
            base.OnClosed(e);
        }
    }
}
