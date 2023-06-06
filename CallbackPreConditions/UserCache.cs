using System.Text.Json;
using System.Text.Json.Serialization;

namespace CallbackPreConditions
{
    public class UserCache
    {
        private readonly string _fileCachePath;

        public UserCache(string fileCachePath)
        {
            _fileCachePath = fileCachePath;
        }

        public async Task<User?> Get()
        {
            if (!File.Exists(_fileCachePath))
            {
                return null;
            }

            string userJson = await File.ReadAllTextAsync(_fileCachePath);

            if (userJson.Length == 0)
            {
                return null;
            }

            return JsonSerializer.Deserialize<User>(userJson);
        }

        public async Task Set(User user)
        {
            await File.WriteAllTextAsync(_fileCachePath, JsonSerializer.Serialize(user));
        }

        public async Task Clear()
        {
            await File.WriteAllTextAsync(_fileCachePath, string.Empty);
        }

        private bool HasFileCachePermission()
        {
            try
            {
                using FileStream fs = File.Open(_fileCachePath, FileMode.OpenOrCreate);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
