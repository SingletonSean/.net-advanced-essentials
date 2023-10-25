namespace ConfigurationPolymorphism
{
    public class PromotionCartItem : ICartItem
    {
        private const int PROMOTION_PRICE_DISCOUNT = 5;
        private const int PROMOTION_ADDITIONAL_WARRANTY_DAYS = 10;

        private readonly ICartItem _baseCartItem;

        public string Name => _baseCartItem.Name;
        public decimal Price => _baseCartItem.Price - PROMOTION_PRICE_DISCOUNT;
        public int WarrantyDays => _baseCartItem.WarrantyDays + PROMOTION_ADDITIONAL_WARRANTY_DAYS;

        public PromotionCartItem(ICartItem baseCartItem)
        {
            _baseCartItem = baseCartItem;
        }
    }
}
