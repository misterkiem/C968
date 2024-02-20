using CommunityToolkit.Mvvm.ComponentModel;
using InventoryManager.Wpf.Messages;
using System.Collections.ObjectModel;

namespace InventoryManager.Wpf.Vms
{
    public abstract class ErrorNotifyVm : ObservableObject
    {
        public ObservableCollection<string> Errors { get; } = new();
        public bool HasNoErrors() => !Errors.Any();
        
        protected ErrorNotifyVm()
        {
            Messenger.Register<ErrorsChangedMessage>(this, OnErrorsChanged);
        }

        protected virtual void OnErrorsChanged(object recipient, ErrorsChangedMessage message)
        {
            string errorMessage = message.Message;
            if (message.WasRemoved) Errors.Remove(errorMessage);
            else Errors.Add(errorMessage);
        }
    }
}
