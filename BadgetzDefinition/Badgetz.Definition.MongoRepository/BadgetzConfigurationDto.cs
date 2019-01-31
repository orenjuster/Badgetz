using System.Collections;
using System.Collections.Generic;

namespace Badgetz.Definition.MongoRepository
{
    class BadgetzConfigurationDto : MongoDbDtoBase
    {
        public IEnumerable<string> Intervals { get; internal set; }
        public IEnumerable<string> UnitsOfMeasure { get; internal set; }
    }
}
