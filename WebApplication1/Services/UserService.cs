using Microsoft.AspNetCore.Mvc;
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
        private readonly ITokenService _tokenService;
        public UserService(IOptions<BlogDatabaseSettings> blogDatabaseSettings, ITokenService tokenService)
        {
            var mongoClient = new MongoClient(blogDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(blogDatabaseSettings.Value.DatabaseName);
            _user = mongoDatabase.GetCollection<User>(blogDatabaseSettings.Value.UserCollectionName);
            _tokenService = tokenService;
        }

        public void Logout(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<UserToken> RegisterUser(User user)
        {
            UserToken userToken = null;
            
            if (user != null)
            {
                User newUser = new User();
                newUser.UserName = user.UserName;
                newUser.Email = user.Email;
                newUser.DOB = user.DOB;
                newUser.Email = user.Email;
                newUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                await _user.InsertOneAsync(newUser);
                return new UserToken
                {
                    _id = newUser._id,
                    Token = _tokenService.CreateToken(newUser)
                };
               
            }
            else
            {
                return userToken;
            }
        }


        public async Task<UserToken> LoginUser(User user)
        {
            UserToken response =null;
            if (user != null)
            {
                User userReturn = await _user.Find(userFind => userFind.UserName == user.UserName).FirstAsync();
                bool passwordCheck = BCrypt.Net.BCrypt.Verify(user.Password, userReturn.Password);
                if (passwordCheck)
                {
                    return new UserToken
                    {
                        _id = userReturn._id,
                        Token = _tokenService.CreateToken(userReturn)
                    };
                }
                else
                {
                    return response;
                }
            }
            else
            {
                return response;
            }
            
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
