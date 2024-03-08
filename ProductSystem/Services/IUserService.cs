using ProductSystem.Models;

namespace ProductSystem.Services
{
    public interface IUserService
    {
        User getUserByUserNameAndPassword(string userName, string password);
    }
}
