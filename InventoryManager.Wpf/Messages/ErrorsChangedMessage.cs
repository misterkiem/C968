namespace InventoryManager.Wpf.Messages;

public class ErrorsChangedMessage
{
    public object Sender { get; set; }
    public bool WasRemoved { get; set; }

    public ErrorsChangedMessage(object source, bool wasRemoved = false)
    {
        Sender = source;
        WasRemoved = wasRemoved;
    }
}
