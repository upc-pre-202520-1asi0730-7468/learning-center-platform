using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;

/// <summary>
/// Partial class for Tutorial audit fields.
/// </summary>
public partial class Tutorial : IEntityWithCreatedUpdatedDate
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