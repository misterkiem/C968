using InventoryManager.Wpf.Messages;
using InventoryManager.Wpf.Vms;
using InventoryModels;
using System.Windows;

namespace InventoryManager.Wpf.Views
{
    /// <summary>
    /// Interaction logic for PartCard.xaml
    /// </summary>
    public partial class PartWindow : Window
    {
        public PartWindow(PartWindowVm vm)
        {
            Messenger.Register<ClosePartWindowMessage>(this, OnClosedMessage);
            DataContext = vm;
            InitializeComponent();
        }

        private void OnClosedMessage(object recipient, ClosePartWindowMessage message)
        {
            Messenger.Unregister<ClosePartWindowMessage>(this);
            Close();
        }
    }
}
