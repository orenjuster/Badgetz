using Badgetz.Definition.Model.Entities;
using Badgetz.Definition.Model.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Badgetz.Definition.MongoRepository
{
    public class BadgetDefinitionMongoRepository : IBadgetDefinitionRepository
    {
        private IMongoCollection<BadgetDefinitionDto> _badgetzCollection;
        private readonly IBadgetDefinitionFactory _badgetDefinitionFactory;

        public BadgetDefinitionMongoRepository(IBadgetDefinitionFactory badgetDefinitionFactory)
        {
            var client = new MongoClient("mongodb://mdorenjuster:subarub3@mdcluster-shard-00-00-mcvu5.mongodb.net:27017,mdcluster-shard-00-01-mcvu5.mongodb.net:27017,mdcluster-shard-00-02-mcvu5.mongodb.net:27017/test?ssl=true&replicaSet=MdCluster-shard-0&authSource=admin&retryWrites=true");

            var database = client.GetDatabase("BadgetzDB");

            _badgetzCollection = database.GetCollection<BadgetDefinitionDto>("BadgetzDefinition");

            _badgetDefinitionFactory = badgetDefinitionFactory;
        }

        public async Task Add(IBadgetDefinition badgetDefinition)
        {
            var dto = ModelToDto(badgetDefinition);

            await _badgetzCollection.InsertOneAsync(dto);
        }

        private BadgetDefinitionDto ModelToDto(IBadgetDefinition badgetDefinition)
        {
            return badgetDefinition == null ? null : new BadgetDefinitionDto
            {
                BadgetId = badgetDefinition.Id,
                Name = badgetDefinition.Name,
                Description = badgetDefinition.Description,
                Interval = badgetDefinition.Interval,
                UnitOfMeasure = badgetDefinition.UnitOfMeasure,
                UnitOfMeasurePerInterval = badgetDefinition.UnitOfMeasurePerInterval,
                CreatedOn = badgetDefinition.CreatedOn,
                UserId = badgetDefinition.UserId
            };
        }

        public async Task<IEnumerable<IBadgetDefinition>> GetAll()
        {
            var all = await _badgetzCollection.Find(o => true).ToListAsync();

            return all.Select(DtoToModel);
        }

        private IBadgetDefinition DtoToModel(BadgetDefinitionDto dto)
        {
            var model = dto == null
                ? null
                : _badgetDefinitionFactory.Create(dto.Name, dto.Description, dto.UnitOfMeasure, dto.UnitOfMeasurePerInterval, dto.Interval, dto.UserId);

            model.Id = dto.BadgetId;
            model.CreatedOn = dto.CreatedOn;

            return model;
        }

        public async Task<IBadgetDefinition> GetById(Guid badgetId)
        {
            var searchResults = await _badgetzCollection.FindAsync(o => o.BadgetId == badgetId.ToString());

            var resultsList = await searchResults.ToListAsync();

            return DtoToModel(resultsList.LastOrDefault());
        }

        public async Task<IEnumerable<IBadgetDefinition>> GetAll(IEnumerable<string> badgetIds)
        {
            var filter = Builders<BadgetDefinitionDto>.Filter.In(o => o.BadgetId, badgetIds);

            var searchResults = await _badgetzCollection.FindAsync(filter);

            var resultsList = await searchResults.ToListAsync();

            return resultsList.Select(DtoToModel);
        }
    }
}