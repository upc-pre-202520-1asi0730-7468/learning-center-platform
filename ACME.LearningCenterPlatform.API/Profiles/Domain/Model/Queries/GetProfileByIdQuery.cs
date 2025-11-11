namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Queries;

/// <summary>
/// Query to get a profile by its ID.
/// </summary>
/// <param name="ProfileId">The unique identifier of the profile.</param>
public record GetProfileByIdQuery(int ProfileId);