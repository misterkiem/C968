using CommunityToolkit.Mvvm.Messaging.Messages;
using InventoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Wpf.Vms
{
    public partial class OpenWindowMessage
    {
        public bool IsAdd { get; } = false;
        public bool IsProduct { get; } = false;
        public InventoryItem? SelectedItem { get; } = null;
    }
}
