namespace InventoryManager.Wpf.Messages;

public class ErrorsChangedMessage
{
    public string Message { get; set; }
    public bool WasRemoved { get; set; }

    public ErrorsChangedMessage(string message, bool wasRemoved = false)
    {
        Message = message;
        WasRemoved = wasRemoved;
    }
}
