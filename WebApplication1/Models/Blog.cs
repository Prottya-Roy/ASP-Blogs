using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models
{
    public class Blog
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }

        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Body { get; set; }
        public int upvote { get; set; }
        public int downvote { get; set; }
        public string author { get; set; }

    }
}
