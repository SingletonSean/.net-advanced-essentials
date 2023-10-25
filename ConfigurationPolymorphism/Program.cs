using ConfigurationPolymorphism;

Print(new CartItemBuilder("Skateboard", 99.99m).Build());
Print(new CartItemBuilder("Skateboard", 99.99m).WithExtendedWarranty().Build());
Print(new CartItemBuilder("Skateboard", 99.99m).WithExtendedWarranty().WithPromotion().Build());

void Print(ICartItem cartItem)
{
    Console.WriteLine($"{cartItem.Name} | ${cartItem.Price} | {cartItem.WarrantyDays} day warranty");
}