using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;

/// <summary>
/// Partial class for Tutorial aggregate handling content and assets.
/// </summary>
public partial class Tutorial : IPublishable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tutorial"/> class.
    /// </summary>
    public Tutorial()
    {
        Title = string.Empty;
        Summary = string.Empty;
        Assets = new List<Asset>();
        Status = EPublishingStatus.Draft;
    }

    /// <summary>
    /// Gets the collection of assets associated with the tutorial.
    /// </summary>
    public ICollection<Asset> Assets { get; }

    /// <summary>
    /// Gets the publishing status of the tutorial.
    /// </summary>
    public EPublishingStatus Status { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the tutorial has readable assets.
    /// </summary>
    public bool HasReadableAssets => Assets.Any(a => a.Readable);

    /// <summary>
    /// Gets a value indicating whether the tutorial has viewable assets.
    /// </summary>
    public bool HasViewableAssets => Assets.Any(a => a.Viewable);

    /// <summary>
    /// Gets a value indicating whether the tutorial is readable.
    /// </summary>
    public bool Readable => HasReadableAssets;

    /// <summary>
    /// Gets a value indicating whether the tutorial is viewable.
    /// </summary>
    public bool Viewable => HasViewableAssets;

    /// <summary>
    /// Sends the tutorial to edit status if all assets are ready.
    /// </summary>
    public void SendToEdit()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ReadyToEdit))
            Status = EPublishingStatus.ReadyToEdit;
    }

    /// <summary>
    /// Sends the tutorial to approval status if all assets are ready.
    /// </summary>
    public void SendToApproval()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ReadyToApproval))
            Status = EPublishingStatus.ReadyToApproval;
    }

    /// <summary>
    /// Approves and locks the tutorial if all assets are approved.
    /// </summary>
    public void ApproveAndLock()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ApprovedAndLocked))
            Status = EPublishingStatus.ApprovedAndLocked;
    }

    /// <summary>
    /// Rejects the tutorial, setting status back to draft.
    /// </summary>
    public void Reject()
    {
        Status = EPublishingStatus.Draft;
    }

    /// <summary>
    /// Returns the tutorial to edit status.
    /// </summary>
    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }

    private bool HasAllAssetsWithStatus(EPublishingStatus status)
    {
        return Assets.All(a => a.Status == status);
    }

    private bool ExistsImageByUrl(string imageUrl)
    {
        return Assets.Any(asset => asset.Type == EAssetType.Image && (string)asset.GetContent() == imageUrl);
    }

    private bool ExistsVideoByUrl(string videoUrl)
    {
        return Assets.Any(asset => asset.Type == EAssetType.Video && (string)asset.GetContent() == videoUrl);
    }

    private bool ExistsReadableContent(string content)
    {
        return Assets.Any(asset =>
            asset.Type == EAssetType.ReadableContentItem && (string)asset.GetContent() == content);
    }

    /// <summary>
    /// Adds an image asset to the tutorial if it doesn't already exist.
    /// </summary>
    /// <param name="imageUrl">The URL of the image to add.</param>
    public void AddImage(string imageUrl)
    {
        if (ExistsImageByUrl(imageUrl)) return;
        Assets.Add(new ImageAsset(imageUrl));
    }

    /// <summary>
    /// Adds a video asset to the tutorial if it doesn't already exist.
    /// </summary>
    /// <param name="videoUrl">The URL of the video to add.</param>
    public void AddVideo(string videoUrl)
    {
        if (ExistsVideoByUrl(videoUrl)) return;
        Assets.Add(new VideoAsset(videoUrl));
    }

    /// <summary>
    /// Adds readable content to the tutorial if it doesn't already exist.
    /// </summary>
    /// <param name="content">The content to add.</param>
    public void AddReadableContent(string content)
    {
        if (ExistsReadableContent(content)) return;
        Assets.Add(new ReadableContentAsset(content));
    }

    /// <summary>
    /// Removes an asset from the tutorial by its identifier.
    /// </summary>
    /// <param name="identifier">The identifier of the asset to remove.</param>
    public void RemoveAsset(AcmeAssetIdentifier identifier)
    {
        var asset = Assets.SingleOrDefault(a => a.AssetIdentifier == identifier);
        if (asset is null) return;
        Assets.Remove(asset);
    }

    /// <summary>
    /// Clears all assets from the tutorial.
    /// </summary>
    public void ClearAssets()
    {
        Assets.Clear();
    }

    /// <summary>
    /// Gets the content items from the assets.
    /// </summary>
    /// <returns>A list of content items.</returns>
    public List<ContentItem> GetContent()
    {
        var content = new List<ContentItem>();
        if (Assets.Count > 0)
            content.AddRange(Assets.Select(asset =>
                new ContentItem(asset.Type.ToString(),
                    asset.GetContent() as string ?? string.Empty)));
        return content;
    }
}