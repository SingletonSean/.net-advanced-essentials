namespace ConfigurationPolymorphism
{
    public class ExtendedWarrantyCartItem : ICartItem
    {
        private const decimal EXTENDED_WARRANTY_PRICE = 10.00m;
        private const int EXTENDED_WARRANTY_ADDITIONAL_DAYS = 90;

        private readonly ICartItem _baseCartItem;

        public string Name => _baseCartItem.Name;
        public decimal Price => _baseCartItem.Price + EXTENDED_WARRANTY_PRICE;
        public int WarrantyDays => _baseCartItem.WarrantyDays + EXTENDED_WARRANTY_ADDITIONAL_DAYS;

        public ExtendedWarrantyCartItem(ICartItem baseCartItem)
        {
            _baseCartItem = baseCartItem;
        }
    }
}
