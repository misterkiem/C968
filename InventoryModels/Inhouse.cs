namespace InventoryManager.Models;

public class Inhouse : Part
{ 
    public int MachineID { get; set; }
    public Inhouse() { }
    public Inhouse(InventoryItem item) : base(item) { }
}
