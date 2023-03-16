using Microsoft.Extensions.Options;
using MongoDB.Driver;
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

        public async Task<User> RegisterUser(User user)
        {
            await _user.InsertOneAsync(user);
            return user;
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
    }
}
