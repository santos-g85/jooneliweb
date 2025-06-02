using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace jooneliweb.Models
{
    public class BusinessModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Svg { get; set; }
    }
}


    

