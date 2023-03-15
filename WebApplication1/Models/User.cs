using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }

        public List<Blog> Blogs { get; set; }
        
    }
}
