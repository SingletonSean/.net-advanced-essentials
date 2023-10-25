using ConfigurationPolymorphism;

CartItemBuilder cartItemBuilder = new CartItemBuilder("Skateboard", 99.99m);

Print(cartItemBuilder.WithExtendedWarranty().WithPromotion().Build());

void Print(ICartItem cartItem)
{
    Console.WriteLine($"{cartItem.Name} | ${cartItem.Price} | {cartItem.WarrantyDays} day warranty");
}