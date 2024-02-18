namespace InventoryManager.Wpf.Services
{
    public interface IDialogService
    {
        bool DisplayConfirmMessage(string message, string title);
        void DisplayMessage(string message, string title);
    }
}