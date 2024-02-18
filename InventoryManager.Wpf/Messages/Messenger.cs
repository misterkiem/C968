using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Wpf.Messages
{
    public static class Messenger
    {
        public static void Send<T>(T message) where T : class
        {
            WeakReferenceMessenger.Default.Send(message);
        }
        public static void Register<T>(object recipient, MessageHandler<object, T> messageHandler) where T : class
        {
            WeakReferenceMessenger.Default.Register(recipient, messageHandler);
        }
        public static void Unregister<T>(object recipient) where T : class
        {
            WeakReferenceMessenger.Default.Unregister<T>(recipient);
        }
    }
}
