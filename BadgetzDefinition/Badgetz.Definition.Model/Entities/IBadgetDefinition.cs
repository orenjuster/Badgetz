using System;

namespace Badgetz.Definition.Model.Entities
{
    public interface IBadgetDefinition
    {
        string Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        string Interval { get; set; }

        string UnitOfMeasure { get; set; }

        int UnitOfMeasurePerInterval { get; set; }

        DateTime CreatedOn { get; set; }

        string UserId { get; set; }
    }

}
