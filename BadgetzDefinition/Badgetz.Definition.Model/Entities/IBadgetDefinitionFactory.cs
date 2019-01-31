namespace Badgetz.Definition.Model.Entities
{
    public interface IBadgetDefinitionFactory
    {
        IBadgetDefinition Create(string name, string description, string unitOfMeasure, int unitOfMeasurePerIntraval, string interval, string userId);
    }
}
