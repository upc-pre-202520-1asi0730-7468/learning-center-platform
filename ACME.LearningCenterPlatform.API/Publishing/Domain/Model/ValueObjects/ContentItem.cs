namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
/// Represents a content item.
/// </summary>
/// <param name="Type">The type of the content.</param>
/// <param name="Content">The content string.</param>
public record ContentItem(string Type, string Content);