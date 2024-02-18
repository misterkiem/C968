using CommunityToolkit.Mvvm.ComponentModel;
using InventoryManager.Wpf.Messages;

namespace InventoryManager.Wpf.Vms
{
    public abstract class ErrorNotifyVm : ObservableObject
    {
        List<object> _errors = new();
        public bool HasNoErrors() => !_errors.Any();
        
        protected ErrorNotifyVm()
        {
            Messenger.Register<ErrorsChangedMessage>(this, OnErrorsChanged);
        }

        protected virtual void OnErrorsChanged(object recipient, ErrorsChangedMessage message)
        {
            var sender = message.Sender;
            if (message.WasRemoved) _errors.Remove(sender);
            else _errors.Add(sender);
        }
    }
}
