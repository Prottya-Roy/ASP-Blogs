using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core
{
    public class Blog
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string Id { get; set; }
        public string Author { get; set; }
    }
}
