namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

public record AcmeAssetIdentifier(Guid Identifier)
{
    public AcmeAssetIdentifier() : this(Guid.NewGuid()) {}
}