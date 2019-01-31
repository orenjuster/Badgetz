using System.Collections;
using System.Collections.Generic;

namespace Badgetz.Definition.Model.Repositories
{
    public interface IBadgetDefinitionConfigurationRepository
    {
        void AddIntervalType(string interval);

        IEnumerable<string> GetAllIntervals();

        void AddUnitOfMeasureType(string unitOfMeasure);

        IEnumerable<string> GetAllUnitOfMeasures();
    }
}
