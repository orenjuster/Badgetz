using System;

namespace Badgetz.Definition.MongoRepository
{
    class BadgetDefinitionDto : MongoDbDtoBase
    {
        public string BadgetId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Interval { get; set; }

        public string UnitOfMeasure { get; set; }

        public int UnitOfMeasurePerInterval { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }
    }
}