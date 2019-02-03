using System.Collections;
using System.Collections.Generic;

namespace Badgetz.Definition.MongoRepository
{
    class BadgetzConfigurationDto : MongoDbDtoBase
    {
        public IEnumerable<string> IntervalTypes { get; internal set; }
        public IEnumerable<string> UnitOfMeasureTypes { get; internal set; }
    }
}
