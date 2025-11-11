namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

/// <summary>
/// Command to add a video asset to a tutorial.
/// </summary>
/// <param name="VideoUrl">The URL of the video to add.</param>
/// <param name="TutorialId">The ID of the tutorial to add the video to.</param>
public record AddVideoAssetToTutorialCommand(string VideoUrl, int TutorialId);