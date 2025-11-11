using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;

/// <summary>
/// Represents a tutorial aggregate root.
/// </summary>
public partial class Tutorial
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Tutorial"/> class with the specified title, summary, and category ID.
    /// </summary>
    /// <param name="title">The title of the tutorial.</param>
    /// <param name="summary">The summary of the tutorial.</param>
    /// <param name="categoryId">The ID of the category.</param>
    public Tutorial(string title, string summary, int categoryId) : this()
    {
        Title = title;
        Summary = summary;
        CategoryId = categoryId;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Tutorial"/> class from a create tutorial command.
    /// </summary>
    /// <param name="command">The create tutorial command.</param>
    public Tutorial(CreateTutorialCommand command) : this(command.Title, command.Summary, command.CategoryId)
    {
    }

    /// <summary>
    /// Gets the unique identifier of the tutorial.
    /// </summary>
    public int Id { get; }
    /// <summary>
    /// Gets the title of the tutorial.
    /// </summary>
    public string Title { get; private set; }
    /// <summary>
    /// Gets the summary of the tutorial.
    /// </summary>
    public string Summary { get; private set; }
    /// <summary>
    /// Gets or sets the category of the tutorial.
    /// </summary>
    public Category? Category { get; internal set; }
    /// <summary>
    /// Gets the category ID of the tutorial.
    /// </summary>
    public int CategoryId { get; private set; }
}