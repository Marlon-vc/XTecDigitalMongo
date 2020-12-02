using MongoDB.Bson.Serialization.Attributes;

namespace XTecDigitalMongo.Models
{
    public class Admin
    {
        [BsonId]
        public string User { get; set; }
        public string Pass { get; set; }
    }
}