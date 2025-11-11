namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;

/// <summary>
/// Query to get a tutorial by its ID.
/// </summary>
/// <param name="TutorialId">The ID of the tutorial.</param>
public record GetTutorialByIdQuery(int TutorialId);