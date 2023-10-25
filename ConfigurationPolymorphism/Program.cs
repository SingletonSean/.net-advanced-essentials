using ConfigurationPolymorphism;

Print(new CartItem("Skateboard", 99.99m, false));
Print(new CartItem("Skateboard", 99.99m, true));

void Print(CartItem cartItem)
{
    Console.WriteLine($"{cartItem.Name} | ${cartItem.Price} | {cartItem.WarrantyDays} day warranty");
}