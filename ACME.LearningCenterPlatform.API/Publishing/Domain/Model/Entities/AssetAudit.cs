using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Partial class for Asset audit fields.
/// </summary>
public partial class Asset : IEntityWithCreatedUpdatedDate
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