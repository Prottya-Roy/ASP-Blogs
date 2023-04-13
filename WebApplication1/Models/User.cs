using MongoDB.Bson.Serialization.Attributes;
using WebApplication1.Extensions;

namespace WebApplication1.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateOnly DOB { get; set; }
        //public List<Photo> Photos { get; set; } = new List<Photo>();

        public int GetAge()
        {
            return DOB.CalculateAge();
        }
        
    }
}
