namespace ACME.LearningCenterPlatform.API.IAM.Interfaces.REST.Resources;

/// <summary>
/// Resource for user sign-up requests.
/// </summary>
/// <param name="Username">The username for sign-up.</param>
/// <param name="Password">The password for sign-up.</param>
public record SignUpResource(string Username, string Password);