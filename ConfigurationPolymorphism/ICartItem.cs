namespace ConfigurationPolymorphism
{
    public interface ICartItem
    {
        string Name { get; }
        decimal Price { get; }
        int WarrantyDays { get; }
    }
}