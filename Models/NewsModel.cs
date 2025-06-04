using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace jooneliweb.Models
{
    public class NewsModel 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonRequired]
        [BsonElement("Content")]
        public string Content { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Image")]
        public BsonBinaryData Image { get; set; }

        [BsonElement("Featured")]
        public bool IsFeatured { get; set; } = false;


        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
