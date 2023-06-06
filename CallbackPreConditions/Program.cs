using CallbackPreConditions;

UserCache userCache = new UserCache("./user-cache.json");

Console.WriteLine("Getting cached user");
User? cachedUser = userCache.Get();
Console.WriteLine($"Cached user: {cachedUser?.Username} {cachedUser?.Website}");

Console.WriteLine("Setting cached user");
userCache.Set(new User()
{
    Username = "SingletonSean",
    Website = "https://seandodson.com"
});

Console.WriteLine("Getting cached user");
User? updatedUser = userCache.Get();
Console.WriteLine($"Cached user: {updatedUser?.Username} {updatedUser?.Website}");

Console.WriteLine("Clearing cached user");
userCache.Clear();