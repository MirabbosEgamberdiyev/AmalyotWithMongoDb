using MongoDB.Bson.Serialization.Attributes;

namespace CRM.Data.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
    }
}
