namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
/// Interface for publishable entities.
/// </summary>
public interface IPublishable
{
    /// <summary>
    /// Sends the entity to edit status.
    /// </summary>
    void SendToEdit();
    /// <summary>
    /// Sends the entity to approval status.
    /// </summary>
    void SendToApproval();
    /// <summary>
    /// Approves and locks the entity.
    /// </summary>
    void ApproveAndLock();
    /// <summary>
    /// Rejects the entity.
    /// </summary>
    void Reject();
    /// <summary>
    /// Returns the entity to edit status.
    /// </summary>
    void ReturnToEdit();
}