namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;

/// <summary>
/// Query to get all tutorials by category ID.
/// </summary>
/// <param name="CategoryId">The ID of the category.</param>
public record GetAllTutorialsByCategoryIdQuery(int CategoryId);