using Badgetz.Definition.Model.Entities;
using Badgetz.Definition.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Badgetz.Definition.Entities
{
    public class BadgetDefinitionFactory : IBadgetDefinitionFactory
    {
        private readonly IBadgetDefinitionRepository _badgetDefinitionRepository;
        private readonly IBadgetDefinitionConfigurationRepository _badgetDefinitionConfigurationRepository;

        public BadgetDefinitionFactory(IBadgetDefinitionRepository badgetDefinitionRepository, IBadgetDefinitionConfigurationRepository badgetDefinitionConfigurationRepository)
        {
            _badgetDefinitionRepository = badgetDefinitionRepository;
            this._badgetDefinitionConfigurationRepository = badgetDefinitionConfigurationRepository;
        }
        public IBadgetDefinition Create(string name, string description, string unitOfMeasure, int unitOfMeasurePerIntraval, string interval, string userId)
        {
            ValidateInterval(interval);
            ValidateUnitOfMeasurePerInterval(unitOfMeasurePerIntraval);

            return new BadgetDefinition
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Description = description,
                UnitOfMeasure = unitOfMeasure,
                UnitOfMeasurePerInterval = unitOfMeasurePerIntraval,
                Interval = interval,
                CreatedOn = DateTime.Now,
                UserId = userId
            };
        }

        private void ValidateUnitOfMeasurePerInterval(int unitOfMeasurePerIntraval)
        {
            if (unitOfMeasurePerIntraval < 0)
                throw new ArgumentException("UnitOfMeasurePerInterval cannot be negative", "unitOfMeasurePerIntraval");
        }

        private void ValidateInterval(string interval)
        {
            IEnumerable<string> intervals = _badgetDefinitionConfigurationRepository.GetAllIntervals();

            if (!intervals.Contains(interval))
                throw new ArgumentException("Invalid Interval Provided", "Interval");
        }
    }
}
