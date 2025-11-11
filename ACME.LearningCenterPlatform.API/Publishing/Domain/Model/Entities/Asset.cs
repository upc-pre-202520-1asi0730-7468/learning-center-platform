using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents an asset entity.
/// </summary>
public partial class Asset(EAssetType type) : IPublishable
{
    /// <summary>
    /// Gets the ID of the asset.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets the asset identifier.
    /// </summary>
    public AcmeAssetIdentifier AssetIdentifier { get; private set; } = new();

    /// <summary>
    /// Gets the type of the asset.
    /// </summary>
    public EAssetType Type { get; private set; } = type;

    /// <summary>
    /// Gets the publishing status of the asset.
    /// </summary>
    public EPublishingStatus Status { get; private set; } = EPublishingStatus.Draft;

    /// <summary>
    /// Gets a value indicating whether the asset is readable.
    /// </summary>
    public virtual bool Readable => false;

    /// <summary>
    /// Gets a value indicating whether the asset is viewable.
    /// </summary>
    public virtual bool Viewable => false;

    /// <summary>
    /// Sends the asset to edit status.
    /// </summary>
    public void SendToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    /// <summary>
    /// Sends the asset to approval status.
    /// </summary>
    public void SendToApproval()
    {
        Status = EPublishingStatus.ReadyToApproval;
    }

    /// <summary>
    /// Approves and locks the asset.
    /// </summary>
    public void ApproveAndLock()
    {
        Status = EPublishingStatus.ApprovedAndLocked;
    }

    /// <summary>
    /// Rejects the asset, setting status back to draft.
    /// </summary>
    public void Reject()
    {
        Status = EPublishingStatus.Draft;
    }

    /// <summary>
    /// Returns the asset to edit status.
    /// </summary>
    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    /// <summary>
    /// Gets the content of the asset.
    /// </summary>
    /// <returns>The content object.</returns>
    public virtual object GetContent()
    {
        return string.Empty;
    }
}