using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;

public partial class Tutorial : IPublishable
{
    public ICollection<Asset> Assets { get; }
    
    public EPublishingStatus Status { get; protected set; }
    
    public bool HasReadableAssets => Assets.Any(a => a.Readable);
    
    public bool HasViewableAssets => Assets.Any(a => a.Viewable);
    
    public bool Readable => HasReadableAssets;
    
    public bool Viewable => HasViewableAssets;
    
    private bool HasAllAssetsWithStatus(EPublishingStatus status) => 
        Assets.All(a => a.Status == status);
    
    public void SendToEdit()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ReadyToEdit))
            Status = EPublishingStatus.ReadyToEdit;
    }

    public void SendToApproval()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ReadyToApproval))
            Status = EPublishingStatus.ReadyToApproval;
    }

    public void ApproveAndLock()
    {
        if (HasAllAssetsWithStatus(EPublishingStatus.ApprovedAndLocked))
            Status = EPublishingStatus.ApprovedAndLocked;
    }

    public void Reject()
    {
        Status = EPublishingStatus.Draft;
    }

    public void ReturnToEdit()
    {
        Status = EPublishingStatus.ReadyToEdit;
    }
    
    private bool ExistsImageByUrl(string imageUrl) => 
        Assets.Any(asset => asset.Type == EAssetType.Image && asset.GetContent() == imageUrl);
    
    private bool ExistsVideoByUrl(string videoUrl) => 
        Assets.Any(asset => asset.Type == EAssetType.Video && asset.GetContent() == videoUrl);
    
    private bool ExistsReadableContent(string content) => 
        Assets.Any(asset => asset.Type == EAssetType.ReadableContentItem && asset.GetContent() == content);

    public void AddImage(string imageUrl)
    {
        if (ExistsImageByUrl(imageUrl)) return;
        Assets.Add(new ImageAsset(imageUrl));
    }
    
    public void AddVideo(string videoUrl)
    {
        if (ExistsVideoByUrl(videoUrl)) return;
        Assets.Add(new VideoAsset(videoUrl));
    }
    
    public void AddReadableContent(string content)
    {
        if (ExistsReadableContent(content)) return;
        Assets.Add(new ReadableContentAsset(content));
    }

    public void RemoveAsset(AcmeAssetIdentifier identifier)
    {
        var asset = Assets.SingleOrDefault(a => a.AssetIdentifier == identifier);
        if (asset is null) return;
        Assets.Remove(asset);
    }
    
    public void ClearAssets() => Assets.Clear();

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