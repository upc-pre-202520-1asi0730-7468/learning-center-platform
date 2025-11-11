using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;

namespace ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutboundServices;

/// <summary>
///     Contract to generate and validate Tokens for users.
/// </summary>
public interface ITokenService
{
    /// <summary>
    ///     Generates a Token for the specified user.
    /// </summary>
    /// <param name="user">The user for which to create the token.</param>
    /// <returns>The generated Token string.</returns>
    string GenerateToken(User user);

    /// <summary>
    ///     Validates the provided Token and returns the user id when valid.
    /// </summary>
    /// <param name="token">The Token to validate.</param>
    /// <returns>The user id if the token is valid; otherwise <c>null</c>.</returns>
    Task<int?> ValidateToken(string token);
}