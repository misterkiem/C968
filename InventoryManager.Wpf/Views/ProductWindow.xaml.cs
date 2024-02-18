using InventoryManager.Wpf.Messages;
using System.Windows;

namespace InventoryManager.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow()
        {
            Messenger.Register<CloseProductWindowMessage>(this, OnCloseProductWindowMessage);
            InitializeComponent();
        }

        private void OnCloseProductWindowMessage(object recipient, CloseProductWindowMessage message)
        {
            Messenger.Unregister<CloseProductWindowMessage>(this);
            Close();
        }
    }
}
