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

        public User? Get()
        {
            if (!File.Exists(_fileCachePath))
            {
                return null;
            }

            string userJson = File.ReadAllText(_fileCachePath);

            if (userJson.Length == 0)
            {
                return null;
            }

            return JsonSerializer.Deserialize<User>(userJson);
        }

        public void Set(User user)
        {
            File.WriteAllText(_fileCachePath, JsonSerializer.Serialize(user));
        }

        public void Clear()
        {
            File.WriteAllText(_fileCachePath, string.Empty);
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
