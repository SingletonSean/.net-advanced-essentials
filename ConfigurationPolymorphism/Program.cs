using ConfigurationPolymorphism;

CartItem cartItem = new CartItem("Skateboard", 99.99m, false);

Console.WriteLine($"{cartItem.Name} | ${cartItem.Price} | {cartItem.WarrantyDays} day warranty");