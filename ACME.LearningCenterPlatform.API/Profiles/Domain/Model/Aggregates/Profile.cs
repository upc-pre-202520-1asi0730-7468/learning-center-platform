using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Aggregates;

/// <summary>
///     Profile Aggregate Root
/// </summary>
/// <remarks>
///     This class represents the Profile aggregate root.
///     It contains the properties and methods to manage the profile information.
/// </remarks>
public partial class Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Profile"/> class.
    /// </summary>
    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Address = new StreetAddress();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Profile"/> class with the specified parameters.
    /// </summary>
    /// <param name="firstName">The first name of the person.</param>
    /// <param name="lastName">The last name of the person.</param>
    /// <param name="email">The email address.</param>
    /// <param name="street">The street address.</param>
    /// <param name="city">The city.</param>
    /// <param name="state">The state.</param>
    /// <param name="postalCode">The postal code.</param>
    /// <param name="country">The country.</param>
    public Profile(string firstName, string lastName, string email, string street, string city, string state,
        string postalCode, string country)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new StreetAddress(street, city, state, postalCode, country);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Profile"/> class from a create profile command.
    /// </summary>
    /// <param name="command">The create profile command.</param>
    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Address = new StreetAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);
    }

    /// <summary>
    /// Gets the unique identifier of the profile.
    /// </summary>
    public int Id { get; }
    /// <summary>
    /// Gets the person's name.
    /// </summary>
    public PersonName Name { get; }
    /// <summary>
    /// Gets the email address.
    /// </summary>
    public EmailAddress Email { get; }
    /// <summary>
    /// Gets the street address.
    /// </summary>
    public StreetAddress Address { get; }

    /// <summary>
    /// Gets the full name of the person.
    /// </summary>
    public string FullName => Name.FullName;
    /// <summary>
    /// Gets the email address as a string.
    /// </summary>
    public string EmailAddress => Email.Address;
    /// <summary>
    /// Gets the full street address as a string.
    /// </summary>
    public string StreetAddress => Address.FullAddress;
}