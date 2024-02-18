using CommunityToolkit.Mvvm.Messaging.Messages;
using InventoryManager.Wpf.Vms;
using InventoryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Wpf.Messages
{
    public partial class OpenWindowMessage
    {
        public object Sender { get; set; }
        public WindowType WindowType { get; set; }
        public InventoryItem? SelectedItem { get; } = null;

        public OpenWindowMessage(WindowType windowType, object sender, InventoryItem? selectedItem)
        {
            WindowType = windowType;
            Sender = sender;
            SelectedItem = selectedItem;
        }
    }
}
