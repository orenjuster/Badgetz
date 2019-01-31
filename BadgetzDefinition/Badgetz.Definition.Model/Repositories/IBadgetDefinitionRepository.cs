using Badgetz.Definition.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Badgetz.Definition.Model.Repositories
{
    public interface IBadgetDefinitionRepository
    {
        Task Add(IBadgetDefinition badgetDefinition);
            
        Task<IBadgetDefinition> GetById(Guid badgetId);

        Task<IEnumerable<IBadgetDefinition>> GetAll();

        Task<IEnumerable<IBadgetDefinition>> GetAll(IEnumerable<string> badgetIds);
    }
}
