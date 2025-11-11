using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents a category entity.
/// </summary>
public class Category(string name)
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class.
    /// </summary>
    public Category() : this(string.Empty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class from a create category command.
    /// </summary>
    /// <param name="command">The create category command.</param>
    public Category(CreateCategoryCommand command) : this(command.Name)
    {
    }

    /// <summary>
    /// Gets or sets the ID of the category.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string Name { get; set; } = name;
    /// <summary>
    /// Gets the list of tutorials in this category.
    /// </summary>
    public List<Tutorial> Tutorials { get; } = [];
}