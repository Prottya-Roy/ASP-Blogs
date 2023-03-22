using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using WebApplication1.Models;


namespace WebApplication1.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;
        public UserService(IOptions<BlogDatabaseSettings> blogDatabaseSettings)
        {
            var mongoClient = new MongoClient(blogDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(blogDatabaseSettings.Value.DatabaseName);
            _user = mongoDatabase.GetCollection<User>(blogDatabaseSettings.Value.UserCollectionName);
        }

        public User LoginUser(User User)
        {
            throw new NotImplementedException();
        }

        public void Logout(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> RegisterUser(User user)
        {
            string response = null;
            if (user != null)
            {
                var salt = 10;
                User newUser = new User();
                newUser.UserName = user.UserName;
                newUser.Email = user.Email;
                newUser.DOB = user.DOB;
                newUser.Email = user.Email;
                newUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
                await _user.InsertOneAsync(newUser);
                response = newUser._id;
            }
            else
            {
                response= "No User Provided";
            }
            return response;
            
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(string Id)
        {
            User user = await _user.Find(user=> user._id==Id).FirstAsync();
            return user;
        }
        public async Task<bool> UserNameAvailable(string userName)
        {
            bool flag=true;
            User user = await _user.Find(user=>user.UserName== userName).FirstAsync();
            if(user!=null)
            {
                flag= false;
            }
            else if(user==null)
            {
                flag= true;
            }
            return flag;
        }

        public async Task<bool> EmailAvailable(string email)
        {
            bool flag = true;
            User user = await _user.Find(user => user.Email == email).FirstAsync();
            if (user != null)
            {
                flag = false;
            }
            else if (user == null)
            {
                flag = true;
            }
            return flag;
        }

        private static bool IsValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
    }
}
