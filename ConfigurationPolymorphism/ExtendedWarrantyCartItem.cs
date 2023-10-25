namespace ConfigurationPolymorphism
{
    public class ExtendedWarrantyCartItem : ICartItem
    {
        private const decimal EXTENDED_WARRANTY_PRICE = 10.00m;
        private const int EXTENDED_WARRANTY_ADDITIONAL_DAYS = 90;

        private readonly ICartItem _cartItem;

        public string Name => _cartItem.Name;
        public decimal Price => _cartItem.Price + EXTENDED_WARRANTY_PRICE;
        public int WarrantyDays => _cartItem.WarrantyDays + EXTENDED_WARRANTY_ADDITIONAL_DAYS;

        public ExtendedWarrantyCartItem(ICartItem cartItem)
        {
            _cartItem = cartItem;
        }
    }
}
