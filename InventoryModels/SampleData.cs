namespace InventoryModels;

public static class SampleData
{
    public static Part[] SampleParts = new Part[]
    {
        new Inhouse() {Id = 0, Name = "Wheel", Price = 12.11m, Min=5, Max=25},
        new Inhouse() {Id = 1, Name = "Pedal", Price = 8.22m, Min=5, Max=25},
        new Inhouse() {Id = 2, Name = "Chain", Price = 1.23m, Min=5, Max=25},
        new Inhouse() {Id = 3, Name = "Seat", Price = 1.23m, Min=2, Max=15}
    };

    public static Product[] SampleProducts = new Product[]
    {
        new Product() {Id = 0, Name = "Red Bicycle", Price = 11.44m, Min=1, Max=25},
        new Product() {Id = 1, Name = "Yellow Bicycle", Price = 11.44m, Min=1, Max=25},
        new Product() {Id = 2, Name = "Blue Bicycle", Price = 11.44m, Min=1, Max=25}
    };

    public static Inventory SampleInventory = new Inventory() { AllParts = new(SampleParts), Products = new(SampleProducts) };
}
