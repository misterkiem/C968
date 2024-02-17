using CommunityToolkit.Mvvm.Messaging.Messages;
using InventoryManager.Wpf.Vms;
using InventoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Wpf.Messages
{
    public partial class OpenWindowMessage
    {
        public WindowType WindowType { get; set; }
        public InventoryItemType ItemType { get; set; }
        public InventoryItem? SelectedItem { get; } = null;
        public OpenWindowMessage(WindowType windowType, InventoryItemType itemType, InventoryItem? selectedItem)
        {
            WindowType = windowType;
            ItemType = itemType;
            SelectedItem = selectedItem;
        }
    }
}
