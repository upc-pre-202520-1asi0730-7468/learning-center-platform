namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
/// Represents an asset identifier.
/// </summary>
/// <param name="Identifier">The GUID identifier.</param>
public record AcmeAssetIdentifier(Guid Identifier)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AcmeAssetIdentifier"/> class with a new GUID.
    /// </summary>
    public AcmeAssetIdentifier() : this(Guid.NewGuid())
    {
    }
}