using WebApplication1.Models;
namespace WebApplication1.Services
{
    public interface IUserService
    {
        User RegisterUser(User user);
        User LoginUser(User User);
        User UpdateUser(User user);
        void Logout(User user);
    }
}
