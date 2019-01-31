using System;
using System.Threading.Tasks;
using Badgetz.Definition.Model.Entities;
using Badgetz.Definition.Model.Repositories;
using Badgetz.Definition.WebService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Badgetz.Definition.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgetzController : ControllerBase
    {
        // GET: api/Badgetz
        private readonly IBadgetDefinitionRepository _badgetDefinitionRepository;
        private readonly IBadgetDefinitionFactory _badgetDefinitionFactory;

        public BadgetzController(IBadgetDefinitionRepository badgetDefinitionRepository, IBadgetDefinitionFactory badgetDefinitionFactory)
        {
            _badgetDefinitionRepository = badgetDefinitionRepository;
            _badgetDefinitionFactory = badgetDefinitionFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var badgetz = await _badgetDefinitionRepository.GetAll();

            return new ObjectResult(badgetz);
        }

        [HttpGet("{badgetId}")]
        public async Task<IActionResult> Get(Guid badgetId)
        {
            var badget = await _badgetDefinitionRepository.GetById(badgetId);

            if (badget == null) return NotFound();

            return new ObjectResult(badget);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddBadgetDefinitionRequest request)
        {
            // Raise an event eith the userId and badetId to bind the user to the badget
            var badgetDefinition = _badgetDefinitionFactory.Create(request.Name, request.Description, request.UnitOfMeasure, request.UnitOfMeasurePerInterval, request.Interval, request.UserId);

            await _badgetDefinitionRepository.Add(badgetDefinition);

            return new ObjectResult(badgetDefinition.Id);
        }
    }
}