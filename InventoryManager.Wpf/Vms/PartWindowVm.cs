using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryManager.Wpf.Messages;
using InventoryManager.Models;
using System.ComponentModel;

namespace InventoryManager.Wpf.Vms
{
    public partial class PartWindowVm : ErrorNotifyVm
    {
        private Inventory _inventory;

        public PartWindowVm(OpenWindowMessage message, Inventory inventory) : base()
        {
            _inventory = inventory;
            var type = message.WindowType;

            WindowType = type;
            if (type == WindowType.AddWindow) { _cardVm = new(inventory.GetNextPartId()); }
            else
            {
                var part = message.SelectedItem as Part;
                if (part is Inhouse inhouse) { MachineId = inhouse.MachineID; }

                if (part is Outsourced outsourced)
                {
                    CompanyName = outsourced.CompanyName;
                    IsInHouse = false;
                }

                _cardVm = new(part);
            }
        }

        [ObservableProperty]
        private InventoryItemCardVm _cardVm;

        [ObservableProperty]
        private string? _companyName;

        [ObservableProperty, NotifyPropertyChangedFor(nameof(IsOutsourced))]
        private bool _isInHouse = true;

        [ObservableProperty]
        private int? _machineId;

        public bool IsOutsourced => !IsInHouse;

        public string? WindowTitle => WindowType switch
        {
            WindowType.AddWindow => "Add Part",
            WindowType.ModifyWindow => "Modify Part",
            _ => null
        };

        public WindowType WindowType { get; set; }

        [RelayCommand(CanExecute = nameof(HasNoErrors))]
        private void Save()
        {
            if (WindowType == WindowType.AddWindow) AddPart();
            else ReplacePart();
            Messenger.Send(new ClosePartWindowMessage());
        }

        [RelayCommand]
        private static void Cancel()
        {
            Messenger.Send(new ClosePartWindowMessage());
        }

        private void AddPart()
        {
            var part = GetPart();
            _inventory.AllParts.Add(part);
        }

        private Part GetPart()
        {
            Part part;
            if (IsInHouse)
            {
                part = new Inhouse(CardVm.GetItem()) { MachineID = MachineId ?? 0 };
            }
            else
            {
                part = new Outsourced(CardVm.GetItem()) { CompanyName = CompanyName ?? string.Empty };
            }
            return part;
        }

        private void ReplacePart()
        {
            var part = GetPart();
            _inventory.UpdatePart(part.Id, part);
        }

        protected override void OnErrorsChanged(object recipient, ErrorsChangedMessage message)
        {
            base.OnErrorsChanged(recipient, message);
            SaveCommand.NotifyCanExecuteChanged();
        }
    }
}