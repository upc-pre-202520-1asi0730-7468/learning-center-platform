namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Queries;

/// <summary>
/// Query to get a category by its ID.
/// </summary>
/// <param name="CategoryId">The ID of the category.</param>
public record GetCategoryByIdQuery(int CategoryId);