using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Aggregates;

/// <summary>
/// Partial class for Profile audit fields.
/// </summary>
public partial class Profile : IEntityWithCreatedUpdatedDate
{
    /// <summary>
    /// Gets or sets the created date.
    /// </summary>
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    /// <summary>
    /// Gets or sets the updated date.
    /// </summary>
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}