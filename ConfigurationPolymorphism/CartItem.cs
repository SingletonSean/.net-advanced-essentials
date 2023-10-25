namespace ConfigurationPolymorphism
{
    public class CartItem
    {
        private const decimal WARRANTY_PRICE = 10.00m;
        private const int BASE_WARRANTY_DAYS  = 30;
        private const int EXTENDED_WARRANTY_ADDITIONAL_DAYS  = 90;

        private readonly decimal _basePrice;
        private readonly bool _hasExtendedWarranty;

        public string Name { get; set; }

        public decimal Price
        {
            get
            {
                decimal calculatedPrice = _basePrice;

                if (_hasExtendedWarranty)
                {
                    calculatedPrice += WARRANTY_PRICE;
                }

                return calculatedPrice;
            }
        }

        public int WarrantyDays
        {
            get
            {
                int calculatedWarrantyDays = BASE_WARRANTY_DAYS;

                if (_hasExtendedWarranty)
                {
                    calculatedWarrantyDays += EXTENDED_WARRANTY_ADDITIONAL_DAYS;
                }

                return calculatedWarrantyDays;
            }
        }

        public CartItem(string name, decimal basePrice, bool hasExtendedWarranty)
        {
            Name = name;
            _basePrice = basePrice;
            _hasExtendedWarranty = hasExtendedWarranty;
        }
    }
}
