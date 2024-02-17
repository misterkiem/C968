using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace InventoryManager.Wpf.Views
{
    /// <summary>
    /// Interaction logic for InventoryGrid.xaml
    /// </summary>
    public partial class InventoryGrid : UserControl
    {
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(InventoryGrid), new PropertyMetadata(null));

        public string IdHeader
        {
            get { return (string)GetValue(IdHeaderProperty); }
            set { SetValue(IdHeaderProperty, value); }
        }
        public static readonly DependencyProperty IdHeaderProperty =
            DependencyProperty.Register("IdHeader", typeof(string), typeof(InventoryGrid), new PropertyMetadata(null));

        public InventoryGrid()
        {
            InitializeComponent();
        }
    }
}
