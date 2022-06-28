using OOauthApi.Models;

namespace OOauthApi.Repositories
{
    public class UserRespository
    {
        public static List<User> Users = new()
        {
            new() { Username = "david", EmailAddress = "david@email.com", Password = "password", GivenName = "David", Surname = "Joseph", Role = "Administrator" },
            new() { Username = "chacha", EmailAddress = "chacha@email.com", Password = "pwd", GivenName = "Simeon", Surname = "Chacha", Role = "Standard" },
        };
    }
}
