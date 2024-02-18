using InventoryManager.Wpf.Messages;
using InventoryManager.Wpf.Vms;
using InventoryModels;
using System.Windows;
using System.Windows.Controls;

namespace InventoryManager.Wpf.Views
{
    /// <summary>
    /// Interaction logic for PartCard.xaml
    /// </summary>
    public partial class PartWindow : ErrorNotifyWindow
    {
        public PartWindow(PartWindowVm vm) : base()
        {
            Messenger.Register<ClosePartWindowMessage>(this, OnClosedMessage);
            InitializeComponent();
            DataContext = vm;
        }

        private void OnClosedMessage(object recipient, ClosePartWindowMessage message)
        {
            Messenger.Unregister<ClosePartWindowMessage>(this);
            Close();
        }
    }
}
