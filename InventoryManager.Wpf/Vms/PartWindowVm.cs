using CommunityToolkit.Mvvm.ComponentModel;
using InventoryModels;

namespace InventoryManager.Wpf.Vms
{
    public partial class PartWindowVm : ObservableObject
    {
        [ObservableProperty]
        bool _isAdding = false;
        [ObservableProperty, NotifyPropertyChangedFor(nameof(IsOutsourced))]
        bool _isInHouse = true;
        public bool IsOutsourced => !IsInHouse;

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

        [ObservableProperty]
        int? _machineId;

        [ObservableProperty]
        string? _companyName;


        public PartWindowVm(Part part)
        {
            ImportPart(part);
        }

        public PartWindowVm(Inventory inventory)
        {
            IsAdding = true;
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
            if (part is Inhouse inhouse) { MachineId = inhouse.MachineID; }
            if (part is Outsourced outsourced)
            {
                CompanyName = outsourced.CompanyName;
                IsInHouse = false;
            }
        }

        void SaveClick()
        {
        }
    }
}
