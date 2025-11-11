using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.IAM.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.IAM.Interfaces.REST.Transform;

/// <summary>
/// Assembler for converting User entities and tokens to AuthenticatedUserResource DTOs.
/// </summary>
public static class AuthenticatedUserResourceFromEntityAssembler
{
    /// <summary>
    /// Converts a User entity and JWT token to an AuthenticatedUserResource.
    /// </summary>
    /// <param name="user">The authenticated User entity.</param>
    /// <param name="token">The JWT token for the user.</param>
    /// <returns>An AuthenticatedUserResource containing the user's data and token.</returns>
    public static AuthenticatedUserResource ToResourceFromEntity(
        User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
}