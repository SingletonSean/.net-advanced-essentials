namespace ConfigurationPolymorphism
{
    public class CartItem : ICartItem
    {
        private const int BASE_WARRANTY_DAYS = 30;

        public string Name { get; }
        public decimal Price { get; }
        public int WarrantyDays => BASE_WARRANTY_DAYS;

        public CartItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
