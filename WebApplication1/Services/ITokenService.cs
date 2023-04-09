namespace WebApplication1.Services
{
    public interface ITokenService
    {
        string CreateToken(Models.User user);
    }
}
