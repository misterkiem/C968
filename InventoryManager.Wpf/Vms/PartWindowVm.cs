using CommunityToolkit.Mvvm.ComponentModel;
using InventoryModels;

namespace InventoryManager.Wpf.Vms
{
    public partial class PartWindowVm : ObservableObject
    {
        [ObservableProperty]
        InventoryItemCardVm _cardVm;

        [ObservableProperty]
        bool _isAdding = false;
        [ObservableProperty, NotifyPropertyChangedFor(nameof(IsOutsourced))]
        bool _isInHouse = true;
        public bool IsOutsourced => !IsInHouse;

        [ObservableProperty]
        int? _machineId;

        [ObservableProperty]
        string? _companyName;

        public PartWindowVm(Part part)
        {
            _cardVm = new(part);
        }

        public PartWindowVm(int id)
        {
            IsAdding = true;
            _cardVm = new(id);
        }

        void SaveClick()
        {
        }
    }
}
