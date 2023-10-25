namespace ConfigurationPolymorphism
{
    public class PromotionCartItem : ICartItem
    {
        private const decimal PROMOTION_PRICE_DISCOUNT = 5.00m;
        private const int PROMOTION_WARRANTY_ADDITIONAL_DAYS = 10;

        private readonly ICartItem _cartItem;

        public string Name => _cartItem.Name;
        public decimal Price => _cartItem.Price - PROMOTION_PRICE_DISCOUNT;
        public int WarrantyDays => _cartItem.WarrantyDays + PROMOTION_WARRANTY_ADDITIONAL_DAYS;

        public PromotionCartItem(ICartItem cartItem)
        {
            _cartItem = cartItem;
        }
    }
}
