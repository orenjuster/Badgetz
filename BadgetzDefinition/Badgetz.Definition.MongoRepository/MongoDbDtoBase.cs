using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Badgetz.Definition.MongoRepository
{
    [BsonIgnoreExtraElements]
    class MongoDbDtoBase : IMongoDbDto
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonExtraElements]
        public BsonDocument ExtraData { get; set; }
    }
}