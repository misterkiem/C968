using InventoryManager.Wpf.Messages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            string error = GetMessage(e);

            switch (e.Action)
            {
                case ValidationErrorEventAction.Added:
                    Messenger.Send(new ErrorsChangedMessage(error));
                    break;
                case ValidationErrorEventAction.Removed:
                    Messenger.Send(new ErrorsChangedMessage(error, true));
                    break;
            }

        }

        string GetMessage(ValidationErrorEventArgs e)
        {
            var error = e.Error;
            var message = error.ErrorContent.ToString();
            if (message is null) return string.Empty;
            if (error.RuleInError is DataErrorValidationRule) return message;
            var propName = (e.Error.BindingInError as BindingExpression)?.ResolvedSourcePropertyName;
            if (propName == "MachineId") propName = "Machine ID";
            if (propName == "InStock") propName = "Inventory";
            message = $"{propName} is non-numeric.";
            return message; 
        }

        protected override void OnClosed(EventArgs e)
        {
            Validation.RemoveErrorHandler(this, HandleError);
            base.OnClosed(e);
        }
    }
}
