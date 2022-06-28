using OOauthApi.Interfaces;
using OOauthApi.Models;
using OOauthApi.Repositories;

namespace OOauthApi.Services
{
    public class UserService : IUserservice
    {
        public User Get(UserLogin userLogin)
        {
            User user = UserRespository.Users.FirstOrDefault(o => o.Username.Equals(userLogin.username, StringComparison.OrdinalIgnoreCase) && o.Password.Equals(userLogin.password));

            return user;
        }

    }
}
