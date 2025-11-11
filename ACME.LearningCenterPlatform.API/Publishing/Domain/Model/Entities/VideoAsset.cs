using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents a video asset.
/// </summary>
public class VideoAsset : Asset
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VideoAsset"/> class.
    /// </summary>
    public VideoAsset() : base(EAssetType.Video)
    {
        VideoUri = null;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="VideoAsset"/> class with the specified video URL.
    /// </summary>
    /// <param name="videoUrl">The URL of the video.</param>
    public VideoAsset(string videoUrl) : base(EAssetType.Video)
    {
        VideoUri = new Uri(videoUrl);
    }

    /// <summary>
    /// Gets the URI of the video.
    /// </summary>
    public Uri? VideoUri { get; }

    /// <summary>
    /// Gets a value indicating whether the asset is viewable.
    /// </summary>
    public override bool Viewable => true;

    /// <summary>
    /// Gets a value indicating whether the asset is readable.
    /// </summary>
    public override bool Readable => false;

    /// <summary>
    /// Gets the content of the asset.
    /// </summary>
    /// <returns>The absolute URI of the video.</returns>
    public override string GetContent()
    {
        return VideoUri is not null ? VideoUri.AbsoluteUri : string.Empty;
    }
}