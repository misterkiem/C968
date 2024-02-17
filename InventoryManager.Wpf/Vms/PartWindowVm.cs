using CommunityToolkit.Mvvm.ComponentModel;
using InventoryModels;

namespace InventoryManager.Wpf.Vms
{
    public partial class PartWindowVm : ObservableObject
    {
        [ObservableProperty]
        bool _isInHouse = true;

        [ObservableProperty]
        int _id;

        [ObservableProperty]
        string? _name;

        [ObservableProperty]
        int? _inStock;

        [ObservableProperty]
        decimal? _price;

        [ObservableProperty]
        int? _min;

        [ObservableProperty]
        int? _max;



        public PartWindowVm(Part part)
        {
            ImportPart(part);
        }

        public PartWindowVm(Inventory inventory)
        {
            Id = inventory.GetNextPartId();
        }

        void ImportPart(Part part)
        {
            Id = part.PartID;
            Name = part.Name;
            InStock = part.InStock;
            Price = part.Price;
            Min = part.Min;
            Max = part.Max;
        }
    }
}
