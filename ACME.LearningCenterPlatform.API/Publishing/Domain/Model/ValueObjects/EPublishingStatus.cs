namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
/// Represents the publishing status.
/// </summary>
public enum EPublishingStatus
{
    /// <summary>
    /// Draft status.
    /// </summary>
    Draft,
    /// <summary>
    /// Ready to edit status.
    /// </summary>
    ReadyToEdit,
    /// <summary>
    /// Ready to approval status.
    /// </summary>
    ReadyToApproval,
    /// <summary>
    /// Approved and locked status.
    /// </summary>
    ApprovedAndLocked
}