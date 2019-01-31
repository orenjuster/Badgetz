using MongoDB.Bson;

namespace Badgetz.Definition.MongoRepository
{
    public interface IMongoDbDto
    {
        ObjectId Id { get; set; }
    }
}