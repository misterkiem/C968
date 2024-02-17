using InventoryManager.Wpf.Vms;
using InventoryModels;
using System.Windows;

namespace InventoryManager.Wpf.Views
{
    /// <summary>
    /// Interaction logic for PartCard.xaml
    /// </summary>
    public partial class PartCard : Window
    {
        public PartCard()
        {
            DataContext = new PartWindowVm(SampleData.SampleInventory);
            InitializeComponent();
        }
    }
}
