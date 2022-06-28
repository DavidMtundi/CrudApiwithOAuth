using OOauthApi.Models;

namespace OOauthApi.Interfaces
{
    public interface IUserservice
    {
        public User Get(UserLogin userLogin);
    }
}
