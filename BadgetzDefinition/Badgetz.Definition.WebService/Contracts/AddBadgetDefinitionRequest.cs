namespace Badgetz.Definition.WebService.Contracts
{
    public class AddBadgetDefinitionRequest
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Interval { get; set; }

        public string UnitOfMeasure { get; set; }

        public int UnitOfMeasurePerInterval { get; set; }
    }
}
