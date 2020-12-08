using System.Collections.Generic;
using Badgetz.Definition.Model.Repositories;
using MongoDB.Driver;

namespace Badgetz.Definition.MongoRepository
{
    public class BadgetDefinitionConfigurationMongoRepository : IBadgetDefinitionConfigurationRepository
    {
        private IMongoCollection<BadgetzConfigurationDto> _configurationCollection;

        public BadgetDefinitionConfigurationMongoRepository()   
        {
            var client = new MongoClient("mongodb://XXX");

            var database = client.GetDatabase("BadgetzDB");

            _configurationCollection = database.GetCollection<BadgetzConfigurationDto>("BadgetzConfiguration");
        }

        public void AddIntervalType(string interval)
        {
            throw new System.NotImplementedException();
        }

        public void AddUnitOfMeasureType(string unitOfMeasure)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetAllIntervals()
        {
            var configuration = GetBadgetDefinitionConfiguration();

            return configuration.IntervalTypes;
        }

        private BadgetzConfigurationDto GetBadgetDefinitionConfiguration()
        {
            var configurations = _configurationCollection.Find(o => true);

            return configurations.FirstOrDefault();
        }

        public IEnumerable<string> GetAllUnitOfMeasures()
        {
            var configuration = GetBadgetDefinitionConfiguration();

            return configuration.UnitOfMeasureTypes;
        }
    }
}
