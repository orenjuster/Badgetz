using Badgetz.Definition.Model.Entities;
using System;

namespace Badgetz.Definition.Entities
{
    public class BadgetDefinition : IBadgetDefinition
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Interval { get; set; }

        public string UnitOfMeasure { get; set; }

        public int UnitOfMeasurePerInterval { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }
    }
}
