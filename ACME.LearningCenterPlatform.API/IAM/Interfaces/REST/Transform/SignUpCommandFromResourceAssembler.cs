using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.IAM.Interfaces.REST.Resources;

namespace ACME.LearningCenterPlatform.API.IAM.Interfaces.REST.Transform;

/// <summary>
/// Assembler for converting SignUpResource DTOs to SignUpCommand objects.
/// </summary>
public static class SignUpCommandFromResourceAssembler
{
    /// <summary>
    /// Converts a SignUpResource to a SignUpCommand.
    /// </summary>
    /// <param name="resource">The SignUpResource containing sign-up data.</param>
    /// <returns>A SignUpCommand for user registration.</returns>
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }
}